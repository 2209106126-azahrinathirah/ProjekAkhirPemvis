Imports MySql.Data.MySqlClient

Public Class FormLogin

    ' Memanggil prosedur koneksi() saat form dimuat
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Menginisialisasi koneksi ke database
        Module1.koneksi()
    End Sub

    ' Metode untuk melakukan login
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' Pastikan koneksi sudah dibuka sebelum memeriksa statusnya
        If Module1.CONN.State = ConnectionState.Closed Then
            Module1.CONN.Open()
        End If

        ' Sekarang Anda bisa memeriksa status koneksi
        If Module1.CONN.State = ConnectionState.Open Then
            ' Lakukan verifikasi login di sini
            If txt_user.Text = "admin" AndAlso txt_password.Text = "123" Then
                ' Login berhasil sebagai admin
                MsgBox("Login berhasil sebagai admin!")
                Me.Hide()
                Dim DashboardForm As New Dashboard_Admin()
                Dashboard_Admin.Show()
            Else
                ' Lakukan verifikasi login sebagai penyewa
                If CekLogin(txt_user.Text, txt_password.Text) Then
                    ' Login berhasil sebagai penyewa
                    MsgBox("Login berhasil sebagai penyewa!")
                    ' Set CurrentUsername menggunakan nilai dari textbox username
                    Module1.SetCurrentUsername(txt_user.Text)
                    Me.Hide()
                    Dim DashboardForm As New Dashboard_Penyewa()
                    Dashboard_Penyewa.Show()
                Else
                    MsgBox("Username atau password salah!")
                End If
            End If
        Else
            MsgBox("Tidak dapat terhubung ke database.")
        End If
    End Sub

    ' Fungsi untuk memeriksa login berdasarkan data di database
    Private Function CekLogin(username As String, password As String) As Boolean
        Dim query As String = "SELECT COUNT(*) FROM akun WHERE username = @username AND password = @password"
        Dim result As Integer

        Try
            ' Buat objek MySqlCommand dan kirim perintah SQL ke database
            Dim CMD As New MySqlCommand(query, Module1.CONN)

            ' Tambahkan parameter untuk menghindari SQL injection
            CMD.Parameters.AddWithValue("@username", username)
            CMD.Parameters.AddWithValue("@password", password)

            ' Eksekusi perintah SQL dan simpan hasilnya ke variabel result
            result = Convert.ToInt32(CMD.ExecuteScalar())
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
            Return False ' Jika terjadi kesalahan, kembalikan False
        End Try

        ' Jika hasilnya lebih dari 0, berarti login berhasil
        Return result > 0
    End Function

    ' Event handler untuk tombol Registrasi
    Private Sub btnRegis_Click(sender As Object, e As EventArgs) Handles btnRegis.Click
        ' Sembunyikan Form Login
        Me.Hide()

        ' Tampilkan Form Registrasi
        Dim RegistrasiForm As New FormRegistrasi()
        FormRegistrasi.Show()
    End Sub

    ' Event handler untuk tombol keluar
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        End
    End Sub

End Class
