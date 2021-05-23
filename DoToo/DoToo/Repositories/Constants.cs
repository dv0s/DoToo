using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DoToo.Repositories
{
    public static class Constants
    {
        public const string DatabaseFilename = "TodoItems.db";

        public const SQLite.SQLiteOpenFlags Flags =
            // Open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // Create the database if it doesn't exsist
            SQLite.SQLiteOpenFlags.Create |
            // Enable ulti-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}
