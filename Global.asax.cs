using System;
using CinemaWebClient.Models.Identity;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CinemaWebClient.Models;

namespace CinemaWebClient
{
    public class MvcApplication : System.Web.HttpApplication
    {


        //----------------------------------------------------------------//

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //----------------------------------------------------------------//

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            var context = HttpContext.Current;
            var cookie = context?.Request?.Cookies[Constans.userName];
            if (cookie != null && !string.IsNullOrEmpty(cookie.Value))
            {
                context.User = new CustomPrincipal(cookie.Value);
            }
        }

        //----------------------------------------------------------------//

        protected void Session_Start(Object sender, EventArgs e)
        {
            (User as CustomPrincipal)?.Online();
        }

        //----------------------------------------------------------------//

        protected void Session_End(Object sender, EventArgs e)
        {
            if(Context != null)
            {
                (User as CustomPrincipal)?.Offline();
            }
        }

        //----------------------------------------------------------------//
    }
}
