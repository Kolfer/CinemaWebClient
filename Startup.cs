using CinemaWebClient.Infrastructure;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin;
using Autofac.Integration.Mvc;
using Owin;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(CinemaWebClient.Startup))]

namespace CinemaWebClient
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = "AppCookie",
                LoginPath = new PathString("/Account/Login"),
            });
            AutofacConfig autofacConfig = new AutofacConfig();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(autofacConfig.container));
            app.UseAutofacMiddleware(autofacConfig.container);
        }
    }
}
