using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Reporting.Base;

namespace Reporting.ConsoleReportWriter
{
    public class TextReportWriter : Reporting.Base.IReportWriter
    {
        protected readonly IReportConfiguration _configuration;

       public TextReportWriter(IReportConfiguration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            _configuration = configuration;
        }

        protected void Write(string text)
        {
            if (_configuration.Destination == null) throw new ArgumentNullException("_configuration.Destination");

            _configuration.Destination.WriteLine(text);
        }

        #region IReportWriter Members

        public string MimeType { get { return "text/plain"; } }

        public string Name { get { return "Text"; } }

        public void Begin() { }

        public void End() { }

        public void Heading(string heading)
        {
            Write("HEADING: " + heading); 
        }

        public void UnorderedList(params string [] unorderedList)
        {
            foreach(var item in unorderedList) Write(" - " + item);
        }

        #endregion
    }
}
