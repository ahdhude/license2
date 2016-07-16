Class MainWindow
    Private Sub button_Click(sender As Object, e As RoutedEventArgs) Handles button.Click
        Dim login As New login
        login.Show()
    End Sub

    Private Sub button1_Click(sender As Object, e As RoutedEventArgs) Handles button1.Click
        Dim welcome As New welcome
        welcome.Show()

    End Sub

    Private Sub button2_Click(sender As Object, e As RoutedEventArgs) Handles button2.Click
        Dim customer As New customer
        customer.Show()



    End Sub
End Class
