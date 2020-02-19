Public Class Board
    Dim WithEvents Timer As New Timer
    Dim DataBase As New DataBase
    Dim DataSet As New DataSet
    Dim SQLCommand As String
    Dim Datetime As String
    Dim Count As Integer = 20
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer.Interval = 1000
        Timer.Start()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim name As String = TextBox1.Text
        Dim message As String = TextBox2.Text
        Datetime = Today & " " & Date.Now.ToString("HH:mm:ss")
        SQLCommand = "INSERT INTO `message`(`user`, `message`, `datetime`) VALUES ('" & name & "','" & message & "','" & Datetime & "')"
        DataBase.Command(SQLCommand)
    End Sub


    Sub UpdateUI() Handles Timer.Tick
        SQLCommand = "select * from message order by sn desc limit " & Count
        DataSet = DataBase.Adapter(SQLCommand, "Data")
        DataGridView1.DataSource = DataSet.Tables("Data")
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
        Signin.MdiParent = MessageBoard
        Signin.Show()
        Signin.Focus()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Val(TextBox3.Text) <= 0 Then
            MsgBox("時間不可小於0", MsgBoxStyle.OkOnly, "Alarm")
        ElseIf Val(TextBox3.Text) > 1 Then
            Timer.Interval = Val(TextBox3.Text) * 1000
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Report.MdiParent = MessageBoard
        Me.Close()
        Report.Show()
        Report.Focus()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Count = Val(TextBox4.Text)
    End Sub
End Class
