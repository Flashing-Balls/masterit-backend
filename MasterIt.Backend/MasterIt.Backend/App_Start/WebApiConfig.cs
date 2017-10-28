using System.Web.Http;

namespace MasterIt.Backend
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            config.Routes.MapHttpRoute(
                name: "CommentsApi",
                routeTemplate: "api/{controller}/{postId}",
                defaults: new { controller = "comments" }
            );

            config.Routes.MapHttpRoute(
                name: "PostsApi",
                routeTemplate: "api/{controller}/{userId}",
                defaults: new { controller = "posts" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}