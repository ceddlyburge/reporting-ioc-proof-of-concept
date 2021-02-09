using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reporting.Base
{
    public class ReportGenerator
    {
        public void GenerateReport(Report report, IReportWriter writer)
        {
            writer.Begin();
            try
            {
                report.Generate(writer); 
            }
            finally
            {
                writer.End();
            }
        }
    }
}
