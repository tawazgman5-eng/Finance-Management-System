using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Finance_Management_Sys
{
    public partial class AdminExpensesForm : Form
    {
        private int selectedID = -1;

        public AdminExpensesForm()
        {
            InitializeComponent();
        }

        private void AdminExpensesForm_Load(object sender, EventArgs e)
        {
            LoadExpenses();
            LoadBalance();
            lblWelcome.Text = $"Welcome, {Session.CurrentUserName} ({Session.CurrentUserRole})";

            // Subscribe to balance update event
            Session.OnBalanceUpdated += UpdateBalanceLabel;
        }

        private void UpdateBalanceLabel(decimal newBalance)
        {
            lblBalance.Text = $"Available Balance: ${newBalance:F2}";
        }

        // ─────────── LOAD ───────────
        private void LoadExpenses()
        {
            using var conn = DatabaseHelper.GetConnection();
            try
            {
                string sql = @"
                SELECT e.id, e.expense_name, e.amount, e.payment_method, e.created_at, e.status,
                       u1.FullName AS created_by,
                       u2.FullName AS updated_by
                FROM expenses e
                LEFT JOIN users u1 ON e.created_by = u1.UserID
                LEFT JOIN users u2 ON e.updated_by = u2.UserID";

                using var ad = new SQLiteDataAdapter(sql, conn);
                var dt = new DataTable();
                ad.Fill(dt);
                dataGridViewExpenses.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Could not load data: " + ex.Message);
            }
        }

        // ─────────── TEST CONNECTION ───────────
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                MessageBox.Show("✅ Connection successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Connection failed: " + ex.Message);
            }
        }

        // ─────────── INSERT ───────────
        private void buttonInsert_Click(object sender, EventArgs e)
        {
            string expenseName = txtExpenseName.Text.Trim();
            string amountText = txtAmount.Text.Trim();

            if (string.IsNullOrWhiteSpace(expenseName))
            {
                MessageBox.Show("Expense name is required.");
                return;
            }

            if (!decimal.TryParse(amountText, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a valid positive amount.");
                return;
            }

            using var conn = DatabaseHelper.GetConnection();
            try
            {
                const string sql = @"INSERT INTO expenses 
                                    (expense_name, amount, created_by, status, created_at) 
                                    VALUES (@name, @amount, @createdBy, 'Pending', CURRENT_TIMESTAMP)";
                using var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", expenseName);
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@createdBy", Session.CurrentUserId);
                cmd.ExecuteNonQuery();

                MessageBox.Show("✅ Data inserted successfully!");
                LoadExpenses();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Insert failed: " + ex.Message);
            }
        }

        // ─────────── UPDATE ───────────
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (selectedID == -1)
            {
                MessageBox.Show("Please select a record to update.");
                return;
            }

            try
            {
                using var conn = DatabaseHelper.GetConnection();
                const string sql = "UPDATE expenses SET expense_name=@name, amount=@amount WHERE id=@id";
                using var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", txtExpenseName.Text.Trim());
                cmd.Parameters.AddWithValue("@amount", Convert.ToDecimal(txtAmount.Text.Trim()));
                cmd.Parameters.AddWithValue("@id", selectedID);
                cmd.ExecuteNonQuery();

                MessageBox.Show("✅ Record updated successfully!");
                LoadExpenses();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Update failed: " + ex.Message);
            }
        }

        // ─────────── DELETE ───────────
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (selectedID == -1)
            {
                MessageBox.Show("Please select a record first.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this record?",
                                "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            using var conn = DatabaseHelper.GetConnection();
            try
            {
                string sql = "DELETE FROM expenses WHERE id=@id";
                using var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", selectedID);
                cmd.ExecuteNonQuery();

                MessageBox.Show("✅ Expense deleted!");
                selectedID = -1;
                txtExpenseName.Clear();
                txtAmount.Clear();
                LoadExpenses();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Delete failed: " + ex.Message);
            }
        }

        // ─────────── GRID SELECTION ───────────
        private void dataGridViewExpenses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridViewExpenses.Rows[e.RowIndex];
            if (row.Cells["id"].Value == null) return;

            selectedID = Convert.ToInt32(row.Cells["id"].Value);
            txtExpenseName.Text = row.Cells["expense_name"].Value?.ToString();
            txtAmount.Text = row.Cells["amount"].Value?.ToString();
            cmbStatus.SelectedItem = row.Cells["status"].Value?.ToString();
        }

        // ─────────── FILTER BY DATE ───────────
        private void FilterByExactDate(DateTime selectedDate)
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                const string sql = @"SELECT id, expense_name, amount, created_at
                                     FROM expenses
                                     WHERE date(created_at) = @d
                                     ORDER BY created_at DESC";
                using var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@d", selectedDate.ToString("yyyy-MM-dd"));

                using var ad = new SQLiteDataAdapter(cmd);
                var dt = new DataTable();
                ad.Fill(dt);
                dataGridViewExpenses.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Daily filter failed: " + ex.Message);
            }
        }

        private void FilterByMonthYear(DateTime selectedDate)
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                const string sql = @"SELECT id, expense_name, amount, created_at
                                     FROM expenses
                                     WHERE strftime('%Y-%m', created_at) = @ym
                                     ORDER BY created_at DESC";
                using var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ym", selectedDate.ToString("yyyy-MM"));

                using var ad = new SQLiteDataAdapter(cmd);
                var dt = new DataTable();
                ad.Fill(dt);
                dataGridViewExpenses.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Monthly filter failed: " + ex.Message);
            }
        }

        // ─────────── SEARCH ───────────
        private void SearchExpenses(string term)
        {
            using var conn = DatabaseHelper.GetConnection();
            try
            {
                string sql = @"
                SELECT e.id, e.expense_name, e.amount, e.payment_method, e.created_at, e.status,
                       u1.FullName AS created_by,
                       u2.FullName AS updated_by
                FROM expenses e
                LEFT JOIN users u1 ON e.created_by = u1.UserID
                LEFT JOIN users u2 ON e.updated_by = u2.UserID
                WHERE e.expense_name LIKE @k
                ORDER BY e.created_at DESC";

                using var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@k", "%" + term + "%");

                using var ad = new SQLiteDataAdapter(cmd);
                var dt = new DataTable();
                ad.Fill(dt);
                dataGridViewExpenses.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Search failed: " + ex.Message);
            }
        }

        // ─────────── SAVE STATUS + BALANCE ───────────
        private void btnSaveStatus_Click(object sender, EventArgs e)
        {
            if (selectedID == -1)
            {
                MessageBox.Show("Please select an expense.");
                return;
            }

            string newStatus = cmbStatus.SelectedItem?.ToString() ?? "Pending";

            try
            {
                using var conn = DatabaseHelper.GetConnection();

                if (newStatus == "Approved")
                {
                    string getAmountQuery = "SELECT amount FROM expenses WHERE id=@id";
                    using var getCmd = new SQLiteCommand(getAmountQuery, conn);
                    getCmd.Parameters.AddWithValue("@id", selectedID);
                    decimal expenseAmount = Convert.ToDecimal(getCmd.ExecuteScalar());

                    string deductQuery = "UPDATE accounts SET Balance = Balance - @amount WHERE AccountID=1";
                    using var deductCmd = new SQLiteCommand(deductQuery, conn);
                    deductCmd.Parameters.AddWithValue("@amount", expenseAmount);
                    deductCmd.ExecuteNonQuery();
                }

                string updateQuery = "UPDATE expenses SET status=@status, updated_by=@updatedBy WHERE id=@id";
                using var updateCmd = new SQLiteCommand(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@status", newStatus);
                updateCmd.Parameters.AddWithValue("@updatedBy", Session.CurrentUserId);
                updateCmd.Parameters.AddWithValue("@id", selectedID);
                updateCmd.ExecuteNonQuery();

                MessageBox.Show($"✅ Expense status updated to {newStatus}");
                LoadExpenses();
                LoadBalance();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Status update failed: " + ex.Message);
            }
        }

        private void LoadBalance()
        {
            using var conn = DatabaseHelper.GetConnection();
            try
            {
                string query = "SELECT Balance FROM accounts WHERE AccountID=1 LIMIT 1";
                using var cmd = new SQLiteCommand(query, conn);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    decimal balance = Convert.ToDecimal(result);
                    lblBalance.Text = $"Available Balance: ${balance:F2}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Could not load balance: " + ex.Message);
            }
        }

        // ─────────── EXTRA HANDLERS (to fix CS0103) ───────────
        private void button_showAll_Click(object sender, EventArgs e)
        {
            LoadExpenses();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                SearchExpenses(txtSearch.Text.Trim());
            else
                LoadExpenses();
        }

        private void buttonSearch_Click_1(object sender, EventArgs e)
        {
            SearchExpenses(txtSearch.Text.Trim());
        }

        private void buttonFilterDate_Click(object sender, EventArgs e)
        {
            if (radioDaily.Checked)
                FilterByExactDate(datePickerFilter.Value);
            else if (radioMonthly.Checked)
                FilterByMonthYear(datePickerFilter.Value);
        }

        private void buttonShowAllDate_Click(object sender, EventArgs e)
        {
            LoadExpenses();
        }

        // ─────────── NAVIGATION ───────────
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnManageEmployees_Click(object sender, EventArgs e)
        {
            new AdminEmployeeForm().ShowDialog();
        }

        private void btnRegisterUser_Click(object sender, EventArgs e)
        {
            if (Session.CurrentUserRole != "Admin")
            {
                MessageBox.Show("Only Admins can register new users.");
                return;
            }

            new RegisterForm().ShowDialog();
        }
    }
}
