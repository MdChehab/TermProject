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
            txtDetails.Clear();
            txtDetails.AppendText($"Type: {item.Type}\r\n");
            txtDetails.AppendText($"Created: {item.CreatedAt}\r\n");
            txtDetails.AppendText($"Updated: {item.UpdatedAt}\r\n\r\n");

            switch (item)
            {
                case LoginItem login:
                    txtDetails.AppendText($"Name: {login.Name}\r\n");
                    txtDetails.AppendText($"Username: {login.Username}\r\n");
                    txtDetails.AppendText($"Password: ••••••••\r\n");
                    txtDetails.AppendText($"URL: {login.Url}\r\n");
                    txtDetails.AppendText($"Notes: {login.Notes}\r\n");
                    break;
                case CreditCardItem card:
                    txtDetails.AppendText($"Cardholder: {card.CardholderName}\r\n");
                    txtDetails.AppendText($"Card Number: ••••••••\r\n");
                    txtDetails.AppendText($"Expiration: {card.ExpirationDate.ToShortDateString()}\r\n");
                    txtDetails.AppendText($"CVV: •••\r\n");
                    break;
                case IdentityItem identity:
                    txtDetails.AppendText($"Name: {identity.FullName}\r\n");
                    txtDetails.AppendText($"Email: {identity.Email}\r\n");
                    txtDetails.AppendText($"Phone: {identity.Phone}\r\n");
                    break;
                case SecureNoteItem note:
                    txtDetails.AppendText($"Title: {note.Title}\r\n");
                    txtDetails.AppendText($"Content: {note.Content}\r\n");
                    break;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _autoLockTimer?.Stop();
            _autoLockTimer?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
