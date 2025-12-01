using System;
using System.Windows.Forms;
using TermProject2025.Data;
using TermProject2025.Models;
using TermProject2025.Services;

namespace TermProject2025.Forms
{
    public partial class AddEditItemForm : Form
    {
        private readonly VaultService _vaultService;
        private readonly VaultItem? _existingItem;
        private readonly bool _isEditMode;

        public AddEditItemForm(VaultItem? itemToEdit = null)
        {
            InitializeComponent();
            var context = new MyPassDbContext();
            var encryptionService = new EncryptionService();
            _vaultService = new VaultService(context, encryptionService);

            _existingItem = itemToEdit;
            _isEditMode = itemToEdit != null;

            // Populate item type dropdown
            cmbItemType.Items.AddRange(new[] { "Login", "Credit Card", "Identity", "Secure Note" });
            cmbItemType.SelectedIndex = 0;

            if (_isEditMode && _existingItem != null)
            {
                this.Text = "Edit Vault Item";
                btnSave.Text = "Update";
                LoadExistingItem();
            }
            else
            {
                this.Text = "Add Vault Item";
                btnSave.Text = "Save";
            }
        }

        private void cmbItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear all fields
            ClearAllFields();

            // Show/hide panels based on type
            string itemType = cmbItemType.SelectedItem?.ToString() ?? "Login";

            panelLogin.Visible = itemType == "Login";
            panelCreditCard.Visible = itemType == "Credit Card";
            panelIdentity.Visible = itemType == "Identity";
            panelSecureNote.Visible = itemType == "Secure Note";
        }

        private void ClearAllFields()
        {
            // Login
            txtLoginName.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtUrl.Clear();
            txtNotes.Clear();

            // Credit Card
            txtCardholderName.Clear();
            txtCardNumber.Clear();
            txtCVV.Clear();
            txtBillingAddress.Clear();
            dtpExpiration.Value = DateTime.Now.AddYears(3);

            // Identity
            txtFullName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtPassportNumber.Clear();
            txtLicenseNumber.Clear();
            txtSSN.Clear();
            dtpPassportExp.Value = DateTime.Now.AddYears(10);
            dtpLicenseExp.Value = DateTime.Now.AddYears(5);

            // Secure Note
            txtNoteTitle.Clear();
            txtNoteContent.Clear();
        }

        private void LoadExistingItem()
        {
            if (_existingItem == null) return;

            // Set type and trigger field visibility
            switch (_existingItem.Type)
            {
                case "Login":
                    cmbItemType.SelectedItem = "Login";
                    var login = _existingItem as LoginItem;
                    if (login != null)
                    {
                        txtLoginName.Text = login.Name;
                        txtUsername.Text = login.Username;
                        txtPassword.Text = login.Password;
                        txtUrl.Text = login.Url;
                        txtNotes.Text = login.Notes;
                    }
                    break;

                case "CreditCard":
                    cmbItemType.SelectedItem = "Credit Card";
                    var card = _existingItem as CreditCardItem;
                    if (card != null)
                    {
                        txtCardholderName.Text = card.CardholderName;
                        txtCardNumber.Text = card.CardNumber;
                        txtCVV.Text = card.CVV;
                        txtBillingAddress.Text = card.BillingAddress;
                        dtpExpiration.Value = card.ExpirationDate;
                    }
                    break;

                case "Identity":
                    cmbItemType.SelectedItem = "Identity";
                    var identity = _existingItem as IdentityItem;
                    if (identity != null)
                    {
                        txtFullName.Text = identity.FullName;
                        txtEmail.Text = identity.Email;
                        txtPhone.Text = identity.Phone;
                        txtAddress.Text = identity.Address;
                        txtPassportNumber.Text = identity.PassportNumber;
                        txtLicenseNumber.Text = identity.LicenseNumber;
                        txtSSN.Text = identity.SSN;
                        if (identity.PassportExpiration.HasValue)
                            dtpPassportExp.Value = identity.PassportExpiration.Value;
                        if (identity.LicenseExpiration.HasValue)
                            dtpLicenseExp.Value = identity.LicenseExpiration.Value;
                    }
                    break;

                case "SecureNote":
                    cmbItemType.SelectedItem = "Secure Note";
                    var note = _existingItem as SecureNoteItem;
                    if (note != null)
                    {
                        txtNoteTitle.Text = note.Title;
                        txtNoteContent.Text = note.Content;
                    }
                    break;
            }

            cmbItemType.Enabled = false; // Can't change type when editing
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                VaultItem item;
                string itemType = cmbItemType.SelectedItem?.ToString() ?? "Login";

                if (_isEditMode && _existingItem != null)
                {
                    item = _existingItem;
                }
                else
                {
                    item = itemType switch
                    {
                        "Login" => new LoginItem(),
                        "Credit Card" => new CreditCardItem(),
                        "Identity" => new IdentityItem(),
                        "Secure Note" => new SecureNoteItem(),
                        _ => new LoginItem()
                    };
                }

                // Populate fields based on type
                switch (itemType)
                {
                    case "Login":
                        var login = item as LoginItem;
                        if (login != null)
                        {
                            login.Name = txtLoginName.Text.Trim();
                            login.Username = txtUsername.Text.Trim();
                            login.Password = txtPassword.Text;
                            login.Url = txtUrl.Text.Trim();
                            login.Notes = txtNotes.Text.Trim();

                            if (string.IsNullOrEmpty(login.Name))
                            {
                                MessageBox.Show("Please enter a name for this login.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        break;

                    case "Credit Card":
                        var card = item as CreditCardItem;
                        if (card != null)
                        {
                            card.CardholderName = txtCardholderName.Text.Trim();
                            card.CardNumber = txtCardNumber.Text.Trim();
                            card.CVV = txtCVV.Text.Trim();
                            card.BillingAddress = txtBillingAddress.Text.Trim();
                            card.ExpirationDate = dtpExpiration.Value;

                            if (string.IsNullOrEmpty(card.CardholderName))
                            {
                                MessageBox.Show("Please enter the cardholder name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        break;

                    case "Identity":
                        var identity = item as IdentityItem;
                        if (identity != null)
                        {
                            identity.FullName = txtFullName.Text.Trim();
                            identity.Email = txtEmail.Text.Trim();
                            identity.Phone = txtPhone.Text.Trim();
                            identity.Address = txtAddress.Text.Trim();
                            identity.PassportNumber = txtPassportNumber.Text.Trim();
                            identity.LicenseNumber = txtLicenseNumber.Text.Trim();
                            identity.SSN = txtSSN.Text.Trim();
                            identity.PassportExpiration = dtpPassportExp.Value;
                            identity.LicenseExpiration = dtpLicenseExp.Value;

                            if (string.IsNullOrEmpty(identity.FullName))
                            {
                                MessageBox.Show("Please enter the full name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        break;

                    case "Secure Note":
                        var note = item as SecureNoteItem;
                        if (note != null)
                        {
                            note.Title = txtNoteTitle.Text.Trim();
                            note.Content = txtNoteContent.Text.Trim();

                            if (string.IsNullOrEmpty(note.Title))
                            {
                                MessageBox.Show("Please enter a title for this note.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        break;
                }

                btnSave.Enabled = false;
                bool success;

                if (_isEditMode)
                {
                    success = await _vaultService.UpdateItemAsync(item);
                }
                else
                {
                    success = await _vaultService.AddItemAsync(item);
                }

                if (success)
                {
                    MessageBox.Show(_isEditMode ? "Item updated successfully!" : "Item added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to save item. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }

        private void btnGeneratePassword_Click(object sender, EventArgs e)
        {
            var passwordGenForm = new PasswordGeneratorForm();
            if (passwordGenForm.ShowDialog() == DialogResult.OK)
            {
                txtPassword.Text = passwordGenForm.GeneratedPassword;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
