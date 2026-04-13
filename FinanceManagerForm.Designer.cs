namespace Finance_Management_Sys
{
    partial class FinanceManagerForm
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
            dataGridViewFM = new DataGridView();
            txtFMExpenseName = new TextBox();
            txtFMAmount = new TextBox();
            cmbFMStatus = new ComboBox();
            cmbPaymentMethod = new ComboBox();
            btnFMUpdateStatus = new Button();
            btnFMRefresh = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            lblWelcome = new Label();
            btnAddIncome = new Button();
            txtIncomeAmount = new TextBox();
            lblCurrentBalanceFM = new Label();
            btnLogout = new Button();
            btnExit = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFM).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewFM
            // 
            dataGridViewFM.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewFM.Location = new Point(20, 106);
            dataGridViewFM.Name = "dataGridViewFM";
            dataGridViewFM.RowHeadersWidth = 51;
            dataGridViewFM.Size = new Size(1364, 295);
            dataGridViewFM.TabIndex = 0;
            dataGridViewFM.CellClick += dataGridViewFM_CellClick;
            // 
            // txtFMExpenseName
            // 
            txtFMExpenseName.Location = new Point(160, 423);
            txtFMExpenseName.Name = "txtFMExpenseName";
            txtFMExpenseName.Size = new Size(200, 27);
            txtFMExpenseName.TabIndex = 1;
            // 
            // txtFMAmount
            // 
            txtFMAmount.Location = new Point(160, 474);
            txtFMAmount.Name = "txtFMAmount";
            txtFMAmount.Size = new Size(200, 27);
            txtFMAmount.TabIndex = 2;
            // 
            // cmbFMStatus
            // 
            cmbFMStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFMStatus.Items.AddRange(new object[] { "Resolved", "Declined" });
            cmbFMStatus.Location = new Point(160, 518);
            cmbFMStatus.Name = "cmbFMStatus";
            cmbFMStatus.Size = new Size(200, 28);
            cmbFMStatus.TabIndex = 3;
            // 
            // cmbPaymentMethod
            // 
            cmbPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentMethod.Items.AddRange(new object[] { "Cash", "Credit Card" });
            cmbPaymentMethod.Location = new Point(160, 561);
            cmbPaymentMethod.Name = "cmbPaymentMethod";
            cmbPaymentMethod.Size = new Size(200, 28);
            cmbPaymentMethod.TabIndex = 4;
            // 
            // btnFMUpdateStatus
            // 
            btnFMUpdateStatus.Location = new Point(437, 467);
            btnFMUpdateStatus.Name = "btnFMUpdateStatus";
            btnFMUpdateStatus.Size = new Size(150, 30);
            btnFMUpdateStatus.TabIndex = 5;
            btnFMUpdateStatus.Text = "Update Decision";
            btnFMUpdateStatus.UseVisualStyleBackColor = true;
            btnFMUpdateStatus.Click += btnFMUpdateStatus_Click;
            // 
            // btnFMRefresh
            // 
            btnFMRefresh.Location = new Point(437, 516);
            btnFMRefresh.Name = "btnFMRefresh";
            btnFMRefresh.Size = new Size(150, 30);
            btnFMRefresh.TabIndex = 6;
            btnFMRefresh.Text = "Refresh";
            btnFMRefresh.UseVisualStyleBackColor = true;
            btnFMRefresh.Click += btnFMRefresh_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 426);
            label1.Name = "label1";
            label1.Size = new Size(110, 20);
            label1.TabIndex = 7;
            label1.Text = "Expense Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 477);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 8;
            label2.Text = "Amount:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 521);
            label3.Name = "label3";
            label3.Size = new Size(52, 20);
            label3.TabIndex = 9;
            label3.Text = "Status:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 564);
            label4.Name = "label4";
            label4.Size = new Size(124, 20);
            label4.TabIndex = 10;
            label4.Text = "Payment Method:";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblWelcome.Location = new Point(20, 10);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(230, 23);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome, Finance Manager";
            // 
            // btnAddIncome
            // 
            btnAddIncome.Location = new Point(160, 57);
            btnAddIncome.Name = "btnAddIncome";
            btnAddIncome.Size = new Size(128, 33);
            btnAddIncome.TabIndex = 11;
            btnAddIncome.Text = "Update Balance";
            btnAddIncome.UseVisualStyleBackColor = true;
            btnAddIncome.Click += btnAddIncome_Click;
            // 
            // txtIncomeAmount
            // 
            txtIncomeAmount.Location = new Point(20, 60);
            txtIncomeAmount.Name = "txtIncomeAmount";
            txtIncomeAmount.Size = new Size(120, 27);
            txtIncomeAmount.TabIndex = 12;
            // 
            // lblCurrentBalanceFM
            // 
            lblCurrentBalanceFM.AutoSize = true;
            lblCurrentBalanceFM.Location = new Point(395, 13);
            lblCurrentBalanceFM.Name = "lblCurrentBalanceFM";
            lblCurrentBalanceFM.Size = new Size(155, 20);
            lblCurrentBalanceFM.TabIndex = 13;
            lblCurrentBalanceFM.Text = "Current Balance: $0.00";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(915, 45);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(100, 30);
            btnLogout.TabIndex = 14;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(1025, 45);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(100, 30);
            btnExit.TabIndex = 15;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // FinanceManagerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1482, 618);
            Controls.Add(dataGridViewFM);
            Controls.Add(txtFMExpenseName);
            Controls.Add(txtFMAmount);
            Controls.Add(cmbFMStatus);
            Controls.Add(cmbPaymentMethod);
            Controls.Add(btnFMUpdateStatus);
            Controls.Add(btnFMRefresh);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(lblCurrentBalanceFM);
            Controls.Add(txtIncomeAmount);
            Controls.Add(btnAddIncome);
            Controls.Add(lblWelcome);
            Controls.Add(btnLogout);
            Controls.Add(btnExit);
            Name = "FinanceManagerForm";
            Text = "Finance Manager Dashboard";
            Load += FinanceManagerForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewFM).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewFM;
        private TextBox txtFMExpenseName;
        private TextBox txtFMAmount;
        private ComboBox cmbFMStatus;
        private ComboBox cmbPaymentMethod;
        private Button btnFMUpdateStatus;
        private Button btnFMRefresh;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private System.Windows.Forms.Label lblWelcome;
        private Button btnAddIncome;
        private TextBox txtIncomeAmount;
        private Label lblCurrentBalanceFM;
        private Button btnLogout;
        private Button btnExit;
        

    }
}
