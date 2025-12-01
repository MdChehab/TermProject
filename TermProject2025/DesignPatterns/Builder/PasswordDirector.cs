namespace TermProject2025.DesignPatterns.Builder
{
    /*
     * ═══════════════════════════════════════════════════════════════════
     * DESIGN PATTERN: Builder (Director)
     * ═══════════════════════════════════════════════════════════════════
     * PURPOSE: Provide preset configurations for password generation
     *
     * PATTERN MAPPING:
     * - PasswordDirector → Director
     * - IPasswordBuilder → Builder interface
     *
     * IMPLEMENTATION NOTES:
     * - Encapsulates common password construction sequences
     * - Provides convenient preset methods (Strong, Medium, PIN)
     * - Simplifies password creation for common use cases
     * ═══════════════════════════════════════════════════════════════════
     */
    public class PasswordDirector
    {
        public string CreateStrongPassword(IPasswordBuilder builder)
        {
            return builder
                .SetLength(20)
                .IncludeUppercase(true)
                .IncludeLowercase(true)
                .IncludeNumbers(true)
                .IncludeSpecialCharacters(true)
                .Build();
        }
        public string CreateMediumPassword(IPasswordBuilder builder)
        {
            return builder
                .SetLength(12)
                .IncludeUppercase(true)
                .IncludeLowercase(true)
                .IncludeNumbers(true)
                .IncludeSpecialCharacters(false)
                .Build();
        }
        public string CreatePIN(IPasswordBuilder builder)
        {
            return builder
                .SetLength(8)
                .IncludeUppercase(false)
                .IncludeLowercase(false)
                .IncludeNumbers(true)
                .IncludeSpecialCharacters(false)
                .Build();
        }
        public string CreateMemorablePassword(IPasswordBuilder builder)
        {
            return builder
                .SetLength(12)
                .IncludeUppercase(false)
                .IncludeLowercase(true)
                .IncludeNumbers(true)
                .IncludeSpecialCharacters(false)
                .Build();
        }
    }
}
