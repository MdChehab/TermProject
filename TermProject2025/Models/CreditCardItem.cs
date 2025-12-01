using System;

namespace TermProject2025.Models
{
    public class CreditCardItem : VaultItem
    {
        public string CardholderName { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty;
        public DateTime ExpirationDate { get; set; }
        public string CVV { get; set; } = string.Empty;
        public string BillingAddress { get; set; } = string.Empty;
        public CreditCardItem()
        {
            Type = "CreditCard";
        }
    }
}
