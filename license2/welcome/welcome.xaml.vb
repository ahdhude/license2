Imports System.Windows.Media.Effects

Public Class welcome
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)

        Dim DatabaseDataSet As license2.databaseDataSet = CType(Me.FindResource("DatabaseDataSet"), license2.databaseDataSet)
        'Load data into the table customer. You can modify this code as needed.
        Dim DatabaseDataSetcustomerTableAdapter As license2.databaseDataSetTableAdapters.customerTableAdapter = New license2.databaseDataSetTableAdapters.customerTableAdapter()
        DatabaseDataSetcustomerTableAdapter.Fill(DatabaseDataSet.customer)
        Dim CustomerViewSource As System.Windows.Data.CollectionViewSource = CType(Me.FindResource("CustomerViewSource"), System.Windows.Data.CollectionViewSource)
        CustomerViewSource.View.MoveCurrentToFirst()
    End Sub

    Private Sub PopupBox_OnOpened(sender As Object, e As RoutedEventArgs)
        Console.WriteLine("Just making sure the popup has opened.")
    End Sub

    Private Sub PopupBox_OnClosed(sender As Object, e As RoutedEventArgs)
        Console.WriteLine("Just making sure the popup has closed.")
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim x As BlurEffect = New BlurEffect
        x.Radius = 4

        Me.Effect = x

        Dim f As newuser = New newuser
        f.ShowDialog()






    End Sub

    Private Sub Button_GotFocus(sender As Object, e As RoutedEventArgs)

    End Sub

    Private Sub Window_MouseMove(sender As Object, e As MouseEventArgs)
        Me.Effect = Nothing

    End Sub
End Class
