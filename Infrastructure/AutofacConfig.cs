using Autofac;
using Autofac.Integration.Mvc;
using CinemaWebClient.Models.Identity;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;

namespace CinemaWebClient.Infrastructure
{
    public class AutofacConfig 
    {
        public IContainer container { get; private set; }

        private ContainerBuilder containerBuilder;

        //----------------------------------------------------------------//

        public AutofacConfig()
        {
            containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterControllers(typeof(MvcApplication).Assembly);
            RegisterService();
        }

        //----------------------------------------------------------------//

        private void RegisterService()
        {
            containerBuilder.RegisterType<UserSession>().As<IUserSession>()
                            .InstancePerRequest();
            container = containerBuilder.Build();
        }

        //----------------------------------------------------------------//

    }
}