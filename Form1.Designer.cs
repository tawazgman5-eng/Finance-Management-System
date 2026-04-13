namespace Finance_Management_Sys
{
    partial class Form1HBv
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
            button_showAll = new Button();
            txtSearch = new TextBox();
            buttonSearch = new Button();
            datePickerFilter = new DateTimePicker();
            buttonFilterDate = new Button();
            buttonShowAllDate = new Button();
            radioDaily = new RadioButton();
            radioMonthly = new RadioButton();
            lblBalance = new Label();
            lblWelcome = new Label();
            btnLogout = new Button();
            btnExit = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewExpenses).BeginInit();
            SuspendLayout();
            // 
            // btnTestConnection
            // 
            btnTestConnection.Location = new Point(0, 0);
            btnTestConnection.Name = "btnTestConnection";
            btnTestConnection.Size = new Size(75, 23);
            btnTestConnection.TabIndex = 22;
            // 
            // buttonInsert
            // 
            buttonInsert.Location = new Point(688, 499);
            buttonInsert.Name = "buttonInsert";
            buttonInsert.Size = new Size(239, 29);
            buttonInsert.TabIndex = 3;
            buttonInsert.Text = "Submit Expense";
            buttonInsert.UseVisualStyleBackColor = true;
            buttonInsert.Click += button1_Click;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(1051, 370);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(348, 27);
            txtAmount.TabIndex = 4;
            // 
            // txtExpenseName
            // 
            txtExpenseName.Location = new Point(190, 370);
            txtExpenseName.Name = "txtExpenseName";
            txtExpenseName.Size = new Size(445, 27);
            txtExpenseName.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(55, 370);
            label1.Name = "label1";
            label1.Size = new Size(110, 20);
            label1.TabIndex = 6;
            label1.Text = "Expense Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(969, 377);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 7;
            label2.Text = "Amount:";
            // 
            // dataGridViewExpenses
            // 
            dataGridViewExpenses.ColumnHeadersHeight = 29;
            dataGridViewExpenses.Location = new Point(43, 640);
            dataGridViewExpenses.Name = "dataGridViewExpenses";
            dataGridViewExpenses.RowHeadersWidth = 51;
            dataGridViewExpenses.Size = new Size(1479, 307);
            dataGridViewExpenses.TabIndex = 21;
            // 
            // button_showAll
            // 
            button_showAll.Location = new Point(1221, 57);
            button_showAll.Name = "button_showAll";
            button_showAll.Size = new Size(99, 30);
            button_showAll.TabIndex = 0;
            button_showAll.Text = "Show All";
            button_showAll.Click += button_showAll_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(1335, 57);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(125, 27);
            txtSearch.TabIndex = 13;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(1478, 55);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(109, 29);
            buttonSearch.TabIndex = 14;
            buttonSearch.Text = "Search";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click_1;
            // 
            // datePickerFilter
            // 
            datePickerFilter.Format = DateTimePickerFormat.Short;
            datePickerFilter.Location = new Point(14, 92);
            datePickerFilter.Name = "datePickerFilter";
            datePickerFilter.Size = new Size(250, 27);
            datePickerFilter.TabIndex = 15;
            // 
            // buttonFilterDate
            // 
            buttonFilterDate.Location = new Point(6, 139);
            buttonFilterDate.Name = "buttonFilterDate";
            buttonFilterDate.Size = new Size(120, 29);
            buttonFilterDate.TabIndex = 16;
            buttonFilterDate.Text = "Filter by Date";
            buttonFilterDate.UseVisualStyleBackColor = true;
            buttonFilterDate.Click += buttonFilterDate_Click;
            // 
            // buttonShowAllDate
            // 
            buttonShowAllDate.Location = new Point(144, 139);
            buttonShowAllDate.Name = "buttonShowAllDate";
            buttonShowAllDate.Size = new Size(120, 29);
            buttonShowAllDate.TabIndex = 17;
            buttonShowAllDate.Text = "Show All (Date)";
            buttonShowAllDate.UseVisualStyleBackColor = true;
            buttonShowAllDate.Click += buttonShowAllDate_Click;
            // 
            // radioDaily
            // 
            radioDaily.AutoSize = true;
            radioDaily.Location = new Point(318, 95);
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
            radioMonthly.Location = new Point(318, 144);
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
            lblBalance.Location = new Point(584, 12);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(134, 20);
            lblBalance.TabIndex = 20;
            lblBalance.Text = "Available Balance :";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblWelcome.Location = new Point(20, 10);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(129, 23);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome, User";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(1368, 7);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(100, 30);
            btnLogout.TabIndex = 23;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(1478, 7);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(100, 30);
            btnExit.TabIndex = 24;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // Form1HBv
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1599, 765);
            Controls.Add(lblBalance);
            Controls.Add(radioMonthly);
            Controls.Add(radioDaily);
            Controls.Add(buttonShowAllDate);
            Controls.Add(buttonFilterDate);
            Controls.Add(datePickerFilter);
            Controls.Add(buttonSearch);
            Controls.Add(txtSearch);
            Controls.Add(button_showAll);
            Controls.Add(dataGridViewExpenses);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtExpenseName);
            Controls.Add(txtAmount);
            Controls.Add(buttonInsert);
            Controls.Add(btnTestConnection);
            Controls.Add(lblWelcome);
            Controls.Add(btnLogout);
            Controls.Add(btnExit);
            Name = "Form1HBv";
            Text = "Finance Expense Manager";
            Load += Form1HBv_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewExpenses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnTestConnection;
        private Button buttonInsert;
        private TextBox txtAmount;
        private TextBox txtExpenseName;
        private Label label1;
        private Label label2;
        private DataGridView dataGridViewExpenses;
        private Button button_showAll;
        private TextBox txtSearch;
        private Button buttonSearch;
        private DateTimePicker datePickerFilter;
        private Button buttonFilterDate;
        private Button buttonShowAllDate;
        private RadioButton radioDaily;
        private RadioButton radioMonthly;
        private Label lblBalance;
        private Label lblWelcome;
        private Button btnLogout;
        private Button btnExit;
    }
}
