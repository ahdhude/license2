Public Class practice
    Dim q_num As Integer = 1





    Sub ans_load()

        Dim db As New databaseDataSetTableAdapters.AnswerTableAdapter
        ans_1.Text = db.GetData(q_num).Rows(0).Item(1)
        ans_2.Text = db.GetData(q_num).Rows(1).Item(1)
        ans_3.Text = db.GetData(q_num).Rows(2).Item(1)
        ans_4.Text = db.GetData(q_num).Rows(3).Item(1)

    End Sub






    Sub question_load()

        If q_num = 4 Then ''USE form what happens when all question displayed

            End
        End If

        label_numb.Content = q_num
        Dim db As New databaseDataSetTableAdapters.QuestionTableAdapter
        question.Text = db.GetData(q_num).Rows(0).Item(1)



    End Sub

    Private Sub button_Click(sender As Object, e As RoutedEventArgs) Handles button.Click
        q_num = q_num + 1
        Call question_load()
        Call ans_load()


    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Call question_load()
        Call ans_load()


    End Sub
End Class
