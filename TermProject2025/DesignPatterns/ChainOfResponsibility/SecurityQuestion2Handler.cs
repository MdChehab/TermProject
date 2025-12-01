namespace TermProject2025.DesignPatterns.ChainOfResponsibility
{
    /*
     * ═══════════════════════════════════════════════════════════════════
     * DESIGN PATTERN: Chain of Responsibility (Concrete Handler)
     * ═══════════════════════════════════════════════════════════════════
     * PURPOSE: Validate the second security question
     *
     * PATTERN MAPPING:
     * - SecurityQuestion2Handler → ConcreteHandler
     * - RecoveryHandler → Handler
     *
     * IMPLEMENTATION NOTES:
     * - Validates the second security question answer
     * - Passes to next handler if validation succeeds
     * - Returns false if validation fails (breaks the chain)
     * ═══════════════════════════════════════════════════════════════════
     */
    public class SecurityQuestion2Handler : RecoveryHandler
    {
        public override bool Handle(string userAnswer, string storedAnswerHash)
        {
            // Verify this question's answer
            if (!VerifyAnswer(userAnswer, storedAnswerHash))
            {
                return false; // Second question failed, stop the chain
            }

            // Second question passed, continue to next handler if exists
            if (_nextHandler != null)
            {
                return true; // Indicate this handler passed
            }

            // No more handlers (shouldn't happen with proper setup)
            return true;
        }
    }
}
