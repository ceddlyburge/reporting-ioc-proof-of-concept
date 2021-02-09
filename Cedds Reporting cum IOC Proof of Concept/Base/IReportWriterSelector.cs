using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reporting.Base
{
    public interface IReportWriterSelector
    {
        IReportWriter Select();
    }
}
