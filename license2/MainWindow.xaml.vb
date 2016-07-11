Class MainWindow
    Private Sub button_Click(sender As Object, e As RoutedEventArgs) Handles button.Click
        Dim login As New login
        login.Show()
    End Sub

    Private Sub button1_Click(sender As Object, e As RoutedEventArgs) Handles button1.Click
        Dim welcome As New welcome
        welcome.Show()

    End Sub
End Class
