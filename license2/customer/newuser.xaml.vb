﻿Imports System.Windows.Controls
Imports System.Windows.Input
Imports System.Windows.Media.Effects

Public Class newuser
    Dim island_id As Integer
    Dim idnum As String
    Dim license As String

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
        AtollComboBox.Text = Nothing

    End Sub



    Private Sub AtollComboBox_LostKeyboardFocus(sender As Object, e As KeyboardFocusChangedEventArgs) Handles AtollComboBox.LostKeyboardFocus

        If AtollComboBox.Text = Nothing Then
        Else

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

        End If


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


        db.InsertQuery(textbox_name.Text, textbox_idnum.Text, textbox_address.Text, dob.Text, textBox_phone.Text, license, island_id)
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

        If textbox_address.Text = Nothing Then

            textbox_address.Foreground = Brushes.Red

            If textbox_name.Text = Nothing Then
                textbox_name.Foreground = Brushes.Red
            End If





            If textbox_idnum.Text = Nothing Then
                textbox_idnum.Foreground = Brushes.Red
            End If
            If combo_island.Text = Nothing Then

                combo_island.Foreground = Brushes.Red
            End If

            If AtollComboBox.Text = Nothing Then
                AtollComboBox.Foreground = Brushes.Red

            End If
            If textBox_phone.Text = Nothing Then

                textBox_phone.Foreground = Brushes.Red
            End If

            If dob.Text = Nothing Then
                dob.Foreground = Brushes.Red
            End If
        Else

            Call idvalidate()




        End If




    End Function


    Private Sub textbox_address_GotMouseCapture(sender As Object, e As MouseEventArgs) Handles textbox_address.GotMouseCapture



        textbox_address.Foreground = Brushes.Black





    End Sub

    Private Sub textBox_phone_TextChanged(sender As Object, e As TextChangedEventArgs) Handles textBox_phone.TextChanged

        textBox_phone.Foreground = Brushes.Black



    End Sub

    Private Sub textbox_idnum_GotMouseCapture(sender As Object, e As MouseEventArgs) Handles textbox_idnum.GotMouseCapture

        textbox_idnum.Foreground = Brushes.Black



    End Sub

    Private Sub textbox_linum_GotMouseCapture(sender As Object, e As MouseEventArgs) Handles textbox_linum.GotMouseCapture

        textbox_linum.Foreground = Brushes.Black

    End Sub

    Private Sub textbox_name_GotMouseCapture(sender As Object, e As MouseEventArgs) Handles textbox_name.GotMouseCapture

        textbox_name.Foreground = Brushes.Black

    End Sub

    Private Sub textBox_phone_GotMouseCapture(sender As Object, e As MouseEventArgs) Handles textBox_phone.GotMouseCapture

        textBox_phone.Foreground = Brushes.Black

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
            Call focus_id()

        ElseIf inputid.Count < 7 Then

            Call focus_id()



        Else

            Call addcustomer()




        End If

    End Function



    Function focus_id()

        textbox_idnum.Foreground = Brushes.Red



    End Function

    Private Sub combo_island_GotFocus(sender As Object, e As RoutedEventArgs) Handles combo_island.GotFocus


    End Sub
End Class
