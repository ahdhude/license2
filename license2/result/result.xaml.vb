Public Class result
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        label_mandotory.Content = score.mandscore
        label_overall.Content = score.totscore
        label_rules.Content = score.ansscore

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


    End Sub
End Class
