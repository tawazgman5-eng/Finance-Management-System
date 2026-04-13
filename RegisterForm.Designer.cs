
namespace Finance_Management_Sys
{
    partial class RegisterForm
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
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            cmbRole = new ComboBox();
            cmbDepartment = new ComboBox();
            btnRegister = new Button();
            lblEmail = new Label();
            lblPassword = new Label();
            lblConfirmPassword = new Label();
            lblRole = new Label();
            lblDepartment = new Label();
            cmbEmployees = new ComboBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(180, 129);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 27);
            txtEmail.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(180, 181);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(200, 27);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(180, 236);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(200, 27);
            txtConfirmPassword.TabIndex = 3;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Items.AddRange(new object[] { "User", "Admin", "FinanceManager" });
            cmbRole.Location = new Point(180, 290);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(200, 28);
            cmbRole.TabIndex = 0;
            // 
            // cmbDepartment
            // 
            cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDepartment.Items.AddRange(new object[] { "Finance", "HR", "IT", "General" });
            cmbDepartment.Location = new Point(180, 341);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(200, 28);
            cmbDepartment.TabIndex = 5;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(180, 393);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(200, 35);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "Register";
            btnRegister.Click += btnRegister_Click;
            // 
            // lblEmail
            // 
            lblEmail.Location = new Point(60, 129);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(100, 23);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Email:";
            // 
            // lblPassword
            // 
            lblPassword.Location = new Point(60, 181);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(100, 23);
            lblPassword.TabIndex = 9;
            lblPassword.Text = "Password:";
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.Location = new Point(60, 236);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(100, 23);
            lblConfirmPassword.TabIndex = 10;
            lblConfirmPassword.Text = "Confirm Password:";
            // 
            // lblRole
            // 
            lblRole.Location = new Point(60, 290);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(100, 23);
            lblRole.TabIndex = 11;
            lblRole.Text = "Role:";
            // 
            // lblDepartment
            // 
            lblDepartment.Location = new Point(60, 341);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(100, 23);
            lblDepartment.TabIndex = 12;
            lblDepartment.Text = "Department:";
            // 
            // cmbEmployees
            // 
            cmbEmployees.FormattingEnabled = true;
            cmbEmployees.Location = new Point(180, 79);
            cmbEmployees.Name = "cmbEmployees";
            cmbEmployees.Size = new Size(200, 28);
            cmbEmployees.TabIndex = 13;
            cmbEmployees.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 82);
            label1.Name = "label1";
            label1.Size = new Size(122, 20);
            label1.TabIndex = 14;
            label1.Text = "Select Employee:";
            // 
            // RegisterForm
            // 
            ClientSize = new Size(588, 515);
            Controls.Add(label1);
            Controls.Add(cmbEmployees);
            Controls.Add(txtEmail);
            Controls.Add(txtPassword);
            Controls.Add(txtConfirmPassword);
            Controls.Add(cmbRole);
            Controls.Add(cmbDepartment);
            Controls.Add(btnRegister);
            Controls.Add(lblEmail);
            Controls.Add(lblPassword);
            Controls.Add(lblConfirmPassword);
            Controls.Add(lblRole);
            Controls.Add(lblDepartment);
            Name = "RegisterForm";
            Text = "User Registration";
            ResumeLayout(false);
            PerformLayout();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {

        }

        #endregion
        private TextBox txtEmail;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;
        private ComboBox cmbRole;
        private ComboBox cmbDepartment;
        private Button btnRegister;
        private Label lblEmail;
        private Label lblPassword;
        private Label lblConfirmPassword;
        private Label lblRole;
        private Label lblDepartment;
        private ComboBox cmbEmployees;
        private Label label1;

    }
}
