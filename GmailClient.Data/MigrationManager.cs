﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailClient.Data
{
    /// <summary>
    /// Класс управляет процессом миграции
    /// </summary>
    public static class MigrationManager
    {
        /// <summary>
        /// Запуск миграции
        /// </summary>
        /// <param name="connectionString">Строка соединения с базой</param>
        public static void Start(string connectionString)
        {
            var migrator = new Migrator(connectionString);

            migrator.Migrate(runner => runner.MigrateUp());
        }
    }
}
