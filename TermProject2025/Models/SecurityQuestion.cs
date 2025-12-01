using System;

namespace TermProject2025.Models
{
    public class SecurityQuestion
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Question { get; set; } = string.Empty;
        public string AnswerHash { get; set; } = string.Empty;
        public int QuestionNumber { get; set; }
        public User? User { get; set; }
    }
}
