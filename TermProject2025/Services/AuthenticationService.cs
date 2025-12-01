using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TermProject2025.Data;
using TermProject2025.DesignPatterns.Singleton;
using TermProject2025.Models;

namespace TermProject2025.Services
{
    public class AuthenticationService
    {
        private readonly MyPassDbContext _context;
        private readonly EncryptionService _encryptionService;

        public AuthenticationService(MyPassDbContext context, EncryptionService encryptionService)
        {
            _context = context;
            _encryptionService = encryptionService;
        }

        #region Registration
        public async Task<bool> RegisterAsync(string email, string masterPassword,
            string question1, string answer1,
            string question2, string answer2,
            string question3, string answer3)
        {
            // Check if email already exists
            if (await _context.Users.AnyAsync(u => u.Email == email))
                return false;

            // Generate salt for key derivation
            var salt = _encryptionService.GenerateSalt();
            var saltBase64 = _encryptionService.BytesToBase64(salt);

            // Hash the master password
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(masterPassword, workFactor: 12);

            // Create user
            var user = new User
            {
                Email = email,
                PasswordHash = passwordHash,
                Salt = saltBase64,
                CreatedAt = DateTime.Now
            };

            // Hash security question answers
            var securityQuestions = new[]
            {
                new SecurityQuestion { Question = question1, AnswerHash = BCrypt.Net.BCrypt.HashPassword(answer1.ToLower()), QuestionNumber = 1 },
                new SecurityQuestion { Question = question2, AnswerHash = BCrypt.Net.BCrypt.HashPassword(answer2.ToLower()), QuestionNumber = 2 },
                new SecurityQuestion { Question = question3, AnswerHash = BCrypt.Net.BCrypt.HashPassword(answer3.ToLower()), QuestionNumber = 3 }
            };

            user.SecurityQuestions.AddRange(securityQuestions);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return true;
        }

        #endregion

        #region Authentication
        public async Task<bool> LoginAsync(string email, string masterPassword)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
                return false;

            // Verify password
            if (!BCrypt.Net.BCrypt.Verify(masterPassword, user.PasswordHash))
                return false;

            // Derive master key
            var salt = _encryptionService.Base64ToBytes(user.Salt);
            var masterKey = _encryptionService.DeriveKey(masterPassword, salt);

            // Start session
            UserSession.Instance.Login(user.Id, user.Email, masterKey);

            return true;
        }
        public void Logout()
        {
            UserSession.Instance.Logout();
        }

        #endregion

        #region Password Recovery
        public async Task<SecurityQuestion[]?> GetSecurityQuestionsAsync(string email)
        {
            var user = await _context.Users
                .Include(u => u.SecurityQuestions)
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
                return null;

            return user.SecurityQuestions.OrderBy(sq => sq.QuestionNumber).ToArray();
        }
        public async Task<bool> ResetPasswordAsync(string email, string newPassword)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
                return false;

            // Hash new password
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword, workFactor: 12);

            // Optionally generate new salt (this would invalidate existing vault data)
            // For this implementation, we'll keep the same salt

            await _context.SaveChangesAsync();
            return true;
        }

        #endregion
    }
}
