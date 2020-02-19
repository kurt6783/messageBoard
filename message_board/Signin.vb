Public Class Signin
    Dim DataBase As New DataBase
    Dim DataSet As New DataSet
    Dim SQLCommand As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Account As String = TextBox1.Text
        Dim password As String = TextBox2.Text
        SQLCommand = "select  * from user where account = '" & Account & "'"
        DataSet = DataBase.Adapter(SQLCommand, "Data")
        If Account = "" Then
            MsgBox("請輸入帳號", MsgBoxStyle.OkOnly, "Alarm")
        ElseIf password = "" Then
            MsgBox("請輸入密碼", MsgBoxStyle.OkOnly, "Alarm")
        ElseIf DataSet.Tables("Data").Rows.Count = 0 Then
            MsgBox("無此帳號", MsgBoxStyle.OkOnly, "Alarm")
        ElseIf password = DataSet.Tables("Data").Rows(0)("password").ToString Then
            Board.MdiParent = MessageBoard
            Board.Show()
            Board.Focus()
            Me.Close()
            MessageBoard.User = Account
            Board.TextBox1.Text = Account
        Else
            MsgBox("密碼錯誤", MsgBoxStyle.OkOnly, "Alarm")
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        CreateAccount.MdiParent = MessageBoard
        CreateAccount.Show()
        CreateAccount.Focus()
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        MsgBox("請向系統管理員繳交100元即可取回密碼", MsgBoxStyle.OkOnly, "Alarm")
    End Sub
End Class