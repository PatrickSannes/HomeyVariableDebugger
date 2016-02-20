using System.Web.Http;
using System.Web.Http.Dependencies;
using Newtonsoft.Json.Converters;
using Owin;
using Swashbuckle.Application;

namespace HomeyDebugger.Api
{
    public class OwinWebApiConfig
    {
        public static IDependencyResolver DependencyResolver { get; set; }

        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();

            config.EnableCors();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}",
                defaults: new { controller="Variable"});
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter());

            if (DependencyResolver != null)
                config.DependencyResolver = DependencyResolver;

            // add swagger/swashbuckle, cf.: https://github.com/domaindrivendev/Swashbuckle
            config
                .EnableSwagger(c => c.SingleApiVersion("v1", "A title for your API"))
                .EnableSwaggerUi();

            appBuilder.UseWebApi(config);
        }
    }
}