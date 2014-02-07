using System.Web;
using System.Web.Mvc;

namespace Vecc.WebSecurity.ExampleSite
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
