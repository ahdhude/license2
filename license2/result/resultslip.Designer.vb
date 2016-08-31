<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class resultslip
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.FinalScoreBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.databaseDataSet = New license2.databaseDataSet()
        Me.FinalScoreTableAdapter = New license2.databaseDataSetTableAdapters.FinalScoreTableAdapter()
        Me.ScoreBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ScoreTableAdapter = New license2.databaseDataSetTableAdapters.ScoreTableAdapter()
        CType(Me.FinalScoreBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.databaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ScoreBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.ScoreBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "license2.resultrep.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(575, 292)
        Me.ReportViewer1.TabIndex = 0
        '
        'FinalScoreBindingSource
        '
        Me.FinalScoreBindingSource.DataMember = "FinalScore"
        Me.FinalScoreBindingSource.DataSource = Me.databaseDataSet
        '
        'databaseDataSet
        '
        Me.databaseDataSet.DataSetName = "databaseDataSet"
        Me.databaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FinalScoreTableAdapter
        '
        Me.FinalScoreTableAdapter.ClearBeforeFill = True
        '
        'ScoreBindingSource
        '
        Me.ScoreBindingSource.DataMember = "Score"
        Me.ScoreBindingSource.DataSource = Me.databaseDataSet
        '
        'ScoreTableAdapter
        '
        Me.ScoreTableAdapter.ClearBeforeFill = True
        '
        'resultslip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(575, 292)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "resultslip"
        Me.Text = "resultslip"
        CType(Me.FinalScoreBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.databaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ScoreBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents FinalScoreBindingSource As Forms.BindingSource
    Friend WithEvents databaseDataSet As databaseDataSet
    Friend WithEvents FinalScoreTableAdapter As databaseDataSetTableAdapters.FinalScoreTableAdapter
    Friend WithEvents ScoreBindingSource As Forms.BindingSource
    Friend WithEvents ScoreTableAdapter As databaseDataSetTableAdapters.ScoreTableAdapter
End Class
