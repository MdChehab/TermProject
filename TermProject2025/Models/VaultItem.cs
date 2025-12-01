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

    /// <summary>
    /// Base class for all vault items.
    /// Implements ISubject from Observer pattern to notify about changes.
    /// </summary>
    public abstract class VaultItem : ISubject
    {
        #region Properties

        /// <summary>
        /// Unique identifier for the vault item.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Foreign key to the User table.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Type of vault item (Login, CreditCard, Identity, SecureNote).
        /// </summary>
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// Encrypted JSON data containing sensitive information.
        /// </summary>
        public string EncryptedData { get; set; } = string.Empty;

        /// <summary>
        /// Timestamp when the item was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Timestamp when the item was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Navigation property to the owning user.
        /// </summary>
        public User? User { get; set; }

        #endregion

        #region Observer Pattern Implementation

        /// <summary>
        /// List of observers watching this vault item.
        /// </summary>
        private readonly List<IObserver> _observers = new List<IObserver>();

        /// <summary>
        /// Attach an observer to this subject.
        /// </summary>
        /// <param name="observer">The observer to attach.</param>
        public void Attach(IObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        /// <summary>
        /// Detach an observer from this subject.
        /// </summary>
        /// <param name="observer">The observer to detach.</param>
        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        /// <summary>
        /// Notify all attached observers about a change.
        /// </summary>
        /// <param name="message">The notification message.</param>
        /// <param name="type">The type of notification.</param>
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
