using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Vecc.WebSecurity.ContentSecurity.Policy;

namespace Vecc.WebSecurity.ExampleSite
{
    public class MvcApplication : HttpApplication
    {
        public static readonly Security SecurityManager = new Security();
        private static bool _setReportUri;

        protected void Application_Start()
        {
            SecurityManager.ContentSecurityPolicy =
                Policies.SelfOnly;
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (!_setReportUri)
            {
                SecurityManager.ContentSecurityPolicy.ReportUri =
                    UrlHelper.GenerateContentUrl("~/Report.ashx",
                                                 new HttpContextWrapper(this.Context));

                _setReportUri = true;
            }
            SecurityManager.Apply(this.Context);
        }
    }
}