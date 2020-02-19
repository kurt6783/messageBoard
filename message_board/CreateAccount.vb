Public Class CreateAccount
    Dim DataBase As New DataBase
    Dim DataSet As New DataSet
    Dim Datetime As String
    Dim SQLCommand As String
    Dim Mac As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Account As String = TextBox1.Text
        Dim password As String = TextBox2.Text
        Dim passwordcheck As String = TextBox3.Text
        Mac = Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces(0).GetPhysicalAddress().ToString()
        Datetime = Today & " " & Date.Now.ToString("HH:mm:ss")
        If Account = "" Then
            MsgBox("請輸入帳號", MsgBoxStyle.OkOnly, "Alarm")
        ElseIf password = "" Then
            MsgBox("請輸入密碼", MsgBoxStyle.OkOnly, "Alarm")
        ElseIf passwordcheck = "" Then
            MsgBox("請輸入確認密碼", MsgBoxStyle.OkOnly, "Alarm")
        ElseIf password <> passwordcheck Then
            MsgBox("重複密碼錯誤", MsgBoxStyle.OkOnly, "Alarm")
        ElseIf Account <> "" And password = passwordcheck Then
            SQLCommand = "select  * from user where account = '" & Account & "'"
            DataSet = DataBase.Adapter(SQLCommand, "Data")
            If DataSet.Tables("Data").Rows.Count = 1 Then
                MsgBox("此帳號已被使用", MsgBoxStyle.OkOnly, "Alarm")
                Me.Close()
                Signin.MdiParent = MessageBoard
                Signin.Show()
                Signin.Focus()
            ElseIf DataSet.Tables("Data").Rows.Count = 0 Then
                SQLCommand = "INSERT INTO `user`(`account`, `password`, `datetime`) VALUES ('" & Account & "','" & password & "','" & Datetime & "')"
                DataBase.Command(SQLCommand)
                MsgBox("帳號建立成功", MsgBoxStyle.OkOnly, "Alarm")
                Me.Close()
                Signin.MdiParent = MessageBoard
                Signin.Show()
                Signin.Focus()
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
        Signin.MdiParent = MessageBoard
        Signin.Show()
        Signin.Focus()
    End Sub

    Private Sub CreatAccount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MsgBox("此密碼於資料庫未加密，請勿使用常用密碼。", MsgBoxStyle.OkOnly, "Alarm")
    End Sub
End Class