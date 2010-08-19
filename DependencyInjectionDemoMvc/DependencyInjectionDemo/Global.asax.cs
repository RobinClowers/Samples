using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DependencyInjectionDemo.Infrastructure;

namespace DependencyInjectionDemo
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
            var container = new ContainerWrapper();
            container.InitializeContainer();
        }

        void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}