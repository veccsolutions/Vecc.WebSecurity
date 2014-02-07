namespace Vecc.WebSecurity.XssProtection
{
    /// <summary>
    ///     The valid options for the X-XSS-Protection header.
    /// </summary>
    public enum XssProtectionOption
    {
        /// <summary>
        ///     Don't attempt to block cross site scripting from links.
        /// </summary>
        Disabled,

        /// <summary>
        ///     Disable scripts in pages suspected to be a cross site scripting.
        /// </summary>
        Enabled,

        /// <summary>
        ///     If cross site scripting is detected, don't display the page at all.
        /// </summary>
        EnabledAndBlockPage
    }
}