Imports MySql.Data.MySqlClient

Public Class Keluhan

    ' Method untuk mereset input kosong
    Sub Kosong()
        cbJenisKeluhan.SelectedIndex = -1
        cbNoKamar.SelectedIndex = -1
        txtnama.Clear()
        txtKeterangan.Clear()
        txtSearch.Clear()
    End Sub

    Private Sub LoadDataGrid()
        DataGridView1.ScrollBars = ScrollBars.Both
        ' Bersihkan DataGridView sebelum memuat data baru
        DataGridView1.Rows.Clear()

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

    Private Sub FormKeluhan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Memuat data ke combo box jenis keluhan
        LoadJenisKeluhan()

        ' Memuat data ke combo box nomor kamar
        LoadNomorKamar()

        ' Menambahkan kolom-kolom ke DataGridView
        DataGridView1.Columns.Add("IdKeluhanColumn", "ID Keluhan")
        DataGridView1.Columns.Add("NamaPenyewaColumn", "Nama Penyewa")
        DataGridView1.Columns.Add("NoKamarColumn", "Nomor Kamar")
        DataGridView1.Columns.Add("JenisKeluhanColumn", "Jenis Keluhan")
        DataGridView1.Columns.Add("KeteranganColumn", "Keterangan")

        ' Memanggil method untuk memuat data ke DataGridView
        LoadDataGrid()
    End Sub

    ' Method untuk memuat data ke combo box jenis keluhan
    Private Sub LoadJenisKeluhan()
        ' Isi combo box dengan opsi jenis keluhan
        cbJenisKeluhan.Items.AddRange({"Keamanan", "Kebersihan", "Wifi Error"})
    End Sub

    ' Method untuk memuat data ke combo box nomor kamar berdasarkan transaksi yang sudah ada
    Private Sub LoadNomorKamar()
        ' Query untuk mengambil nomor kamar dari transaksi yang sudah ada
        Dim query As String = "SELECT DISTINCT no_kamar FROM transaksi"

        ' Gunakan koneksi
        Using connection As New MySqlConnection(CONN.ConnectionString)
            Using command As New MySqlCommand(query, connection)
                connection.Open()

                Using reader As MySqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        ' Tambahkan nomor kamar ke combo box
                        cbNoKamar.Items.Add(reader("no_kamar").ToString())
                    End While
                End Using
            End Using
        End Using
    End Sub

    Private Sub cbNoKamar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbNoKamar.SelectedIndexChanged
        ' Memastikan ada item yang dipilih sebelum mencoba untuk mengambil nilainya
        If cbNoKamar.SelectedItem IsNot Nothing Then
            ' Memuat nama penyewa berdasarkan nomor kamar yang dipilih
            LoadNamaPenyewaByNomorKamar(cbNoKamar.SelectedItem.ToString())
        End If
    End Sub

    ' Method untuk memuat nama penyewa berdasarkan nomor kamar yang dipilih
    Private Sub LoadNamaPenyewaByNomorKamar(nomorKamar As String)
        ' Query untuk mengambil nama penyewa berdasarkan nomor kamar
        Dim query As String = "SELECT p.nama FROM penyewa p INNER JOIN transaksi t ON p.id = t.id WHERE t.no_kamar = @nomorKamar"

        ' Gunakan koneksi
        Using connection As New MySqlConnection(CONN.ConnectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@nomorKamar", nomorKamar)
                connection.Open()

                Using reader As MySqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        ' Isi textbox nama dengan nama penyewa yang sesuai
                        txtnama.Text = reader("nama").ToString()
                    End If
                End Using
            End Using
        End Using
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        ' Pastikan klik dilakukan pada sel yang bukan header
        If e.RowIndex >= 0 Then
            ' Dapatkan data dari baris yang dipilih
            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            Dim idKeluhan As String = selectedRow.Cells("IdKeluhanColumn").Value.ToString()
            Dim namaPenyewa As String = selectedRow.Cells("NamaPenyewaColumn").Value.ToString()
            Dim noKamar As String = selectedRow.Cells("NoKamarColumn").Value.ToString()
            Dim jenisKeluhan As String = selectedRow.Cells("JenisKeluhanColumn").Value.ToString()
            Dim keterangan As String = selectedRow.Cells("KeteranganColumn").Value.ToString()

            ' Tampilkan data dari baris yang dipilih di inputan
            txtnama.Text = namaPenyewa
            cbNoKamar.SelectedItem = noKamar
            cbJenisKeluhan.SelectedItem = jenisKeluhan
            txtKeterangan.Text = keterangan
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' Mendapatkan nilai dari inputan
        Dim namaPenyewa As String = txtnama.Text
        Dim idKamar As String = cbNoKamar.SelectedItem.ToString()
        Dim jenisKeluhan As String = cbJenisKeluhan.SelectedItem.ToString()
        Dim keterangan As String = txtKeterangan.Text

        ' Query untuk memasukkan data keluhan ke database
        Dim query As String = "INSERT INTO keluhan (nama, no_kamar, jenis_keluhan, keterangan) VALUES (@nama, @idKamar, @jenisKeluhan, @keterangan)"

        ' Gunakan koneksi
        Using connection As New MySqlConnection(CONN.ConnectionString)
            Using command As New MySqlCommand(query, connection)
                ' Tambahkan parameter
                command.Parameters.AddWithValue("@nama", namaPenyewa)
                command.Parameters.AddWithValue("@idKamar", idKamar)
                command.Parameters.AddWithValue("@jenisKeluhan", jenisKeluhan)
                command.Parameters.AddWithValue("@keterangan", keterangan)

                Try
                    ' Buka koneksi dan jalankan perintah SQL
                    connection.Open()
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()

                    ' Tampilkan pesan berdasarkan hasil eksekusi perintah SQL
                    If rowsAffected > 0 Then
                        MessageBox.Show("Keluhan berhasil ditambahkan ke database.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' Reset input fields
                        Kosong()

                        ' Memuat data ke DataGridView setelah menambahkan keluhan baru ke database
                        LoadDataGrid()
                    Else
                        MessageBox.Show("Gagal menambahkan keluhan ke database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ' Mendapatkan ID keluhan dari inputan
        Dim idKeluhan As String = txtSearch.Text.Trim()

        ' Memuat data dari database berdasarkan ID keluhan
        SearchKeluhanByID(idKeluhan)
    End Sub

    Private Sub SearchKeluhanByID(idKeluhan As String)
        ' Bersihkan DataGridView sebelum memuat data baru
        DataGridView1.Rows.Clear()

        ' Query untuk melakukan pencarian data keluhan berdasarkan ID keluhan
        Dim query As String = "SELECT * FROM keluhan WHERE id_keluhan = @idKeluhan"

        ' Gunakan koneksi
        Using connection As New MySqlConnection(CONN.ConnectionString)
            Using command As New MySqlCommand(query, connection)
                ' Tambahkan parameter ID keluhan
                command.Parameters.AddWithValue("@idKeluhan", idKeluhan)

                connection.Open()

                ' Gunakan MySqlDataReader untuk membaca data
                Using reader As MySqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        ' Ambil nilai kolom dari baris yang cocok dengan ID keluhan
                        Dim namaPenyewa As String = reader("nama").ToString()
                        Dim noKamar As String = reader("no_kamar").ToString()
                        Dim jenisKeluhan As String = reader("jenis_keluhan").ToString()
                        Dim keterangan As String = reader("keterangan").ToString()

                        ' Tambahkan baris ke DataGridView
                        DataGridView1.Rows.Add(idKeluhan, namaPenyewa, noKamar, jenisKeluhan, keterangan)
                    Else
                        MessageBox.Show("Keluhan dengan ID tersebut tidak ditemukan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Using
            End Using
        End Using
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        ' Mengosongkan input fields
        Kosong()

        ' Memuat data pada DataGridView
        LoadDataGrid()
    End Sub

    Private Sub pbBack_Click(sender As Object, e As EventArgs) Handles pbBack.Click
        ' Sembunyikan Form Keluhan
        Me.Hide()

        ' Buat instance Form Dashboard Penyewa
        Dim DashboardForm As New Dashboard_Penyewa()

        ' Tampilkan Form Dashboard Penyewa
        Dashboard_Penyewa.Show()
    End Sub

End Class
