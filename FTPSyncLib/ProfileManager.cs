using System.Text.Json;

namespace FTPSyncLib
{
    public static class ProfileManager
    {
        private static Dictionary<string, FTPProfile> _profiles = [];
        private static readonly JsonSerializerOptions _jsonOptions = new() { WriteIndented = true };

        public static void RenameProfile(string oldName, string newName)
        {
            if (!ProfileExists(oldName))
            {
                throw new InvalidOperationException($"Profile with name '{oldName}' does not exist.");
            }
            if (ProfileExists(newName))
            {
                throw new InvalidOperationException($"Profile with name '{newName}' already exists.");
            }
            var profile = _profiles[oldName];
            _profiles.Remove(oldName);
            profile.ProfileName = newName;
            _profiles[newName] = profile;
            Order();
        }

        public static bool IsProfileNameValid(string profileName)
        {
            return !string.IsNullOrWhiteSpace(profileName) && (profileName.Length > 4);
        }

        public static bool ProfileExists(string profileName)
        {
            return _profiles.ContainsKey(profileName);
        }

        public static void AddProfile(FTPProfile profile)
        {
            if (ProfileExists(profile.ProfileName))
            {
                throw new InvalidOperationException($"Profile with name '{profile.ProfileName}' already exists.");
            }
            _profiles[profile.ProfileName] = profile;
            Order();
        }

        public static void RemoveProfile(string profileName)
        {
            if (!ProfileExists(profileName))
            {
                throw new InvalidOperationException($"Profile with name '{profileName}' does not exist.");
            }
            _profiles.Remove(profileName);
            Order();
        }

        public static FTPProfile GetProfile(string profileName)
        {
            if (!ProfileExists(profileName))
            {
                throw new InvalidOperationException($"Profile with name '{profileName}' does not exist.");
            }
            return _profiles[profileName];
        }

        public static void LoadFromFile(string profilesFile)
        {
            if (!File.Exists(profilesFile))
            {
                throw new FileNotFoundException("Profiles file not found.", profilesFile);
            }
            LoadFromString(File.ReadAllText(profilesFile));
        }

        public static void LoadFromString(string json)
        {
            var profilesDeserialized = JsonSerializer.Deserialize<Dictionary<string, FTPProfile>>(json) ?? throw new InvalidDataException("Failed to deserialize profiles.");
            _profiles = profilesDeserialized;
            Order();
        }

        public static void SaveToFile(string profilesFile)
        {
            File.WriteAllText(profilesFile, SaveToString());
        }

        public static void Order()
        {
            _profiles = _profiles.OrderBy(kvp => kvp.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

        public static string SaveToString()
        {
            Order();
            return JsonSerializer.Serialize(_profiles, _jsonOptions);
        }

        public static IEnumerable<string> GetAllProfileNames()
        {
            return _profiles.Keys;   
        }

        public static IEnumerable<string> GetDueToSyncProfileNames()
        {
            return _profiles.Where(t=>t.Value.DueForSync).Select(t=>t.Key);
        }
    }
}
