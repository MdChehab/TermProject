namespace TermProject2025.DesignPatterns.ChainOfResponsibility
{
    /*
     * ═══════════════════════════════════════════════════════════════════
     * DESIGN PATTERN: Chain of Responsibility
     * ═══════════════════════════════════════════════════════════════════
     * PURPOSE: Process password recovery through a chain of security questions
     *
     * PATTERN MAPPING:
     * - RecoveryHandler → Handler (abstract class)
     *
     * IMPLEMENTATION NOTES:
     * - Abstract handler class for security question validation
     * - Each handler validates one question before passing to next
     * - Chain only succeeds if all three questions are answered correctly
     * ═══════════════════════════════════════════════════════════════════
     */
    public abstract class RecoveryHandler
    {
        protected RecoveryHandler? _nextHandler;
        public void SetNext(RecoveryHandler handler)
        {
            _nextHandler = handler;
        }
        public abstract bool Handle(string userAnswer, string storedAnswerHash);
        protected bool VerifyAnswer(string answer, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(answer, hash);
        }
    }
}
