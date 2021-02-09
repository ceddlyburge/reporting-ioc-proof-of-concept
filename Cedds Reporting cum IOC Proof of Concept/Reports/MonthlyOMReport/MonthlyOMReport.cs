using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reporting.Base;

namespace Reporting.MonthlyOMReport
{
    public class MonthlyOMReport : Report
    {
        #region IReport Members

        public override string Name
        {
            get { return "Monthly Operation and Maintenance"; }
        }

        protected override void Generate(IReportWriter write)
        {
            if (write == null) throw new ArgumentNullException("write");

            write.Heading("Monthly Operation and Maintenance for Forss");
            
            write.UnorderedList("Production 10.3 GWh", "Availability 97.8%", "etc") ;
        }

        #endregion
    }
}
