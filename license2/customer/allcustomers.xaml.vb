Public Class allcustomers
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs) Handles MyBase.Loaded

        Dim DatabaseDataSet As license2.databaseDataSet = CType(Me.FindResource("DatabaseDataSet"), license2.databaseDataSet)
        'Load data into the table DataTable1. You can modify this code as needed.
        Dim DatabaseDataSetDataTable1TableAdapter As license2.databaseDataSetTableAdapters.DataTable1TableAdapter = New license2.databaseDataSetTableAdapters.DataTable1TableAdapter()
        DatabaseDataSetDataTable1TableAdapter.Fill(DatabaseDataSet.DataTable1)
        Dim DataTable1ViewSource As System.Windows.Data.CollectionViewSource = CType(Me.FindResource("DataTable1ViewSource"), System.Windows.Data.CollectionViewSource)
        DataTable1ViewSource.View.MoveCurrentToFirst()
    End Sub
End Class
