using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReportParameterMVC.Models;
using ReportParameterMVC.Reports;

namespace ReportParameterMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? parameterOrderID)
        {
            ViewBag.Message = "Report Parameter Example";
            // Add a report to a view data.
            XtraReport1 Report = new XtraReport1();
            ViewData["Report"] = Report;
            if (parameterOrderID == null)
                parameterOrderID = 10248; // default parameter value

            DevExpress.XtraReports.Parameters.Parameter param = Report.Parameters["OrderID"];
            if (param != null)
                param.Value = Convert.ToInt32(parameterOrderID);

            return View();
        }


        public ActionResult ReportViewerPartial()
        {
            ViewData["Report"] = new ReportParameterMVC.Reports.XtraReport1();
            return PartialView("ReportViewerPartial");
        }

        public ActionResult ExportReportViewer()
        {
            return DevExpress.Web.Mvc.ReportViewerExtension.ExportTo(new ReportParameterMVC.Reports.XtraReport1());
        }
    }
}
