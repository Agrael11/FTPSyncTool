using System.Security.Cryptography;

namespace FTPSyncService
{
    internal static class AuthTokenManager
    {
        private static Dictionary<string, DateTime> tokens = [];

        public static string CreateToken()
        {
            var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
            while (tokens.ContainsKey(token))
            {
                token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
            }
            var expireTime = DateTime.UtcNow + TimeSpan.FromMinutes(30);
            tokens.Add(token, expireTime);
            return token;
        }
        public static bool ValidateToken(string token)
        {
            if (tokens.TryGetValue(token, out DateTime expiry))
            {
                return (expiry > DateTime.UtcNow);
            }
            return false;
        }

        public static void InvalidateToken(string token)
        {
            tokens.Remove(token);
        }

        public static void CleanupExpired()
        {
            tokens = (tokens.Where(t => t.Value > DateTime.UtcNow).ToDictionary());
        }
    }
}
