using System;
using System.Windows.Forms;
using TermProject2025.DesignPatterns.Singleton;

namespace TermProject2025.Services
{
    public class ClipboardService
    {
        private System.Windows.Forms.Timer? _clearTimer;
        private string _lastCopiedSensitiveData = string.Empty;

        public void CopyToClipboard(string data, bool isSensitive = true)
        {
            if (string.IsNullOrEmpty(data))
                return;

            Clipboard.SetText(data);

            if (isSensitive)
            {
                _lastCopiedSensitiveData = data;
                StartClearTimer();
            }
        }

        private void StartClearTimer()
        {
            _clearTimer?.Stop();
            _clearTimer?.Dispose();

            _clearTimer = new System.Windows.Forms.Timer();
            _clearTimer.Interval = UserSession.Instance.ClipboardClearMinutes * 60 * 1000;
            _clearTimer.Tick += (s, e) =>
            {
                try
                {
                    if (Clipboard.ContainsText() && Clipboard.GetText() == _lastCopiedSensitiveData)
                    {
                        Clipboard.Clear();
                    }
                }
                catch
                {
                }
                finally
                {
                    _clearTimer?.Stop();
                }
            };
            _clearTimer.Start();
        }

        public void Clear()
        {
            try
            {
                Clipboard.Clear();
            }
            catch
            {
            }
        }
    }
}
