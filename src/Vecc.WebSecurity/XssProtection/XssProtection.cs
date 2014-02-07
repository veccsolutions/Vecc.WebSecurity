using System.Web;

namespace Vecc.WebSecurity.XssProtection
{
    /// <summary>
    ///     X-XSS-Protection header policy.
    /// </summary>
    public class XssProtection
    {
        #region Properties

        /// <summary>
        ///     Gets or sets whether the policy is enabled.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        ///     Gets or sets the options for the policy.
        /// </summary>
        public XssProtectionOption Options { get; set; }

        #endregion Properties

        #region Public Methods

        /// <summary>
        ///     If the policy is enabled, will apply the header based on the option specified.
        /// </summary>
        /// <param name="context"></param>
        public void Apply(HttpContext context)
        {
            if (this.Enabled)
            {
                var headerName = "X-XSS-Protection";
                switch (this.Options)
                {
                    case XssProtectionOption.Disabled:
                        context.Response.AddHeader(headerName, "0");
                        break;
                    case XssProtectionOption.Enabled:
                        context.Response.AddHeader(headerName, "1");
                        break;
                    case XssProtectionOption.EnabledAndBlockPage:
                        context.Response.AddHeader(headerName, "1;mode=block");
                        break;
                }
            }
        }

        #endregion Public Methods
    }
}