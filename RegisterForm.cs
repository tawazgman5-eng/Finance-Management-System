using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite; // ✅ SQLite

namespace Finance_Management_Sys
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        // Load roles based on who is logged in
        private void LoadRoleOptions()
        {
            cmbRole.Items.Clear();

            if (Session.CurrentUserRole == "Admin")
            {
                cmbRole.Items.AddRange(new object[] { "User", "Admin", "FinanceManager" });
            }
            else
            {
                cmbRole.Items.Add("User");
            }

            cmbRole.SelectedIndex = 0;
        }

        // Load employees who don’t already have a user account
        private void LoadEmployees()
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                string sql = @"SELECT e.EmployeeID, e.FullName 
                               FROM employees e
                               WHERE e.EmployeeID NOT IN (SELECT EmployeeID FROM users)";
                using var ad = new SQLiteDataAdapter(sql, conn);
                var dt = new DataTable();
                ad.Fill(dt);

                cmbEmployees.DataSource = dt;
                cmbEmployees.DisplayMember = "FullName";
                cmbEmployees.ValueMember = "EmployeeID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Could not load employees: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            LoadRoleOptions();
            LoadEmployees();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (cmbEmployees.SelectedValue == null)
            {
                MessageBox.Show("Please select an employee.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string empId = cmbEmployees.SelectedValue.ToString();
            string fullName = cmbEmployees.Text; // from employees table
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string role = cmbRole.SelectedItem?.ToString();

            // ===== VALIDATION =====
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("All fields are required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password.Length < 6 ||
                !System.Text.RegularExpressions.Regex.IsMatch(password, @"[A-Za-z]") ||
                !System.Text.RegularExpressions.Regex.IsMatch(password, @"\d"))
            {
                MessageBox.Show("Password must be at least 6 characters long and contain both letters and numbers.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please select a role.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ===== DATABASE INSERT =====
            try
            {
                using var conn = DatabaseHelper.GetConnection();

                const string sql = @"INSERT INTO users 
                                     (FullName, Email, EmployeeID, Password, Role, IsActive) 
                                     VALUES (@FullName, @Email, @EmpId, @Password, @Role, 1)";

                using var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@FullName", fullName);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@EmpId", empId);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Role", role);

                cmd.ExecuteNonQuery();

                MessageBox.Show("✅ User registered successfully!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Registration failed: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
