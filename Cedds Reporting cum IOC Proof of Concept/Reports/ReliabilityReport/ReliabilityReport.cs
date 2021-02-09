using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reporting.Base;

namespace Reporting.ReliabilityReport
{
    public class ReliabilityReport : Report
    {
        #region IReport Members

        public override string Name
        {
            get { return "Reliability"; }
        }

        protected override void Generate(IReportWriter write)
        {
            if (write == null) throw new ArgumentNullException("write");

            write.Heading("Forss Reliability");
            
            write.UnorderedList("January: Very reliable", "February: like clockwork", "etc") ;
        }

        #endregion
    }
}
