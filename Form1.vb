Public Class Form1


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPassword.PasswordChar = "*"c
    End Sub

    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        txtPassword.PasswordChar = If(chkShowPassword.Checked, ControlChars.NullChar, "*"c)
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If String.IsNullOrWhiteSpace(txtEmployeeID.Text) OrElse String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("Please fill in all required fields.")
            Exit Sub
        End If

        If txtPassword.Text = "admin" Then

            Form2.currentLoggedInEmpID = txtEmployeeID.Text
            Dim f2 As New Form2()
            f2.Show()
            Me.Hide()
        Else
            MessageBox.Show("Wrong Password!")
        End If
    End Sub



End Class