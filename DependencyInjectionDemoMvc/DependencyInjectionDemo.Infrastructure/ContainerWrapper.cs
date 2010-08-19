using System;
using System.Web;
using System.Web.Mvc;
using StructureMap;

namespace DependencyInjectionDemo.Infrastructure
{
    public class ContainerWrapper
    {
        public const string ContainerKey = "Container";
        Container container;

        public void InitializeContainer()
        {
            container = new Container();
            container.Configure(c => c.Scan(s =>
            {
                s.WithDefaultConventions();
                s.AddAllTypesOf<IController>();
            }));

            HttpContext.Current.Application[ContainerKey] = this;
        }

        internal object GetInstance(Type type)
        {
            return container.GetInstance(type);
        }

        internal T GetInstance<T>()
        {
            return container.GetInstance<T>();
        }
    }
}
