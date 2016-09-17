Imports Infragistics.Win.UltraWinGrid

Public Class allcust
    Private Sub allcust_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DatabaseDataSet.customer' table. You can move, or remove it, as needed.
        Me.CustomerTableAdapter.Fill(Me.DatabaseDataSet.customer)
        'TODO: This line of code loads data into the 'DatabaseDataSet.DataTable2' table. You can move, or remove it, as needed.


    End Sub

    Private Sub CustomerBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles CustomerBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.CustomerBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.DatabaseDataSet)

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click







    End Sub

    Private Sub allcust_FormClosed(sender As Object, e As Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dim wel1 As New welcome
        wel1.Show()


    End Sub
End Class