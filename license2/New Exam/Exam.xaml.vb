Imports System.Data
Imports System.IO
Imports System.IO.FileStream
Imports System.Drawing.Imaging
Imports System.Windows.Controls
Imports System.Threading
Imports System.Windows.Threading

Public Class Exam

    Private timer As DispatcherTimer
    Private i As Integer = 1800
    Dim format As String = " hh:mm:ss"
    Dim q_label As Integer = 1


    Dim q_num As Integer = 1
    Dim cans As String
    Dim slcans As String
    Dim sltru As String = "True"
    Dim itru As String


    Dim fullscore As Integer
    Dim mandscore As Integer
    Dim finalscore As Integer

    Dim finalarray(29) As Integer
    Dim mandarray(4) As Integer

    Dim randomarray() As Integer
    Dim rand_q_num As Integer




    Sub load_random_quest()

        Call addlistbox()
        Call remover()
        Call addrandom()
        listBox.Items.Clear()
        Call addmandatory()
        Call addrandman()


        Dim q_gen As New databaseDataSetTableAdapters.TableTableAdapter

        For i As Integer = 0 To 29
            q_gen.Insert(finalarray(i), "NULL")
        Next

    End Sub



    'GEtting the question number


    Sub getquestion_num()

        Dim getq As New databaseDataSetTableAdapters.TableTableAdapter
        rand_q_num = getq.GetDataBy(q_label).Rows(0).Item(1)



    End Sub






    Function question_load()



        label_numb.Content = q_label


        Dim db As New databaseDataSetTableAdapters.QuestionTableAdapter
        question.Text = db.GetData(rand_q_num).Rows(0).Item(1)
        Call loadcategory()

        loadimage()


    End Function


    Sub ans_load()

        Dim db As New databaseDataSetTableAdapters.AnswerTableAdapter
        ans_1.Text = db.GetData(rand_q_num).Rows(0).Item(1)
        ans_2.Text = db.GetData(rand_q_num).Rows(1).Item(1)
        ans_3.Text = db.GetData(rand_q_num).Rows(2).Item(1)
        ans_4.Text = db.GetData(rand_q_num).Rows(3).Item(1)

        loadimageans()


    End Sub

    "

    Private Sub button_Click(sender As Object, e As RoutedEventArgs) Handles button.Click
        If (ans1.IsChecked) Then
            slcans = ans_1.Text
            ans1.IsChecked = False
            ans1_card.Background = Brushes.CornflowerBlue

        ElseIf (ans2.IsChecked) Then
            slcans = ans_2.Text
            ans2.IsChecked = False
            ans2_card.Background = Brushes.CornflowerBlue
        ElseIf (ans3.IsChecked) Then
            slcans = ans_3.Text
            ans3.IsChecked = False
            ans3_card.Background = Brushes.CornflowerBlue
        ElseIf (ans4.IsChecked) Then
            slcans = ans_4.Text
            ans4.IsChecked = False
            ans4_card.Background = Brushes.CornflowerBlue
        Else
            MsgBox("please select something")
            Exit Sub

        End If



        q_num = q_num + 1
        If q_num = 58 Then 'whhen all question displayed
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

        Call load_random_quest()


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

        Dim mandscorecount As Integer = dt.GetDataBy21(customer.selected_id).Rows.Count
        Dim otherscorecount As Integer = dt.GetDataBy1(customer.selected_id).Count - dt.GetDataBy21(customer.selected_id).Rows.Count



        fullscore = ((dt.GetDataBy1(customer.selected_id).Count / 57) * 100)


        mandscore = (((dt.GetDataBy21(customer.selected_id).Rows.Count / 5) * 100) / 100) * 25


        finalscore = dt.GetDataBy1(customer.selected_id).Rows.Count + dt.GetDataBy21(customer.selected_id).Rows.Count


        score.totscore = fullscore
        score.mandscore = mandscore
        score.ansscore = ((finalscore / 52) * 100) / 100 * 75

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
        Dim uri As String = CStr(rand_q_num)

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

        Dim uri As String = CStr(rand_q_num)

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

    Private Sub ans1_Checked(sender As Object, e As RoutedEventArgs) Handles ans1.Checked
        ans2.IsChecked = False
        ans3.IsChecked = False
        ans4.IsChecked = False


        ans1_card.Background = Brushes.Aqua
        ans2_card.Background = Brushes.CornflowerBlue

        ans3_card.Background = Brushes.CornflowerBlue

        ans4_card.Background = Brushes.CornflowerBlue


    End Sub

    Private Sub ans2_Checked(sender As Object, e As RoutedEventArgs) Handles ans2.Checked
        ans3.IsChecked = False
        ans1.IsChecked = False
        ans4.IsChecked = False


        ans1_card.Background = Brushes.CornflowerBlue
        ans2_card.Background = Brushes.Aqua

        ans3_card.Background = Brushes.CornflowerBlue

        ans4_card.Background = Brushes.CornflowerBlue
    End Sub

    Private Sub ans3_Checked(sender As Object, e As RoutedEventArgs) Handles ans3.Checked

        ans2.IsChecked = False
        ans1.IsChecked = False
        ans4.IsChecked = False


        ans1_card.Background = Brushes.CornflowerBlue
        ans3_card.Background = Brushes.Aqua

        ans2_card.Background = Brushes.CornflowerBlue

        ans4_card.Background = Brushes.CornflowerBlue

    End Sub

    Private Sub ans4_Checked(sender As Object, e As RoutedEventArgs) Handles ans4.Checked

        ans2.IsChecked = False
        ans1.IsChecked = False
        ans3.IsChecked = False


        ans1_card.Background = Brushes.CornflowerBlue
        ans4_card.Background = Brushes.Aqua

        ans2_card.Background = Brushes.CornflowerBlue

        ans3_card.Background = Brushes.CornflowerBlue
    End Sub



    Function loadcategory()

        Dim category As New databaseDataSetTableAdapters.QuestionTableAdapter
        Categoryname.Text = category.GetDataBy(rand_q_num).Rows(0).Item(6).ToString





    End Function




    'ARRAY STUFF'''''''''''



    Function addlistbox()

        For i As Integer = 0 To 10000
            Dim value As Integer = CInt(Int((53 * Rnd())) + 1)


            If listBox.Items.Contains(value) Then



            Else

                listBox.Items.Add(value)

            End If



        Next


    End Function



    Function remover()

        For i As Integer = 0 To 56



            Try

                If listBox.Items.Item(i) = 1 Then
                    listBox.Items.RemoveAt(i)

                ElseIf listBox.Items.Item(i) = 2 Then
                    listBox.Items.RemoveAt(i)

                ElseIf listBox.Items.Item(i) = 3 Then

                    listBox.Items.RemoveAt(i)

                ElseIf listBox.Items.Item(i) = 4 Then

                    listBox.Items.RemoveAt(i)
                ElseIf listBox.Items.Item(i) = 16 Then
                    listBox.Items.RemoveAt(i)

                ElseIf listBox.Items.Item(i) = 14 Then
                    listBox.Items.RemoveAt(i)

                End If
            Catch ex As Exception

            End Try

        Next


    End Function





    'THIS is used for shuffle array randomly
    Public Shared Sub Shuffle(ByRef shuffleArray() As Integer)
        Dim counter As Integer
        Dim newPosition As Integer
        Dim shuffleMethod As New Random
        Dim tempObject As Integer

        For counter = 0 To shuffleArray.Length - 1
            newPosition = shuffleMethod.Next(0, shuffleArray.Length - 1)

            tempObject = shuffleArray(counter)
            shuffleArray(counter) = shuffleArray(newPosition)
            shuffleArray(newPosition) = tempObject
        Next counter
    End Sub



    'this is used to add mandotory values into the q list 

    Function addmandatory()

        Dim mand() As Integer = {1, 2, 3, 4, 16, 14}

        Shuffle(mand)


        For Each num In mand

            listBox.Items.Add(num)
        Next

        Dim lastitem As Integer
        lastitem = listBox.Items.Count
        lastitem = lastitem - 1

        listBox.Items.RemoveAt(lastitem)



    End Function



    'it randomly adds values in listbox into the final array
    Function addrandom()

        For i = 0 To 24


            finalarray(i) = (listBox.Items.Item(i))
        Next

    End Function

    Function addrandman()


        For i = 0 To 4


            mandarray(i) = (listBox.Items.Item(i))

        Next
        mandarray.CopyTo(finalarray, 25)

        Shuffle(finalarray)

    End Function






End Class
