namespace TermProject2025.DesignPatterns.Proxy
{
    /*
     * ═══════════════════════════════════════════════════════════════════
     * DESIGN PATTERN: Proxy (Real Subject)
     * ═══════════════════════════════════════════════════════════════════
     * PURPOSE: Store and provide access to actual sensitive data
     *
     * PATTERN MAPPING:
     * - SensitiveData → RealSubject
     * - ISensitiveData → Subject interface
     *
     * IMPLEMENTATION NOTES:
     * - Stores the actual sensitive data
     * - Always returns unmasked data
     * - Accessed through the proxy for security
     * ═══════════════════════════════════════════════════════════════════
     */
    public class SensitiveData : ISensitiveData
    {
        private string _data = string.Empty;
        public string GetData()
        {
            return _data;
        }
        public void SetData(string data)
        {
            _data = data ?? string.Empty;
        }
    }
}
