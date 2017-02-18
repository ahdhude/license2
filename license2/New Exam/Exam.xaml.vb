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



    Dim majuboorscore As Integer

    Dim rulescount As Integer
    Dim adhabucount As Integer
    Dim nishaancount As Integer

    Dim unaswered As Integer
    Dim rulescore As Integer
    Dim adhabuscore As Integer
    Dim nishaanscore As Integer


    Dim finalarray(30) As Integer
    Dim mandarray(4) As Integer

    Dim randomarray() As Integer
    Dim rand_q_num As Integer




    Sub load_random_qst()
        ListBox1.Items.Clear()
        listbox2.Items.Clear()
        listbox3.Items.Clear()
        Call add_listbox_1()
        Call randomize_listbox1()
        Call randomize_listbox2()
        Call add_listbox3()
        Call randomize_listbox3()

        Call addrandom()


        Call repeatedv()






        Dim qst As Integer = 1

        Dim q_gen As New databaseDataSetTableAdapters.TableTableAdapter

        For x As Integer = 0 To 30


            q_gen.UpdateQuery(finalarray(x), qst)
            qst = qst + 1

        Next

    End Sub



    'GEtting the question number


    Sub getquestion_num()

        Dim getq As New databaseDataSetTableAdapters.TableTableAdapter
        rand_q_num = getq.GetDataBy(q_label).Rows(0).Item(1)



    End Sub






    Function question_load()
        button.IsEnabled = True

        btn_finish.IsEnabled = False


        label_numb.Content = q_label

        Dim dt As New databaseDataSetTableAdapters.TableTableAdapter
        rand_q_num = dt.GetDataBy(q_label).Rows(0).Item(1)

        If rand_q_num = 0 Then

            exam.Close()
            Dim a As New Exam
            a.Show()

        End If

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



    Private Sub button_Click(sender As Object, e As RoutedEventArgs) Handles button.Click
        Dim selincount As Integer
        Dim selcheck As New databaseDataSetTableAdapters.TableTableAdapter
        Dim sindex As Integer
        Dim selected As New databaseDataSetTableAdapters.TableTableAdapter


        If (ans1.IsChecked) Then
            slcans = ans_1.Text
            ans1.IsChecked = False
            ans1_card.Background = Brushes.CornflowerBlue
            selected.UpdateQuery1(1, q_label)

        ElseIf (ans2.IsChecked) Then
            slcans = ans_2.Text
            ans2.IsChecked = False
            ans2_card.Background = Brushes.CornflowerBlue
            selected.UpdateQuery1(2, q_label)
        ElseIf (ans3.IsChecked) Then
            slcans = ans_3.Text
            ans3.IsChecked = False
            ans3_card.Background = Brushes.CornflowerBlue
            selected.UpdateQuery1(3, q_label)
        ElseIf (ans4.IsChecked) Then
            slcans = ans_4.Text
            ans4.IsChecked = False
            ans4_card.Background = Brushes.CornflowerBlue
            selected.UpdateQuery1(4, q_label)
        Else
            MsgBox("please select something")
            Exit Sub

        End If



        q_label = q_label + 1


        selincount = selcheck.GetDataBy(q_label).Rows(0).Item(2)

        If selincount = 0 Then

            If q_label = 31 Then 'whhen all question displayed

                btn_finish.IsEnabled = True
                button.IsEnabled = False





            Else
                Call correct()



            End If


        Else




            Call question_load()
            Call ans_load()

            Dim selectedindex As New databaseDataSetTableAdapters.TableTableAdapter
            sindex = selectedindex.GetDataBy(q_label).Rows(0).Item(2)

            If sindex = 1 Then
                ans1.IsChecked = True
            ElseIf sindex = 2 Then
                ans2.IsChecked = True

            ElseIf sindex = 3 Then
                ans3.IsChecked = True
            Else
                ans4.IsChecked = True
            End If




        End If










    End Sub










    Sub correct()

        q_label = q_label - 1


        Dim dt As New databaseDataSetTableAdapters.ScoreTableAdapter

        Dim db As New databaseDataSetTableAdapters.AnswerTableAdapter
        cans = db.GetDataBy(rand_q_num).Rows(0).Item(1)



        If cans = slcans Then

            dt.UpdateQuery(1, rand_q_num, customer.selected_id, q_label)





        Else

            dt.UpdateQuery(0, rand_q_num, customer.selected_id, q_label)

        End If


        q_label = q_label + 1
        If q_label = 31 Then
            Exit Sub
        Else

            Call question_load()
            Call ans_load()

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

    Sub updatefinalscore()


        Dim dt As New databaseDataSetTableAdapters.ScoreTableAdapter

        Dim mandscorecount As Integer = dt.GetDataBy21(customer.selected_id).Rows.Count
        Dim otherscorecount As Integer = dt.GetDataBy1(customer.selected_id).Count - dt.GetDataBy21(customer.selected_id).Rows.Count



        fullscore = ((dt.GetDataBy1(customer.selected_id).Count / 30) * 100)


        mandscore = (((dt.GetDataBy21(customer.selected_id).Rows.Count / 5) * 100) / 100) * 25


        finalscore = dt.GetDataBy1(customer.selected_id).Rows.Count + dt.GetDataBy21(customer.selected_id).Rows.Count


        score.totscore = fullscore
        score.mandscore = mandscore
        score.ansscore = ((finalscore / 30) * 100) / 100 * 75

        score.mandscorecount = mandscorecount
        score.anscorecount = otherscorecount





        Dim pass As New databaseDataSetTableAdapters.FinalScoreTableAdapter




        If mandscore = 25 And finalscore >= 75 Then




            pass.Insert(customer.cst_id, finalscore, 1, customer.datetime, mandscorecount, otherscorecount)
        Else

            pass.Insert(customer.cst_id, finalscore, 0, customer.datetime, mandscorecount, otherscorecount)



        End If






    End Sub

    Sub calculatefinalscore()

        Dim unans As New databaseDataSetTableAdapters.TableTableAdapter
        unaswered = unans.GetDataBy11().Rows.Count  ' counts the total unaswered questions 



        Dim ad As New databaseDataSetTableAdapters.TableTableAdapter
        adhabucount = ad.GetDataBy4().Rows.Count  ' counts the total adhabu questions 

        adhabu_quest_count = adhabucount


        Dim gav As New databaseDataSetTableAdapters.TableTableAdapter
        rulescount = gav.GetDataBy5().Rows.Count  ' counts the total gavaidhu questions 
        gavaidhu_quest_count = rulescount




        Dim sig As New databaseDataSetTableAdapters.TableTableAdapter
        nishaancount = sig.GetDataBy6.Rows.Count  ' counts the total signs questions 

        nishaan_quest_count = nishaancount


        Dim tomaj As New databaseDataSetTableAdapters.TableTableAdapter
        majuboorscore = tomaj.GetDataBy7.Rows.Count
        majubooru_score_count = majuboorscore




        Dim totad As New databaseDataSetTableAdapters.TableTableAdapter
        adhabuscore = totad.GetDataBy8().Rows.Count  ' counts the total adhabu score
        adhabu_score_count = adhabuscore


        Dim totgav As New databaseDataSetTableAdapters.TableTableAdapter
        rulescore = totgav.GetDataBy9().Rows.Count  ' counts the total gavaidhu score 

        gavaidhu_score_count = rulescore



        Dim totsig As New databaseDataSetTableAdapters.TableTableAdapter
        nishaanscore = totsig.GetDataBy10.Rows.Count  ' counts the total signs score 

        nishaan_score_count = nishaanscore



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



    '    Function addlistbox()

    'line1:
    '        Dim value As Integer = CInt(Int((53 * Rnd())) + 1)


    '        If listBox.Items.Contains(value) And listBox.Items.Count <> 53 Then

    '            GoTo line1

    '        ElseIf listBox.Items.Count >= 53 Then

    '            Exit Function


    '        Else

    '            listBox.Items.Add(value)


    '        End If

    '        GoTo line1





    '    End Function



    'Function remover()


    '    Dim indexx As Integer = listBox.Items.Count
    '    indexx = listBox.Items.Count
    '    Dim z As Integer = 1



    '    While indexx <> z


    '        If listBox.Items.Item(z) = 1 Then
    '            listBox.Items.RemoveAt(z)
    '            indexx = listBox.Items.Count
    '            z = z - 1


    '        ElseIf listBox.Items.Item(z) = 2 Then
    '            listBox.Items.RemoveAt(z)
    '            indexx = listBox.Items.Count
    '            z = z - 1

    '        ElseIf listBox.Items.Item(z) = 3 Then

    '            listBox.Items.RemoveAt(z)
    '            indexx = listBox.Items.Count
    '            z = z - 1

    '        ElseIf listBox.Items.Item(z) = 4 Then

    '            listBox.Items.RemoveAt(z)
    '            indexx = listBox.Items.Count
    '            z = z - 1
    '        ElseIf listBox.Items.Item(z) = 16 Then
    '            listBox.Items.RemoveAt(z)
    '            indexx = listBox.Items.Count
    '            z = z - 1

    '        ElseIf listBox.Items.Item(z) = 14 Then
    '            listBox.Items.RemoveAt(z)
    '            indexx = listBox.Items.Count
    '            z = z - 1
    '        ElseIf listBox.Items.Item(z) = 0 Then
    '            listBox.Items.RemoveAt(z)
    '            indexx = listBox.Items.Count
    '            z = z - 1

    '        Else


    '        End If

    '        z = z + 1


    '    End While













    'End Function





    'THIS is used for shuffle array randomly



    'Public Shared Sub Shuffle(ByRef shuffleArray() As Integer)
    '    Dim counter As Integer
    '    Dim newPosition As Integer
    '    Dim shuffleMethod As New Random
    '    Dim tempObject As Integer

    '    For counter = 0 To shuffleArray.Length - 1
    '        newPosition = shuffleMethod.Next(0, shuffleArray.Length - 1)

    '        tempObject = shuffleArray(counter)
    '        shuffleArray(counter) = shuffleArray(newPosition)
    '        shuffleArray(newPosition) = tempObject
    '    Next counter
    'End Sub



    ''this is used to add mandotory values into the q list 

    'Function addmandatory()

    '    Dim mand() As Integer = {1, 2, 3, 4, 16, 14}

    '    Shuffle(mand)


    '    For Each num In mand

    '        listBox.Items.Add(num)
    '    Next

    '    Dim lastitem As Integer
    '    lastitem = listBox.Items.Count
    '    lastitem = lastitem - 1

    '    listBox.Items.RemoveAt(lastitem)



    'End Function








    Sub add_listbox_1()


        For index = 1 To 53

            ListBox1.Items.Add(index)

            If ListBox1.Items.Contains(1) Then
                listbox2.Items.Add(1)
                ListBox1.Items.Remove(1)

            ElseIf ListBox1.Items.Contains(2) Then
                listbox2.Items.Add(2)
                ListBox1.Items.Remove(2)
            ElseIf ListBox1.Items.Contains(3) Then
                listbox2.Items.Add(3)
                ListBox1.Items.Remove(3)
            ElseIf ListBox1.Items.Contains(4) Then
                listbox2.Items.Add(4)
                ListBox1.Items.Remove(4)
            ElseIf ListBox1.Items.Contains(16) Then
                listbox2.Items.Add(16)
                ListBox1.Items.Remove(16)
            ElseIf ListBox1.Items.Contains(14) Then
                listbox2.Items.Add(14)
                ListBox1.Items.Remove(14)

            End If

        Next

    End Sub


    Sub randomize_listbox1()

        Dim rng As New Random()

        ' Helps with flicker

        ListBox1.BeginInit()
        ' Start at end, work down to first element
        For i As Integer = ListBox1.Items.Count - 1 To 1 Step -1
            ' Get random index
            Dim swapIndex As Integer = rng.Next(0, i + 1)
            ' Swap
            Dim temp As Object = ListBox1.Items(i)
            ListBox1.Items(i) = ListBox1.Items(swapIndex)
            ListBox1.Items(swapIndex) = temp
        Next

        ListBox1.EndInit()
    End Sub


    Sub randomize_listbox2()

        Dim rng As New Random()

        ' Helps with flicker
        listbox2.BeginInit()

        ' Start at end, work down to first element
        For i As Integer = listbox2.Items.Count - 1 To 1 Step -1
            ' Get random index
            Dim swapIndex As Integer = rng.Next(0, i + 1)
            ' Swap
            Dim temp As Object = listbox2.Items(i)
            listbox2.Items(i) = listbox2.Items(swapIndex)
            listbox2.Items(swapIndex) = temp
        Next

        listbox2.EndInit()
    End Sub


    Sub randomize_listbox3()

        Dim rng As New Random()

        ' Helps with flicker
        listbox3.BeginInit()

        ' Start at end, work down to first element
        For i As Integer = listbox3.Items.Count - 1 To 1 Step -1
            ' Get random index
            Dim swapIndex As Integer = rng.Next(0, i + 1)
            ' Swap
            Dim temp As Object = listbox3.Items(i)
            listbox3.Items(i) = listbox3.Items(swapIndex)
            listbox3.Items(swapIndex) = temp
        Next

        listbox3.EndInit()
    End Sub


    Sub add_listbox3()


        For index = 0 To 24

            listbox3.Items.Add(ListBox1.Items.Item(index))


        Next

        For index = 0 To 4



            listbox3.Items.Add(listbox2.Items.Item(index))



        Next


    End Sub




    'it randomly adds values in listbox into the final array
    Function addrandom()

        For a = 0 To 29


            finalarray(a) = (listbox3.Items.Item(a))
        Next


    End Function

    'Function addrandman()


    '    For b = 0 To 4


    '        mandarray(b) = (listBox.Items.Item(b))

    '    Next

    '    Shuffle(mandarray)
    '    listBox.Items.Clear()

    '    mandarray.CopyTo(finalarray, 25)

    '    Exit Function

    'End Function

    Private Sub exam_Loaded(sender As Object, e As RoutedEventArgs) Handles MyBase.Loaded, MyBase.Loaded
        Call load_random_qst()


        Dim dt As DispatcherTimer = New DispatcherTimer()
        AddHandler dt.Tick, AddressOf dispatcherTimer_Tick
        dt.Interval = New TimeSpan(0, 0, 1)
        dt.Start()







        Call question_load()
        Call ans_load()

    End Sub

    Private Sub btn_back_Click(sender As Object, e As RoutedEventArgs) Handles btn_back.Click
        Dim sindex As Integer

        q_label = q_label - 1


        If q_label <= 0 Then
            q_label = q_label + 1

            Exit Sub

        End If

line1:
        Call question_load()
        Call ans_load()

        Dim selectedindex As New databaseDataSetTableAdapters.TableTableAdapter
        sindex = selectedindex.GetDataBy(q_label).Rows(0).Item(2)

        If sindex = 1 Then
            ans1.IsChecked = True
        ElseIf sindex = 2 Then
            ans2.IsChecked = True

        ElseIf sindex = 3 Then
            ans3.IsChecked = True
        Else
            ans4.IsChecked = True
        End If







    End Sub

    Private Sub btn_finish_Click(sender As Object, e As RoutedEventArgs) Handles btn_finish.Click
        If ans1.IsChecked = False And ans2.IsChecked = False And ans3.IsChecked = False And ans4.IsChecked = False Then
            MsgBox("please select something")
            Exit Sub

        End If

        Call correct()

        Call updatefinalscore()
        Call calculatefinalscore()


        Close()
        Dim scoresheet As New result
        scoresheet.Show()
    End Sub



    Sub repeatedv()

        Dim dt As New databaseDataSetTableAdapters.TableTableAdapter
        dt.UpdateQuery(50, 30)


    End Sub



End Class
