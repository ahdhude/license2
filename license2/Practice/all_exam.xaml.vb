Public Class all_exam
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs) Handles MyBase.Loaded

        Dim DatabaseDataSet As license2.databaseDataSet = CType(Me.FindResource("DatabaseDataSet"), license2.databaseDataSet)
        'Load data into the table DataTable3. You can modify this code as needed.
        Dim DatabaseDataSetDataTable3TableAdapter As license2.databaseDataSetTableAdapters.DataTable3TableAdapter = New license2.databaseDataSetTableAdapters.DataTable3TableAdapter()
        DatabaseDataSetDataTable3TableAdapter.Fill(DatabaseDataSet.DataTable3)
        Dim DataTable3ViewSource As System.Windows.Data.CollectionViewSource = CType(Me.FindResource("DataTable3ViewSource"), System.Windows.Data.CollectionViewSource)
        DataTable3ViewSource.View.MoveCurrentToFirst()
    End Sub
End Class
