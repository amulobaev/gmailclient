using System;

namespace GmailClient.Data
{
    /// <summary>
    /// Migration manager
    /// </summary>
    public class MigrationManager : IMigrationManager
    {
        private readonly string _connectionString;

        /// <summary>
        /// Connection string
        /// </summary>
        /// <param name="connectionString"></param>
        public MigrationManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Start migrations
        /// </summary>
        public void Start()
        {
            Migrator migrator = new Migrator(_connectionString);
            migrator.Migrate(runner => runner.MigrateUp());
        }
    }
}
