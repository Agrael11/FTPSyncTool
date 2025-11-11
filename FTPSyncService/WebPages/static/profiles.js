window.FTPSync = (function () {

  const FTPProtocol = {
    Auto: 0,
    FTP: 1,
    FTPS_Explicit: 2,
    FTPS_Implicit: 3
  };

  const FTPTransferMode = {
    Binary: 0,
    ASCII: 1
  };

  const DownloadMethod = {
    Mirror: 0,
    Update: 1
  };

  const BackupMethod = {
    SingleFolder: 0,
    NamedFolders: 1,
    NamedZips: 2
  };

  class FTPProfile {
    constructor(data = {}) {
      this.ProfileName = data.ProfileName || "";
      this.Host = data.Host || "";
      this.Port = data.Port ?? 21;
      this.Username = data.Username || "";
      this.Password = data.Password || "";
      this.PassiveMode = data.PassiveMode ?? true;
      this.Protocol = data.Protocol ?? FTPProtocol.FTP;
      this.TransferMode = data.TransferMode ?? FTPTransferMode.Binary;
      this.RemoteDirectory = data.RemoteDirectory || "";
      this.LocalDirectory = data.LocalDirectory || "";
      this.DownloadMethod = data.DownloadMethod ?? DownloadMethod.Mirror;
      this.OverwriteLocalFiles = data.OverwriteLocalFiles ?? true;
      this.SyncFrequency = data.SyncFrequency || "24:00:00";
      this.LastSynced = data.LastSynced || null;
      this.DirectoryBackupMethod = data.DirectoryBackupMethod ?? BackupMethod.SingleFolder;
      this.RemoteSubDirectoryNameFormat = data.RemoteSubDirectoryNameFormat || "'Backup_'yyyy-MM-dd_HH-mm";
      this.DueForSync = data.DueForSync ?? false;
    }

    toJSON() {
      return { ...this };
    }
  }

  class ProfileManager {
    constructor() {
      this.profiles = {};
    }

    loadFromJSON(json) {
      this.profiles = {};
      for (const [key, val] of Object.entries(json)) {
        this.profiles[key] = new FTPProfile(val);
      }
      this.sortProfiles();
    }

    toJSON() {
      this.sortProfiles();
      return Object.fromEntries(
        Object.entries(this.profiles)
          .sort(([a], [b]) => a.localeCompare(b))
          .map(([key, val]) => [key, val.toJSON()])
      );
    }

    addProfile(profile) {
      if (this.profiles[profile.ProfileName])
        throw new Error(`Profile '${profile.ProfileName}' already exists.`);
      this.profiles[profile.ProfileName] = profile;
      this.sortProfiles();
    }

    renameProfile(oldName, newName) {
      if (!this.profiles[oldName]) return false;
      if (this.profiles[newName])
        throw new Error(`Profile '${newName}' already exists.`);
      const profile = this.profiles[oldName];
      delete this.profiles[oldName];
      profile.ProfileName = newName;
      this.profiles[newName] = profile;
      this.sortProfiles();
      return true;
    }

    removeProfile(name) {
      delete this.profiles[name];
    }

    getProfile(name) {
      return this.profiles[name] || null;
    }

    getAllProfiles() {
      return Object.values(this.profiles);
    }

    sortProfiles() {
      this.profiles = Object.fromEntries(
        Object.entries(this.profiles).sort(([a], [b]) => a.localeCompare(b))
      );
    }
  }

  return { FTPProtocol, FTPTransferMode, DownloadMethod, BackupMethod, FTPProfile, ProfileManager };
})();
