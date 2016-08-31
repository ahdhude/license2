Imports Microsoft.Reporting.WinForms

Public Class resultslip
    Private Sub resultslip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'databaseDataSet.FinalScore' table. You can move, or remove it, as needed.

        Me.ScoreTableAdapter.Fill(Me.databaseDataSet.Score)


        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("NameParameter", score.name, True))
        paramList.Add(New ReportParameter("Address", score.address, True))
        paramList.Add(New ReportParameter("island", score.atollis, True))
        paramList.Add(New ReportParameter("date", Today, True))
        paramList.Add(New ReportParameter("mandatory", score.mandscore, True))
        paramList.Add(New ReportParameter("other", score.totscore, True))
        Me.ReportViewer1.LocalReport.SetParameters(paramList)




        Me.ReportViewer1.RefreshReport()


    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load

    End Sub
End Class