Imports System
Imports System.Security.Cryptography
Imports System.Text
Imports license2



Public Class login

    Private Sub btn_close_Click(sender As Object, e As RoutedEventArgs) Handles btn_close.Click
        Application.Current.Shutdown()
    End Sub

    Shared Function GetMd5Hash(ByVal md5Hash As MD5, ByVal input As String) As String

        ' Convert the input string to a byte array and compute the hash.
        Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))

        ' Create a new Stringbuilder to collect the bytes
        ' and create a string.
        Dim sBuilder As New StringBuilder()

        ' Loop through each byte of the hashed data 
        ' and format each one as a hexadecimal string.
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i

        ' Return the hexadecimal string.
        Return sBuilder.ToString()

    End Function 'GetMd5Hash


    ' Verify a hash against a string.
    Shared Function VerifyMd5Hash(ByVal md5Hash As MD5, ByVal input As String, ByVal hash As String) As Boolean
        ' Hash the input.
        Dim hashOfInput As String = GetMd5Hash(md5Hash, input)

        ' Create a StringComparer an compare the hashes.
        Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase

        If 0 = comparer.Compare(hashOfInput, hash) Then
            Return True
        Else
            Return False
        End If

    End Function 'VerifyMd5Hash
    Private Sub btn_login_Click(sender As Object, e As RoutedEventArgs) Handles btn_login.Click
        Dim savedhash As String
        Dim saveduser As String
        Dim db As New databaseDataSetTableAdapters.UserTableAdapter

        Try
            saveduser = db.GetDataBy(textbox_user.Text).Rows(0).Item(1)
            savedhash = db.GetDataBy(textbox_user.Text).Rows(0).Item(2)
        Catch ex As Exception
            MsgBox("username incorrect")
            With textbox_user
                .Focus()
                .SelectAll()
            End With
            Exit Sub
        End Try



        Dim [source] As String = password_box.Password.ToString
        Using md5Hash As MD5 = MD5.Create()

            Dim hash As String = GetMd5Hash(md5Hash, source)





            If saveduser = textbox_user.Text And hash = savedhash Then
                Dim welcome As New welcome
                welcome.Show()

                Me.Hide()


            Else
                MsgBox("password incorrect", MsgBoxStyle.Exclamation)
                With password_box
                    .Focus()
                    .SelectAll()

                End With
            End If
        End Using
    End Sub

    Private Sub password_box_KeyDown(sender As Object, e As KeyEventArgs) Handles password_box.KeyDown
        If (e.Key = Key.Return) Then
            Call btn_login_Click(sender, e)

        End If
    End Sub

    Private Sub textbox_user_KeyDown(sender As Object, e As KeyEventArgs) Handles textbox_user.KeyDown
        If (e.Key = Key.Return) Then
            Call btn_login_Click(sender, e)

        End If
    End Sub
End Class
