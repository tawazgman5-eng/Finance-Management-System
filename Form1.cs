using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Finance_Management_Sys
{
    public partial class Form1HBv : Form
    {
        private int selectedID = -1;

        public Form1HBv()
        {
            InitializeComponent();
        }

        private void Form1HBv_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, {Session.CurrentUserName} ({Session.CurrentUserRole})";
            radioMonthly.Checked = true;
            LoadExpenses();
            LoadBalance();

            // Subscribe to balance update event
            Session.OnBalanceUpdated += UpdateBalanceLabel;
        }

        // Update balance label
        private void UpdateBalanceLabel(decimal newBalance)
        {
            lblBalance.Text = $"Available Balance: ${newBalance:F2}";
        }

        // ─────────── LOAD EXPENSES ───────────
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

        // ─────────── INSERT EXPENSE ───────────
        private void button1_Click(object sender, EventArgs e)
        {
            string expenseName = txtExpenseName.Text.Trim();
            string amountText = txtAmount.Text.Trim();

            // Validate
            if (string.IsNullOrWhiteSpace(expenseName))
            {
                MessageBox.Show("Expense name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(expenseName, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Expense name should contain only letters and spaces.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(amountText, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a valid positive amount.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        // ─────────── VALIDATION KEY PRESS ───────────
        private void TxtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;

            if ((e.KeyChar == '.') && (txtAmount.Text.Contains('.')))
                e.Handled = true;
        }

        private void TxtExpenseName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
                e.Handled = true;
        }

        // ─────────── DATE FILTERING ───────────
        private void buttonFilterDate_Click(object sender, EventArgs e)
        {
            if (radioDaily.Checked)
                FilterByExactDate(datePickerFilter.Value);
            else if (radioMonthly.Checked)
                FilterByMonthYear(datePickerFilter.Value);
            else
                MessageBox.Show("Please select a filter option (Daily or Monthly).");
        }

        private void FilterByMonthYear(DateTime value)
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
                    WHERE strftime('%m', e.created_at) = @month 
                      AND strftime('%Y', e.created_at) = @year
                    ORDER BY e.created_at DESC";

                using var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@month", value.ToString("MM"));
                cmd.Parameters.AddWithValue("@year", value.ToString("yyyy"));

                using var ad = new SQLiteDataAdapter(cmd);
                var dt = new DataTable();
                ad.Fill(dt);
                dataGridViewExpenses.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Filter by month/year failed: " + ex.Message);
            }
        }

        private void FilterByExactDate(DateTime value)
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
                    WHERE date(e.created_at) = @date
                    ORDER BY e.created_at DESC";

                using var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@date", value.ToString("yyyy-MM-dd"));

                using var ad = new SQLiteDataAdapter(cmd);
                var dt = new DataTable();
                ad.Fill(dt);
                dataGridViewExpenses.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Filter by exact date failed: " + ex.Message);
            }
        }

        private void buttonShowAllDate_Click(object sender, EventArgs e)
        {
            LoadExpenses();
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

        private void buttonSearch_Click_1(object sender, EventArgs e)
        {
            var term = txtSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(term))
            {
                MessageBox.Show("Please enter a keyword to search.");
                return;
            }
            SearchExpenses(term);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var term = txtSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(term))
                LoadExpenses();
            else
                SearchExpenses(term);
        }

        private void button_showAll_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadExpenses();
        }

        // ─────────── LOGOUT / EXIT ───────────
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new LoginForm();
            loginForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // ─────────── LOAD BALANCE ───────────
        private void LoadBalance()
        {
            using var conn = DatabaseHelper.GetConnection();
            try
            {
                string query = "SELECT Balance FROM accounts WHERE AccountID = 1 LIMIT 1";
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
    }
}
