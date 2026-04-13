using System;
using System.Windows.Forms;
using System.Data.SQLite; // ✅ SQLite instead of MySQL

namespace Finance_Management_Sys
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtUsername.Text.Trim();
            string password = txtPassword.Text ?? string.Empty;

            // Basic checks
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter Email and Password.", "Missing credentials",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ Email format validation
            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ Password minimum length
            if (password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var conn = DatabaseHelper.GetConnection();

                const string sql = @"SELECT UserID, FullName, Password, Role, IsActive
                                     FROM users
                                     WHERE Email = @Email AND Password = @Password
                                     LIMIT 1";

                using var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                using var reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Invalid email or password.", "Login failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool isActive = Convert.ToBoolean(reader["IsActive"]);
                if (!isActive)
                {
                    MessageBox.Show("Account is not active.", "Login failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string role = reader["Role"]?.ToString() ?? "User";

                // ✅ Save session
                Session.CurrentUserRole = role;
                Session.CurrentUserId = Convert.ToInt32(reader["UserID"]);
                Session.CurrentUserName = reader["FullName"]?.ToString() ?? "Unknown";

                this.Hide();
                if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                {
                    var adminForm = new AdminExpensesForm();
                    adminForm.Show();
                }
                else if (role.Equals("FinanceManager", StringComparison.OrdinalIgnoreCase))
                {
                    var fmForm = new FinanceManagerForm();
                    fmForm.Show();
                }
                else
                {
                    var main = new Form1HBv();
                    main.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login failed: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }
    }
}
