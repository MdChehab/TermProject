namespace TermProject2025.DesignPatterns.ChainOfResponsibility
{
    /*
     * ═══════════════════════════════════════════════════════════════════
     * DESIGN PATTERN: Chain of Responsibility (Concrete Handler)
     * ═══════════════════════════════════════════════════════════════════
     * PURPOSE: Validate the third (final) security question
     *
     * PATTERN MAPPING:
     * - SecurityQuestion3Handler → ConcreteHandler
     * - RecoveryHandler → Handler
     *
     * IMPLEMENTATION NOTES:
     * - Validates the third and final security question answer
     * - Returns true only if all three questions were answered correctly
     * - End of the chain - no more handlers after this
     * ═══════════════════════════════════════════════════════════════════
     */
    public class SecurityQuestion3Handler : RecoveryHandler
    {
        public override bool Handle(string userAnswer, string storedAnswerHash)
        {
            // Verify this question's answer
            if (!VerifyAnswer(userAnswer, storedAnswerHash))
            {
                return false; // Third question failed
            }

            // Third question passed - all three questions verified!
            // No next handler, this is the end of the chain
            return true;
        }
    }
}
