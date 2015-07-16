using System.Configuration;

namespace SGCorp.Data
{
    public class Settings
    {
        private static string _connectionString;

        public static string GetConnectionString()
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                _connectionString = ConfigurationManager.ConnectionStrings["SWCCorp"].ConnectionString;
            }
            return _connectionString;
        }
    }
}