namespace Vecc.WebSecurity.ContentSecurity.Logger
{
    /// <summary>
    ///     A violation report that would be sent by the browser for policy violations.
    /// </summary>
    /// <remarks>
    ///     A full example of the JSON object that would be posted to the web server:
    ///     <code>
    ///     {
    ///         "csp-report": {
    ///             "document-uri": "http://example.org/page.html",
    ///             "referrer": "http://evil.example.com/haxor.html",
    ///             "blocked-uri": "http://evil.example.com/image.png",
    ///             "violated-directive": "default-src 'self'",
    ///             "original-policy": "default-src 'self'; report-uri http://example.org/csp-report.cgi"
    ///         }
    ///     }
    /// </code>
    /// </remarks>
    public class CspReport
    {
        #region Properties

        /// <summary>
        ///     The address of the page making the request.
        /// </summary>
        /// <remarks>In the JSON object, the property name is "document-uri"</remarks>
        public virtual string DocumentUri { get; set; }

        /// <summary>
        ///     The referrer to the page requesting the blocked resource
        /// </summary>
        /// <remarks>In the JSON object, the property name is "referrer"</remarks>
        public virtual string Referrer { get; set; }

        /// <summary>
        ///     The violated directive name.
        /// </summary>
        /// <remarks>In the JSON object, the property name is "violated-directive"</remarks>
        public virtual string ViolatedDirective { get; set; }

        /// <summary>
        ///     The full policy that was violated.
        /// </summary>
        /// <remarks>In the JSON object, the property name is "original-policy"</remarks>
        public virtual string OriginalPolicy { get; set; }

        /// <summary>
        ///     The uri of blocked resource
        /// </summary>
        /// <remarks>In the JSON object, the property name is "blocked-uri"</remarks>
        public virtual string BlockedUri { get; set; }

        #endregion Properties
    }
}