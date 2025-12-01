using System;
using System.Windows.Forms;
using TermProject2025.Data;
using TermProject2025.Services;

namespace TermProject2025.Forms
{
    public partial class RegisterForm : Form
    {
        private readonly AuthenticationService _authService;
        private readonly PasswordStrengthService _passwordStrength;

        public RegisterForm()
        {
            InitializeComponent();
            var context = new MyPassDbContext();
            var encryptionService = new EncryptionService();
            _authService = new AuthenticationService(context, encryptionService);
            _passwordStrength = new PasswordStrengthService();

            PopulateSecurityQuestions();
        }

        private void PopulateSecurityQuestions()
        {
            string[] questions = new[]
            {
                "What was the name of your first pet?",
                "In what city were you born?",
                "What is your mother's maiden name?",
                "What was your first car?",
                "What elementary school did you attend?",
                "What is the name of your favorite teacher?",
                "What street did you grow up on?",
                "What is your favorite movie?",
                "What is your favorite book?"
            };

            cmbQuestion1.Items.AddRange(questions);
            cmbQuestion2.Items.AddRange(questions);
            cmbQuestion3.Items.AddRange(questions);

            cmbQuestion1.SelectedIndex = 0;
            cmbQuestion2.SelectedIndex = 1;
            cmbQuestion3.SelectedIndex = 2;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
            int strength = _passwordStrength.GetStrengthPercentage(password);
            string description = _passwordStrength.GetStrengthDescription(password);

            progressBarStrength.Value = strength;
            lblStrength.Text = description;

            if (strength <= 33)
                progressBarStrength.ForeColor = System.Drawing.Color.Red;
            else if (strength <= 66)
                progressBarStrength.ForeColor = System.Drawing.Color.Orange;
            else
                progressBarStrength.ForeColor = System.Drawing.Color.Green;
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrEmpty(email) || !email.Contains("@"))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(password) || password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtAnswer1.Text) || string.IsNullOrEmpty(txtAnswer2.Text) || string.IsNullOrEmpty(txtAnswer3.Text))
            {
                MessageBox.Show("Please answer all three security questions.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnRegister.Enabled = false;

            try
            {
                bool success = await _authService.RegisterAsync(
                    email, password,
                    cmbQuestion1.Text, txtAnswer1.Text,
                    cmbQuestion2.Text, txtAnswer2.Text,
                    cmbQuestion3.Text, txtAnswer3.Text
                );

                if (success)
                {
                    MessageBox.Show("Account created successfully! You can now login.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Email address already exists. Please use a different email.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Registration error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnRegister.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
