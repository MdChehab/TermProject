using System.Text.RegularExpressions;
using TermProject2025.Models;

namespace TermProject2025.DesignPatterns.Observer
{
    /*
     * ═══════════════════════════════════════════════════════════════════
     * DESIGN PATTERN: Observer (Concrete Observer)
     * ═══════════════════════════════════════════════════════════════════
     * PURPOSE: Detect weak passwords in login vault items
     *
     * PATTERN MAPPING:
     * - WeakPasswordDetector → ConcreteObserver
     * - IObserver → Observer interface
     *
     * IMPLEMENTATION NOTES:
     * - Analyzes password strength when login items are created/modified
     * - Checks for length, complexity, and common patterns
     * - Forwards weak password warnings to NotificationManager
     * ═══════════════════════════════════════════════════════════════════
     */
    public class WeakPasswordDetector : IObserver
    {
        public void CheckPassword(VaultItem item)
        {
            if (item is LoginItem login && !string.IsNullOrEmpty(login.Password))
            {
                var strength = CalculatePasswordStrength(login.Password);
                if (strength == PasswordStrength.Weak)
                {
                    Update($"Weak password detected for {login.Name}. Consider using a stronger password.",
                           NotificationType.WeakPassword);
                }
            }
        }

        #region Private Methods

        private PasswordStrength CalculatePasswordStrength(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return PasswordStrength.Weak;

            int score = 0;

            // Length check
            if (password.Length >= 8) score++;
            if (password.Length >= 12) score++;
            if (password.Length >= 16) score++;

            // Complexity checks
            if (Regex.IsMatch(password, @"[a-z]")) score++; // Lowercase
            if (Regex.IsMatch(password, @"[A-Z]")) score++; // Uppercase
            if (Regex.IsMatch(password, @"[0-9]")) score++; // Numbers
            if (Regex.IsMatch(password, @"[^a-zA-Z0-9]")) score++; // Special chars

            // Common patterns (reduce score)
            if (Regex.IsMatch(password, @"^(12345|password|qwerty)", RegexOptions.IgnoreCase))
                score -= 3;

            if (score <= 3)
                return PasswordStrength.Weak;
            else if (score <= 5)
                return PasswordStrength.Medium;
            else
                return PasswordStrength.Strong;
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
    public enum PasswordStrength
    {
        Weak,
        Medium,
        Strong
    }
}
