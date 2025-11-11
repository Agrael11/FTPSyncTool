using FTPSyncLib;

namespace FTPSyncService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Delay(1000, stoppingToken);

            while (!stoppingToken.IsCancellationRequested)
            {
                UpdateProfiles();

                await Task.Delay(1000, stoppingToken);
            }
        }

        private void UpdateProfiles()
        {
            LoadProfiles();
            var toExecute = ProfileManager.GetDueToSyncProfileNames().ToArray();
            foreach (var profileName in toExecute)
            {
                var profile = ProfileManager.GetProfile(profileName);
                using var connection = new FTPConnection(profile);
                if (connection.DownloadRemote())
                {
                    profile.LastSynced = DateTime.Now;
                }
            }
            SaveProfiles();
        }

        private void LoadProfiles()
        {
            ProfileManager.LoadFromFile(PathInfo.ProfilesFile);
        }

        private void SaveProfiles()
        {
            ProfileManager.SaveToFile(PathInfo.ProfilesFile);
        }
    }
}
