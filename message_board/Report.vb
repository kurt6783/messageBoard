Public Class Report
    Dim Database As New DataBase
    Dim DataSet As New DataSet
    Dim SQLCommand As String
    Private Sub report_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Context As String = TextBox1.Text
        Dim User As String = MessageBoard.User
        Dim DateTime As String = Today & " " & Date.Now.ToString("HH:mm:ss")
        SQLCommand = "INSERT INTO `report`(`user`, `content`, `datetime`) VALUES ('" & User & "','" & Context & "','" & DateTime & "')"
        Database.Command(SQLCommand)
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Board.MdiParent = MessageBoard
        Me.Close()
        Board.Show()
        Board.Focus()
    End Sub
End Class