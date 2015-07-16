using System.Configuration;

namespace SWCDotNet.Data
{
    public class Settings
    {
        private static string _connectionString;

        public static string GetConnectionString()
        {
            if (string.IsNullOrEmpty(_connectionString))
                _connectionString = ConfigurationManager.ConnectionStrings["SWCDotNetCohort"].ConnectionString;

            return _connectionString;
        }
    }
}