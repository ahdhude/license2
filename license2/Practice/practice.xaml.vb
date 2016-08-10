Public Class practice
    Dim q_num As Integer = 1












    Sub question_load()

        If q_num = 4 Then ''USE form what happens when all question displayed

            End
        End If


        Dim db As New databaseDataSetTableAdapters.QuestionTableAdapter
        question.Text = db.GetData(q_num).Rows(0).Item(1)



    End Sub

    Private Sub button_Click(sender As Object, e As RoutedEventArgs) Handles button.Click
        q_num = q_num + 1
        Call question_load()

    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Call question_load()

    End Sub
End Class
