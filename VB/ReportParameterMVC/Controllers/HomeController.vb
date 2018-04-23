Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports ReportParameterMVC.Reports

Namespace ReportParameterMVC.Controllers
	Public Class HomeController
		Inherits Controller
		Public Function Index(ByVal parameterOrderID As Nullable(Of Integer)) As ActionResult
            'ViewBag.Message = "Report Parameter Example"
			' Add a report to a view data.
			Dim Report As New XtraReport1()
			ViewData("Report") = Report
			If Not parameterOrderID.HasValue Then
				parameterOrderID = 10248 ' default parameter value
			End If

			Dim param As DevExpress.XtraReports.Parameters.Parameter = Report.Parameters("OrderID")
			If param IsNot Nothing Then
				param.Value = Convert.ToInt32(parameterOrderID)
			End If

			Return View()
		End Function


		Public Function ReportViewerPartial() As ActionResult
			ViewData("Report") = New ReportParameterMVC.Reports.XtraReport1()
			Return PartialView("ReportViewerPartial")
		End Function

		Public Function ExportReportViewer() As ActionResult
			Return DevExpress.Web.Mvc.ReportViewerExtension.ExportTo(New ReportParameterMVC.Reports.XtraReport1())
		End Function
	End Class
End Namespace
