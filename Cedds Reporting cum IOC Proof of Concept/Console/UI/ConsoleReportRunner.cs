using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reporting.ConsoleUI;
using Reporting.Base;

namespace Reporting.ConsoleUI
{
    public class ConsoleReportRunner
    {
        protected readonly ConsoleReportSelector _reportSelector;
        protected readonly ConsoleReportWriterSelector _writerSelector;
        protected readonly ReportGenerator _generateReport;

        public ConsoleReportRunner(ConsoleReportSelector reportSelector, ConsoleReportWriterSelector writerSelector, ReportGenerator generateReport)
        {
            if (reportSelector == null) throw new ArgumentNullException("reportSelector");
            if (writerSelector == null) throw new ArgumentNullException("writerSelector");
            if (generateReport == null) throw new ArgumentNullException("generateReport");

            _reportSelector = reportSelector;
            _writerSelector = writerSelector;
            _generateReport = generateReport;
        }

        public void Run()
        {
            // the line below won't compile as  Report.Generate is protected internal, so we don't have access to it
            //_reportSelector.Select().Generate(_writerSelector.Select())
            // Instead we are forced to use the report generator which guarantees that writer.beginreport and writer.endreport are called
            _generateReport.GenerateReport(_reportSelector.Select(), _writerSelector.Select());
            Console.WriteLine("Press return to exit");
            Console.ReadLine();
        }

    }
}
