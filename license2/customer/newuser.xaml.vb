Public Class newuser
    Private Sub btn_close_Click(sender As Object, e As RoutedEventArgs) Handles btn_close.Click
        Me.Close()




    End Sub

    Private Sub DatePicker_GotFocus(sender As Object, e As RoutedEventArgs)
        DOB.IsDropDownOpen = True
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)


        Dim DatabaseDataSet As license2.databaseDataSet = CType(Me.FindResource("DatabaseDataSet"), license2.databaseDataSet)
        'Load data into the table Atoll. You can modify this code as needed.
        Dim DatabaseDataSetAtollTableAdapter As license2.databaseDataSetTableAdapters.AtollTableAdapter = New license2.databaseDataSetTableAdapters.AtollTableAdapter()
        DatabaseDataSetAtollTableAdapter.Fill(DatabaseDataSet.Atoll)
        Dim AtollViewSource As System.Windows.Data.CollectionViewSource = CType(Me.FindResource("AtollViewSource"), System.Windows.Data.CollectionViewSource)
        AtollViewSource.View.MoveCurrentToFirst
    End Sub





End Class
