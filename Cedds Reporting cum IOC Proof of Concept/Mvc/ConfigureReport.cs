using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Reporting.Base;

namespace Reporting.MvcUI
{
    public class ReportConfiguration : IReportConfiguration, IWordReportConfiguration
    {
        protected string _wordTemplate;
        protected TextWriter _reportDestination;
        
        public void ConfigureReport(TextWriter reportDestination, string wordTemplate)
        {
            _wordTemplate = wordTemplate;
            _reportDestination = reportDestination;
        }

        public TextWriter Destination
        {
            get { return _reportDestination; }
        }

        public string WordTemplate
        {
            get { return _wordTemplate; }
        }
    }
}
