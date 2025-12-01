using System;
using System.Windows.Forms;
using TermProject2025.Data;
using TermProject2025.Services;

namespace TermProject2025.Forms
{
    public partial class LoginForm : Form
    {
        private readonly AuthenticationService _authService;

        public LoginForm()
        {
            InitializeComponent();
            var context = new MyPassDbContext();
            var encryptionService = new EncryptionService();
            _authService = new AuthenticationService(context, encryptionService);
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblError.Text = "Please enter both email and password.";
                lblError.Visible = true;
                return;
            }

            btnLogin.Enabled = false;
            lblError.Visible = false;

            try
            {
                bool success = await _authService.LoginAsync(email, password);

                if (success)
                {
                    var mainForm = new MainForm();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    lblError.Text = "Invalid email or password.";
                    lblError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = $"Login error: {ex.Message}";
                lblError.Visible = true;
            }
            finally
            {
                btnLogin.Enabled = true;
            }
        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        private void linkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var recoveryForm = new PasswordRecoveryForm();
            recoveryForm.ShowDialog();
        }
    }
}
