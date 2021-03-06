using System.Web.Mvc;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using A5_SecurityMisconfiguration_EpiServer.Business.Rendering;
using A5_SecurityMisconfiguration_EpiServer.Helpers;
using EPiServer.Web.Mvc;
using EPiServer.Web.Mvc.Html;
using StructureMap;

namespace A5_SecurityMisconfiguration_EpiServer.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class DependencyResolverInitialization : IConfigurableModule
    {
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.Container.Configure(ConfigureContainer);

            DependencyResolver.SetResolver(new StructureMapDependencyResolver(context.Container));
        }

        private static void ConfigureContainer(ConfigurationExpression container)
        {
            //Swap out the default ContentRenderer for our custom
            container.For<IContentRenderer>().Use<ErrorHandlingContentRenderer>();
            container.For<ContentAreaRenderer>().Use<AlloyContentAreaRenderer>();

            //Implementations for custom interfaces can be registered here.
        }

        public void Initialize(InitializationEngine context)
        {
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

        public void Preload(string[] parameters)
        {
        }
    }
}
