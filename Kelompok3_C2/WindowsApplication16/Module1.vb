Imports MySql.Data.MySqlClient

Module Module1
    Public CONN As MySqlConnection
    Public CMD As MySqlCommand
    Public RD As MySqlDataReader
    Public DA As MySqlDataAdapter
    Public DS As DataSet
    Public STR As String
    Public CurrentUsername As String = ""

    Sub koneksi()
        Try
            STR = "server=localhost;userid=root;password=;database=karintihouse"
            ' Ganti nama database sesuaikan dengan nama database Anda
            CONN = New MySqlConnection(STR)
            If CONN.State = ConnectionState.Closed Then
                CONN.Open()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ' Fungsi untuk menetapkan nama pengguna yang saat ini masuk
    Public Sub SetCurrentUsername(username As String)
        CurrentUsername = username
    End Sub

    ' Fungsi untuk mendapatkan nama pengguna yang saat ini masuk
    Public Function GetCurrentUsername() As String
        Return CurrentUsername
    End Function
End Module
