using TermProject2025.Models;

namespace TermProject2025.DesignPatterns.Observer
{
    /*
     * ═══════════════════════════════════════════════════════════════════
     * DESIGN PATTERN: Observer
     * ═══════════════════════════════════════════════════════════════════
     * PURPOSE: Define the Observer interface for receiving notifications
     *
     * PATTERN MAPPING:
     * - IObserver → Observer interface
     *
     * IMPLEMENTATION NOTES:
     * - All observers must implement the Update method
     * - Called by subjects when state changes occur
     * ═══════════════════════════════════════════════════════════════════
     */
    public interface IObserver
    {
        void Update(string message, NotificationType type);
    }
}
