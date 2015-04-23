using System;

namespace GmailClient.Data
{
    /// <summary>
    /// Migration manager
    /// </summary>
    public static class MigrationManager
    {
        /// <summary>
        /// Start migrations
        /// </summary>
        /// <param name="connectionString">Connection string</param>
        public static void Start(string connectionString)
        {
            Migrator migrator = new Migrator(connectionString);
            migrator.Migrate(runner => runner.MigrateUp());
        }
    }
}
