Imports System.Windows.Controls
Imports System.Windows.Input

Public Class newuser
    Dim island_id As Integer
    Dim idnum As String

    Private Sub btn_close_Click(sender As Object, e As RoutedEventArgs) Handles btn_close.Click
        Me.Close()




    End Sub

    Private Sub DatePicker_GotFocus(sender As Object, e As RoutedEventArgs)

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


        db.InsertQuery(textbox_name.Text, textbox_idnum.Text, textbox_address.Text, dob.Text, textBox_phone.Text, textbox_linum.Text, island_id)
        MsgBox(textbox_name.Text + vbCrLf + textbox_idnum.Text + vbCrLf + textbox_address.Text, Title:="Customer Added")

        For Each ctrl As Control In stack1.Children

            If TypeOf ctrl Is TextBox Then
                Dim tb As TextBox = TryCast(ctrl, TextBox)
                tb.Text = Nothing

            ElseIf TypeOf ctrl Is DatePicker Then
                Dim dp As DatePicker = TryCast(ctrl, DatePicker)
                dp.Text = Nothing


            End If

        Next


        For Each ctrl As Control In stack2.Children

            If TypeOf ctrl Is TextBox Then
                Dim tb As TextBox = TryCast(ctrl, TextBox)
                tb.Text = Nothing

            ElseIf TypeOf ctrl Is ComboBox Then
                Dim cb As ComboBox = TryCast(ctrl, ComboBox)
                cb.Text = Nothing


            End If
        Next



    End Function


    Function customervalidate()


        For Each ctrl As Control In stack1.Children


            If TypeOf ctrl Is TextBox Then
                Dim tb As TextBox = TryCast(ctrl, TextBox)
                If tb.Text = "" Then
                    tb.Foreground = Brushes.Red




                End If

                If textbox_linum.Text = Nothing Then
                    textbox_linum.Text = "0000000"
                End If

            ElseIf TypeOf ctrl Is DatePicker Then
                Dim dp As DatePicker = TryCast(ctrl, DatePicker)
                If dp.Text = "" Then
                    dp.Foreground = Brushes.Red

                End If
            Else

                GoTo Line

            End If



        Next

Line:
        For Each ctrl As Control In stack2.Children

            If TypeOf ctrl Is TextBox Then
                Dim tb As TextBox = TryCast(ctrl, TextBox)
                If tb.Text = "" Then
                    tb.Foreground = Brushes.Red


                End If
            ElseIf TypeOf ctrl Is ComboBox Then

                Dim combo As ComboBox = TryCast(ctrl, ComboBox)
                Try
                    If combo.SelectedItem = "" Then


                        combo.Foreground = Brushes.Red




                    End If

                Catch ex As Exception

                End Try
            Else

                Call idvalidate()

            End If



        Next



    End Function


    Private Sub textbox_address_GotMouseCapture(sender As Object, e As MouseEventArgs) Handles textbox_address.GotMouseCapture

        If textbox_address.Text = "please enter a valid item" Then
            textbox_address.Clear()
            textbox_address.Foreground = Brushes.Black
        Else

        End If
    End Sub

    Private Sub textBox_phone_TextChanged(sender As Object, e As TextChangedEventArgs) Handles textBox_phone.TextChanged
        If textBox_phone.Text = "please enter a valid item" Then
            textBox_phone.Clear()
            textBox_phone.Foreground = Brushes.Black
        Else

        End If
    End Sub

    Private Sub textbox_idnum_GotMouseCapture(sender As Object, e As MouseEventArgs) Handles textbox_idnum.GotMouseCapture
        If textbox_idnum.Text = "please enter a valid item" Then
            textbox_idnum.Clear()
            textbox_idnum.Foreground = Brushes.Black
        Else

        End If
    End Sub

    Private Sub textbox_linum_GotMouseCapture(sender As Object, e As MouseEventArgs) Handles textbox_linum.GotMouseCapture
        If textbox_linum.Text = "please enter a valid item" Then
            textbox_linum.Clear()
            textbox_linum.Foreground = Brushes.Black
        Else

        End If
    End Sub

    Private Sub textbox_name_GotMouseCapture(sender As Object, e As MouseEventArgs) Handles textbox_name.GotMouseCapture
        If textbox_name.Text = "please enter a valid item" Then
            textbox_name.Clear()
            textbox_name.Foreground = Brushes.Black
        Else

        End If
    End Sub

    Private Sub textBox_phone_GotMouseCapture(sender As Object, e As MouseEventArgs) Handles textBox_phone.GotMouseCapture
        If textBox_phone.Text = "please enter a valid item" Then
            textBox_phone.Clear()
            textBox_phone.Foreground = Brushes.Black
        Else

        End If
    End Sub

    Private Sub combo_island_GotMouseCapture(sender As Object, e As MouseEventArgs) Handles combo_island.GotMouseCapture
        combo_island.Foreground = Brushes.Black
    End Sub

    Private Sub dob_GotMouseCapture(sender As Object, e As MouseEventArgs) Handles dob.GotMouseCapture
        dob.Foreground = Brushes.Black
    End Sub


    Function idvalidate()

        Dim inputid As String

        inputid = textbox_idnum.Text

        Dim db As New databaseDataSetTableAdapters.customerTableAdapter
        idnum = db.GetData().Rows(0).Item(2)
        If inputid = idnum Then

            MsgBox("CUSTOMER ALREADY EXIST")

        Else

            Call addcustomer()




        End If

    End Function
End Class
