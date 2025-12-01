using System;
using System.Windows.Forms;
using TermProject2025.Data;
using TermProject2025.DesignPatterns.ChainOfResponsibility;
using TermProject2025.Services;

namespace TermProject2025.Forms
{
    public partial class PasswordRecoveryForm : Form
    {
        private readonly AuthenticationService _authService;
        private Models.SecurityQuestion[]? _securityQuestions;
        private string? _userEmail;

        public PasswordRecoveryForm()
        {
            InitializeComponent();
            var context = new MyPassDbContext();
            var encryptionService = new EncryptionService();
            _authService = new AuthenticationService(context, encryptionService);
        }

        private async void btnLoadQuestions_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please enter your email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _securityQuestions = await _authService.GetSecurityQuestionsAsync(email);

            if (_securityQuestions == null || _securityQuestions.Length != 3)
            {
                MessageBox.Show("Email not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _userEmail = email;

            // Display questions
            lblQuestion1.Text = _securityQuestions[0].Question;
            lblQuestion2.Text = _securityQuestions[1].Question;
            lblQuestion3.Text = _securityQuestions[2].Question;

            panelQuestions.Visible = true;
            panelEmail.Visible = false;
        }

        private async void btnVerify_Click(object sender, EventArgs e)
        {
            if (_securityQuestions == null || string.IsNullOrEmpty(_userEmail))
                return;

            // Create Chain of Responsibility
            var handler1 = new SecurityQuestion1Handler();
            var handler2 = new SecurityQuestion2Handler();
            var handler3 = new SecurityQuestion3Handler();

            handler1.SetNext(handler2);
            handler2.SetNext(handler3);

            // Validate all three questions
            bool q1Valid = handler1.Handle(txtAnswer1.Text.Trim().ToLower(), _securityQuestions[0].AnswerHash);
            bool q2Valid = handler2.Handle(txtAnswer2.Text.Trim().ToLower(), _securityQuestions[1].AnswerHash);
            bool q3Valid = handler3.Handle(txtAnswer3.Text.Trim().ToLower(), _securityQuestions[2].AnswerHash);

            if (q1Valid && q2Valid && q3Valid)
            {
                // All questions verified - show password reset
                panelQuestions.Visible = false;
                panelResetPassword.Visible = true;
            }
            else
            {
                MessageBox.Show("One or more answers are incorrect. Please try again.", "Verification Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAnswer1.Clear();
                txtAnswer2.Clear();
                txtAnswer3.Clear();
            }
        }

        private async void btnResetPassword_Click(object sender, EventArgs e)
        {
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPassword.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool success = await _authService.ResetPasswordAsync(_userEmail!, newPassword);

            if (success)
            {
                MessageBox.Show("Password reset successfully! You can now login with your new password.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to reset password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
