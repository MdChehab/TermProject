using System;
using System.Collections.Generic;

namespace TermProject2025.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Salt { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public List<SecurityQuestion> SecurityQuestions { get; set; } = new List<SecurityQuestion>();
        public List<VaultItem> VaultItems { get; set; } = new List<VaultItem>();
    }
}
