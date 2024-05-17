Imports MySql.Data.MySqlClient

Public Class FormRegistrasi
    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Dim username As String = txt_user_regis.Text
        Dim password As String = txt_password_regis.Text

        ' Panggil prosedur koneksi untuk membuka koneksi ke database
        koneksi()

        Try
            ' Buat perintah SQL untuk menyimpan data registrasi ke dalam tabel akun
            Dim query As String = "INSERT INTO akun (username, password) VALUES (@username, @password)"

            ' Buat objek MySqlCommand dan kirim perintah SQL ke database
            CMD = New MySqlCommand(query, CONN)

            ' Tambahkan parameter untuk menghindari SQL injection
            CMD.Parameters.AddWithValue("@username", username)
            CMD.Parameters.AddWithValue("@password", password)

            ' Eksekusi perintah SQL
            CMD.ExecuteNonQuery()

            ' Tampilkan pesan registrasi berhasil
            MessageBox.Show("Registrasi berhasil!")

            ' Sembunyikan form registrasi
            Me.Hide()

            ' Tampilkan form login kembali
            Dim loginForm As New FormLogin()
            loginForm.Show()
        Catch ex As Exception
            MessageBox.Show("Registrasi gagal: " & ex.Message)
        Finally
            ' Tutup koneksi setelah selesai
            CONN.Close()
        End Try
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Hide()
        FormLogin.Show()
    End Sub

End Class
