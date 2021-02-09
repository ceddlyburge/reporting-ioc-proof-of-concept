using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reporting.Base;
using System.IO;

namespace Reporting.WordReportWriter
{
    // Preferably this would write directly to a file, rather than interact with word through com. I don't know how styles / templates work when doing this but I thought I would include the template to demonstrate the principal
    public class WordReportWriter : IReportWriter
    {
        protected readonly IWordReportConfiguration _configuration;

        public WordReportWriter(IWordReportConfiguration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            _configuration = configuration;
        }

        public void Begin() 
        { 
            Write("TEMPLATE: " + _configuration.WordTemplate); // this line is a placeholder for opening the template
        }

        public void End() { }

        protected void Write(string text)
        {
            if (_configuration.Destination == null) throw new ArgumentNullException("_configuration.Destination");

            _configuration.Destination.WriteLine(text); // obviously this should really write to word file format
        }

        #region IReportWriter Members

        public string MimeType { get { return "Word"; } }

        public string Name { get { return "Microsoft Word document"; } }

        public void Heading(string heading)
        {
            Write("HEADING: " + heading);
        }

        public void UnorderedList(params string[] unorderedList)
        {
            foreach (var item in unorderedList) Write(" - " + item);
        }

        #endregion
    }
}
