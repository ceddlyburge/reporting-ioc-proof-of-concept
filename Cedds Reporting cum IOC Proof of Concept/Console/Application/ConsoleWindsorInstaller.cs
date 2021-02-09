using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.MicroKernel.SubSystems.Configuration;
using Reporting.Base;

namespace Reporting.ConsoleApplication
{
    public class ConsoleWindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // register anything in reporting.base
            container.Register(Classes.FromAssemblyNamed("Reporting.Base").Pick().WithServiceAllInterfaces());

            // register all classes that descend from Report in the reports directory
            container.Register(Classes.FromAssemblyInDirectory(new AssemblyFilter(@"D:\Source\Reporting\Reports")).BasedOn<Report>().WithServiceBase());

            // register all writers. I feel we should be able to do this more automatically. Putting them all in the same assembly would definitely work.
            //container.Register(Classes.FromAssemblyInThisApplication().BasedOn<IReportWriter>().WithServiceAllInterfaces());
            container.Register(Classes.FromAssemblyNamed("Reporting.ConsoleReportWriter").BasedOn<IReportWriter>().WithServiceAllInterfaces());
            container.Register(Classes.FromAssemblyNamed("Reporting.WordReportWriter").BasedOn<IReportWriter>().WithServiceAllInterfaces());

            // use the console ui
            container.Register(Classes.FromAssemblyNamed("Reporting.ConsoleUI").InNamespace("Reporting.ConsoleUI").WithServiceAllInterfaces().WithServiceSelf());
        }
    }
}
