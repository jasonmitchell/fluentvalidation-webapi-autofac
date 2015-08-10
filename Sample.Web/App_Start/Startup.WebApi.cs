using System.Net.Http.Formatting;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;

namespace Sample.Web
{
    public partial class Startup
    {
        private static void ConfigureWebApi(IAppBuilder app, IContainer container)
        {
            var configuration = new HttpConfiguration();
            app.UseWebApi(configuration);

            // Web API configuration and services
            configuration.Formatters.Clear();
            configuration.Formatters.Add(new JsonMediaTypeFormatter());
            configuration.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
            configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Web API routes
            configuration.MapHttpAttributeRoutes();

            configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}