Imports MySql.Data.MySqlClient
Imports System.Data

Public Class DataBase
    Dim myServerData As String = "Server =192.168.50.241;port = 3306;database =message_board;user id = test ;password =kurt6783 ;charset = utf8"
    Dim Client As MySqlConnection = New MySqlConnection(myServerData)

    Public Property ServerData()
        Get
            Return myServerData
        End Get
        Set(ByVal value)
            myServerData = value
        End Set
    End Property


    Public Function Adapter(ByVal Command As String, ByVal DataName As String)
        Try
            Client.Open()
            Dim Adp As MySqlDataAdapter = New MySqlDataAdapter(Command, Client)
            Dim DataSet As DataSet = New DataSet
            Adp.Fill(DataSet, DataName)
            Client.Close()
            Return DataSet
        Catch ex As Exception
            Client.Close()
            Return ex.Message.ToString
        End Try
    End Function

    Public Function Command(ByVal SQLCommand As String)
        Try
            Client.Open()
            Dim Order As MySqlCommand = New MySqlCommand(SQLCommand, Client)
            Order.ExecuteNonQuery()
            Client.Close()
            Return "Success"
        Catch ex As Exception
            Client.Close()
            Return ex.Message.ToString
        End Try
    End Function
End Class
