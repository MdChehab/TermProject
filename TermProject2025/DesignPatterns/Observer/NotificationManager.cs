using System;
using System.Collections.Generic;
using TermProject2025.Models;

namespace TermProject2025.DesignPatterns.Observer
{
    /*
     * ═══════════════════════════════════════════════════════════════════
     * DESIGN PATTERN: Observer (Concrete Observer)
     * ═══════════════════════════════════════════════════════════════════
     * PURPOSE: Manage and store all notifications
     *
     * PATTERN MAPPING:
     * - NotificationManager → ConcreteObserver
     * - IObserver → Observer interface
     *
     * IMPLEMENTATION NOTES:
     * - Receives notifications from vault items
     * - Stores notifications for display in UI
     * - Provides access to notification list
     * ═══════════════════════════════════════════════════════════════════
     */
    public class NotificationManager : IObserver
    {
        #region Singleton Pattern

        private static NotificationManager? _instance;
        private static readonly object _lock = new object();
        public static NotificationManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new NotificationManager();
                        }
                    }
                }
                return _instance;
            }
        }

        private NotificationManager() { }

        #endregion

        #region Properties
        private readonly List<Notification> _notifications = new List<Notification>();
        public event EventHandler<Notification>? NotificationAdded;

        #endregion

        #region Public Methods
        public List<Notification> GetNotifications()
        {
            return new List<Notification>(_notifications);
        }
        public int GetUnreadCount()
        {
            return _notifications.FindAll(n => !n.IsRead).Count;
        }
        public void MarkAsRead(int notificationId)
        {
            var notification = _notifications.Find(n => n.Id == notificationId);
            if (notification != null)
            {
                notification.IsRead = true;
            }
        }
        public void ClearAll()
        {
            _notifications.Clear();
        }

        #endregion

        #region IObserver Implementation
        public void Update(string message, NotificationType type)
        {
            var notification = new Notification
            {
                Id = _notifications.Count + 1,
                Message = message,
                Type = type,
                CreatedAt = DateTime.Now,
                IsRead = false
            };

            _notifications.Add(notification);
            NotificationAdded?.Invoke(this, notification);
        }

        #endregion
    }
}
