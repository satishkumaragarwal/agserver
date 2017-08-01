using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Microsoft.Practices.Unity;
using TMS.AddressBook.WebApplication.App_Start;
using TMS.AddressBook.Resolver;
using TMS.AddressBook.Logging;

namespace TMS.AddressBook.WebApplication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var container = new UnityContainer();
            ComponentLoader.LoadContainer(container, ".\\bin", "TMS.AddressBook.BusinessLayer.dll");
            ComponentLoader.LoadContainer(container, ".\\bin", "TMS.AddressBook.DataLayer.dll");
            ComponentLoader.LoadContainer(container, ".\\bin", "TMS.AddressBook.Logging.dll");
            config.DependencyResolver = new UnityResolver(container);
            config.Filters.Add(new WebApplicationExceptionFilterAttribute(container.Resolve<ILogger>()));
        }
    }
}
