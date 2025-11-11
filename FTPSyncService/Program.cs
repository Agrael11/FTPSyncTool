using FTPSyncLib;
using Microsoft.Extensions.FileProviders;

namespace FTPSyncService
{
    internal record LoginRequest(string username, string password);

    public class Program
    {
        public static void Main(string[] args)
        {
            var config = CommonConfigFile.Config.LoadFromFile(PathInfo.ConfigurationFile);

            if (config is null || !config.WebAPI)
            {
                StartAsSvc(args);
                return;
            }

            StartAsWeb(config, args);
        }

        public static void StartAsSvc(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddWindowsService();
            builder.Services.AddHostedService<Worker>();

            var host = builder.Build();
            host.Run();
        }

        public static void StartAsWeb(CommonConfigFile.Config config, string[] args)
        {
            Host.CreateDefaultBuilder(args)
            .UseWindowsService(options => options.ServiceName = "FTPSyncToolService")
            .ConfigureServices(services =>
            {
                services.AddSingleton(config);
                services.AddHostedService<Worker>();
                services.AddHostedService<WebHostService>();
            })
            .Build()
            .Run();
        }
    }
}