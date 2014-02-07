using System;
using System.Web;
using Vecc.WebSecurity.Helpers;

namespace Vecc.WebSecurity.StrictTransportSecurity
{
    public class TransportSecurity
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the max age for the browser to cache this header.
        /// </summary>
        public TimeSpan MaxCacheAge { get; set; }

        /// <summary>
        ///     Gets or sets the whether to redirect the current request to https.
        /// </summary>
        public bool RedirectHttpToHttps { get; set; }

        /// <summary>
        ///     Gets or sets whether to apply this policy to the response.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        ///     Gets or sets the methods to determine if it's https, and what the current uri is.
        ///     Load balancers may change the uri.
        /// </summary>
        public IHttpInformation HttpInformation { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        ///     Default constructor, uses the DefaultHttpInformation for getting http information.
        /// </summary>
        public TransportSecurity()
        {
            this.MaxCacheAge = new TimeSpan(1, 0, 0, 0); //set the cache to default to a day
            this.HttpInformation = new DefaultHttpInformation();
        }

        /// <summary>
        ///     Constructor that specifies the http information.
        /// </summary>
        /// <param name="httpInformation">The IHttpInformation object to use for getting the http request information.</param>
        public TransportSecurity(IHttpInformation httpInformation)
            : this()
        {
            this.HttpInformation = httpInformation;
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        ///     If the policy is enabled, it will apply the strict-transport-security
        ///     header to the response and redirect the current request if needed.
        /// </summary>
        /// <param name="context">HttpContext to apply the policy to.</param>
        public void Apply(HttpContext context)
        {
            if (!this.Enabled)
            {
                return;
            }

            if (this.HttpInformation.IsHttps(context))
            {
                context.Response.AddHeader("Strict-Transport-Security", "max-age=" + this.MaxCacheAge.TotalSeconds);
            }
            else if (this.RedirectHttpToHttps)
            {
                context.Response.RedirectPermanent("https://" + this.HttpInformation.GetCurrentUri(context));
            }
        }

        #endregion Public Methods
    }
}