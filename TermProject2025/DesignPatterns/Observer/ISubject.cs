using TermProject2025.Models;

namespace TermProject2025.DesignPatterns.Observer
{
    /*
     * ═══════════════════════════════════════════════════════════════════
     * DESIGN PATTERN: Observer
     * ═══════════════════════════════════════════════════════════════════
     * PURPOSE: Define the Subject interface for managing observers
     *
     * PATTERN MAPPING:
     * - ISubject → Subject interface
     *
     * IMPLEMENTATION NOTES:
     * - Subjects maintain a list of observers
     * - Provides methods to attach/detach observers
     * - Notifies all observers when state changes
     * ═══════════════════════════════════════════════════════════════════
     */
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify(string message, NotificationType type);
    }
}
