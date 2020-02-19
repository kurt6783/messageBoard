Imports System.Windows.Forms

Public Class MessageBoard
    Public ASD
    Dim DataBase As New DataBase
    Dim DataSet As New DataSet
    Dim SQLCommand As String
    Public User As String
    Private Sub MessageBoard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Version() As String = Me.Text.Split(":")
        SQLCommand = "select * from version order by sn desc limit 1"
        DataSet = DataBase.Adapter(SQLCommand, "Data")
        If DataSet.Tables("Data").Rows(0)("version").ToString = Version(1) Then
            Signin.MdiParent = Me
            Signin.Show()
            Signin.Focus()
        Else
            UpdateForm.MdiParent = Me
            UpdateForm.Show()
            UpdateForm.Focus()
            UpdateForm.TextBox1.Text = DataSet.Tables("Data").Rows(0)("update_address").ToString
            MsgBox("已有更新版本，請至下列網址下載更新。", MsgBoxStyle.OkOnly, "Alarm")
        End If
    End Sub
End Class
