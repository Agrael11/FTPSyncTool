using System.Text.Json;

namespace FTPSyncLib
{
    public enum FTPProtocol 
    {
        Auto,
        FTP,
        FTPS_Explicit,
        FTPS_Implicit
    }

    public enum FTPTransferMode
    {
        Binary,
        ASCII
    }

    public enum DownloadMethod
    {
        Mirror,
        Update
    }
    public enum BackupMethod
    {
        SingleFolder,
        NamedFolders,
        NamedZips
    }

    public class FTPProfile
    {
        public string ProfileName { get; set; } = "";
        public string Host { get; set; } = "";
        public int Port { get; set; } = 21;
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public bool PassiveMode { get; set; } = true;
        public FTPProtocol Protocol { get; set; } = FTPProtocol.FTP;
        public FTPTransferMode TransferMode { get; set; } = FTPTransferMode.Binary;
        public string RemoteDirectory { get; set; } = "";
        public string LocalDirectory { get; set; } = "";
        public DownloadMethod DownloadMethod { get; set; } = DownloadMethod.Mirror;
        public bool OverwriteLocalFiles { get; set; } = true;
        public TimeSpan SyncFrequency { get; set; } = TimeSpan.FromHours(24);
        public DateTime? LastSynced { get; set; } = null;
        public BackupMethod DirectoryBackupMethod { get; set; } = BackupMethod.SingleFolder;
        public string RemoteSubDirectoryNameFormat { get; set; } = "'Backup_'yyyy-MM-dd_HH-mm";
        public bool DueForSync => IsDueForSync();

        public FTPProfile()
        {

        }

        public FTPProfile(string profileName, string host, int port, string username, string password, bool passiveMode, FTPProtocol protocol, FTPTransferMode transferMode, string remoteDirectory, string localDirectory, DownloadMethod downloadMethod, bool overwriteLocalFiles, TimeSpan syncFrequency, BackupMethod directoryBackupMethod, string remoteSubDirectoryNameFormat)
        {
            ProfileName = profileName;
            Host = host;
            Port = port;
            Username = username;
            Password = password;
            PassiveMode = passiveMode;
            Protocol = protocol;
            TransferMode = transferMode;
            RemoteDirectory = remoteDirectory;
            LocalDirectory = localDirectory;
            DownloadMethod = downloadMethod;
            OverwriteLocalFiles = overwriteLocalFiles;
            SyncFrequency = syncFrequency;
            DirectoryBackupMethod = directoryBackupMethod;
            RemoteSubDirectoryNameFormat = remoteSubDirectoryNameFormat;
        }

        public bool IsDueForSync()
        {
            if (LastSynced is null)
            {
                return true;
            }
            return DateTime.Now - LastSynced >= SyncFrequency;
        }
        public static string Serialize(FTPProfile profile)
        {
            return JsonSerializer.Serialize(profile);
        }

        public static FTPProfile Deserialize(string json)
        {
            var profile = JsonSerializer.Deserialize<FTPProfile>(json);
            return profile is null ? throw new InvalidDataException("Failed to deserialize FTPProfile.") : profile;
        }
    }
}
