using System;

namespace TermProject2025.DesignPatterns.Proxy
{
    /*
     * ═══════════════════════════════════════════════════════════════════
     * DESIGN PATTERN: Proxy
     * ═══════════════════════════════════════════════════════════════════
     * PURPOSE: Control access to sensitive data with masking functionality
     *
     * PATTERN MAPPING:
     * - MaskedDataProxy → Proxy
     * - SensitiveData → RealSubject
     * - ISensitiveData → Subject interface
     *
     * IMPLEMENTATION NOTES:
     * - Controls access to the real sensitive data
     * - Returns masked version by default (••••••••)
     * - Allows temporary unmasking for viewing
     * - Adds security layer between client and real data
     * ═══════════════════════════════════════════════════════════════════
     */

    public class MaskedDataProxy : ISensitiveData
    {
        private readonly SensitiveData _realData;
        private bool _isUnmasked = false;
        private DateTime _unmaskTime;
        private const int AutoMaskSeconds = 30;

        public MaskedDataProxy()
        {
            _realData = new SensitiveData();
        }

        public bool IsUnmasked => _isUnmasked;

        public string GetData()
        {
            if (_isUnmasked && (DateTime.Now - _unmaskTime).TotalSeconds > AutoMaskSeconds)
            {
                Mask();
            }

            if (_isUnmasked)
            {
                return _realData.GetData();
            }
            else
            {
                var realDataString = _realData.GetData();
                if (string.IsNullOrEmpty(realDataString))
                    return string.Empty;

                return new string('•', Math.Min(8, realDataString.Length));
            }
        }

        public void SetData(string data)
        {
            _realData.SetData(data);
        }

        public void Unmask()
        {
            _isUnmasked = true;
            _unmaskTime = DateTime.Now;
        }

        public void Mask()
        {
            _isUnmasked = false;
        }

        public void ToggleMask()
        {
            if (_isUnmasked)
                Mask();
            else
                Unmask();
        }

        public string GetRealData()
        {
            return _realData.GetData();
        }
    }
}
