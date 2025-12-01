using System;

namespace TermProject2025.Models
{
    public class IdentityItem : VaultItem
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PassportNumber { get; set; } = string.Empty;
        public DateTime? PassportExpiration { get; set; }
        public string LicenseNumber { get; set; } = string.Empty;
        public DateTime? LicenseExpiration { get; set; }
        public string SSN { get; set; } = string.Empty;
        public IdentityItem()
        {
            Type = "Identity";
        }
    }
}
