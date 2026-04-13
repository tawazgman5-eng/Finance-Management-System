using System;
using System.Windows.Forms;
using System.Data.SQLite;  // ✅ Use SQLite now

namespace Finance_Management_Sys
{
    public partial class DBConnectionTest : Form
    {
        public DBConnectionTest()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();

                // 1. Check users count
                string countSql = "SELECT COUNT(*) FROM users";
                using var countCmd = new SQLiteCommand(countSql, conn);
                int userCount = Convert.ToInt32(countCmd.ExecuteScalar());

                // 2. Check if a specific admin exists
                string emailToCheck = "admin@example.com"; // 🔹 change to your test email
                string sql = "SELECT Role FROM users WHERE Email = @Email LIMIT 1";
                using var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Email", emailToCheck);

                object roleResult = cmd.ExecuteScalar();

                if (roleResult != null)
                {
                    MessageBox.Show($"✅ Connected.\nUsers in DB: {userCount}\n" +
                        $"User '{emailToCheck}' exists as Role: {roleResult}",
                        "DB Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"✅ Connected.\nUsers in DB: {userCount}\n" +
                        $"⚠️ User '{emailToCheck}' was NOT found.",
                        "DB Test", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ DB Connection/Query FAILED: " + ex.Message,
                    "DB Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
