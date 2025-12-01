namespace TermProject2025.Models
{
    public class LoginItem : VaultItem
    {
        public string Name { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public LoginItem()
        {
            Type = "Login";
        }
    }
}
