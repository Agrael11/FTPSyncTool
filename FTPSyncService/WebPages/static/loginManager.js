// loginManager.js

// SHA-256 hashing for password before sending to server
async function sha256(str) {
    const buf = await crypto.subtle.digest("SHA-256", new TextEncoder().encode(str));
    return Array.from(new Uint8Array(buf))
        .map(b => b.toString(16).padStart(2, "0"))
        .join("")
        .toUpperCase();
}

const loginManager = {
    storageKey: "ftpSyncToken",
    storageExpiry: "ftpSyncExpiry",

    async login(username, password) {
        const hashed = await sha256(password);

        const res = await fetch("/login", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ username, password: hashed })
        });

        if (!res.ok) {
            alert("Login failed.");
            return false;
        }

        const data = await res.json();
        localStorage.setItem(this.storageKey, data.token);
        localStorage.setItem(this.storageExpiry, data.expires);

        window.location.href = "/static/index.html";
        return true;
    },

    async logout() {
        const token = localStorage.getItem(this.storageKey);
        if (token) {
            await fetch("/logout", {
                method: "POST",
                headers: { "Authorization": `Bearer ${token}` }
            });
        }
        localStorage.removeItem(this.storageKey);
        localStorage.removeItem(this.storageExpiry);
        window.location.href = "/static/login.html";
    },

    getToken() {
        const token = localStorage.getItem(this.storageKey);
        const expiry = localStorage.getItem(this.storageExpiry);
        if (!token || !expiry) return null;

        if (new Date(expiry) < new Date()) {
            this.clearToken();
            return null;
        }
        return token;
    },

    clearToken() {
        localStorage.removeItem(this.storageKey);
        localStorage.removeItem(this.storageExpiry);
    },

    async authenticatedFetch(url, options = {}) {
        const token = this.getToken();
        if (!token) {
            this.redirectToLogin();
            return;
        }

        options.headers = {
            ...(options.headers || {}),
            "Authorization": `Bearer ${token}`
        };

        const res = await fetch(url, options);

        if (res.status === 401 || res.status === 403) {
            this.clearToken();
            this.redirectToLogin();
            return;
        }

        return res;
    },

    redirectIfNotAuthenticated() {
        if (!this.getToken()) {
            this.redirectToLogin();
        }
    },

    redirectToLogin() {
        window.location.href = "/static/login.html";
    }
};

window.loginManager = loginManager;
