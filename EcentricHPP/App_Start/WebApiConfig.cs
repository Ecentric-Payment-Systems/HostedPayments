using System.Web.Http;

namespace EcentricHPP
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("apiDefaultRoute", "api/{controller}/{action}", null);
        }
    }
}
