Imports System.Drawing
Imports System.Windows.Forms

Public Class QandA
    Private Sub QandA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DatabaseDataSet.DataTable4' table. You can move, or remove it, as needed.
        Me.DataTable4TableAdapter.Fill(Me.DatabaseDataSet.DataTable4)
        'TODO: This line of code loads data into the 'DatabaseDataSet.DataTable4' table. You can move, or remove it, as needed.
        Me.DataTable4TableAdapter.Fill(Me.DatabaseDataSet.DataTable4)
        'TODO: This line of code loads data into the 'databaseDataSet.DataTable4' table. You can move, or remove it, as needed.
        Me.DataTable4TableAdapter.Fill(Me.DatabaseDataSet.DataTable4)

        Me.Focus()




    End Sub


End Class