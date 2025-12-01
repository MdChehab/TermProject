using System;
using TermProject2025.Models;

namespace TermProject2025.DesignPatterns.Observer
{
    /*
     * ═══════════════════════════════════════════════════════════════════
     * DESIGN PATTERN: Observer (Concrete Observer)
     * ═══════════════════════════════════════════════════════════════════
     * PURPOSE: Check for expiring documents and credit cards
     *
     * PATTERN MAPPING:
     * - ExpirationChecker → ConcreteObserver
     * - IObserver → Observer interface
     *
     * IMPLEMENTATION NOTES:
     * - Checks for credit card expirations (within 30 days)
     * - Checks for passport expirations (within 90 days)
     * - Checks for license expirations (within 90 days)
     * - Forwards notifications to NotificationManager
     * ═══════════════════════════════════════════════════════════════════
     */
    public class ExpirationChecker : IObserver
    {
        public void CheckExpirations(VaultItem item)
        {
            if (item is CreditCardItem creditCard)
            {
                CheckCreditCardExpiration(creditCard);
            }
            else if (item is IdentityItem identity)
            {
                CheckPassportExpiration(identity);
                CheckLicenseExpiration(identity);
            }
        }

        #region Private Methods

        private void CheckCreditCardExpiration(CreditCardItem creditCard)
        {
            var daysUntilExpiration = (creditCard.ExpirationDate - DateTime.Now).Days;

            if (daysUntilExpiration <= 30 && daysUntilExpiration > 0)
            {
                Update($"Credit card for {creditCard.CardholderName} expires in {daysUntilExpiration} days",
                       NotificationType.CreditCardExpiration);
            }
            else if (daysUntilExpiration <= 0)
            {
                Update($"Credit card for {creditCard.CardholderName} has expired",
                       NotificationType.CreditCardExpiration);
            }
        }

        private void CheckPassportExpiration(IdentityItem identity)
        {
            if (identity.PassportExpiration.HasValue)
            {
                var daysUntilExpiration = (identity.PassportExpiration.Value - DateTime.Now).Days;

                if (daysUntilExpiration <= 90 && daysUntilExpiration > 0)
                {
                    Update($"Passport for {identity.FullName} expires in {daysUntilExpiration} days",
                           NotificationType.PassportExpiration);
                }
                else if (daysUntilExpiration <= 0)
                {
                    Update($"Passport for {identity.FullName} has expired",
                           NotificationType.PassportExpiration);
                }
            }
        }

        private void CheckLicenseExpiration(IdentityItem identity)
        {
            if (identity.LicenseExpiration.HasValue)
            {
                var daysUntilExpiration = (identity.LicenseExpiration.Value - DateTime.Now).Days;

                if (daysUntilExpiration <= 90 && daysUntilExpiration > 0)
                {
                    Update($"License for {identity.FullName} expires in {daysUntilExpiration} days",
                           NotificationType.LicenseExpiration);
                }
                else if (daysUntilExpiration <= 0)
                {
                    Update($"License for {identity.FullName} has expired",
                           NotificationType.LicenseExpiration);
                }
            }
        }

        #endregion

        #region IObserver Implementation
        public void Update(string message, NotificationType type)
        {
            // Forward to NotificationManager
            NotificationManager.Instance.Update(message, type);
        }

        #endregion
    }
}
