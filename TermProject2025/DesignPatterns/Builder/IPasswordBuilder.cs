namespace TermProject2025.DesignPatterns.Builder
{
    /*
     * ═══════════════════════════════════════════════════════════════════
     * DESIGN PATTERN: Builder
     * ═══════════════════════════════════════════════════════════════════
     * PURPOSE: Build complex password objects with configurable requirements
     *
     * PATTERN MAPPING:
     * - IPasswordBuilder → Builder interface
     *
     * IMPLEMENTATION NOTES:
     * - Defines fluent interface for password construction
     * - Allows method chaining for easy configuration
     * - Returns string (password) as the final product
     * ═══════════════════════════════════════════════════════════════════
     */
    public interface IPasswordBuilder
    {
        IPasswordBuilder SetLength(int length);
        IPasswordBuilder IncludeUppercase(bool include);
        IPasswordBuilder IncludeLowercase(bool include);
        IPasswordBuilder IncludeNumbers(bool include);
        IPasswordBuilder IncludeSpecialCharacters(bool include);
        string Build();
    }
}
