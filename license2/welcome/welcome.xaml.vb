Imports System.Windows.Media.Effects

Public Class welcome
    Public selected_id As String

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)

        Dim DatabaseDataSet As license2.databaseDataSet = CType(Me.FindResource("DatabaseDataSet"), license2.databaseDataSet)
        'Load data into the table customer. You can modify this code as needed.
        Dim DatabaseDataSetcustomerTableAdapter As license2.databaseDataSetTableAdapters.customerTableAdapter = New license2.databaseDataSetTableAdapters.customerTableAdapter()
        DatabaseDataSetcustomerTableAdapter.Fill(DatabaseDataSet.customer)
        Dim CustomerViewSource As System.Windows.Data.CollectionViewSource = CType(Me.FindResource("CustomerViewSource"), System.Windows.Data.CollectionViewSource)
        CustomerViewSource.View.MoveCurrentToFirst()
        Id_cardComboBox.Text = Nothing
        stack_customerinfo.Visibility = System.Windows.Visibility.Hidden





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

    Sub custinfo()
        stack_customerinfo.Visibility = System.Windows.Visibility.Visible
        Dim inputid As String

        Dim atoll As String
        Dim island As String


        inputid = Id_cardComboBox.Text

        If inputid = Nothing Then
            Exit Sub
        End If

        Dim db As New databaseDataSetTableAdapters.customerTableAdapter
        label_name.Content = db.GetcustInfo(inputid).Rows(0).Item(1)
        label_address.Content = db.GetcustInfo(inputid).Rows(0).Item(3)
        atoll = db.GetcustInfo(inputid).Rows(0).Item(8)
        island = db.GetcustInfo(inputid).Rows(0).Item(9)
        label_island.Content = atoll & " " & island
        label_contact.Content = "+960 " & db.GetcustInfo(inputid).Rows(0).Item(5)





        'Dim db As New databaseDataSetTableAdapters.customerTableAdapter
        'idnum = db.GetData().Rows(0).Item(2)


    End Sub




    Private Sub Id_cardComboBox_DropDownClosed(sender As Object, e As EventArgs) Handles Id_cardComboBox.DropDownClosed
        Call custinfo()

    End Sub

    Private Sub btn_practice_Click(sender As Object, e As RoutedEventArgs) Handles btn_practice.Click
        If Id_cardComboBox.Text = Nothing Then

            Id_cardComboBox.Foreground = Brushes.Red
            Exit Sub


        End If



        selected_id = Id_cardComboBox.Text
        Dim f As practice = New practice
        f.Show()



    End Sub

    Private Sub Id_cardComboBox_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles Id_cardComboBox.SelectionChanged

    End Sub
End Class
