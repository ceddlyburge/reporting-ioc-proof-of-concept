using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reporting.Base
{
    public interface IReportWriter
    {
        string Name { get; }
        string MimeType { get; }

        void Begin();
        void End();

        // these could have guards to make sure Begin has been called
        void Heading(string heading);
        void UnorderedList(params string [] unorderedList);
        // plus stuff for tables and graphs and all that
    }
}
