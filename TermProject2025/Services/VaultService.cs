using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using TermProject2025.Data;
using TermProject2025.DesignPatterns.Singleton;
using TermProject2025.DesignPatterns.Observer;
using TermProject2025.Models;

namespace TermProject2025.Services
{
    public class VaultService
    {
        private readonly MyPassDbContext _context;
        private readonly EncryptionService _encryptionService;
        private readonly ExpirationChecker _expirationChecker;
        private readonly WeakPasswordDetector _weakPasswordDetector;

        public VaultService(MyPassDbContext context, EncryptionService encryptionService)
        {
            _context = context;
            _encryptionService = encryptionService;
            _expirationChecker = new ExpirationChecker();
            _weakPasswordDetector = new WeakPasswordDetector();
        }

        public async Task<List<VaultItem>> GetAllItemsAsync()
        {
            if (!UserSession.Instance.IsAuthenticated())
                return new List<VaultItem>();

            var items = await _context.VaultItems
                .Where(vi => vi.UserId == UserSession.Instance.CurrentUserId)
                .ToListAsync();

            foreach (var item in items)
            {
                DecryptItem(item);
            }

            return items;
        }

        public async Task<VaultItem?> GetItemByIdAsync(int id)
        {
            var item = await _context.VaultItems.FindAsync(id);

            if (item != null && item.UserId == UserSession.Instance.CurrentUserId)
            {
                DecryptItem(item);
                return item;
            }

            return null;
        }

        public async Task<bool> AddItemAsync(VaultItem item)
        {
            if (!UserSession.Instance.IsAuthenticated())
                return false;

            item.UserId = UserSession.Instance.CurrentUserId;
            item.CreatedAt = DateTime.Now;
            item.UpdatedAt = DateTime.Now;

            EncryptItem(item);

            _context.VaultItems.Add(item);
            await _context.SaveChangesAsync();

            DecryptItem(item);
            item.Attach(NotificationManager.Instance);
            _expirationChecker.CheckExpirations(item);
            _weakPasswordDetector.CheckPassword(item);

            return true;
        }

        public async Task<bool> UpdateItemAsync(VaultItem item)
        {
            if (!UserSession.Instance.IsAuthenticated())
                return false;

            var existing = await _context.VaultItems.FindAsync(item.Id);
            if (existing == null || existing.UserId != UserSession.Instance.CurrentUserId)
                return false;

            item.UpdatedAt = DateTime.Now;
            EncryptItem(item);

            _context.Entry(existing).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();

            DecryptItem(item);
            item.Attach(NotificationManager.Instance);
            _expirationChecker.CheckExpirations(item);
            _weakPasswordDetector.CheckPassword(item);

            return true;
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            if (!UserSession.Instance.IsAuthenticated())
                return false;

            var item = await _context.VaultItems.FindAsync(id);
            if (item == null || item.UserId != UserSession.Instance.CurrentUserId)
                return false;

            _context.VaultItems.Remove(item);
            await _context.SaveChangesAsync();

            return true;
        }

        private void EncryptItem(VaultItem item)
        {
            var key = UserSession.Instance.MasterKey;
            if (key == null) return;

            string json = item switch
            {
                LoginItem login => JsonSerializer.Serialize(new { login.Name, login.Username, login.Password, login.Url, login.Notes }),
                CreditCardItem card => JsonSerializer.Serialize(new { card.CardholderName, card.CardNumber, card.CVV, card.ExpirationDate, card.BillingAddress }),
                IdentityItem identity => JsonSerializer.Serialize(new { identity.FullName, identity.Email, identity.Phone, identity.Address, identity.PassportNumber, identity.PassportExpiration, identity.LicenseNumber, identity.LicenseExpiration, identity.SSN }),
                SecureNoteItem note => JsonSerializer.Serialize(new { note.Title, note.Content }),
                _ => "{}"
            };

            item.EncryptedData = _encryptionService.Encrypt(json, key);
        }

        private void DecryptItem(VaultItem item)
        {
            var key = UserSession.Instance.MasterKey;
            if (key == null || string.IsNullOrEmpty(item.EncryptedData)) return;

            try
            {
                var decrypted = _encryptionService.Decrypt(item.EncryptedData, key);
                PopulateItemFromJson(item, decrypted);
            }
            catch
            {
                // Decryption failed - item remains encrypted
            }
        }

        private void PopulateItemFromJson(VaultItem item, string json)
        {
            switch (item)
            {
                case LoginItem login:
                    var loginData = JsonSerializer.Deserialize<LoginData>(json);
                    if (loginData != null)
                    {
                        login.Name = loginData.Name ?? "";
                        login.Username = loginData.Username ?? "";
                        login.Password = loginData.Password ?? "";
                        login.Url = loginData.Url ?? "";
                        login.Notes = loginData.Notes ?? "";
                    }
                    break;

                case CreditCardItem card:
                    var cardData = JsonSerializer.Deserialize<CreditCardData>(json);
                    if (cardData != null)
                    {
                        card.CardholderName = cardData.CardholderName ?? "";
                        card.CardNumber = cardData.CardNumber ?? "";
                        card.CVV = cardData.CVV ?? "";
                        card.ExpirationDate = cardData.ExpirationDate;
                        card.BillingAddress = cardData.BillingAddress ?? "";
                    }
                    break;

                case IdentityItem identity:
                    var identityData = JsonSerializer.Deserialize<IdentityData>(json);
                    if (identityData != null)
                    {
                        identity.FullName = identityData.FullName ?? "";
                        identity.Email = identityData.Email ?? "";
                        identity.Phone = identityData.Phone ?? "";
                        identity.Address = identityData.Address ?? "";
                        identity.PassportNumber = identityData.PassportNumber ?? "";
                        identity.PassportExpiration = identityData.PassportExpiration;
                        identity.LicenseNumber = identityData.LicenseNumber ?? "";
                        identity.LicenseExpiration = identityData.LicenseExpiration;
                        identity.SSN = identityData.SSN ?? "";
                    }
                    break;

                case SecureNoteItem note:
                    var noteData = JsonSerializer.Deserialize<SecureNoteData>(json);
                    if (noteData != null)
                    {
                        note.Title = noteData.Title ?? "";
                        note.Content = noteData.Content ?? "";
                    }
                    break;
            }
        }

        private class LoginData
        {
            public string? Name { get; set; }
            public string? Username { get; set; }
            public string? Password { get; set; }
            public string? Url { get; set; }
            public string? Notes { get; set; }
        }

        private class CreditCardData
        {
            public string? CardholderName { get; set; }
            public string? CardNumber { get; set; }
            public string? CVV { get; set; }
            public DateTime ExpirationDate { get; set; }
            public string? BillingAddress { get; set; }
        }

        private class IdentityData
        {
            public string? FullName { get; set; }
            public string? Email { get; set; }
            public string? Phone { get; set; }
            public string? Address { get; set; }
            public string? PassportNumber { get; set; }
            public DateTime? PassportExpiration { get; set; }
            public string? LicenseNumber { get; set; }
            public DateTime? LicenseExpiration { get; set; }
            public string? SSN { get; set; }
        }

        private class SecureNoteData
        {
            public string? Title { get; set; }
            public string? Content { get; set; }
        }
    }
}
