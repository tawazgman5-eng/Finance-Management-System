using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Finance_Management_Sys
{
    public partial class AdminEmployeeForm : Form
    {
        private int selectedEmpId = -1;

        public AdminEmployeeForm()
        {
            InitializeComponent();
        }

        private void AdminEmployeeForm_Load(object sender, EventArgs e)
        {
            if (Session.CurrentUserRole != "Admin")
            {
                MessageBox.Show("Access denied. Only Admins can manage employees.");
                this.Close();
                return;
            }

            LoadEmployees();
        }

        // ─────────────────── LOAD EMPLOYEES ───────────────────
        private void LoadEmployees()
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                string sql = "SELECT EmployeeID, FullName, Department, Position, DateJoined FROM employees ORDER BY EmployeeID";
                using var ad = new SQLiteDataAdapter(sql, conn);
                var dt = new DataTable();
                ad.Fill(dt);
                dgvEmployees.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Could not load employees: " + ex.Message);
            }
        }

        // ─────────────────── ADD EMPLOYEE ───────────────────
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string empId = txtEmployeeID.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string department = txtDepartment.Text.Trim();
            string position = txtPosition.Text.Trim();
            string dateJoined = dtpDateJoined.Value.ToString("yyyy-MM-dd");

            if (string.IsNullOrWhiteSpace(empId) || string.IsNullOrWhiteSpace(fullName))
            {
                MessageBox.Show("Employee ID and Full Name are required.");
                return;
            }

            try
            {
                using var conn = DatabaseHelper.GetConnection();
                const string sql = @"INSERT INTO employees (EmployeeID, FullName, Department, Position, DateJoined)
                                     VALUES (@id, @name, @dept, @pos, @date)";
                using var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", empId);
                cmd.Parameters.AddWithValue("@name", fullName);
                cmd.Parameters.AddWithValue("@dept", department);
                cmd.Parameters.AddWithValue("@pos", position);
                cmd.Parameters.AddWithValue("@date", dateJoined);
                cmd.ExecuteNonQuery();

                MessageBox.Show("✅ Employee added successfully.");
                ClearInputs();
                LoadEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Insert failed: " + ex.Message);
            }
        }

        // ─────────────────── UPDATE EMPLOYEE ───────────────────
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedEmpId == -1)
            {
                MessageBox.Show("Please select an employee to update.");
                return;
            }

            string fullName = txtFullName.Text.Trim();
            string department = txtDepartment.Text.Trim();
            string position = txtPosition.Text.Trim();
            string dateJoined = dtpDateJoined.Value.ToString("yyyy-MM-dd");

            try
            {
                using var conn = DatabaseHelper.GetConnection();
                const string sql = @"UPDATE employees 
                                     SET FullName=@name, Department=@dept, Position=@pos, DateJoined=@date
                                     WHERE EmployeeID=@id";
                using var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", selectedEmpId);
                cmd.Parameters.AddWithValue("@name", fullName);
                cmd.Parameters.AddWithValue("@dept", department);
                cmd.Parameters.AddWithValue("@pos", position);
                cmd.Parameters.AddWithValue("@date", dateJoined);
                cmd.ExecuteNonQuery();

                MessageBox.Show("✅ Employee updated successfully.");
                ClearInputs();
                LoadEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Update failed: " + ex.Message);
            }
        }

        // ─────────────────── DELETE EMPLOYEE ───────────────────
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedEmpId == -1)
            {
                MessageBox.Show("Please select an employee to delete.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this employee?", "Confirm",
                MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                using var conn = DatabaseHelper.GetConnection();
                const string sql = "DELETE FROM employees WHERE EmployeeID=@id";
                using var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", selectedEmpId);
                cmd.ExecuteNonQuery();

                MessageBox.Show("✅ Employee deleted successfully.");
                ClearInputs();
                LoadEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Delete failed: " + ex.Message);
            }
        }

        // ─────────────────── GRID SELECTION ───────────────────
        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvEmployees.Rows[e.RowIndex];
            if (row.Cells["EmployeeID"].Value == null) return;

            selectedEmpId = Convert.ToInt32(row.Cells["EmployeeID"].Value);
            txtEmployeeID.Text = row.Cells["EmployeeID"].Value?.ToString();
            txtFullName.Text = row.Cells["FullName"].Value?.ToString();
            txtDepartment.Text = row.Cells["Department"].Value?.ToString();
            txtPosition.Text = row.Cells["Position"].Value?.ToString();

            if (row.Cells["DateJoined"].Value != null && DateTime.TryParse(row.Cells["DateJoined"].Value.ToString(), out DateTime dj))
            {
                dtpDateJoined.Value = dj;
            }

            txtEmployeeID.Enabled = false; // prevent editing primary key
        }

        private void ClearInputs()
        {
            txtEmployeeID.Clear();
            txtFullName.Clear();
            txtDepartment.Clear();
            txtPosition.Clear();
            dtpDateJoined.Value = DateTime.Today;
            txtEmployeeID.Enabled = true;
            selectedEmpId = -1;
        }
    }
}
