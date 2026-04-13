using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Finance_Management_Sys
{
    public partial class FinanceManagerForm : Form
    {
        private int selectedID = -1;

        public FinanceManagerForm()
        {
            InitializeComponent();
        }

        // ───────────────────────── LIFECYCLE ─────────────────────────
        private void FinanceManagerForm_Load(object sender, EventArgs e)
        {
            if (Session.CurrentUserRole != "FinanceManager")
            {
                MessageBox.Show("Access denied. Only Finance Managers can access this form.");
                this.Close();
                return;
            }

            lblWelcome.Text = $"Welcome, {Session.CurrentUserName} ({Session.CurrentUserRole})";
            LoadApprovedExpenses();
            LoadBalance();
        }

        private void LoadBalance()
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                string query = "SELECT Balance FROM accounts WHERE AccountID = 1 LIMIT 1";
                using var cmd = new SQLiteCommand(query, conn);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    decimal balance = Convert.ToDecimal(result);
                    lblCurrentBalanceFM.Text = $"Current Balance: ${balance:F2}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Could not load balance: " + ex.Message);
            }
        }

        private void btnAddIncome_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtIncomeAmount.Text.Trim(), out decimal income) || income <= 0)
            {
                MessageBox.Show("Please enter a valid positive income amount.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var conn = DatabaseHelper.GetConnection();
                string query = "UPDATE accounts SET Balance = Balance + @amount WHERE AccountID = 1";
                using var cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@amount", income);
                cmd.ExecuteNonQuery();

                // 🔹 Get updated balance
                string selectQuery = "SELECT Balance FROM accounts WHERE AccountID = 1 LIMIT 1";
                using var selectCmd = new SQLiteCommand(selectQuery, conn);
                decimal newBalance = Convert.ToDecimal(selectCmd.ExecuteScalar());

                // 🔹 Trigger balance update event
                Session.RaiseBalanceUpdated(newBalance);

                MessageBox.Show($"✅ Successfully added income of ${income:F2}");
                txtIncomeAmount.Clear();
                LoadBalance();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Failed to update balance: " + ex.Message);
            }
        }

        // ───────────────────────── LOAD DATA ─────────────────────────
        private void LoadApprovedExpenses()
        {
            try
            {
                using var conn = DatabaseHelper.GetConnection();
                string sql = @"
                    SELECT e.id, e.expense_name, e.amount, e.created_at, e.status,
                           e.payment_method,
                           u1.FullName AS created_by,
                           u2.FullName AS updated_by
                    FROM expenses e
                    LEFT JOIN users u1 ON e.created_by = u1.UserID
                    LEFT JOIN users u2 ON e.updated_by = u2.UserID
                    WHERE e.status IN ('Approved','Resolved','Rejected')";

                using var ad = new SQLiteDataAdapter(sql, conn);
                var dt = new DataTable();
                ad.Fill(dt);
                dataGridViewFM.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Could not load expenses: " + ex.Message);
            }
        }

        // ───────────────────────── GRID SELECTION ─────────────────────
        private void dataGridViewFM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridViewFM.Rows[e.RowIndex];
            if (row.Cells["id"].Value == null) return;

            selectedID = Convert.ToInt32(row.Cells["id"].Value);
            txtFMExpenseName.Text = row.Cells["expense_name"].Value?.ToString();
            txtFMAmount.Text = row.Cells["amount"].Value?.ToString();
            cmbFMStatus.SelectedItem = row.Cells["status"].Value?.ToString();
            cmbPaymentMethod.SelectedItem = row.Cells["payment_method"].Value?.ToString();
        }

        // ───────────────────────── UPDATE DECISION ────────────────────
        private void btnFMUpdateStatus_Click(object sender, EventArgs e)
        {
            if (selectedID == -1)
            {
                MessageBox.Show("Please select an expense.");
                return;
            }

            string newStatus = cmbFMStatus.SelectedItem?.ToString() ?? "Approved";
            string paymentMethod = cmbPaymentMethod.SelectedItem?.ToString() ?? "Cash";

            try
            {
                using var conn = DatabaseHelper.GetConnection();

                if (newStatus == "Declined")
                {
                    // Refund balance
                    string getAmountQuery = "SELECT amount FROM expenses WHERE id=@id";
                    using var getCmd = new SQLiteCommand(getAmountQuery, conn);
                    getCmd.Parameters.AddWithValue("@id", selectedID);
                    decimal expenseAmount = Convert.ToDecimal(getCmd.ExecuteScalar());

                    string refundQuery = "UPDATE accounts SET Balance = Balance + @amount WHERE AccountID=1";
                    using var refundCmd = new SQLiteCommand(refundQuery, conn);
                    refundCmd.Parameters.AddWithValue("@amount", expenseAmount);
                    refundCmd.ExecuteNonQuery();
                }

                // Update expense with FM decision + payment method
                string updateQuery = @"UPDATE expenses 
                                       SET status=@status, payment_method=@paymentMethod, updated_by=@updatedBy 
                                       WHERE id=@id";
                using var updateCmd = new SQLiteCommand(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@status", newStatus);
                updateCmd.Parameters.AddWithValue("@paymentMethod", paymentMethod);
                updateCmd.Parameters.AddWithValue("@updatedBy", Session.CurrentUserId);
                updateCmd.Parameters.AddWithValue("@id", selectedID);
                updateCmd.ExecuteNonQuery();

                MessageBox.Show($"✅ Expense updated to {newStatus} with {paymentMethod}");
                LoadApprovedExpenses();
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Status update failed: " + ex.Message);
            }
        }

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

        // ───────────────────────── REFRESH ────────────────────────────
        private void btnFMRefresh_Click(object sender, EventArgs e)
        {
            LoadApprovedExpenses();
        }
    }
}
