using System.Web;
using Vecc.WebSecurity.ContentSecurity.Policy;
using Vecc.WebSecurity.StrictTransportSecurity;

namespace Vecc.WebSecurity
{
    /// <summary>
    ///     Provides increased cross site scripting and web security enhancements
    ///     for asp.net.
    /// </summary>
    public class Security
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the content security policy for this instance.
        ///     The content-security-policy header.
        /// </summary>
        public Policy ContentSecurityPolicy { get; set; }

        /// <summary>
        ///     Gets or sets the strict transport security policy for this instance.
        ///     The strict-transport-security header.
        /// </summary>
        public TransportSecurity StrictTransportSecurity { get; set; }

        /// <summary>
        ///     Gets or sets the xss protection policy for this instance.
        ///     The x-xss-protection header.
        /// </summary>
        public XssProtection.XssProtection XssProtection { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        ///     Default constructor.
        /// </summary>
        public Security()
        {
            this.ContentSecurityPolicy = new Policy();
            this.StrictTransportSecurity = new TransportSecurity();
            this.XssProtection = new XssProtection.XssProtection();
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        ///     Applies each of the policies in this security instance.
        /// </summary>
        /// <param name="context">Http context to apply the policies to.</param>
        public virtual void Apply(HttpContext context)
        {
            this.ContentSecurityPolicy.Apply(context);
            this.StrictTransportSecurity.Apply(context);
            this.XssProtection.Apply(context);
        }

        #endregion Public Methods
    }
}