using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace DependencyInjectionDemo.Infrastructure
{
    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(
            RequestContext requestContext, Type controllerType)
        {
            var application = requestContext.HttpContext.Application;
            var container = (ContainerWrapper)application[ContainerWrapper.ContainerKey];
            return container.GetInstance(controllerType) as IController;
        }
    }
}