// Assumes FTPSync.ProfileManager and FTPSync.FTPProfile already exist
window.FTPSyncHelpers = (function () {

  const API_URL = "/profiles.json"; // Adjust if needed
  const manager = new FTPSync.ProfileManager();

 async function loadFromServer() {
    const res = await loginManager.authenticatedFetch(API_URL);
    if (!res || !res.ok) throw new Error(`Failed to load profiles (${res?.status})`);
    const data = await res.json();
    manager.loadFromJSON(data);
    return manager;
  }

  async function saveToServer() {
    const json = JSON.stringify(manager.toJSON(), null, 2);
    const res = await loginManager.authenticatedFetch(API_URL, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: json
    });
    if (!res || !res.ok) throw new Error(`Failed to save profiles (${res?.status})`);
    return true;
  }


  function renameProfile(oldName, newName) {
    const success = manager.renameProfile(oldName, newName);
    if (success) return saveToServer();
    throw new Error("Rename failed: profile not found or name already exists.");
  }

  function deleteProfile(name) {
    manager.removeProfile(name);
    return saveToServer();
  }

  function addProfile(profileData) {
    const profile = new FTPSync.FTPProfile(profileData);
    manager.addProfile(profile);
    return saveToServer();
  }

  function replaceProfile(profileData) {
    const profile = new FTPSync.FTPProfile(profileData);
    manager.removeProfile(profile.ProfileName);
    manager.addProfile(profile);
    return saveToServer();
  }

  return {
    manager,
    loadFromServer,
    saveToServer,
    renameProfile,
    deleteProfile,
    addProfile,
    replaceProfile
  };
})();
