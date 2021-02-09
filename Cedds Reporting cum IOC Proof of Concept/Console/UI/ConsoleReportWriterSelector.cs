using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reporting.Base;

namespace Reporting.ConsoleUI
{
    public class ConsoleReportWriterSelector : IReportWriterSelector
    {
        protected readonly IEnumerable<IReportWriter> _writers;

        public ConsoleReportWriterSelector(IEnumerable<Reporting.Base.IReportWriter> writers)
        {
            if (writers == null) throw new ArgumentNullException("writers");

            _writers = writers;
        }

        #region IReportSelector Members

        public IReportWriter Select()
        {
            int i = 1;
            Console.WriteLine("Select Writer") ;
            foreach (var writer in _writers) 
            {
                Console.WriteLine(i.ToString() + " " + writer.Name);
                i++;
            }

            if (int.TryParse(Console.ReadLine(), out i))
            {
                return _writers.ToArray()[i - 1];
            }
            else
            {
                return _writers.First();
            }
        }

        #endregion
    }
}
