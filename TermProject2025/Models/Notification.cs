using System;

namespace TermProject2025.Models
{
    public enum NotificationType
    {
        WeakPassword,
        CreditCardExpiration,
        PassportExpiration,
        LicenseExpiration,
        Info,
        Warning,
        Error
    }
    public class Notification
    {
        public int Id { get; set; }
        public string Message { get; set; } = string.Empty;
        public NotificationType Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; }
    }
}
