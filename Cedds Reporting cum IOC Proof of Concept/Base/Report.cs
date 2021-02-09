using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Reporting.Base
{
    public abstract class Report
    {
        public abstract string Name { get; }
        protected internal abstract void Generate(IReportWriter write);
    }
}
