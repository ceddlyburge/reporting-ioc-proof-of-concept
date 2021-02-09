using System;
using System.Web.Mvc;
using Castle.Windsor;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor.Installer;
using System.Web.Routing;

namespace Reporting.MvcApplication
{
    public class DependencyControllerFactory : DefaultControllerFactory, IDisposable
    {
        protected readonly WindsorContainer _container;

        public DependencyControllerFactory()
        {
            _container = new WindsorContainer();

            _container.Kernel.Resolver.AddSubResolver(new CollectionResolver(_container.Kernel));
            _container.Install(FromAssembly.This());
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                return null;
            }
            else
            {
                return (IController)_container.Resolve(controllerType);
            }
        }

        public override void ReleaseController(IController controller)
        {
            _container.Release(controller);
        }

        public void Dispose()
        {
            _container.Dispose();
        }
    }
}

