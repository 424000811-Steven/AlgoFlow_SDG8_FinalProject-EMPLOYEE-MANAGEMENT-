<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.AttendanceDBDataSet1 = New algoflow_project.AttendanceDBDataSet()
        Me.AttendanceTableAdapter1 = New algoflow_project.AttendanceDBDataSetTableAdapters.AttendanceTableAdapter()
        CType(Me.AttendanceDBDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "algoflow_project.AttendanceReport.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(-4, 12)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(807, 373)
        Me.ReportViewer1.TabIndex = 0
        '
        'AttendanceDBDataSet1
        '
        Me.AttendanceDBDataSet1.DataSetName = "AttendanceDBDataSet"
        Me.AttendanceDBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AttendanceTableAdapter1
        '
        Me.AttendanceTableAdapter1.ClearBeforeFill = True
        '
        'ReportForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "ReportForm"
        Me.Text = "ReportForm.vb"
        CType(Me.AttendanceDBDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents AttendanceDBDataSet1 As AttendanceDBDataSet
    Friend WithEvents AttendanceTableAdapter1 As AttendanceDBDataSetTableAdapters.AttendanceTableAdapter
End Class
