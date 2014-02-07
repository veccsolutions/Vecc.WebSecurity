using System.Web.Mvc;
using Vecc.WebSecurity.ContentSecurity.Policy;
using Vecc.WebSecurity.ExampleSite.Models;

namespace Vecc.WebSecurity.ExampleSite.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var model = new IndexModel
                        {
                            ContentSecurityPolicyAllowSelf = MvcApplication.SecurityManager.ContentSecurityPolicy.Default.Tags.HasFlag(DirectiveSources.Self),
                            ContentSecurityPolicyEnabled = MvcApplication.SecurityManager.ContentSecurityPolicy.Enabled,
                            ContentSecurityPolicyReportOnly = MvcApplication.SecurityManager.ContentSecurityPolicy.ReportOnly,
                            ContentSecurityPolicyReportUri = MvcApplication.SecurityManager.ContentSecurityPolicy.ReportUri,
                            StrictTransportSecurityEnabled = MvcApplication.SecurityManager.StrictTransportSecurity.Enabled,
                            StrictTransportSecurityRedirectEnabled = MvcApplication.SecurityManager.StrictTransportSecurity.RedirectHttpToHttps,
                            XssProtectionEnabled = MvcApplication.SecurityManager.XssProtection.Enabled,
                            XssProtectionOption = MvcApplication.SecurityManager.XssProtection.Options
                        };

            return View("Index", model);
        }

        [HttpPost]
        public ActionResult Index(IndexModel model)
        {
            if (model.ContentSecurityPolicyAllowSelf)
            {
                MvcApplication.SecurityManager.ContentSecurityPolicy = Policies.SelfOnly;
            }
            else
            {
                MvcApplication.SecurityManager.ContentSecurityPolicy = Policies.NoResources;
            }

            MvcApplication.SecurityManager.ContentSecurityPolicy.Enabled = model.ContentSecurityPolicyEnabled;
            MvcApplication.SecurityManager.ContentSecurityPolicy.ReportOnly = model.ContentSecurityPolicyReportOnly;
            MvcApplication.SecurityManager.ContentSecurityPolicy.ReportUri = model.ContentSecurityPolicyReportUri;
            MvcApplication.SecurityManager.StrictTransportSecurity.Enabled = model.StrictTransportSecurityEnabled;
            MvcApplication.SecurityManager.StrictTransportSecurity.RedirectHttpToHttps = model.StrictTransportSecurityRedirectEnabled;
            MvcApplication.SecurityManager.XssProtection.Enabled = model.XssProtectionEnabled;
            MvcApplication.SecurityManager.XssProtection.Options = model.XssProtectionOption;

            return View("Index", model);
        }

        [HttpGet]
        [ValidateInput(false)]
        public ActionResult Xss()
        {
            return this.Index();
        }
    }
}