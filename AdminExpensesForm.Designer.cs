
namespace Finance_Management_Sys
{
    partial class AdminExpensesForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            btnTestConnection = new Button();
            buttonInsert = new Button();
            txtAmount = new TextBox();
            txtExpenseName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            dataGridViewExpenses = new DataGridView();
            buttonUpdate = new Button();
            buttonDelete = new Button();
            button_showAll = new Button();
            txtSearch = new TextBox();
            buttonSearch = new Button();
            datePickerFilter = new DateTimePicker();
            buttonFilterDate = new Button();
            buttonShowAllDate = new Button();
            radioDaily = new RadioButton();
            radioMonthly = new RadioButton();
            lblBalance = new Label();
            cmbStatus = new ComboBox();
            btnSaveStatus = new Button();
            btnRegisterUser = new Button();
            lblWelcome = new Label();
            btnLogout = new Button();
            btnExit = new Button();
            btnManageEmployees = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewExpenses).BeginInit();
            SuspendLayout();
            // 
            // btnTestConnection
            // 
            btnTestConnection.Location = new Point(1396, 498);
            btnTestConnection.Name = "btnTestConnection";
            btnTestConnection.Size = new Size(158, 29);
            btnTestConnection.TabIndex = 1;
            btnTestConnection.Text = "Test Connection";
            btnTestConnection.UseVisualStyleBackColor = true;
            btnTestConnection.Click += btnTestConnection_Click;
            // 
            // buttonInsert
            // 
            buttonInsert.Location = new Point(41, 333);
            buttonInsert.Name = "buttonInsert";
            buttonInsert.Size = new Size(239, 29);
            buttonInsert.TabIndex = 3;
            buttonInsert.Text = "Insert Data";
            buttonInsert.UseVisualStyleBackColor = true;
            buttonInsert.Click += btnInsert_Click;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(155, 245);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(352, 27);
            txtAmount.TabIndex = 4;
            // 
            // txtExpenseName
            // 
            txtExpenseName.Location = new Point(155, 174);
            txtExpenseName.Name = "txtExpenseName";
            txtExpenseName.Size = new Size(352, 27);
            txtExpenseName.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 174);
            label1.Name = "label1";
            label1.Size = new Size(110, 20);
            label1.TabIndex = 6;
            label1.Text = "Expense Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(71, 248);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 7;
            label2.Text = "Amount:";
            // 
            // dataGridViewExpenses
            // 
            dataGridViewExpenses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewExpenses.Location = new Point(33, 645);
            dataGridViewExpenses.Name = "dataGridViewExpenses";
            dataGridViewExpenses.RowHeadersWidth = 51;
            dataGridViewExpenses.Size = new Size(1459, 362);
            dataGridViewExpenses.TabIndex = 8;
            dataGridViewExpenses.CellClick += dataGridViewExpenses_CellClick;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(82, 599);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(140, 29);
            buttonUpdate.TabIndex = 9;
            buttonUpdate.Text = "Update Selected";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += btnUpdate_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(295, 599);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(140, 29);
            buttonDelete.TabIndex = 10;
            buttonDelete.Text = "Delete Selected";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += btnDelete_Click;
            // 
            // button_showAll
            // 
            button_showAll.Location = new Point(1133, 21);
            button_showAll.Name = "button_showAll";
            button_showAll.Size = new Size(99, 30);
            button_showAll.TabIndex = 0;
            button_showAll.Text = "Show All";
            button_showAll.Click += btnShowAll_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(1269, 24);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(125, 27);
            txtSearch.TabIndex = 13;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(1425, 22);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(109, 29);
            buttonSearch.TabIndex = 14;
            buttonSearch.Text = "Search";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += btnSearch_Click;
            // 
            // datePickerFilter
            // 
            datePickerFilter.Format = DateTimePickerFormat.Short;
            datePickerFilter.Location = new Point(1317, 159);
            datePickerFilter.Name = "datePickerFilter";
            datePickerFilter.Size = new Size(250, 27);
            datePickerFilter.TabIndex = 15;
            // 
            // buttonFilterDate
            // 
            buttonFilterDate.Location = new Point(1345, 205);
            buttonFilterDate.Name = "buttonFilterDate";
            buttonFilterDate.Size = new Size(120, 29);
            buttonFilterDate.TabIndex = 16;
            buttonFilterDate.Text = "Filter by Date";
            buttonFilterDate.UseVisualStyleBackColor = true;
            buttonFilterDate.Click += btnFilterDate_Click;
            // 
            // buttonShowAllDate
            // 
            buttonShowAllDate.Location = new Point(1471, 205);
            buttonShowAllDate.Name = "buttonShowAllDate";
            buttonShowAllDate.Size = new Size(120, 29);
            buttonShowAllDate.TabIndex = 17;
            buttonShowAllDate.Text = "Show All (Date)";
            buttonShowAllDate.UseVisualStyleBackColor = true;
            buttonShowAllDate.Click += btnShowAllDate_Click;
            // 
            // radioDaily
            // 
            radioDaily.AutoSize = true;
            radioDaily.Location = new Point(1250, 122);
            radioDaily.Name = "radioDaily";
            radioDaily.Size = new Size(158, 24);
            radioDaily.TabIndex = 18;
            radioDaily.TabStop = true;
            radioDaily.Text = "Filter by Exact Date";
            radioDaily.UseVisualStyleBackColor = true;
            // 
            // radioMonthly
            // 
            radioMonthly.AutoSize = true;
            radioMonthly.Location = new Point(1414, 122);
            radioMonthly.Name = "radioMonthly";
            radioMonthly.Size = new Size(164, 24);
            radioMonthly.TabIndex = 19;
            radioMonthly.TabStop = true;
            radioMonthly.Text = "Filter by Month/Year";
            radioMonthly.UseVisualStyleBackColor = true;
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Location = new Point(666, 31);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(134, 20);
            lblBalance.TabIndex = 20;
            lblBalance.Text = "Available Balance :";
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Items.AddRange(new object[] { "Pending", "Approved", "Declined" });
            cmbStatus.Location = new Point(699, 599);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(150, 28);
            cmbStatus.TabIndex = 23;
            // 
            // btnSaveStatus
            // 
            btnSaveStatus.Location = new Point(869, 599);
            btnSaveStatus.Name = "btnSaveStatus";
            btnSaveStatus.Size = new Size(120, 28);
            btnSaveStatus.TabIndex = 24;
            btnSaveStatus.Text = "Update Status";
            btnSaveStatus.UseVisualStyleBackColor = true;
            btnSaveStatus.Click += btnSaveStatus_Click;
            // 
            // btnRegisterUser
            // 
            btnRegisterUser.Location = new Point(1391, 401);
            btnRegisterUser.Name = "btnRegisterUser";
            btnRegisterUser.Size = new Size(200, 35);
            btnRegisterUser.TabIndex = 25;
            btnRegisterUser.Text = "Register New User";
            btnRegisterUser.UseVisualStyleBackColor = true;
            btnRegisterUser.Click += btnRegisterUser_Click;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblWelcome.Location = new Point(12, 9);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(148, 23);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome, Admin";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(3, 78);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(100, 30);
            btnLogout.TabIndex = 26;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(122, 78);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(100, 30);
            btnExit.TabIndex = 27;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnManageEmployees
            // 
            btnManageEmployees.Location = new Point(35, 454);
            btnManageEmployees.Name = "btnManageEmployees";
            btnManageEmployees.Size = new Size(200, 35);
            btnManageEmployees.TabIndex = 15;
            btnManageEmployees.Text = "Manage Employees";
            btnManageEmployees.UseVisualStyleBackColor = true;
            btnManageEmployees.Click += btnManageEmployees_Click;
            // 
            // AdminExpensesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1599, 765);
            Controls.Add(btnManageEmployees);
            Controls.Add(lblBalance);
            Controls.Add(radioMonthly);
            Controls.Add(radioDaily);
            Controls.Add(buttonShowAllDate);
            Controls.Add(buttonFilterDate);
            Controls.Add(datePickerFilter);
            Controls.Add(buttonSearch);
            Controls.Add(txtSearch);
            Controls.Add(button_showAll);
            Controls.Add(buttonDelete);
            Controls.Add(buttonUpdate);
            Controls.Add(dataGridViewExpenses);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtExpenseName);
            Controls.Add(txtAmount);
            Controls.Add(buttonInsert);
            Controls.Add(btnTestConnection);
            Controls.Add(cmbStatus);
            Controls.Add(btnSaveStatus);
            Controls.Add(btnRegisterUser);
            Controls.Add(lblWelcome);
            Controls.Add(btnLogout);
            Controls.Add(btnExit);
            Name = "AdminExpensesForm";
            Text = "Finance Expense Manager";
            Load += AdminExpensesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewExpenses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void btnShowAllDate_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnFilterDate_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Button btnTestConnection;
        private Button buttonInsert;
        private TextBox txtAmount;
        private TextBox txtExpenseName;
        private Label label1;
        private Label label2;
        private DataGridView dataGridViewExpenses;
        private Button buttonUpdate;
        private Button buttonDelete;
        private Button button_showAll;
        private TextBox txtSearch;
        private Button buttonSearch;
        private DateTimePicker datePickerFilter;
        private Button buttonFilterDate;
        private Button buttonShowAllDate;
        private RadioButton radioDaily;
        private RadioButton radioMonthly;
        private Label lblBalance;
        private ComboBox cmbStatus;
        private Button btnSaveStatus;
        private Button btnRegisterUser;
        private System.Windows.Forms.Label lblWelcome;
        private Button btnLogout;
        private Button btnExit;
        private Button btnManageEmployees;
    }
}
