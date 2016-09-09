Imports System.Data
Imports System.IO
Imports System.IO.FileStream
Imports System.Drawing.Imaging
Imports System.Windows.Controls
Imports System.Threading
Imports System.Windows.Threading

Public Class practice

    Private timer As DispatcherTimer
    Private i As Integer = 1800
    Dim format As String = " hh:mm:ss"


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

        loadimageans()


    End Sub






    Function question_load()



        label_numb.Content = q_num

        Dim db As New databaseDataSetTableAdapters.QuestionTableAdapter
        question.Text = db.GetData(q_num).Rows(0).Item(1)

        loadimage()







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

        Dim dt As DispatcherTimer = New DispatcherTimer()
        AddHandler dt.Tick, AddressOf dispatcherTimer_Tick
        dt.Interval = New TimeSpan(0, 0, 1)
        dt.Start()




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







        Else



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

        Dim mandscorecount As Integer = dt.GetDataBy21(customer.selected_id).Rows.Count
        Dim otherscorecount As Integer = dt.GetDataBy1(customer.selected_id).Count - dt.GetDataBy21(customer.selected_id).Rows.Count



        fullscore = ((dt.GetDataBy1(customer.selected_id).Count / 4) * 100)


        mandscore = (((dt.GetDataBy21(customer.selected_id).Rows.Count / 2) * 100) / 100) * 25


        finalscore = dt.GetDataBy1(customer.selected_id).Rows.Count + dt.GetDataBy21(customer.selected_id).Rows.Count


        score.totscore = fullscore
        score.mandscore = mandscore
        score.ansscore = ((finalscore / 2) * 100) / 100 * 75

        score.mandscorecount = mandscorecount
        score.anscorecount = otherscorecount





        Dim pass As New databaseDataSetTableAdapters.FinalScoreTableAdapter




        If mandscore = 25 And finalscore >= 75 Then




            pass.Insert(customer.cst_id, finalscore, 1, customer.datetime, mandscorecount, otherscorecount)
        Else

            pass.Insert(customer.cst_id, finalscore, 0, customer.datetime, mandscorecount, otherscorecount)



        End If






    End Sub



    Sub data_score_clear()






    End Sub



    Sub loadimage()

        Dim imagestring As String
        Dim uri As String = CStr(q_num)

        imagestring = "/license2;component/Resources/" + uri + ".bmp"
        imagestring = imagestring.Trim


        Dim uriSource = New Uri(imagestring, UriKind.Relative)

        question_image.Source = New BitmapImage(uriSource)


    End Sub



    Sub loadimageans()

        Dim ans1 As String
        Dim ans2 As String
        Dim ans3 As String
        Dim ans4 As String

        Dim uri As String = CStr(q_num)

        ans1 = "/license2;component/Resources/" + uri + "_a1" + ".bmp"
        ans1 = ans1.Trim

        ans2 = "/license2;component/Resources/" + uri + "_a2" + ".bmp"
        ans2 = ans2.Trim

        ans3 = "/license2;component/Resources/" + uri + "_a3" + ".bmp"
        ans3 = ans3.Trim

        ans4 = "/license2;component/Resources/" + uri + "_a4" + ".bmp"
        ans4 = ans4.Trim


        Dim an1 = New Uri(ans1, UriKind.Relative)
        Dim an2 = New Uri(ans2, UriKind.Relative)
        Dim an3 = New Uri(ans3, UriKind.Relative)
        Dim an4 = New Uri(ans4, UriKind.Relative)

        image_1.Source = New BitmapImage(an1)
        image_2.Source = New BitmapImage(an2)
        image_3.Source = New BitmapImage(an3)
        image_4.Source = New BitmapImage(an4)



    End Sub










    Public Sub dispatcherTimer_Tick(ByVal sender As Object, ByVal e As EventArgs)

        i = i - 1
        If i = 0 Then

            Me.stack_ans.IsEnabled = False
            MsgBox("Time Up!")
            Me.Close()






        End If

        Dim hms = TimeSpan.FromSeconds(i)
        Dim h = hms.Hours.ToString
        Dim m = hms.Minutes.ToString
        Dim s = hms.Seconds.ToString
        mytextBlock.Text = h + ":" + m + ":" + s




    End Sub

End Class
