
const ProtocolLabels = ["Auto", "FTP", "FTPS Explicit", "FTPS Implicit"];
const TransferLabels = ["Binary", "ASCII"];
const BackupLabels = ["Single Directory", "Named Directories", "Named Zips"];
const DownloadLabels = ["Mirror", "Update"];

// common: update model + save
async function applyAndSave(updateFn) {
  updateFn();
  await FTPSyncHelpers.saveToServer();
  // re-render the right pane after save
  if (typeof showProfile === "function") showProfile(currentProfile, currentName);
}

// helpers for TimeSpan <-> minutes
function minsFromTimeSpan(ts) {
  // ts like "00:01:00" or "24:00:00"
  if (!ts) return 1440;
  const parts = String(ts).split(":").map((x) => parseInt(x, 10));
  if (parts.length !== 3 || parts.some((p) => Number.isNaN(p))) return 1440;
  // convert full seconds to minutes
  const hours = parts[0];
  const minutes = parts[1];
  const seconds = parts[2];
  return hours * 60 + minutes + Math.floor(seconds / 60);
}

function timeSpanFromMinutes(m) {
  const total = Number(m) || 0;
  const h = Math.floor(total / 60);
  const min = total % 60;
  const pad = (n) => String(n).padStart(2, "0");
  return `${pad(h)}:${pad(min)}:00`;
}

document.getElementById("logoutBtn").addEventListener("click", async () => {
    await loginManager.logout();
});


// DOM-ready
document.addEventListener("DOMContentLoaded", async () => {
  const list = document.getElementById("profileList");
  const info = document.getElementById("profileInfo");
  const refreshBtn = document.getElementById("refreshBtn");
  const addBtn = document.getElementById("addBtn");
  const status = document.getElementById("status");

  let currentProfile = null;
  let currentName = null;

  async function loadProfiles() {
    if (status) status.textContent = "Loading...";
    try {
      await FTPSyncHelpers.loadFromServer();
      renderProfiles();
      if (status)
        status.textContent = `Loaded ${Object.keys(FTPSyncHelpers.manager.profiles).length} profiles.`;
    } catch (err) {
      console.error(err);
      if (status) status.textContent = "❌ Failed to load profiles.";
    }
  }

  function renderProfiles() {
    if (!list) return;
    list.innerHTML = "";
    const entries = Object.entries(FTPSyncHelpers.manager.profiles || {}).sort((a, b) => a[0].localeCompare(b[0]));

    for (const [name, p] of entries) {
      const li = document.createElement("li");
      li.className = "profile-item";
      const last = p && p.LastSynced ? new Date(p.LastSynced).toLocaleString() : "Never";
      li.innerHTML = `
        <div class="name">${name}</div>
        <div class="meta">${(p && p.Host) || "(no host)"}<br><span class="sync">Last: ${last}</span></div>
      `;
      li.onclick = () => showProfile(p, name);
      list.appendChild(li);
    }
  }

  // text -> input on click
  function editableText(container, label, get, set, { placeholder = "" } = {}) {
    const row = document.createElement("div");
    row.className = "row";
    const lab = document.createElement("div");
    lab.className = "lab";
    lab.textContent = label;
    const val = document.createElement("div");
    val.className = "val edit";
    const span = document.createElement("span");
    span.textContent = get() || placeholder;

    const pencil = document.createElement("button");
    pencil.className = "icon";
    pencil.textContent = "✏️";

    function startEdit() {
      const input = document.createElement("input");
      input.type = "text";
      input.value = get() || "";
      input.onkeydown = (e) => {
        if (e.key === "Enter") input.blur();
      };
      input.onblur = () => applyAndSave(() => set(input.value));
      val.replaceChildren(input);
      input.focus();
      input.select();
    }

    pencil.onclick = startEdit;
    span.onclick = startEdit;

    val.append(span, pencil);
    row.append(lab, val);
    container.append(row);
  }

  // number-only (e.g., Port, Frequency minutes)
  function editableNumber(container, label, get, set, { min = 0, max = 65535 } = {}) {
    const row = document.createElement("div");
    row.className = "row";
    const lab = document.createElement("div");
    lab.className = "lab";
    lab.textContent = label;
    const val = document.createElement("div");
    val.className = "val edit";

    const span = document.createElement("span");
    span.textContent = String(get());
    const pencil = document.createElement("button");
    pencil.className = "icon";
    pencil.textContent = "✏️";

    function startEdit() {
      const input = document.createElement("input");
      input.type = "number";
      input.min = String(min);
      input.max = String(max);
      input.value = String(get());
      input.onkeydown = (e) => {
        if (e.key === "Enter") input.blur();
      };
      input.onblur = () => {
        const n = parseInt(input.value, 10);
        if (!Number.isFinite(n) || n < min || n > max) {
          input.focus();
          return;
        }
        applyAndSave(() => set(n));
      };
      val.replaceChildren(input);
      input.focus();
      input.select();
    }

    pencil.onclick = startEdit;
    span.onclick = startEdit;

    val.append(span, pencil);
    row.append(lab, val);
    container.append(row);
  }

  // dropdown for enums / booleans
  function editableSelect(container, label, get, set, options) {
    const row = document.createElement("div");
    row.className = "row";
    const lab = document.createElement("div");
    lab.className = "lab";
    lab.textContent = label;
    const val = document.createElement("div");
    val.className = "val edit";

    const currentIndex = get();
    const span = document.createElement("span");
    span.textContent = (options && options[currentIndex]) || "";
    const pencil = document.createElement("button");
    pencil.className = "icon";
    pencil.textContent = "▾";

    function startEdit() {
      const sel = document.createElement("select");
      (options || []).forEach((optLabel, idx) => {
        const o = document.createElement("option");
        o.value = String(idx);
        o.textContent = optLabel;
        if (idx === currentIndex) o.selected = true;
        sel.append(o);
      });
      sel.onchange = () => applyAndSave(() => set(parseInt(sel.value, 10)));
      sel.onblur = () => sel.onchange();
      val.replaceChildren(sel);
      sel.focus();
    }

    pencil.onclick = startEdit;
    span.onclick = startEdit;

    val.append(span, pencil);
    row.append(lab, val);
    container.append(row);
  }

  // checkbox (Overwrite / Passive vs Active)
  function editableBool(container, label, get, set) {
    const row = document.createElement("div");
    row.className = "row";
    const lab = document.createElement("div");
    lab.className = "lab";
    lab.textContent = label;
    const val = document.createElement("div");
    val.className = "val";

    const chk = document.createElement("input");
    chk.type = "checkbox";
    chk.checked = Boolean(get());
    chk.onchange = () => applyAndSave(() => set(chk.checked));

    val.append(chk);
    row.append(lab, val);
    container.append(row);
  }

  function showProfile(profile, name) {
    currentProfile = profile;
    currentName = name;

    if (!info) return;
    info.innerHTML = ""; // clear

    // Title with inline rename (unique name enforcement handled server-side or in helper)
    const h = document.createElement("h2");
    const titleWrap = document.createElement("div");
    titleWrap.className = "title-row";
    const titleSpan = document.createElement("span");
    titleSpan.textContent = (profile && profile.ProfileName) || name || "(unnamed)";
    const renameBtn = document.createElement("button");
    renameBtn.className = "icon";
    renameBtn.textContent = "✏️";

    function startRename() {
      const input = document.createElement("input");
      input.type = "text";
      input.value = (profile && profile.ProfileName) || name || "";
      input.onkeydown = (e) => {
        if (e.key === "Enter") input.blur();
      };
      input.onblur = async () => {
        const newName = input.value.trim();
        if (!newName || newName === name) {
          showProfile(profile, name);
          return;
        }
        try {
          await FTPSyncHelpers.renameProfile(name, newName);
          await FTPSyncHelpers.loadFromServer();
          renderProfiles();
          const p = FTPSyncHelpers.manager.getProfile(newName);
          showProfile(p, newName);
        } catch (e) {
          alert(e.message);
          showProfile(profile, name);
        }
      };
      titleWrap.replaceChildren(input);
      input.focus();
      input.select();
    }

    renameBtn.onclick = startRename;
    titleWrap.append(titleSpan, renameBtn);
    h.append(titleWrap);
    info.append(h);

    // Sections
    const mkGroup = (caption) => {
      const g = document.createElement("div");
      g.className = "group";
      const cap = document.createElement("h3");
      cap.textContent = caption;
      g.append(cap);
      info.append(g);
      return g;
    };

    // Basic connection
    const gBasic = mkGroup("Basic Connection");
    editableText(gBasic, "Host", () => profile?.Host, (v) => (profile.Host = v), { placeholder: "hostname" });
    editableText(gBasic, "Username", () => profile?.Username, (v) => (profile.Username = v));
    editableText(gBasic, "Password", () => profile?.Password, (v) => (profile.Password = v));
    editableText(gBasic, "Remote Directory", () => profile?.RemoteDirectory, (v) => (profile.RemoteDirectory = v));

    // Advanced connection
    const gAdv = mkGroup("Advanced Connection");
    editableNumber(gAdv, "Port", () => profile?.Port ?? 21, (v) => (profile.Port = v), { min: 1, max: 65535 });
    editableSelect(gAdv, "Protocol", () => profile?.Protocol ?? 0, (v) => (profile.Protocol = v), ProtocolLabels);
    // Passive/Active: your model uses PassiveMode (bool). Show as dropdown: Passive/Active.
    editableSelect(gAdv, "Mode", () => (profile?.PassiveMode ? 0 : 1), (v) => (profile.PassiveMode = v === 0), ["Passive", "Active"]);
    editableSelect(gAdv, "Transfer", () => profile?.TransferMode ?? 0, (v) => (profile.TransferMode = v), TransferLabels);

    // Backup settings
    const gBackup = mkGroup("Backup Settings");
    editableText(gBackup, "Backup Directory", () => profile?.LocalDirectory, (v) => (profile.LocalDirectory = v));
    editableSelect(gBackup, "Backup Mode", () => profile?.DirectoryBackupMethod ?? 0, (v) => (profile.DirectoryBackupMethod = v), BackupLabels);
    editableText(gBackup, "Subdir Naming", () => profile?.RemoteSubDirectoryNameFormat, (v) => (profile.RemoteSubDirectoryNameFormat = v));

    // Synchronization
    const gSync = mkGroup("Synchronization");
    editableSelect(gSync, "Download Method", () => profile?.DownloadMethod ?? 0, (v) => (profile.DownloadMethod = v), DownloadLabels);
    editableBool(gSync, "Overwrite Existing", () => profile?.OverwriteLocalFiles, (v) => (profile.OverwriteLocalFiles = v));
    editableNumber(
      gSync,
      "Frequency (minutes)",
      () => minsFromTimeSpan(profile?.SyncFrequency),
      (m) => (profile.SyncFrequency = timeSpanFromMinutes(m)),
      { min: 1, max: 525600 }
    );

    // Read-only status
    const gStatus = mkGroup("Status");
    const ro = document.createElement("div");
    ro.className = "read";
    const lastSynced = profile?.LastSynced ? new Date(profile.LastSynced).toLocaleString() : "Never";
    ro.innerHTML = `<div><b>Last Synced:</b> ${lastSynced}</div>`;
    gStatus.append(ro);

    // Danger actions
    const actions = document.createElement("div");
    actions.className = "actions";
    const del = document.createElement("button");
    del.textContent = "🗑 Delete";
    del.onclick = async () => {
      if (!confirm(`Delete profile '${name}'?`)) return;
      await FTPSyncHelpers.deleteProfile(name);
      await FTPSyncHelpers.loadFromServer();
      // clear details & re-render list
      info.innerHTML = "<p>Select a profile.</p>";
      renderProfiles();
    };
    actions.append(del);
    info.append(actions);
  }

  addBtn.onclick = async () => {
    const base = "Unnamed";
    let idx = 1;
    const existing = Object.keys(FTPSyncHelpers.manager.profiles || {});
    let name = base;
    while (existing.includes(name)) {
      name = `${base}-${idx++}`;
    }

    const newProfile = new FTPSync.FTPProfile({ ProfileName: name });
    try {
      await FTPSyncHelpers.addProfile(newProfile);
      await FTPSyncHelpers.loadFromServer();
      renderProfiles();
      showProfile(newProfile, name);
    } catch (err) {
      alert("Add failed: " + err.message);
    }
  };

  refreshBtn.onclick = loadProfiles;
  await loadProfiles();

  // auto-refresh every 60s when viewing a profile
  setInterval(async () => {
    if (currentName) {
      await FTPSyncHelpers.loadFromServer();
      const updated = FTPSyncHelpers.manager.getProfile(currentName);
      if (updated) showProfile(updated, currentName);
      renderProfiles();
    }
  }, 60000);
});
