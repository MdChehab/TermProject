using System;
using System.Collections.Generic;
using TermProject2025.DesignPatterns.Observer;

namespace TermProject2025.Models
{
    /*
     * ═══════════════════════════════════════════════════════════════════
     * DESIGN PATTERN: Observer (Subject Implementation)
     * ═══════════════════════════════════════════════════════════════════
     * PURPOSE: Notify observers when vault items are created or modified
     *
     * PATTERN MAPPING:
     * - VaultItem → ConcreteSubject
     * - ISubject → Subject interface
     *
     * IMPLEMENTATION NOTES:
     * - VaultItem acts as the subject being observed
     * - Notifies observers about weak passwords, expirations, etc.
     * - Observers can attach/detach from vault items
     * ═══════════════════════════════════════════════════════════════════
     */
    public abstract class VaultItem : ISubject
    {
        #region Properties
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; } = string.Empty;
        public string EncryptedData { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User? User { get; set; }

        #endregion

        #region Observer Pattern Implementation
        private readonly List<IObserver> _observers = new List<IObserver>();
        public void Attach(IObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }
        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }
        public void Notify(string message, NotificationType type)
        {
            foreach (var observer in _observers)
            {
                observer.Update(message, type);
            }
        }

        #endregion
    }
}
