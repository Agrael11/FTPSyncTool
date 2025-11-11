namespace FTPSyncLib
{
    public static class PathInfo
    {
        public static readonly string ConfigurationLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Tachi", "FTPSync");
        public static readonly string ConfigurationFile = Path.Combine(ConfigurationLocation, "cofig.json");
        public static readonly string ProfilesFile = Path.Combine(ConfigurationLocation, "profiles.json");
        public static readonly string ServiceName = "FTPSyncToolService";
    }
}
