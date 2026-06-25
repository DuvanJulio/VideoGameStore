using MySqlConnector;

namespace VideoGameStore.Infrastructure.Utils
{
    public class AppEnviroment
    {
        public string DATABASE_SERVER { get; set; } = string.Empty;

        public int DATABASE_PORT { get; set; } = 3306;

        public string DATABASE_NAME { get; set; } = string.Empty;

        public string DATABASE_USER_ID { get; set; } = string.Empty;

        public string DATABASE_PASSWORD { get; set; } = string.Empty;

        public MySqlConnectionStringBuilder DATABASE_STRING_BUILDER => new()
        {
            Server = DATABASE_SERVER,
            Port = (uint)DATABASE_PORT,
            Database = DATABASE_NAME,
            UserID = DATABASE_USER_ID,
            Password = DATABASE_PASSWORD,
            SslMode = MySqlSslMode.None
        };
    }
}