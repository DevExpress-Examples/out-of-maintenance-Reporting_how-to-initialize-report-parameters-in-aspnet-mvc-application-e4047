Imports System.Drawing
Imports System.ComponentModel
Imports DevExpress.XtraReports.UI

Namespace ReportParameterMVC.Reports

    Public Partial Class XtraReport1
        Inherits DevExpress.XtraReports.UI.XtraReport

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub XtraReport1_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
            ordersTableAdapter.FillByOrderID(dataSet11.Orders, CInt(OrderID.Value))
        End Sub
    End Class
End Namespace
