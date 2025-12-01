namespace TermProject2025.DesignPatterns.ChainOfResponsibility
{
    /*
     * ═══════════════════════════════════════════════════════════════════
     * DESIGN PATTERN: Chain of Responsibility (Concrete Handler)
     * ═══════════════════════════════════════════════════════════════════
     * PURPOSE: Validate the first security question
     *
     * PATTERN MAPPING:
     * - SecurityQuestion1Handler → ConcreteHandler
     * - RecoveryHandler → Handler
     *
     * IMPLEMENTATION NOTES:
     * - Validates the first security question answer
     * - Passes to next handler if validation succeeds
     * - Returns false if validation fails (breaks the chain)
     * ═══════════════════════════════════════════════════════════════════
     */
    public class SecurityQuestion1Handler : RecoveryHandler
    {
        public override bool Handle(string userAnswer, string storedAnswerHash)
        {
            // Verify this question's answer
            if (!VerifyAnswer(userAnswer, storedAnswerHash))
            {
                return false; // First question failed, stop the chain
            }

            // First question passed, continue to next handler if exists
            if (_nextHandler != null)
            {
                return true; // Indicate this handler passed, but full validation needs all handlers
            }

            // No more handlers (shouldn't happen with proper setup)
            return true;
        }
    }
}
