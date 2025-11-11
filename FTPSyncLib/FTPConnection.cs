using FluentFTP;
using System.IO.Compression;
using System.Net;

namespace FTPSyncLib
{
    public class FTPConnection(FTPProfile profile) : IDisposable
    {
        private FtpClient? _client = null;
        private readonly FTPProfile _profile = profile;

        private bool Connect()
        {
            try
            {
                var config = new FtpConfig
                {
                    EncryptionMode = _profile.Protocol switch
                    {
                        FTPProtocol.FTP => FtpEncryptionMode.None,
                        FTPProtocol.FTPS_Explicit => FtpEncryptionMode.Explicit,
                        FTPProtocol.FTPS_Implicit => FtpEncryptionMode.Implicit,
                        _ => FtpEncryptionMode.Auto,
                    },
                    DataConnectionType = (_profile.PassiveMode) ? FtpDataConnectionType.AutoPassive : FtpDataConnectionType.AutoActive,
                    DownloadDataType = (_profile.TransferMode == FTPTransferMode.Binary) ? FtpDataType.Binary : FtpDataType.ASCII
                };

                var credentials = new NetworkCredential(_profile.Username, _profile.Password);
                _client = new FtpClient(_profile.Host, credentials, _profile.Port, config);
#if DEBUG
                _client.ValidateCertificate += (control, e) => e.Accept = true;
#endif
                _client.Connect();
                return true;
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine($"Connection error: {ex.Message}");
#endif
                Eventing.Log(Eventing.LogLevel.Error, "Connection error", ex.Message);
                return false;
            }
        }

        private void TryDisconnect()
        {
            if (_client is null || !_client.IsConnected)
                return;
            _client.Disconnect();
            _client.Dispose();
        }

        public void Dispose()
        {
            TryDisconnect();
        }

        public bool DownloadRemote()
        {
            string localSubDir = "";
            if (_profile.DirectoryBackupMethod != BackupMethod.SingleFolder)
            {
                localSubDir = DateTime.Now.ToString(_profile.RemoteSubDirectoryNameFormat);
            }
            if (!DownloadRemote(localSubDir)) return false; 
            if (_profile.DirectoryBackupMethod == BackupMethod.NamedZips)
            {
                if (!ZipDirectory(localSubDir, true)) return false;
            }
            Eventing.Log(Eventing.LogLevel.Info, "FTP Backup", $"Backup successful at {DateTime.Now}");
            return true;
        }

        public bool DownloadRemote(string localSubPath)
        {
            try
            {
                if (!Connect() || _client is null || !_client.IsConnected)
                {
                    return false;
                }
                var fullSubPath = Path.Join(_profile.LocalDirectory, localSubPath);
                Directory.CreateDirectory(fullSubPath);
                _client.DownloadDirectory(fullSubPath, _profile.RemoteDirectory, (_profile.DownloadMethod == DownloadMethod.Mirror) ? FtpFolderSyncMode.Mirror : FtpFolderSyncMode.Update, (_profile.OverwriteLocalFiles) ? FtpLocalExists.Overwrite : FtpLocalExists.Skip);
                TryDisconnect();
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine($"Download error: {ex.Message}");
#endif
                Eventing.Log(Eventing.LogLevel.Error, "Download error", ex.Message);
                return false;
            }
            return true;
        }

        public bool ZipDirectory(string localSubPath, bool deleteAfterwards)
        {
            try
            {
                var fullSubPath = Path.Join(_profile.LocalDirectory, localSubPath);
                var zipPath = Path.Join(_profile.LocalDirectory, localSubPath + ".zip");
                if (Directory.Exists(fullSubPath) == false)
                {
                    Eventing.Log(Eventing.LogLevel.Error, "Zipping error", $"Directory {fullSubPath} already exists.");
                    return false;
                }
                if (File.Exists(zipPath))
                {
                    File.Delete(zipPath);
                }
                ZipFile.CreateFromDirectory(fullSubPath, zipPath);
                if (deleteAfterwards)
                {
                    Directory.Delete(fullSubPath, true);
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine($"Zipping error: {ex.Message}");
#endif
                Eventing.Log(Eventing.LogLevel.Error, "Zipping error", ex.Message);
                return false;
            }
            return true;
        }
    }
}