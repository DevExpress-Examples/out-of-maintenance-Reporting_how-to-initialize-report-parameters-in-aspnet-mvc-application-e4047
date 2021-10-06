Imports System
Imports System.Web.Mvc
Imports ReportParameterMVC.Reports

Namespace ReportParameterMVC.Controllers

    Public Class HomeController
        Inherits Controller

        Public Function Index(ByVal parameterOrderID As Integer?) As ActionResult
            ViewBag.Message = "Report Parameter Example"
            ' Add a report to a view data.
            Dim Report As XtraReport1 = New XtraReport1()
            ViewData("Report") = Report
            If parameterOrderID Is Nothing Then parameterOrderID = 10248 ' default parameter value
            Dim param As DevExpress.XtraReports.Parameters.Parameter = Report.Parameters("OrderID")
            If param IsNot Nothing Then param.Value = Convert.ToInt32(parameterOrderID)
            Return View()
        End Function

        Public Function ReportViewerPartial() As ActionResult
            ViewData("Report") = New XtraReport1()
            Return PartialView("ReportViewerPartial")
        End Function

        Public Function ExportReportViewer() As ActionResult
            Return DevExpress.Web.Mvc.ReportViewerExtension.ExportTo(New XtraReport1())
        End Function
    End Class
End Namespace
