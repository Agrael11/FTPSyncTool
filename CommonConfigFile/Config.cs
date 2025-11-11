using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace CommonConfigFile
{
    public class Config
    {
        public string UserName { get; set; }  = "";
        public string Password { get; set; } = "";
        public int Port { get; set; } = 5050;
        public bool WebAPI { get; set; } = true;

        public string GetPasswordHash()
        {
            var hashed = SHA256.HashData(Encoding.UTF8.GetBytes(Password));
            return Convert.ToHexString(hashed); // uppercase hex string
        }

        public static Config? LoadFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                return null;
            }
            return LoadFromString(File.ReadAllText(filename));
        }

        public static Config? LoadFromString(string json)
        {
            var data = JsonSerializer.Deserialize<Config>(json);
            return data;
        }

        public static string SaveToString(Config config)
        {
            return JsonSerializer.Serialize(config);
        }

        public static void SaveToFile(Config config, string filename)
        {
            File.WriteAllText(filename, SaveToString(config));
        }
    }
}
