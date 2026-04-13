using System.Data.SQLite;
using System.IO;

namespace Finance_Management_Sys
{
    public static class DatabaseHelper
    {
        private static readonly string dbFile = "finance.db"; // database file in app folder
        private static readonly string connectionString = $"Data Source={dbFile};Version=3;";

        public static SQLiteConnection GetConnection()
        {
            EnsureDatabase();
            var conn = new SQLiteConnection(connectionString);
            conn.Open();
            return conn;
        }

        // Ensure DB exists and create schema if missing
        private static void EnsureDatabase()
        {
            if (!File.Exists(dbFile))
            {
                SQLiteConnection.CreateFile(dbFile);
                using var conn = new SQLiteConnection(connectionString);
                conn.Open();

                // === Tables ===
                string createUsers = @"
                    CREATE TABLE users (
                        UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                        FullName TEXT NOT NULL,
                        Email TEXT NOT NULL UNIQUE,
                        EmployeeID TEXT NOT NULL UNIQUE,
                        Password TEXT NOT NULL,
                        Role TEXT NOT NULL,
                        IsActive INTEGER NOT NULL
                    );";

                string createEmployees = @"
                    CREATE TABLE employees (
                        EmployeeID TEXT PRIMARY KEY,
                        FullName TEXT NOT NULL,
                        Department TEXT,
                        Position TEXT,
                        DateJoined TEXT
                    );";

                string createExpenses = @"
                    CREATE TABLE expenses (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        expense_name TEXT NOT NULL,
                        amount REAL NOT NULL,
                        payment_method TEXT,
                        created_at TEXT DEFAULT CURRENT_TIMESTAMP,
                        status TEXT,
                        created_by INTEGER,
                        updated_by INTEGER
                    );";

                string createAccounts = @"
                    CREATE TABLE accounts (
                        AccountID INTEGER PRIMARY KEY,
                        Balance REAL NOT NULL
                    );";

                using var cmd = new SQLiteCommand(createUsers, conn);
                cmd.ExecuteNonQuery();

                cmd.CommandText = createEmployees; cmd.ExecuteNonQuery();
                cmd.CommandText = createExpenses; cmd.ExecuteNonQuery();
                cmd.CommandText = createAccounts; cmd.ExecuteNonQuery();

                // Seed account with balance
                cmd.CommandText = "INSERT INTO accounts (AccountID, Balance) VALUES (1, 0)";
                cmd.ExecuteNonQuery();
            }
        }
    }
}
