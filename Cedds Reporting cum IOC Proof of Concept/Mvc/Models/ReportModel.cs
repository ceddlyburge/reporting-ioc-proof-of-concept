using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Reporting.Base;
using System.Web.Mvc;

namespace Reporting.MvcUI.Models
{
    public class ReportModel
    {
        public IEnumerable<SelectListItem> Reports;
        public IEnumerable<SelectListItem> Writers;
    }
}