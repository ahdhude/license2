Public Class result
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        label_mandotory.Content = score.mandscorecount
        label_overall.Content = score.anscorecount + score.mandscorecount
        label_rules.Content = score.anscorecount

        If score.mandscore = 25 And score.totscore >= 75 Then

            label_pass.Content = "PASS"


        Else
            label_pass.Foreground = Brushes.Red

            label_pass.Content = "FAIL"



        End If



        Dim atoll As String
        Dim island As String
        Dim inputid As String = customer.selected_id

        Dim cust As New databaseDataSetTableAdapters.customerTableAdapter



        label_name.Content = cust.GetcustInfo(inputid).Rows(0).Item(1)
        label_address.Content = cust.GetcustInfo(inputid).Rows(0).Item(3)
        atoll = cust.GetcustInfo(inputid).Rows(0).Item(8)
        island = cust.GetcustInfo(inputid).Rows(0).Item(9)
        label_island.Content = atoll & " " & island

        score.name = cust.GetcustInfo(inputid).Rows(0).Item(1)
        score.address = cust.GetcustInfo(inputid).Rows(0).Item(3)
        score.atollis = atoll & " " & island


    End Sub

    Private Sub button_print_Click(sender As Object, e As RoutedEventArgs) Handles button_print.Click
        Dim slip As New resultslip
        slip.Show()
    End Sub

    Private Sub Window_Closed(sender As Object, e As EventArgs)

        Dim wel As New welcome
        wel.Show()



    End Sub
End Class
