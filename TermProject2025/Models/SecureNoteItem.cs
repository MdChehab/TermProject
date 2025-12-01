namespace TermProject2025.Models
{
    public class SecureNoteItem : VaultItem
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public SecureNoteItem()
        {
            Type = "SecureNote";
        }
    }
}
