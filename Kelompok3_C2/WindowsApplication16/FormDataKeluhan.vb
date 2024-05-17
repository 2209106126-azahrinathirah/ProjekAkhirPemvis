Imports MySql.Data.MySqlClient

Public Class FormDataKeluhan

    Private Sub pbBack_Click(sender As Object, e As EventArgs) Handles pbBack.Click
        ' Sembunyikan Form Data Keluhan
        Me.Hide()

        ' Buat instance Form Dashboard Admin
        Dim DashboardForm As New Dashboard_Admin()

        ' Tampilkan Form Dashboard Admin
        Dashboard_Admin.Show()
    End Sub

    Private Sub LoadDataKeluhan()
        ' Bersihkan DataGridView sebelum memuat data baru
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear() ' Hapus semua kolom sebelum menambahkan yang baru

        ' Tambahkan kolom-kolom baru ke DataGridView
        DataGridView1.Columns.Add("IdKeluhanColumn", "ID Keluhan")
        DataGridView1.Columns.Add("NamaPenyewaColumn", "Nama Penyewa")
        DataGridView1.Columns.Add("NoKamarColumn", "Nomor Kamar")
        DataGridView1.Columns.Add("JenisKeluhanColumn", "Jenis Keluhan")
        DataGridView1.Columns.Add("KeteranganColumn", "Keterangan")

        ' Query untuk memuat data keluhan dari database
        Dim query As String = "SELECT * FROM keluhan"

        ' Gunakan koneksi
        Using connection As New MySqlConnection(CONN.ConnectionString)
            Using command As New MySqlCommand(query, connection)
                connection.Open()

                ' Gunakan MySqlDataReader untuk membaca data
                Using reader As MySqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        ' Ambil nilai kolom dari setiap baris
                        Dim idKeluhan As String = reader("id_keluhan").ToString()
                        Dim namaPenyewa As String = reader("nama").ToString()
                        Dim noKamar As String = reader("no_kamar").ToString()
                        Dim jenisKeluhan As String = reader("jenis_keluhan").ToString()
                        Dim keterangan As String = reader("keterangan").ToString()

                        ' Tambahkan baris ke DataGridView
                        DataGridView1.Rows.Add(idKeluhan, namaPenyewa, noKamar, jenisKeluhan, keterangan)
                    End While
                End Using
            End Using
        End Using
    End Sub

    Private Sub btnShowData_Click(sender As Object, e As EventArgs) Handles btnShowData.Click
        LoadDataKeluhan() ' Memuat data keluhan saat tombol "Show Data" ditekan
    End Sub

End Class
