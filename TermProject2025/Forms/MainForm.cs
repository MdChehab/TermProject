using System;
using System.Linq;
using System.Windows.Forms;
using TermProject2025.Data;
using TermProject2025.DesignPatterns.Mediator;
using TermProject2025.DesignPatterns.Observer;
using TermProject2025.DesignPatterns.Singleton;
using TermProject2025.Models;
using TermProject2025.Services;

namespace TermProject2025.Forms
{
    public partial class MainForm : Form
    {
        private readonly VaultService _vaultService;
        private readonly ClipboardService _clipboardService;
        private readonly UIMediator _mediator;
        private System.Windows.Forms.Timer? _autoLockTimer;

        public MainForm()
        {
            InitializeComponent();
            var context = new MyPassDbContext();
            var encryptionService = new EncryptionService();
            _vaultService = new VaultService(context, encryptionService);
            _clipboardService = new ClipboardService();
            _mediator = new UIMediator();

            // Subscribe to mediator events
            _mediator.RefreshList += (s, e) => LoadVaultItems();
            _mediator.DataCopied += (s, text) => _clipboardService.CopyToClipboard(text);

            // Subscribe to notifications
            NotificationManager.Instance.NotificationAdded += OnNotificationAdded;

            InitializeAutoLock();
            LoadVaultItems();
        }

        private async void LoadVaultItems()
        {
            try
            {
                var items = await _vaultService.GetAllItemsAsync();
                lstVaultItems.Items.Clear();

                foreach (var item in items)
                {
                    string display = item switch
                    {
                        LoginItem login => $"[Login] {login.Name}",
                        CreditCardItem card => $"[Card] {card.CardholderName}",
                        IdentityItem identity => $"[Identity] {identity.FullName}",
                        SecureNoteItem note => $"[Note] {note.Title}",
                        _ => "[Unknown]"
                    };

                    lstVaultItems.Items.Add(new ListViewItem(new[] {
                        display,
                        item.Type,
                        item.UpdatedAt.ToShortDateString()
                    }) { Tag = item });
                }

                UpdateNotificationCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnNotificationAdded(object? sender, Notification notification)
        {
            UpdateNotificationCount();
        }

        private void UpdateNotificationCount()
        {
            int count = NotificationManager.Instance.GetUnreadCount();
            lblNotificationCount.Text = count > 0 ? $"Notifications: {count}" : "No notifications";
        }

        private void InitializeAutoLock()
        {
            _autoLockTimer = new System.Windows.Forms.Timer();
            _autoLockTimer.Interval = 1000; // Check every second
            _autoLockTimer.Tick += AutoLockTimer_Tick;
            _autoLockTimer.Start();

            // Hook into user activity events
            this.MouseMove += (s, e) => UserSession.Instance.UpdateActivity();
            this.KeyPress += (s, e) => UserSession.Instance.UpdateActivity();
        }

        private void AutoLockTimer_Tick(object? sender, EventArgs e)
        {
            if (UserSession.Instance.ShouldAutoLock())
            {
                LockVault();
            }
            else
            {
                var remaining = TimeSpan.FromMinutes(UserSession.Instance.AutoLockMinutes) -
                               (DateTime.Now - UserSession.Instance.LastActivity);
                lblAutoLock.Text = $"Auto-lock in: {remaining:mm\\:ss}";
            }
        }

        private void LockVault()
        {
            _autoLockTimer?.Stop();
            UserSession.Instance.Logout();
            this.Close();
            var loginForm = new LoginForm();
            loginForm.Show();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            var addItemForm = new AddEditItemForm();
            if (addItemForm.ShowDialog() == DialogResult.OK)
            {
                LoadVaultItems(); // Refresh the list
            }
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            if (lstVaultItems.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an item to edit.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = lstVaultItems.SelectedItems[0].Tag as VaultItem;
            if (item != null)
            {
                var editItemForm = new AddEditItemForm(item);
                if (editItemForm.ShowDialog() == DialogResult.OK)
                {
                    LoadVaultItems(); // Refresh the list
                }
            }
        }

        private void btnPasswordGenerator_Click(object sender, EventArgs e)
        {
            var passwordGenForm = new PasswordGeneratorForm();
            passwordGenForm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LockVault();
        }

        private void lstVaultItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstVaultItems.SelectedItems.Count > 0)
            {
                var item = lstVaultItems.SelectedItems[0].Tag as VaultItem;
                if (item != null)
                {
                    DisplayItemDetails(item);
                }
            }
        }

        private void lstVaultItems_DoubleClick(object sender, EventArgs e)
        {
            if (lstVaultItems.SelectedItems.Count > 0)
            {
                var item = lstVaultItems.SelectedItems[0].Tag as VaultItem;
                if (item != null)
                {
                    var editItemForm = new AddEditItemForm(item);
                    if (editItemForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadVaultItems(); // Refresh the list
                    }
                }
            }
        }

        private async void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (lstVaultItems.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an item to delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var item = lstVaultItems.SelectedItems[0].Tag as VaultItem;
            if (item != null)
            {
                var result = MessageBox.Show(
                    $"Are you sure you want to delete this item?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    bool success = await _vaultService.DeleteItemAsync(item.Id);
                    if (success)
                    {
                        MessageBox.Show("Item deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadVaultItems(); // Refresh the list
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DisplayItemDetails(VaultItem item)
        {
            panelDetails.Controls.Clear();
            int yPos = 10;

            // Add header info
            AddLabel($"Type: {item.Type}", ref yPos, true);
            AddLabel($"Created: {item.CreatedAt}", ref yPos);
            AddLabel($"Updated: {item.UpdatedAt}", ref yPos);
            yPos += 10;

            switch (item)
            {
                case LoginItem login:
                    AddLabel("Name:", ref yPos, true);
                    AddTextField(login.Name, ref yPos);

                    AddLabel("Username:", ref yPos, true);
                    AddFieldWithCopy(login.Username, ref yPos, false);

                    AddLabel("Password:", ref yPos, true);
                    AddFieldWithCopy(login.Password, ref yPos, true);

                    AddLabel("URL:", ref yPos, true);
                    AddFieldWithCopy(login.Url, ref yPos, false);

                    if (!string.IsNullOrEmpty(login.Notes))
                    {
                        AddLabel("Notes:", ref yPos, true);
                        AddTextField(login.Notes, ref yPos);
                    }
                    break;

                case CreditCardItem card:
                    AddLabel("Cardholder Name:", ref yPos, true);
                    AddTextField(card.CardholderName, ref yPos);

                    AddLabel("Card Number:", ref yPos, true);
                    AddFieldWithCopy(card.CardNumber, ref yPos, true);

                    AddLabel("Expiration Date:", ref yPos, true);
                    AddTextField(card.ExpirationDate.ToString("MM/yyyy"), ref yPos);

                    AddLabel("CVV:", ref yPos, true);
                    AddFieldWithCopy(card.CVV, ref yPos, true);

                    if (!string.IsNullOrEmpty(card.BillingAddress))
                    {
                        AddLabel("Billing Address:", ref yPos, true);
                        AddTextField(card.BillingAddress, ref yPos);
                    }
                    break;

                case IdentityItem identity:
                    AddLabel("Full Name:", ref yPos, true);
                    AddTextField(identity.FullName, ref yPos);

                    AddLabel("Email:", ref yPos, true);
                    AddFieldWithCopy(identity.Email, ref yPos, false);

                    AddLabel("Phone:", ref yPos, true);
                    AddFieldWithCopy(identity.Phone, ref yPos, false);

                    if (!string.IsNullOrEmpty(identity.Address))
                    {
                        AddLabel("Address:", ref yPos, true);
                        AddTextField(identity.Address, ref yPos);
                    }

                    if (!string.IsNullOrEmpty(identity.SSN))
                    {
                        AddLabel("SSN:", ref yPos, true);
                        AddFieldWithCopy(identity.SSN, ref yPos, true);
                    }

                    if (!string.IsNullOrEmpty(identity.PassportNumber))
                    {
                        AddLabel("Passport Number:", ref yPos, true);
                        AddFieldWithCopy(identity.PassportNumber, ref yPos, true);
                    }

                    if (!string.IsNullOrEmpty(identity.LicenseNumber))
                    {
                        AddLabel("License Number:", ref yPos, true);
                        AddFieldWithCopy(identity.LicenseNumber, ref yPos, true);
                    }
                    break;

                case SecureNoteItem note:
                    AddLabel("Title:", ref yPos, true);
                    AddTextField(note.Title, ref yPos);

                    AddLabel("Content:", ref yPos, true);
                    AddTextField(note.Content, ref yPos, true);
                    break;
            }
        }

        private void AddLabel(string text, ref int yPos, bool bold = false)
        {
            var label = new Label
            {
                Text = text,
                Location = new System.Drawing.Point(10, yPos),
                AutoSize = true,
                Font = bold ? new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold) : new System.Drawing.Font("Segoe UI", 9F)
            };
            panelDetails.Controls.Add(label);
            yPos += 25;
        }

        private void AddTextField(string text, ref int yPos, bool multiline = false)
        {
            var textBox = new TextBox
            {
                Text = text,
                Location = new System.Drawing.Point(10, yPos),
                Width = 550,
                ReadOnly = true,
                BackColor = System.Drawing.SystemColors.Window,
                Multiline = multiline,
                Height = multiline ? 80 : 23,
                ScrollBars = multiline ? ScrollBars.Vertical : ScrollBars.None
            };
            panelDetails.Controls.Add(textBox);
            yPos += multiline ? 90 : 30;
        }

        private void AddFieldWithCopy(string value, ref int yPos, bool isSensitive)
        {
            var textBox = new TextBox
            {
                Text = isSensitive ? "••••••••••••" : value,
                Location = new System.Drawing.Point(10, yPos),
                Width = 350,
                ReadOnly = true,
                BackColor = System.Drawing.SystemColors.Window,
                Tag = new { Value = value, IsMasked = isSensitive }
            };

            var btnToggle = new Button
            {
                Text = isSensitive ? "Show" : "",
                Location = new System.Drawing.Point(365, yPos - 1),
                Width = 60,
                Height = 25,
                Visible = isSensitive
            };

            var btnCopy = new Button
            {
                Text = "Copy",
                Location = new System.Drawing.Point(isSensitive ? 430 : 365, yPos - 1),
                Width = 60,
                Height = 25
            };

            if (isSensitive)
            {
                btnToggle.Click += (s, e) =>
                {
                    var tag = (dynamic)textBox.Tag;
                    bool currentlyMasked = tag.IsMasked;

                    if (currentlyMasked)
                    {
                        textBox.Text = tag.Value;
                        btnToggle.Text = "Hide";
                        textBox.Tag = new { tag.Value, IsMasked = false };
                    }
                    else
                    {
                        textBox.Text = "••••••••••••";
                        btnToggle.Text = "Show";
                        textBox.Tag = new { tag.Value, IsMasked = true };
                    }
                };
            }

            btnCopy.Click += (s, e) =>
            {
                var tag = (dynamic)textBox.Tag;
                _clipboardService.CopyToClipboard(tag.Value, isSensitive);
                MessageBox.Show($"Copied to clipboard!{(isSensitive ? " Will auto-clear in 5 minutes." : "")}",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            panelDetails.Controls.Add(textBox);
            panelDetails.Controls.Add(btnToggle);
            panelDetails.Controls.Add(btnCopy);

            yPos += 35;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _autoLockTimer?.Stop();
            _autoLockTimer?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
