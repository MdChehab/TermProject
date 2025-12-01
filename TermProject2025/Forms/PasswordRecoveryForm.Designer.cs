namespace TermProject2025.Forms
{
    partial class PasswordRecoveryForm
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
            this.panelEmail = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblEmailPrompt = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnLoadQuestions = new System.Windows.Forms.Button();
            this.panelQuestions = new System.Windows.Forms.Panel();
            this.lblQuestion1 = new System.Windows.Forms.Label();
            this.txtAnswer1 = new System.Windows.Forms.TextBox();
            this.lblQuestion2 = new System.Windows.Forms.Label();
            this.txtAnswer2 = new System.Windows.Forms.TextBox();
            this.lblQuestion3 = new System.Windows.Forms.Label();
            this.txtAnswer3 = new System.Windows.Forms.TextBox();
            this.btnVerify = new System.Windows.Forms.Button();
            this.panelResetPassword = new System.Windows.Forms.Panel();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelEmail.SuspendLayout();
            this.panelQuestions.SuspendLayout();
            this.panelResetPassword.SuspendLayout();
            this.SuspendLayout();
            //
            // panelEmail
            //
            this.panelEmail.Controls.Add(this.lblTitle);
            this.panelEmail.Controls.Add(this.lblEmailPrompt);
            this.panelEmail.Controls.Add(this.txtEmail);
            this.panelEmail.Controls.Add(this.btnLoadQuestions);
            this.panelEmail.Location = new System.Drawing.Point(0, 0);
            this.panelEmail.Name = "panelEmail";
            this.panelEmail.Size = new System.Drawing.Size(500, 200);
            this.panelEmail.TabIndex = 0;
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(120, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(250, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Password Recovery";
            //
            // lblEmailPrompt
            //
            this.lblEmailPrompt.AutoSize = true;
            this.lblEmailPrompt.Location = new System.Drawing.Point(30, 70);
            this.lblEmailPrompt.Name = "lblEmailPrompt";
            this.lblEmailPrompt.Size = new System.Drawing.Size(120, 15);
            this.lblEmailPrompt.TabIndex = 1;
            this.lblEmailPrompt.Text = "Enter your email:";
            //
            // txtEmail
            //
            this.txtEmail.Location = new System.Drawing.Point(30, 90);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(440, 23);
            this.txtEmail.TabIndex = 2;
            //
            // btnLoadQuestions
            //
            this.btnLoadQuestions.Location = new System.Drawing.Point(30, 130);
            this.btnLoadQuestions.Name = "btnLoadQuestions";
            this.btnLoadQuestions.Size = new System.Drawing.Size(440, 35);
            this.btnLoadQuestions.TabIndex = 3;
            this.btnLoadQuestions.Text = "Load Security Questions";
            this.btnLoadQuestions.UseVisualStyleBackColor = true;
            this.btnLoadQuestions.Click += new System.EventHandler(this.btnLoadQuestions_Click);
            //
            // panelQuestions
            //
            this.panelQuestions.Controls.Add(this.lblQuestion1);
            this.panelQuestions.Controls.Add(this.txtAnswer1);
            this.panelQuestions.Controls.Add(this.lblQuestion2);
            this.panelQuestions.Controls.Add(this.txtAnswer2);
            this.panelQuestions.Controls.Add(this.lblQuestion3);
            this.panelQuestions.Controls.Add(this.txtAnswer3);
            this.panelQuestions.Controls.Add(this.btnVerify);
            this.panelQuestions.Location = new System.Drawing.Point(0, 0);
            this.panelQuestions.Name = "panelQuestions";
            this.panelQuestions.Size = new System.Drawing.Size(500, 300);
            this.panelQuestions.TabIndex = 1;
            this.panelQuestions.Visible = false;
            //
            // lblQuestion1
            //
            this.lblQuestion1.AutoSize = true;
            this.lblQuestion1.Location = new System.Drawing.Point(30, 30);
            this.lblQuestion1.Name = "lblQuestion1";
            this.lblQuestion1.Size = new System.Drawing.Size(70, 15);
            this.lblQuestion1.TabIndex = 0;
            this.lblQuestion1.Text = "Question 1:";
            //
            // txtAnswer1
            //
            this.txtAnswer1.Location = new System.Drawing.Point(30, 50);
            this.txtAnswer1.Name = "txtAnswer1";
            this.txtAnswer1.Size = new System.Drawing.Size(440, 23);
            this.txtAnswer1.TabIndex = 1;
            //
            // lblQuestion2
            //
            this.lblQuestion2.AutoSize = true;
            this.lblQuestion2.Location = new System.Drawing.Point(30, 90);
            this.lblQuestion2.Name = "lblQuestion2";
            this.lblQuestion2.Size = new System.Drawing.Size(70, 15);
            this.lblQuestion2.TabIndex = 2;
            this.lblQuestion2.Text = "Question 2:";
            //
            // txtAnswer2
            //
            this.txtAnswer2.Location = new System.Drawing.Point(30, 110);
            this.txtAnswer2.Name = "txtAnswer2";
            this.txtAnswer2.Size = new System.Drawing.Size(440, 23);
            this.txtAnswer2.TabIndex = 3;
            //
            // lblQuestion3
            //
            this.lblQuestion3.AutoSize = true;
            this.lblQuestion3.Location = new System.Drawing.Point(30, 150);
            this.lblQuestion3.Name = "lblQuestion3";
            this.lblQuestion3.Size = new System.Drawing.Size(70, 15);
            this.lblQuestion3.TabIndex = 4;
            this.lblQuestion3.Text = "Question 3:";
            //
            // txtAnswer3
            //
            this.txtAnswer3.Location = new System.Drawing.Point(30, 170);
            this.txtAnswer3.Name = "txtAnswer3";
            this.txtAnswer3.Size = new System.Drawing.Size(440, 23);
            this.txtAnswer3.TabIndex = 5;
            //
            // btnVerify
            //
            this.btnVerify.Location = new System.Drawing.Point(30, 220);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(440, 35);
            this.btnVerify.TabIndex = 6;
            this.btnVerify.Text = "Verify Answers";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            //
            // panelResetPassword
            //
            this.panelResetPassword.Controls.Add(this.lblNewPassword);
            this.panelResetPassword.Controls.Add(this.txtNewPassword);
            this.panelResetPassword.Controls.Add(this.lblConfirmPassword);
            this.panelResetPassword.Controls.Add(this.txtConfirmPassword);
            this.panelResetPassword.Controls.Add(this.btnResetPassword);
            this.panelResetPassword.Location = new System.Drawing.Point(0, 0);
            this.panelResetPassword.Name = "panelResetPassword";
            this.panelResetPassword.Size = new System.Drawing.Size(500, 250);
            this.panelResetPassword.TabIndex = 2;
            this.panelResetPassword.Visible = false;
            //
            // lblNewPassword
            //
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Location = new System.Drawing.Point(30, 50);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(92, 15);
            this.lblNewPassword.TabIndex = 0;
            this.lblNewPassword.Text = "New Password:";
            //
            // txtNewPassword
            //
            this.txtNewPassword.Location = new System.Drawing.Point(30, 70);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(440, 23);
            this.txtNewPassword.TabIndex = 1;
            this.txtNewPassword.UseSystemPasswordChar = true;
            //
            // lblConfirmPassword
            //
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(30, 110);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(116, 15);
            this.lblConfirmPassword.TabIndex = 2;
            this.lblConfirmPassword.Text = "Confirm Password:";
            //
            // txtConfirmPassword
            //
            this.txtConfirmPassword.Location = new System.Drawing.Point(30, 130);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(440, 23);
            this.txtConfirmPassword.TabIndex = 3;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            //
            // btnResetPassword
            //
            this.btnResetPassword.Location = new System.Drawing.Point(30, 180);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(440, 35);
            this.btnResetPassword.TabIndex = 4;
            this.btnResetPassword.Text = "Reset Password";
            this.btnResetPassword.UseVisualStyleBackColor = true;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(190, 320);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // PasswordRecoveryForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 370);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panelResetPassword);
            this.Controls.Add(this.panelQuestions);
            this.Controls.Add(this.panelEmail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PasswordRecoveryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Password Recovery";
            this.panelEmail.ResumeLayout(false);
            this.panelEmail.PerformLayout();
            this.panelQuestions.ResumeLayout(false);
            this.panelQuestions.PerformLayout();
            this.panelResetPassword.ResumeLayout(false);
            this.panelResetPassword.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelEmail;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblEmailPrompt;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnLoadQuestions;
        private System.Windows.Forms.Panel panelQuestions;
        private System.Windows.Forms.Label lblQuestion1;
        private System.Windows.Forms.TextBox txtAnswer1;
        private System.Windows.Forms.Label lblQuestion2;
        private System.Windows.Forms.TextBox txtAnswer2;
        private System.Windows.Forms.Label lblQuestion3;
        private System.Windows.Forms.TextBox txtAnswer3;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Panel panelResetPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.Button btnCancel;
    }
}
