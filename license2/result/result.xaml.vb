Public Class result
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        label_mandotory.Content = score.majubooru_score_count
        label_gannon_total.Content = score.gavaidhu_quest_count
        label_curtosy_total.Content = score.adhabu_quest_count
        label_nishaan_total.Content = score.nishaan_quest_count

        label_gaanoon_score.Content = score.gavaidhu_score_count
        label_curtosy_score.Content = score.adhabu_score_count
        label_nishaan_score.Content = score.nishaan_score_count




        label_overall_score.Content = score.majubooru_score_count + score.gavaidhu_score_count + score.adhabu_score_count + score.nishaan_score_count

        Dim madpercent As Integer


        Dim others As Integer

        Dim overall As Integer

        madpercent = (((score.majubooru_score_count / 5) * 100) / 100) * 25
        label_mandotory_percentage.Content = madpercent




        others = ((((score.gavaidhu_score_count + score.adhabu_score_count + score.nishaan_score_count) / 25) * 100) / 100) * 75
        label_others_percentage.Content = others

        overall = madpercent + others
        label_total_percentage.Content = overall






        If madpercent = 25 And overall >= 75 Then

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
