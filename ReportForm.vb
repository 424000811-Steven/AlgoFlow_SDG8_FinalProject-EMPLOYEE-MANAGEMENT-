Imports Microsoft.Reporting.WinForms

Public Class ReportForm

    Private Sub ReportForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim ds As New AttendanceDBDataSet
        Dim ta As New AttendanceDBDataSetTableAdapters.AttendanceTableAdapter

        ta.Fill(ds.Attendance)

        ReportViewer1.LocalReport.DataSources.Clear()

        Dim rds As New ReportDataSource("EmployeeAttendance", ds.Tables("Attendance"))

        ReportViewer1.LocalReport.DataSources.Add(rds)

        ReportViewer1.RefreshReport()

    End Sub

End Class