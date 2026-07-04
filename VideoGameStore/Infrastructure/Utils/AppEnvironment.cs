using MySqlConnector;

namespace VideoGameStore.Infrastructure.Utils
{
    public class AppEnvironment
    {
        public string DATABASE_SERVER { get; set; } = string.Empty;

        public int DATABASE_PORT { get; set; } = 3306;

        public string DATABASE_NAME { get; set; } = string.Empty;

        public string DATABASE_USER_ID { get; set; } = string.Empty;

        public string DATABASE_PASSWORD { get; set; } = string.Empty;

        public string DATABASE_SSL_MODE { get; set; } = string.Empty;

        private MySqlSslMode ParsedSslMode
        {
            get
            {
                if (Enum.TryParse<MySqlSslMode>(DATABASE_SSL_MODE, true, out var mode))
                {
                    return mode;
                }

                return MySqlSslMode.None;
            }
        }

        public MySqlConnectionStringBuilder DATABASE_STRING_BUILDER => new()
        {
            Server = DATABASE_SERVER,
            Port = (uint)DATABASE_PORT,
            Database = DATABASE_NAME,
            UserID = DATABASE_USER_ID,
            Password = DATABASE_PASSWORD,
            SslMode = ParsedSslMode,
        };
    }
}