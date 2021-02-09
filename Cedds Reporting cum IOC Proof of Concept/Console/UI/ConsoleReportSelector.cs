using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reporting.Base;

namespace Reporting.ConsoleUI
{
    public class ConsoleReportSelector : IReportSelector
    {
        protected readonly IEnumerable<Report> _reports;

        public ConsoleReportSelector(IEnumerable<Report> reports)
        {
            if (reports == null) throw new ArgumentNullException("reports");

            _reports = reports;
        }

        #region IReportSelector Members

        public Report Select()
        {
            int i = 1;
            Console.WriteLine("Select Report") ;
            foreach(var report in _reports) 
            {
                Console.WriteLine(i.ToString() + " " + report.Name);
                i++;
            }

            if (int.TryParse(Console.ReadLine(), out i))
            {
                return _reports.ToArray()[i - 1];
            }
            else
            {
                return _reports.First();
            }
        }

        #endregion
    }
}
