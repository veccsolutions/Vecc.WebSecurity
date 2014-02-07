using System;
using System.ComponentModel;

namespace Vecc.WebSecurity.ContentSecurity.Policy
{
    /// <summary>
    ///     Predefined directive sources according to the content security policy spec 1.0
    /// </summary>
    [Flags]
    public enum DirectiveSources
    {
        /// <summary>
        ///     Will not use any of the default sources
        /// </summary>
        NotSet = 0,

        /// <summary>
        ///     Allows loading resources from the same origin (same scheme, host and port).
        /// </summary>
        [DefaultValue("'self'")]
        Self = 1,

        /// <summary>
        ///     Allows use of inline source elements such as style attribute, onclick, or script tag bodies (depends on the context
        ///     of the source it is applied to)
        /// </summary>
        [DefaultValue("'unsafe-inline'")]
        UnsafeInline = 2,

        /// <summary>
        ///     Allows unsafe dynamic code evaluation such as JavaScript eval(). Only applies to script.
        /// </summary>
        [DefaultValue("'unsafe-eval'")]
        UnsafeEval = 4,

        /// <summary>
        ///     Wildcard, allows anything.
        /// </summary>
        [DefaultValue("*")]
        All = 8,

        /// <summary>
        ///     Prevents loading resources from any source.
        /// </summary>
        [DefaultValue("'none'")]
        None = 16,

        /// <summary>
        ///     Allows loading resources via the data scheme (eg Base64 encoded images).
        /// </summary>
        [DefaultValue("data:")]
        Data = 32,

        /// <summary>
        ///     Allows loading resources only over HTTPS on any domain.
        /// </summary>
        [DefaultValue("https:")]
        Https = 64
    }
}