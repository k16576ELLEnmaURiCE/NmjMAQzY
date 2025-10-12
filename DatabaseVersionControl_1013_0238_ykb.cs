// 代码生成时间: 2025-10-13 02:38:20
using System;
using Xamarin.Forms;
using SQLite;

namespace XamarinApp
{
    /// <summary>
    /// Represents a database version control system
    /// </summary>
    public class DatabaseVersionControl
    {
        private readonly SQLiteAsyncConnection _database;
        private const string DbVersionTable = "DbVersion";
        private const string DbVersionColumnName = "Version";

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseVersionControl"/> class.
        /// </summary>
        /// <param name="database">The database connection.</param>
        public DatabaseVersionControl(SQLiteAsyncConnection database)
        {
            _database = database ?? throw new ArgumentNullException(nameof(database));

            // Ensure DbVersion table exists or create it if not
            _database.CreateTableAsync<DbVersion>();
        }

        /// <summary>
        /// Gets the current database version.
        /// </summary>
        /// <returns>The database version as an integer.</returns>
        public async Task<int> GetCurrentVersionAsync()
        {
            var version = await _database.Table<DbVersion>().FirstOrDefaultAsync();
            return version != null ? version.Version : 0;
        }

        /// <summary>
        /// Updates the database version.
        /// </summary>
        /// <param name="version">The new database version.</param>
        public async Task UpdateVersionAsync(int version)
        {
            var currentVersion = await GetCurrentVersionAsync();
            if (currentVersion == version)
            {
                // No need to update if the version is the same
                return;
            }

            var dbVersion = new DbVersion { Version = version };
            await _database.InsertOrReplaceAsync(dbVersion);
        }
    }

    /// <summary>
    /// Represents the database version model.
    /// </summary>
    public class DbVersion
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public int Version { get; set; }
    }
}
