using System;
using System.Windows.Forms;
using TermProject2025.DesignPatterns.Builder;

namespace TermProject2025.Forms
{
    public partial class PasswordGeneratorForm : Form
    {
        private readonly PasswordDirector _director;
        private string _generatedPassword = string.Empty;

        public string GeneratedPassword => _generatedPassword;

        public PasswordGeneratorForm()
        {
            InitializeComponent();
            _director = new PasswordDirector();
        }

        private void trackBarLength_ValueChanged(object sender, EventArgs e)
        {
            lblLength.Text = trackBarLength.Value.ToString();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                var builder = new PasswordBuilder();

                _generatedPassword = builder
                    .SetLength(trackBarLength.Value)
                    .IncludeUppercase(chkUppercase.Checked)
                    .IncludeLowercase(chkLowercase.Checked)
                    .IncludeNumbers(chkNumbers.Checked)
                    .IncludeSpecialCharacters(chkSpecial.Checked)
                    .Build();

                txtPassword.Text = _generatedPassword;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Generation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPresetStrong_Click(object sender, EventArgs e)
        {
            var builder = new PasswordBuilder();
            _generatedPassword = _director.CreateStrongPassword(builder);
            txtPassword.Text = _generatedPassword;
        }

        private void btnPresetMedium_Click(object sender, EventArgs e)
        {
            var builder = new PasswordBuilder();
            _generatedPassword = _director.CreateMediumPassword(builder);
            txtPassword.Text = _generatedPassword;
        }

        private void btnPresetPIN_Click(object sender, EventArgs e)
        {
            var builder = new PasswordBuilder();
            _generatedPassword = _director.CreatePIN(builder);
            txtPassword.Text = _generatedPassword;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_generatedPassword))
            {
                Clipboard.SetText(_generatedPassword);
                MessageBox.Show("Password copied to clipboard!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUsePassword_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_generatedPassword))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
