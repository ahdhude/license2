Public Class practice
    Dim q_num As Integer = 1
    Dim cans As String
    Dim slcans As String






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

        Call correct()

        q_num = q_num + 1
        Call question_load()
        Call ans_load()



    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Call question_load()
        Call ans_load()


    End Sub








    Sub correct()

        Dim dt As New databaseDataSetTableAdapters.ScoreTableAdapter

        Dim db As New databaseDataSetTableAdapters.AnswerTableAdapter
        cans = db.GetDataBy(q_num).Rows(0).Item(1)


        If cans = slcans Then
            dt.InsertQuery(True, q_num)

        Else
            dt.InsertQuery(False, q_num)


        End If





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
End Class
