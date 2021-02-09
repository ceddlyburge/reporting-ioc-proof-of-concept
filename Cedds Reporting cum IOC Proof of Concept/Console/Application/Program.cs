using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Reporting.Base;
using Reporting.ConsoleUI;

namespace Reporting.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();

            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));

            container.Install(FromAssembly.This());

            var runner = container.Resolve<ConsoleReportRunner>();

            runner.Run();

            container.Release(runner);

            container.Dispose();
        }
    }
}
