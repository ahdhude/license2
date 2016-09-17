Imports System.Data
Imports System.IO
Imports System.IO.FileStream
Imports System.Drawing.Imaging
Imports System.Windows.Controls




Public Class exampractice
    Dim q_num As Integer = 1
    Dim cans As String
    Dim slcans As String

    Dim fullscore As Integer
    Dim mandscore As Integer
    Dim finalscore As Integer


    Public Function ansloadx()
        Dim db As New databaseDataSetTableAdapters.AnswerTableAdapter
        ans_1x.Text = db.GetData(q_num).Rows(0).Item(1)
        ans_2x.Text = db.GetData(q_num).Rows(1).Item(1)
        ans_3x.Text = db.GetData(q_num).Rows(2).Item(1)
        ans_4x.Text = db.GetData(q_num).Rows(3).Item(1)

        loadimageans()

    End Function


    Private Function questionload()
        label.Visibility = Visibility = Visibility.Hidden

        label_numbx.Content = q_num

        Dim db As New databaseDataSetTableAdapters.QuestionTableAdapter
        questionx.Text = db.GetData(q_num).Rows(0).Item(1)

        loadimage()



    End Function

    Private Sub buttonx_Click(sender As Object, e As RoutedEventArgs) Handles buttonx.Click
        If (ans1x.IsChecked) Then

            ans1x.IsChecked = False

        ElseIf (ans2x.IsChecked) Then

            ans2x.IsChecked = False
        ElseIf (ans3x.IsChecked) Then

            ans3x.IsChecked = False
        ElseIf (ans4x.IsChecked) Then

            ans4x.IsChecked = False
        Else


            'if nothing is selected and submit button is pressed

        End If



        q_num = q_num + 1
        If q_num = 5 Then 'whhen all question displayed




            Close()

            Dim wel2 As New welcome
            wel2.Show()



        Else

            Call questionload()
            Call ansloadx()


        End If



    End Sub



    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)

        label.Visibility = Visibility = Visibility.Hidden


    End Sub





    Sub correct()

        label.Visibility = Visibility.Visible




        Dim dt As New databaseDataSetTableAdapters.ScoreTableAdapter

        Dim db As New databaseDataSetTableAdapters.AnswerTableAdapter
        cans = db.GetDataBy(q_num).Rows(0).Item(1)



        If cans = slcans Then

            label.Foreground = Brushes.Blue

            label.Content = "ރަގަޅު"





        Else
            label.Foreground = Brushes.Red

            label.Content = "ނުބައި"

        End If






    End Sub

    Private Sub ans2x_Checked(sender As Object, e As RoutedEventArgs) Handles ans2x.Checked

        slcans = ans_2x.Text
        Call correct()


    End Sub

    Private Sub ans1x_Checked(sender As Object, e As RoutedEventArgs) Handles ans1x.Checked
        slcans = ans_1x.Text
        Call correct()

    End Sub

    Private Sub ans3x_Checked(sender As Object, e As RoutedEventArgs) Handles ans3x.Checked
        slcans = ans_3x.Text
        Call correct()
    End Sub

    Private Sub ans4x_Checked(sender As Object, e As RoutedEventArgs) Handles ans4x.Checked
        slcans = ans_4x.Text
        Call correct()
    End Sub


    Sub loadimage()

        Dim imagestring As String
        Dim uri As String = CStr(q_num)

        imagestring = "/license2;component/Resources/" + uri + ".bmp"
        imagestring = imagestring.Trim


        Dim uriSource = New Uri(imagestring, UriKind.Relative)

        question_imagex.Source = New BitmapImage(uriSource)


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

    Private Sub Window_Loaded_1(sender As Object, e As RoutedEventArgs)
        Call questionload()
        Call ansloadx()
    End Sub
End Class
