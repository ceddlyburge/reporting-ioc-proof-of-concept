using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Reporting.Base;

namespace Reporting.ConsoleUI
{
    public class ConsoleReportConfiguration : IWordReportConfiguration, IReportConfiguration
    {
        #region IWordReportConfiguration Members

        public string WordTemplate
        {
            get 
            {
                Console.WriteLine("Please enter a word template filename: ");
                return Console.ReadLine();
            }
        }

        public TextWriter Destination { get { return Console.Out; } }

        #endregion
    }
}
