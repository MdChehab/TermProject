using System.Text.RegularExpressions;
using TermProject2025.DesignPatterns.Observer;

namespace TermProject2025.Services
{
    public class PasswordStrengthService
    {
        public PasswordStrength CalculateStrength(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return PasswordStrength.Weak;

            int score = 0;

            if (password.Length >= 8) score++;
            if (password.Length >= 12) score++;
            if (password.Length >= 16) score++;

            if (Regex.IsMatch(password, @"[a-z]")) score++;
            if (Regex.IsMatch(password, @"[A-Z]")) score++;
            if (Regex.IsMatch(password, @"[0-9]")) score++;
            if (Regex.IsMatch(password, @"[^a-zA-Z0-9]")) score++;

            if (Regex.IsMatch(password, @"^(12345|password|qwerty|admin|letmein)", RegexOptions.IgnoreCase))
                score -= 3;

            if (Regex.IsMatch(password, @"(abc|bcd|cde|123|234|345|456|567|678|789)", RegexOptions.IgnoreCase))
                score--;

            if (score <= 3)
                return PasswordStrength.Weak;
            else if (score <= 5)
                return PasswordStrength.Medium;
            else
                return PasswordStrength.Strong;
        }

        public int GetStrengthPercentage(string password)
        {
            var strength = CalculateStrength(password);
            return strength switch
            {
                PasswordStrength.Weak => 33,
                PasswordStrength.Medium => 66,
                PasswordStrength.Strong => 100,
                _ => 0
            };
        }

        public string GetStrengthDescription(string password)
        {
            var strength = CalculateStrength(password);
            return strength switch
            {
                PasswordStrength.Weak => "Weak - Consider using a longer password with mixed characters",
                PasswordStrength.Medium => "Medium - Add more complexity for better security",
                PasswordStrength.Strong => "Strong - Good password!",
                _ => "Very Weak"
            };
        }
    }
}
