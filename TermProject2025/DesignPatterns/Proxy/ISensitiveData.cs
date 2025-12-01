namespace TermProject2025.DesignPatterns.Proxy
{
    /*
     * ═══════════════════════════════════════════════════════════════════
     * DESIGN PATTERN: Proxy
     * ═══════════════════════════════════════════════════════════════════
     * PURPOSE: Control access to sensitive data with masking/unmasking
     *
     * PATTERN MAPPING:
     * - ISensitiveData → Subject interface
     *
     * IMPLEMENTATION NOTES:
     * - Defines common interface for both proxy and real subject
     * - Allows proxy to substitute for real object
     * ═══════════════════════════════════════════════════════════════════
     */
    public interface ISensitiveData
    {
        string GetData();
        void SetData(string data);
    }
}
