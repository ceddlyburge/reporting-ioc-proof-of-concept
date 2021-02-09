using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.MicroKernel.SubSystems.Configuration;
using Reporting.Base;
using System.Web.Mvc;

namespace Reporting.MvcApplication
{
    public class MVCWindsorInstaller
    {
        public class ConsoleWindsorInstaller : IWindsorInstaller
        {
            public void Install(IWindsorContainer container, IConfigurationStore store)
            {
                // register anything in reporting.base
                container.Register(Classes.FromAssemblyNamed("Reporting.Base").Pick().WithServiceAllInterfaces());

                // register all classes that implement IReport in the reports directory
                container.Register(Classes.FromAssemblyInDirectory(new AssemblyFilter(@"D:\Source\Reporting\Reports")).BasedOn<Report>().WithServiceBase());

                // register all writers. I feel we should be able to do this more automatically. Putting them all in the same assembly would definitely work.
                // this doesn't seem to though: container.Register(Classes.FromAssemblyInThisApplication().BasedOn<IReportWriter>().WithServiceAllInterfaces());
                container.Register(Classes.FromAssemblyNamed("Reporting.ConsoleReportWriter").BasedOn<IReportWriter>().WithServiceAllInterfaces());
                container.Register(Classes.FromAssemblyNamed("Reporting.WordReportWriter").BasedOn<IReportWriter>().WithServiceAllInterfaces());

                // use the MVC ui
                // You need a new controller for each requeset so we must use one of the more transient lifestyles
                container.Register(Classes.FromAssemblyNamed("Reporting.MvcUI").BasedOn<Controller>().WithServiceAllInterfaces().WithServiceSelf().LifestyleTransient());
                container.Register(Classes.FromAssemblyNamed("Reporting.MvcUI").InNamespace("Reporting.MvcUI").WithServiceAllInterfaces().WithServiceSelf());
            }
        }
    }
}