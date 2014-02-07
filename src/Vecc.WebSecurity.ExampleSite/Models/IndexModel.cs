using Vecc.WebSecurity.XssProtection;

namespace Vecc.WebSecurity.ExampleSite.Models
{
    public class IndexModel
    {
        public bool ContentSecurityPolicyEnabled { get; set; }
        public bool ContentSecurityPolicyReportOnly { get; set; }
        public bool ContentSecurityPolicyAllowSelf { get; set; }
        public string ContentSecurityPolicyReportUri { get; set; }
        public bool XssProtectionEnabled { get; set; }
        public XssProtectionOption XssProtectionOption { get; set; }
        public bool StrictTransportSecurityEnabled { get; set; }
        public bool StrictTransportSecurityRedirectEnabled { get; set; }
    }
}