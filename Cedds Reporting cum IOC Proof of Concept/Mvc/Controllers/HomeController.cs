using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Reporting.Base;
using System.IO;
using Reporting.MvcUI.Models;

namespace Reporting.MvcUI.Controllers
{
    // this creates a circular dependency as this contorller needs reports but the reports need the report configuration.
    [HandleError]
    public class HomeController : Controller
    {
        protected readonly IEnumerable<Report> _reports;
        protected readonly IEnumerable<IReportWriter> _writers;
        protected readonly ReportConfiguration _configureReport;
        protected readonly ReportGenerator _generateReport;


        public HomeController(IEnumerable<Report> reports, IEnumerable<IReportWriter> writers, ReportConfiguration configureReport, ReportGenerator generateReport)
        {
            if (reports == null) throw new ArgumentNullException("reports");
            if (writers == null) throw new ArgumentNullException("writers");
            if (configureReport == null) throw new ArgumentNullException("configureReport");
            if (generateReport == null) throw new ArgumentNullException("generateReport");

            _reports = reports;
            _writers = writers;
            _configureReport = configureReport;
            _generateReport = generateReport;
            
        }

        public ActionResult Index()
        {
            return View(new ReportModel() { Reports = _reports.Select(r => new SelectListItem() { Text = r.Name, Value = r.Name }), Writers = _writers.Select(w => new SelectListItem() { Text = w.Name, Value = w.Name }) });
        }

        public ActionResult CreateReport(string reportName, string writerName, string wordTemplate)
        {
            var report = _reports.Where(r => r.Name == reportName).Single();
            var writer = _writers.Where(w => w.Name == writerName).Single();

            var stream = new MemoryStream();
            var streamWriter = new StreamWriter(stream);

            // this relies on the instance of _configureReport being the same as the instance that the report writers get
            // I am not sure if this is particularly ideal and it might have threading issues. We could use the per request 
            // lifestyle which would work if threading was an issue.
            _configureReport.ConfigureReport(streamWriter, wordTemplate);
            _generateReport.GenerateReport(report, writer);

            streamWriter.Flush();
            stream.Seek(0, SeekOrigin.Begin);

            return new FileStreamResult(stream, writer.MimeType);
        }

        public ActionResult About()
        {
            return View();
        }

    }
}
