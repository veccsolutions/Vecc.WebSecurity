using System.Collections.Generic;
using System.Web;

namespace Vecc.WebSecurity.ContentSecurity.Policy
{
    /// <summary>
    ///     The content security policy for the server response.
    /// </summary>
    public class Policy
    {
        #region Properties

        /// <summary>
        ///     Gets or sets whether or not to apply the policy in the apply method.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        ///     Gets or sets whether the policy will only report violation or if it will report and block requests.
        /// </summary>
        public bool ReportOnly { get; set; }

        /// <summary>
        ///     Gets or sets the uri to send violation reports to.
        /// </summary>
        public string ReportUri { get; set; }

        /// <summary>
        ///     The default policy for loading content such as
        ///     JavaScript, Images, CSS, Font's, AJAX requests,
        ///     Frames, HTML5 Media.
        /// </summary>
        public Directive Default { get; set; }

        /// <summary>
        ///     This directive applies to XMLHttpRequest (AJAX), WebSocket or EventSource.
        ///     If not allowed the browser emulates a 400 HTTP status code.
        /// </summary>
        public Directive Connect { get; set; }

        /// <summary>
        ///     Custom directives that may or may not be in the spec, as such, they may not be honored by the browser.
        /// </summary>
        public ICollection<Directive> CustomDirectives { get; set; }

        /// <summary>
        ///     This directive defines valid sources of fonts.
        /// </summary>
        public Directive Font { get; private set; }

        /// <summary>
        ///     This directive defines valid sources for loading frames.
        /// </summary>
        public Directive Frame { get; private set; }

        /// <summary>
        ///     This directive defines valid sources of images.
        /// </summary>
        public Directive Image { get; private set; }

        /// <summary>
        ///     This directive defines valid sources of audio and video, eg HTML5 &lt;audio&gt;, &lt;video&gt; elements.
        /// </summary>
        public Directive Media { get; private set; }

        /// <summary>
        ///     This directive defines valid sources of plugins, eg &lt;object&gt;, &lt;embed&gt; or &lt;applet&gt;.
        /// </summary>
        public Directive Object { get; private set; }

        /// <summary>
        ///     This directive defines valid sources of JavaScript
        /// </summary>
        public Directive Script { get; private set; }

        /// <summary>
        ///     This directive defines valid sources of stylesheets.
        /// </summary>
        public Directive Style { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        ///     The default constructor
        /// </summary>
        public Policy()
        {
            this.Connect = new Directive(Directives.Connect);
            this.Default = new Directive(Directives.Default);
            this.Font = new Directive(Directives.Font);
            this.Frame = new Directive(Directives.Frame);
            this.Image = new Directive(Directives.Image);
            this.Media = new Directive(Directives.Media);
            this.Object = new Directive(Directives.Object);
            this.Script = new Directive(Directives.Script);
            this.Style = new Directive(Directives.Style);

            this.CustomDirectives = new List<Directive>();
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        ///     Creates the header text from all of the directives.
        /// </summary>
        /// <returns></returns>
        public virtual string ToHeader()
        {
            var result =
                this.Connect.ToHeader() +
                this.Default.ToHeader() +
                this.Font.ToHeader() +
                this.Frame.ToHeader() +
                this.Image.ToHeader() +
                this.Media.ToHeader() +
                this.Object.ToHeader() +
                this.Script.ToHeader() +
                this.Style.ToHeader();

            foreach (var directive in this.CustomDirectives)
            {
                result += directive.ToHeader();
            }

            if (!string.IsNullOrWhiteSpace(this.ReportUri))
            {
                result += "report-uri " + this.ReportUri + ";";
            }

            return result;
        }

        /// <summary>
        ///     If enabled is true, will create and add the header to the context response.
        /// </summary>
        /// <param name="context">Context to apply the header to.</param>
        public virtual void Apply(HttpContext context)
        {
            if (this.Enabled)
            {
                var headerName = this.ReportOnly ? "content-security-policy-report-only" : "content-security-policy";
                var headerValue = this.ToHeader();
                if (!string.IsNullOrWhiteSpace(headerValue))
                {
                    context.Response.AddHeader(headerName, headerValue);
                }
            }
        }

        #endregion Public Methods
    }
}