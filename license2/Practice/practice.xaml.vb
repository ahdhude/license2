Imports System.Data

Public Class practice
    Dim q_num As Integer = 1
    Dim cans As String
    Dim slcans As String

    Dim fullscore As Integer
    Dim mandscore As Integer
    Dim finalscore As Integer






    Sub ans_load()

        Dim db As New databaseDataSetTableAdapters.AnswerTableAdapter
        ans_1.Text = db.GetData(q_num).Rows(0).Item(1)
        ans_2.Text = db.GetData(q_num).Rows(1).Item(1)
        ans_3.Text = db.GetData(q_num).Rows(2).Item(1)
        ans_4.Text = db.GetData(q_num).Rows(3).Item(1)

    End Sub






    Function question_load()



        label_numb.Content = q_num

        Dim db As New databaseDataSetTableAdapters.QuestionTableAdapter
        question.Text = db.GetData(q_num).Rows(0).Item(1)






    End Function

    Private Sub button_Click(sender As Object, e As RoutedEventArgs) Handles button.Click
        If (ans1.IsChecked) Then
            slcans = ans_1.Text
            ans1.IsChecked = False

        ElseIf (ans2.IsChecked) Then
            slcans = ans_2.Text
            ans2.IsChecked = False
        ElseIf (ans3.IsChecked) Then
            slcans = ans_3.Text
            ans3.IsChecked = False
        ElseIf (ans4.IsChecked) Then
            slcans = ans_4.Text
            ans4.IsChecked = False
        Else
            MsgBox("please select something")
            Exit Sub

        End If



        q_num = q_num + 1
        If q_num = 5 Then 'whhen all question displayed
            Call correct()
            Call updatefinalscore()

            Close()
            Dim scoresheet As New result
            scoresheet.Show()

        Else
            Call correct()
            Call question_load()
            Call ans_load()


        End If





    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)





        Call data_score_clear()


        Call question_load()
        Call ans_load()


    End Sub








    Sub correct()

        q_num = q_num - 1


        Dim dt As New databaseDataSetTableAdapters.ScoreTableAdapter

        Dim db As New databaseDataSetTableAdapters.AnswerTableAdapter
        cans = db.GetDataBy(q_num).Rows(0).Item(1)



        If cans = slcans Then
            dt.UpdateQuery(1, q_num, customer.selected_id, q_num)






        Else
            dt.UpdateQuery(0, q_num, customer.selected_id, q_num)


        End If


        q_num = q_num + 1



    End Sub


    Private Sub stack_ans_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles stack_ans.MouseLeftButtonDown


    End Sub

    Private Sub ans1_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs)



    End Sub

    Private Sub ans2_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles ans2.MouseLeftButtonDown

    End Sub

    Private Sub ans3_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles ans3.MouseLeftButtonDown

    End Sub

    Private Sub ans4_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles ans4.MouseLeftButtonDown

    End Sub

    Sub updatefinalscore()


        Dim dt As New databaseDataSetTableAdapters.ScoreTableAdapter





        fullscore = ((dt.GetDataBy1(customer.selected_id).Count / 4) * 100)


        mandscore = (((dt.GetDataBy21(customer.selected_id).Rows.Count / 2) * 100) / 100) * 25


        finalscore = dt.GetDataBy1(customer.selected_id).Rows.Count - dt.GetDataBy21(customer.selected_id).Rows.Count


        score.totscore = fullscore
        score.mandscore = mandscore
        score.ansscore = ((finalscore / 2) * 100) / 100 * 75




        Dim pass As New databaseDataSetTableAdapters.FinalScoreTableAdapter




        If mandscore = 25 And finalscore >= 75 Then




            pass.Insert(customer.cst_id, finalscore, 1, customer.datetime)
        Else

            pass.Insert(customer.cst_id, finalscore, 0, customer.datetime)



        End If






    End Sub



    Sub data_score_clear()






    End Sub

End Class
