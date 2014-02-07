using System.Web;

namespace Vecc.WebSecurity.Helpers
{
    /// <summary>
    ///     The default implementation of the IHttpInformation interface.
    /// </summary>
    public class DefaultHttpInformation : IHttpInformation
    {
        #region IHttpInformation Members

        /// <summary>
        ///     Gets the current uri of the context.
        /// </summary>
        /// <param name="context">Http context to get the uri from.</param>
        /// <returns>The uri of the current request without the http/https.</returns>
        public string GetCurrentUri(HttpContext context)
        {
            if (context.Request.Url.IsDefaultPort)
            {
                return string.Format("{0}{1}",
                                     context.Request.Url.Host,
                                     context.Request.Url.PathAndQuery);
            }

            return string.Format("{0}:{1}{2}",
                                 context.Request.Url.Host,
                                 context.Request.Url.Port,
                                 context.Request.Url.Port);
        }

        /// <summary>
        ///     Determines if it's https by using the Url.Scheme.
        /// </summary>
        /// <param name="context">Http context to check.</param>
        /// <returns>True if it's https, false if it's not.</returns>
        public bool IsHttps(HttpContext context)
        {
            return context.Request.Url.Scheme == "https";
        }

        #endregion
    }
}