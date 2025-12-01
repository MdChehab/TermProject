namespace TermProject2025.DesignPatterns.Mediator
{
    /*
     * ═══════════════════════════════════════════════════════════════════
     * DESIGN PATTERN: Mediator
     * ═══════════════════════════════════════════════════════════════════
     * PURPOSE: Manage communication between UI components
     *
     * PATTERN MAPPING:
     * - IMediator → Mediator interface
     *
     * IMPLEMENTATION NOTES:
     * - Defines the interface for communicating with colleague components
     * - Centralizes complex communication and control logic
     * - Reduces coupling between components
     * ═══════════════════════════════════════════════════════════════════
     */
    public interface IMediator
    {
        void Notify(object sender, string eventName, object? data = null);
    }
}
