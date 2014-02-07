using System.Web;

namespace Vecc.WebSecurity.Helpers
{
    /// <summary>
    ///     This interface allows us to override the information used for determining
    ///     some of the logic in the security classes. This is because when a server
    ///     is behind a load balancer, the uri passed to the server may not be the actual
    ///     uri of the public facing site. The load balancer might also be running as an SSL
    ///     offloader, basically, clients connect to the load balancer as https, load balancer
    ///     then connects to the server as http. The server then has no idea if it is actually
    ///     being used as http or https.
    /// </summary>
    public interface IHttpInformation
    {
        /// <summary>
        ///     Gets the absolute uri of the request without the protocol (http:// or https://).
        /// </summary>
        /// <param name="context">Http context of the current request and response.</param>
        /// <returns>The public facing absolute uri without the protocol (http:// or https://).</returns>
        string GetCurrentUri(HttpContext context);

        /// <summary>
        ///     Gets whether the current connection is secure.
        /// </summary>
        /// <param name="context">Http context of the current request and response.</param>
        /// <returns>The state of the public facing connection.</returns>
        bool IsHttps(HttpContext context);
    }
}