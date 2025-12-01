namespace TermProject2025.Forms
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.progressBarStrength = new System.Windows.Forms.ProgressBar();
            this.lblStrength = new System.Windows.Forms.Label();
            this.lblQuestion1 = new System.Windows.Forms.Label();
            this.cmbQuestion1 = new System.Windows.Forms.ComboBox();
            this.txtAnswer1 = new System.Windows.Forms.TextBox();
            this.lblQuestion2 = new System.Windows.Forms.Label();
            this.cmbQuestion2 = new System.Windows.Forms.ComboBox();
            this.txtAnswer2 = new System.Windows.Forms.TextBox();
            this.lblQuestion3 = new System.Windows.Forms.Label();
            this.cmbQuestion3 = new System.Windows.Forms.ComboBox();
            this.txtAnswer3 = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(140, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Create Account";
            //
            // lblEmail
            //
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(30, 70);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(39, 15);
            this.lblEmail.TabIndex = 1;
            this.lblEmail.Text = "Email:";
            //
            // txtEmail
            //
            this.txtEmail.Location = new System.Drawing.Point(30, 90);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(420, 23);
            this.txtEmail.TabIndex = 2;
            //
            // lblPassword
            //
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(30, 125);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(93, 15);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Master Password:";
            //
            // txtPassword
            //
            this.txtPassword.Location = new System.Drawing.Point(30, 145);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(420, 23);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            //
            // lblConfirmPassword
            //
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(30, 210);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(104, 15);
            this.lblConfirmPassword.TabIndex = 5;
            this.lblConfirmPassword.Text = "Confirm Password:";
            //
            // txtConfirmPassword
            //
            this.txtConfirmPassword.Location = new System.Drawing.Point(30, 230);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(420, 23);
            this.txtConfirmPassword.TabIndex = 6;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            //
            // progressBarStrength
            //
            this.progressBarStrength.Location = new System.Drawing.Point(30, 175);
            this.progressBarStrength.Name = "progressBarStrength";
            this.progressBarStrength.Size = new System.Drawing.Size(420, 15);
            this.progressBarStrength.TabIndex = 7;
            //
            // lblStrength
            //
            this.lblStrength.AutoSize = true;
            this.lblStrength.Location = new System.Drawing.Point(30, 192);
            this.lblStrength.Name = "lblStrength";
            this.lblStrength.Size = new System.Drawing.Size(0, 15);
            this.lblStrength.TabIndex = 8;
            //
            // lblQuestion1
            //
            this.lblQuestion1.AutoSize = true;
            this.lblQuestion1.Location = new System.Drawing.Point(30, 270);
            this.lblQuestion1.Name = "lblQuestion1";
            this.lblQuestion1.Size = new System.Drawing.Size(103, 15);
            this.lblQuestion1.TabIndex = 9;
            this.lblQuestion1.Text = "Security Question 1:";
            //
            // cmbQuestion1
            //
            this.cmbQuestion1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuestion1.Location = new System.Drawing.Point(30, 290);
            this.cmbQuestion1.Name = "cmbQuestion1";
            this.cmbQuestion1.Size = new System.Drawing.Size(420, 23);
            this.cmbQuestion1.TabIndex = 10;
            //
            // txtAnswer1
            //
            this.txtAnswer1.Location = new System.Drawing.Point(30, 318);
            this.txtAnswer1.Name = "txtAnswer1";
            this.txtAnswer1.PlaceholderText = "Answer";
            this.txtAnswer1.Size = new System.Drawing.Size(420, 23);
            this.txtAnswer1.TabIndex = 11;
            //
            // lblQuestion2
            //
            this.lblQuestion2.AutoSize = true;
            this.lblQuestion2.Location = new System.Drawing.Point(30, 355);
            this.lblQuestion2.Name = "lblQuestion2";
            this.lblQuestion2.Size = new System.Drawing.Size(103, 15);
            this.lblQuestion2.TabIndex = 12;
            this.lblQuestion2.Text = "Security Question 2:";
            //
            // cmbQuestion2
            //
            this.cmbQuestion2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuestion2.Location = new System.Drawing.Point(30, 375);
            this.cmbQuestion2.Name = "cmbQuestion2";
            this.cmbQuestion2.Size = new System.Drawing.Size(420, 23);
            this.cmbQuestion2.TabIndex = 13;
            //
            // txtAnswer2
            //
            this.txtAnswer2.Location = new System.Drawing.Point(30, 403);
            this.txtAnswer2.Name = "txtAnswer2";
            this.txtAnswer2.PlaceholderText = "Answer";
            this.txtAnswer2.Size = new System.Drawing.Size(420, 23);
            this.txtAnswer2.TabIndex = 14;
            //
            // lblQuestion3
            //
            this.lblQuestion3.AutoSize = true;
            this.lblQuestion3.Location = new System.Drawing.Point(30, 440);
            this.lblQuestion3.Name = "lblQuestion3";
            this.lblQuestion3.Size = new System.Drawing.Size(103, 15);
            this.lblQuestion3.TabIndex = 15;
            this.lblQuestion3.Text = "Security Question 3:";
            //
            // cmbQuestion3
            //
            this.cmbQuestion3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuestion3.Location = new System.Drawing.Point(30, 460);
            this.cmbQuestion3.Name = "cmbQuestion3";
            this.cmbQuestion3.Size = new System.Drawing.Size(420, 23);
            this.cmbQuestion3.TabIndex = 16;
            //
            // txtAnswer3
            //
            this.txtAnswer3.Location = new System.Drawing.Point(30, 488);
            this.txtAnswer3.Name = "txtAnswer3";
            this.txtAnswer3.PlaceholderText = "Answer";
            this.txtAnswer3.Size = new System.Drawing.Size(420, 23);
            this.txtAnswer3.TabIndex = 17;
            //
            // btnRegister
            //
            this.btnRegister.Location = new System.Drawing.Point(30, 540);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(200, 35);
            this.btnRegister.TabIndex = 18;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(250, 540);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(200, 35);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // RegisterForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 600);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtAnswer3);
            this.Controls.Add(this.cmbQuestion3);
            this.Controls.Add(this.lblQuestion3);
            this.Controls.Add(this.txtAnswer2);
            this.Controls.Add(this.cmbQuestion2);
            this.Controls.Add(this.lblQuestion2);
            this.Controls.Add(this.txtAnswer1);
            this.Controls.Add(this.cmbQuestion1);
            this.Controls.Add(this.lblQuestion1);
            this.Controls.Add(this.lblStrength);
            this.Controls.Add(this.progressBarStrength);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MyPass - Register";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.ProgressBar progressBarStrength;
        private System.Windows.Forms.Label lblStrength;
        private System.Windows.Forms.Label lblQuestion1;
        private System.Windows.Forms.ComboBox cmbQuestion1;
        private System.Windows.Forms.TextBox txtAnswer1;
        private System.Windows.Forms.Label lblQuestion2;
        private System.Windows.Forms.ComboBox cmbQuestion2;
        private System.Windows.Forms.TextBox txtAnswer2;
        private System.Windows.Forms.Label lblQuestion3;
        private System.Windows.Forms.ComboBox cmbQuestion3;
        private System.Windows.Forms.TextBox txtAnswer3;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnCancel;
    }
}
