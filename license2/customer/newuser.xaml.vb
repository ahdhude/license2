Imports System.Windows.Controls
Imports System.Windows.Input

Public Class newuser
    Dim island_id As Integer

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
        AtollViewSource.View.MoveCurrentToFirst()
        'Load data into the table Island. You can modify this code as needed.
        Dim DatabaseDataSetIslandTableAdapter As license2.databaseDataSetTableAdapters.IslandTableAdapter = New license2.databaseDataSetTableAdapters.IslandTableAdapter()
        DatabaseDataSetIslandTableAdapter.Fill(DatabaseDataSet.Island)
        Dim IslandViewSource As System.Windows.Data.CollectionViewSource = CType(Me.FindResource("IslandViewSource"), System.Windows.Data.CollectionViewSource)
        IslandViewSource.View.MoveCurrentToFirst()
    End Sub

    Private Sub AtollComboBox_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles AtollComboBox.SelectionChanged


    End Sub

    Private Sub AtollComboBox_LostKeyboardFocus(sender As Object, e As KeyboardFocusChangedEventArgs) Handles AtollComboBox.LostKeyboardFocus
        combo_island.Items.Clear()
        Dim atoll_id As Integer
        atoll_id = AtollComboBox.SelectedValue
        Dim island As String
        Dim atollcount As Integer
        Dim index As Integer = 0



        Dim db As New databaseDataSetTableAdapters.IslandTableAdapter

        atollcount = db.GetDataBy(atoll_id).Count


        Do
            island = db.GetDataBy(atoll_id).Rows(index).Item(1)
            combo_island.Items.Add(island)


            index += 1
        Loop Until index = atollcount

    End Sub

    Private Sub combo_island_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles combo_island.SelectionChanged




    End Sub




    Function getislandid()

        Dim island As String

        island = combo_island.SelectedItem.ToString

        Dim db As New databaseDataSetTableAdapters.IslandTableAdapter
        island_id = db.IslandidGetDataBy(combo_island.Text).Rows(0).Item(0)



    End Function

    Private Sub btn_submit_Click(sender As Object, e As RoutedEventArgs) Handles btn_submit.Click
        Call customervalidate()

    End Sub



    Function addcustomer()
        Call getislandid()
        Dim db As New databaseDataSetTableAdapters.customerTableAdapter


        db.InsertQuery(textbox_name.Text, textbox_idnum.Text, textbox_address.Text, DOB.Text, textBox_phone.Text, textbox_linum.Text, island_id)




        Call customervalidate()
        'Dim db As New databaseDataSetTableAdapters.customerTableAdapter
        'db.InsertQuery(textbox_name.Text, textbox_idnum.Text, textbox_address.Text, DOB.Text, textBox_phone.Text, textbox_idnum.Text, island_id)

        'MsgBox("Customer added")
    End Function


    Function customervalidate()
        If textbox_name.Text = "" Then
            textbox_name.Foreground = Brushes.Red
            icon_name.Foreground = Brushes.Red
        End If



        For Each ctrl As Control In mygrid.Children

            If TypeOf ctrl Is TextBox Then
                Dim tb As TextBox = TryCast(ctrl, TextBox)
                MsgBox(tb.Text)

            End If
        Next


    End Function




    Function defaultfields()



    End Function




    Private Sub textBox_TargetUpdated(sender As Object, e As DataTransferEventArgs)

    End Sub

    Private Sub textbox_name_TextChanged(sender As Object, e As TextChangedEventArgs) Handles textbox_name.TextChanged

    End Sub
End Class
