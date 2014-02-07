using System.ComponentModel;

namespace Vecc.WebSecurity.ContentSecurity.Policy
{
    /// <summary>
    ///     Predefined directives supported by the content security policy spec 1.0
    /// </summary>
    public enum Directives
    {
        /// <summary>
        ///     Applies to XMLHttpRequest (AJAX), WebSocket or EventSource.
        ///     If not allowed the browser emulates a 400 HTTP status code.
        /// </summary>
        [DefaultValue("connect-src")]
        Connect,

        /// <summary>
        ///     Default policy for loading content such as
        ///     JavaScript, Images, CSS, Font's, AJAX requests,
        ///     Frames, HTML5 Media.
        /// </summary>
        [DefaultValue("default-src")]
        Default,

        /// <summary>
        ///     Defines valid sources of fonts.
        /// </summary>
        [DefaultValue("font-src")]
        Font,

        /// <summary>
        ///     Defines valid sources for loading frames.
        /// </summary>
        [DefaultValue("frame-src")]
        Frame,

        /// <summary>
        ///     Defines valid sources of images.
        /// </summary>
        [DefaultValue("img-src")]
        Image,

        /// <summary>
        ///     Defines valid sources of audio and video, eg HTML5 &lt;audio&gt;, &lt;video&gt; elements.
        /// </summary>
        [DefaultValue("media-src")]
        Media,

        /// <summary>
        ///     Defines valid sources of plugins, eg &lt;object&gt;, &lt;embed&gt; or &lt;applet&gt;.
        /// </summary>
        [DefaultValue("object-src")]
        Object,

        /// <summary>
        ///     Defines valid sources of JavaScript
        /// </summary>
        [DefaultValue("script-src")]
        Script,

        /// <summary>
        ///     Defines valid sources of stylesheets.
        /// </summary>
        [DefaultValue("style-src")]
        Style
    }
}