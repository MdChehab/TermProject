using System;

namespace TermProject2025.DesignPatterns.Singleton
{
    /*
     * ═══════════════════════════════════════════════════════════════════
     * DESIGN PATTERN: Singleton
     * ═══════════════════════════════════════════════════════════════════
     * PURPOSE: Manage user authentication session throughout application lifecycle
     *
     * PATTERN MAPPING:
     * - UserSession → Singleton
     * - Instance property → getInstance() method
     *
     * IMPLEMENTATION NOTES:
     * - Thread-safe using double-check locking
     * - Ensures only one session instance exists
     * - Provides global access point for session data
     * - Manages authentication state and master key in memory
     * ═══════════════════════════════════════════════════════════════════
     */

    public sealed class UserSession
    {
        private static UserSession? _instance;
        private static readonly object _lock = new object();

        public static UserSession Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new UserSession();
                        }
                    }
                }
                return _instance;
            }
        }

        private UserSession()
        {
            AutoLockMinutes = 5;
            ClipboardClearMinutes = 2;
        }

        public string? CurrentUserEmail { get; private set; }
        public int CurrentUserId { get; private set; }
        public byte[]? MasterKey { get; private set; }
        public DateTime LastActivity { get; set; }
        public int AutoLockMinutes { get; set; }
        public int ClipboardClearMinutes { get; set; }

        public void Login(int userId, string email, byte[] masterKey)
        {
            CurrentUserId = userId;
            CurrentUserEmail = email;
            MasterKey = masterKey;
            LastActivity = DateTime.Now;
        }

        public void Logout()
        {
            CurrentUserId = 0;
            CurrentUserEmail = null;

            if (MasterKey != null)
            {
                Array.Clear(MasterKey, 0, MasterKey.Length);
                MasterKey = null;
            }

            LastActivity = DateTime.MinValue;
        }

        public bool IsAuthenticated()
        {
            return CurrentUserId > 0 && !string.IsNullOrEmpty(CurrentUserEmail) && MasterKey != null;
        }

        public void UpdateActivity()
        {
            LastActivity = DateTime.Now;
        }

        public bool ShouldAutoLock()
        {
            if (!IsAuthenticated())
                return false;

            var elapsed = DateTime.Now - LastActivity;
            return elapsed.TotalMinutes >= AutoLockMinutes;
        }
    }
}
