Imports MySql.Data.MySqlClient

Public Class Transaksi

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' Mendapatkan nilai dari inputan
        Dim idSewa As String = txtIdSewa.Text
        Dim idPenyewa As String = cbNIK.SelectedValue
        Dim namaPenyewa As String = txtNama.Text
        Dim idKamar As String = cbNoKamar.SelectedValue
        Dim lamaSewa As Integer = Convert.ToInt32(txtLamaSewa.Text)
        Dim totalHarga As Integer = lamaSewa * Convert.ToInt32(txtHargaSewa.Text)

        ' Periksa apakah ID transaksi sudah ada dalam database
        If IsIdTransaksiExists(idSewa) Then
            MessageBox.Show("ID transaksi sudah ada dalam database. Harap gunakan ID transaksi yang berbeda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim query As String = "INSERT INTO transaksi (id_transaksi, id, nama, no_kamar, lama_sewa, total) VALUES (@idSewa, @idPenyewa, @namaPenyewa, @idKamar, @lamaSewa, @totalHarga)"

        ' Membuat objek MySqlCommand
        Using connection As New MySqlConnection(CONN.ConnectionString)
            Using command As New MySqlCommand(query, connection)
                ' Menambahkan parameter
                command.Parameters.AddWithValue("@idSewa", idSewa)
                command.Parameters.AddWithValue("@idPenyewa", idPenyewa)
                command.Parameters.AddWithValue("@namaPenyewa", namaPenyewa)
                command.Parameters.AddWithValue("@idKamar", idKamar)
                command.Parameters.AddWithValue("@lamaSewa", lamaSewa)
                command.Parameters.AddWithValue("@totalHarga", totalHarga)

                ' Membuka koneksi dan menjalankan perintah SQL
                connection.Open()
                Dim rowsAffected As Integer = command.ExecuteNonQuery()

                ' Menampilkan pesan berdasarkan hasil eksekusi perintah SQL
                If rowsAffected > 0 Then
                    MessageBox.Show("Data berhasil ditambahkan ke database.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Tambahkan baris baru ke DataGridView
                    DataGridView1.Rows.Add(idSewa, idPenyewa, namaPenyewa, idKamar, lamaSewa, totalHarga)

                    ' Reset input fields
                    ResetFields()

                    ' Pilih baris baru berdasarkan ID transaksi yang baru ditambahkan
                    SelectRowById(idSewa)
                Else
                    MessageBox.Show("Gagal menambahkan data ke database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
        End Using
    End Sub

    Private Sub SelectRowById(idSewa As String)
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells("IdTransaksiColumn").Value.ToString() = idSewa Then
                row.Selected = True
                Exit For
            End If
        Next
    End Sub

    Private Function IsIdTransaksiExists(idTransaksi As String) As Boolean
        ' Cek apakah ID transaksi sudah ada dalam database
        Dim query As String = "SELECT COUNT(*) FROM transaksi WHERE id_transaksi = @idTransaksi"
        Using connection As New MySqlConnection(CONN.ConnectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@idTransaksi", idTransaksi)
                connection.Open()
                Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                Return count > 0
            End Using
        End Using
    End Function

    Private Sub ResetFields()
        ' Mengosongkan semua input fields
        txtIdSewa.Clear()
        txtNama.Clear()
        txtNoHp.Clear()
        txtJK.Clear()
        txtTipeKamar.Clear()
        txtLantai.Clear()
        txtHargaSewa.Clear()
        txtLamaSewa.Clear()
        txtTotal.Clear()
        txtSearch.Clear()

        ' Mengatur nilai default untuk ComboBox
        cbNIK.SelectedIndex = -1
        cbNoKamar.SelectedIndex = -1

        ' Fokuskan pada input pertama
        txtIdSewa.Focus()
    End Sub

    Private selectedNoKamar As String = "" ' Menyimpan nomor kamar yang dipilih

    Private Sub LoadData()
        ' Mengisi ComboBox NIK
        Dim adapter As New MySqlDataAdapter("SELECT * FROM penyewa", CONN)
        Dim dtPenyewa As New DataTable()
        adapter.Fill(dtPenyewa)
        cbNIK.DataSource = dtPenyewa
        cbNIK.DisplayMember = "id"
        cbNIK.ValueMember = "id"

        ' Mengisi ComboBox No Kamar
        Dim adapterKamar As New MySqlDataAdapter("SELECT * FROM kamar", CONN)
        Dim dtKamar As New DataTable()
        adapterKamar.Fill(dtKamar)

        ' Menghapus nomor kamar yang sudah dipilih sebelumnya dari opsi yang tersedia
        Dim selectedNoKamar As String = If(cbNoKamar.SelectedItem IsNot Nothing, cbNoKamar.SelectedValue.ToString(), "")
        If selectedNoKamar <> "" Then
            For i As Integer = dtKamar.Rows.Count - 1 To 0 Step -1
                If dtKamar.Rows(i)("no_kamar").ToString() = selectedNoKamar Then
                    dtKamar.Rows.RemoveAt(i)
                    Exit For
                End If
            Next
        End If

        ' Memuat data yang telah dimodifikasi ke ComboBox No Kamar
        cbNoKamar.DataSource = dtKamar
        cbNoKamar.DisplayMember = "no_kamar"
        cbNoKamar.ValueMember = "no_kamar"
    End Sub

    Private Sub Transaksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Memuat data ke ComboBox saat form dimuat
        koneksi() ' Menggunakan fungsi koneksi dari modul
        LoadData()

        ' Menambahkan kolom-kolom ke DataGridView
        DataGridView1.Columns.Add("IdTransaksiColumn", "Id Transaksi")
        DataGridView1.Columns.Add("IdPenyewaColumn", "ID Penyewa")
        DataGridView1.Columns.Add("NamaPenyewaColumn", "Nama Penyewa")
        DataGridView1.Columns.Add("IdKamarColumn", "ID Kamar")
        DataGridView1.Columns.Add("LamaSewaColumn", "Lama Sewa")
        DataGridView1.Columns.Add("TotalHargaColumn", "Total Harga")

        ' Memanggil method aturGrid saat form dimuat
        aturGrid()

        ' Menampilkan data pada DataGridView saat form dimuat
        LoadDataGrid()
    End Sub

    Private Sub LoadDataGrid()
        ' Membersihkan DataGridView sebelum memuat data baru
        DataGridView1.Rows.Clear()

        ' Memuat data dari database ke DataGridView
        Dim query As String = "SELECT * FROM transaksi"
        Using connection As New MySqlConnection(CONN.ConnectionString)
            Using command As New MySqlCommand(query, connection)
                connection.Open()
                Using reader As MySqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        Dim idSewa As String = reader("id_transaksi").ToString()
                        Dim idPenyewa As String = reader("id").ToString()
                        Dim namaPenyewa As String = reader("nama").ToString()
                        Dim idKamar As String = reader("no_kamar").ToString()
                        Dim lamaSewa As String = reader("lama_sewa").ToString()
                        Dim totalHarga As String = reader("total").ToString()
                        ' Tambahkan baris ke DataGridView dan masukkan nilai Total Harga ke kolom Total Harga
                        DataGridView1.Rows.Add(idSewa, idPenyewa, namaPenyewa, idKamar, lamaSewa, totalHarga)
                        ' Masukkan nilai Total Harga ke dalam kolom "Total Harga" pada baris terakhir
                        DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells("TotalHargaColumn").Value = totalHarga
                    End While
                End Using
            End Using
        End Using
    End Sub

    Private Sub cbNIK_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbNIK.SelectedIndexChanged
        ' Check if the selected item is not null before accessing SelectedValue
        If cbNIK.SelectedItem IsNot Nothing Then
            ' Access SelectedValue after ensuring it's not null
            Dim selectedNIK As String = cbNIK.SelectedValue.ToString()
            ' Now proceed with the rest of your code
            Dim query As String = "SELECT * FROM penyewa WHERE id = @id"

            Using connection As New MySqlConnection(CONN.ConnectionString)
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@id", selectedNIK)
                    connection.Open()

                    Using reader As MySqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            txtNama.Text = reader("nama").ToString()
                            txtNoHp.Text = reader("no_hp").ToString()
                            txtJK.Text = reader("jenis_kelamin").ToString()
                        End If
                    End Using
                End Using
            End Using
        End If
    End Sub

    Private Sub cbNoKamar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbNoKamar.SelectedIndexChanged
        If cbNoKamar.SelectedItem IsNot Nothing Then
            Dim selectedNoKamar As String = cbNoKamar.SelectedValue.ToString()

            ' Periksa apakah nomor kamar sudah ada dalam transaksi
            If IsNomorKamarUnavailable(selectedNoKamar) Then
                MessageBox.Show("Nomor kamar tidak tersedia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ' Kosongkan ComboBox No Kamar
                cbNoKamar.SelectedIndex = -1
                Return ' Hentikan eksekusi jika nomor kamar tidak tersedia
            End If

            ' Jika nomor kamar tersedia, lanjutkan dengan menampilkan data kamar
            Dim query As String = "SELECT * FROM kamar WHERE no_kamar = @no_kamar"
            Using connection As New MySqlConnection(CONN.ConnectionString)
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@no_kamar", selectedNoKamar)
                    connection.Open()

                    Using reader As MySqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            txtTipeKamar.Text = reader("tipe_kamar").ToString()
                            txtLantai.Text = reader("lantai").ToString()
                            txtHargaSewa.Text = reader("harga").ToString()
                        End If
                    End Using
                End Using
            End Using
        End If
    End Sub

    Private Function IsNomorKamarUnavailable(selectedNoKamar As String) As Boolean
        ' Cek apakah nomor kamar sudah ada dalam transaksi
        Dim query As String = "SELECT COUNT(*) FROM transaksi WHERE no_kamar = @no_kamar"
        Using connection As New MySqlConnection(CONN.ConnectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@no_kamar", selectedNoKamar)
                connection.Open()
                Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                Return count > 0 ' True jika kamar tidak tersedia
            End Using
        End Using
    End Function

    Private Sub aturGrid()
        ' Menentukan lebar kolom
        DataGridView1.Columns(0).Width = 75 ' Id Transaksi
        DataGridView1.Columns(1).Width = 75 ' ID Penyewa
        DataGridView1.Columns(2).Width = 75 ' Nama Penyewa
        DataGridView1.Columns(3).Width = 75 ' ID Kamar
        DataGridView1.Columns(4).Width = 75 ' Lama Sewa
        DataGridView1.Columns(5).Width = 75 ' Total Harga

        ' Menentukan header kolom
        DataGridView1.Columns(0).HeaderText = "Id Transaksi"
        DataGridView1.Columns(1).HeaderText = "ID Penyewa"
        DataGridView1.Columns(2).HeaderText = "Nama Penyewa"
        DataGridView1.Columns(3).HeaderText = "ID Kamar"
        DataGridView1.Columns(4).HeaderText = "Lama Sewa"
        DataGridView1.Columns(5).HeaderText = "Total Harga"
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        ' Memilih baris saat di-klik pada DataGridView
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

            ' Menampilkan data yang sesuai di inputan
            txtIdSewa.Text = selectedRow.Cells("IdTransaksiColumn").Value.ToString()
            cbNIK.SelectedValue = selectedRow.Cells("IdPenyewaColumn").Value
            txtNama.Text = selectedRow.Cells("NamaPenyewaColumn").Value.ToString()
            cbNoKamar.SelectedValue = selectedRow.Cells("IdKamarColumn").Value
            txtLamaSewa.Text = selectedRow.Cells("LamaSewaColumn").Value.ToString()

            ' Menampilkan data NIK, nomor HP, jenis kelamin, dan total
            Dim selectedNIK As String = selectedRow.Cells("IdPenyewaColumn").Value.ToString()
            Dim query As String = "SELECT * FROM penyewa WHERE id = @id"

            Using connection As New MySqlConnection(CONN.ConnectionString)
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@id", selectedNIK)
                    connection.Open()

                    Using reader As MySqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            txtNoHp.Text = reader("no_hp").ToString()
                            txtJK.Text = reader("jenis_kelamin").ToString()
                        End If
                    End Using
                End Using
            End Using

            ' Menampilkan nilai total
            txtTotal.Text = selectedRow.Cells("TotalHargaColumn").Value.ToString()
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        ' Mendapatkan nilai dari inputan
        Dim idSewa As String = txtIdSewa.Text
        Dim idPenyewa As String = cbNIK.SelectedValue
        Dim namaPenyewa As String = txtNama.Text
        Dim idKamar As String = cbNoKamar.SelectedValue
        Dim lamaSewa As Integer = Convert.ToInt32(txtLamaSewa.Text)
        Dim hargaSewa As Integer
        If Not Integer.TryParse(txtHargaSewa.Text, hargaSewa) Then
            MessageBox.Show("Harga sewa harus berupa angka yang valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ' Hentikan eksekusi jika harga sewa tidak valid
        End If

        Dim totalHarga As Integer = lamaSewa * hargaSewa

        ' Periksa apakah nomor kamar yang dipilih tersedia
        If IsNomorKamarUnavailable(idKamar) Then
            MessageBox.Show("Nomor kamar tidak tersedia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ' Hentikan eksekusi jika nomor kamar tidak tersedia
        End If

        ' Periksa apakah ID transaksi sudah ada dalam database
        If Not IsIdTransaksiExists(idSewa) Then
            MessageBox.Show("ID transaksi tidak ditemukan dalam database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim query As String = "UPDATE transaksi SET id = @idPenyewa, nama = @namaPenyewa, no_kamar = @idKamar, lama_sewa = @lamaSewa, total = @totalHarga WHERE id_transaksi = @idSewa"

        ' Membuat objek MySqlCommand
        Using connection As New MySqlConnection(CONN.ConnectionString)
            Using command As New MySqlCommand(query, connection)
                ' Menambahkan parameter
                command.Parameters.AddWithValue("@idSewa", idSewa)
                command.Parameters.AddWithValue("@idPenyewa", idPenyewa)
                command.Parameters.AddWithValue("@namaPenyewa", namaPenyewa)
                command.Parameters.AddWithValue("@idKamar", idKamar)
                command.Parameters.AddWithValue("@lamaSewa", lamaSewa)
                command.Parameters.AddWithValue("@totalHarga", totalHarga)

                ' Membuka koneksi dan menjalankan perintah SQL
                connection.Open()
                Dim rowsAffected As Integer = command.ExecuteNonQuery()

                ' Menampilkan pesan berdasarkan hasil eksekusi perintah SQL
                If rowsAffected > 0 Then
                    MessageBox.Show("Data berhasil diperbarui.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Memuat ulang data DataGridView
                    LoadDataGrid()

                    ' Reset input fields
                    ResetFields()

                    ' Pilih baris yang diperbarui
                    SelectRowById(idSewa)
                Else
                    MessageBox.Show("Gagal memperbarui data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
        End Using
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' Mendapatkan ID transaksi yang akan dihapus
        Dim idSewa As String = txtIdSewa.Text

        ' Periksa apakah ID transaksi ada dalam database
        If Not IsIdTransaksiExists(idSewa) Then
            MessageBox.Show("ID transaksi tidak ditemukan dalam database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Konfirmasi penghapusan
        Dim result As DialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus transaksi dengan ID " & idSewa & "?", "Konfirmasi Hapus Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            ' Jika pengguna yakin, lanjutkan dengan penghapusan
            Dim query As String = "DELETE FROM transaksi WHERE id_transaksi = @idSewa"
            Using connection As New MySqlConnection(CONN.ConnectionString)
                Using command As New MySqlCommand(query, connection)
                    ' Menambahkan parameter
                    command.Parameters.AddWithValue("@idSewa", idSewa)

                    ' Membuka koneksi dan menjalankan perintah SQL
                    connection.Open()
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()

                    ' Menampilkan pesan berdasarkan hasil eksekusi perintah SQL
                    If rowsAffected > 0 Then
                        MessageBox.Show("Data berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' Memuat ulang data DataGridView
                        LoadDataGrid()

                        ' Reset input fields
                        ResetFields()
                    Else
                        MessageBox.Show("Gagal menghapus data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            End Using
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ' Mendapatkan nilai dari inputan
        Dim searchQuery As String = txtSearch.Text.Trim()

        If searchQuery <> "" Then
            ' Mencari data berdasarkan ID transaksi
            Dim query As String = "SELECT * FROM transaksi WHERE id_transaksi LIKE '%" & searchQuery & "%'"
            Using connection As New MySqlConnection(CONN.ConnectionString)
                Using command As New MySqlCommand(query, connection)
                    connection.Open()

                    Using reader As MySqlDataReader = command.ExecuteReader()
                        If reader.HasRows Then
                            ' Kosongkan DataGridView
                            DataGridView1.Rows.Clear()

                            ' Tampilkan hasil pencarian pada DataGridView
                            While reader.Read()
                                Dim idSewa As String = reader("id_transaksi").ToString()
                                Dim idPenyewa As String = reader("id").ToString()
                                Dim namaPenyewa As String = reader("nama").ToString()
                                Dim idKamar As String = reader("no_kamar").ToString()
                                Dim lamaSewa As String = reader("lama_sewa").ToString()
                                Dim totalHarga As String = reader("total").ToString()
                                DataGridView1.Rows.Add(idSewa, idPenyewa, namaPenyewa, idKamar, lamaSewa, totalHarga)
                            End While
                        Else
                            ' Jika data tidak ditemukan, kosongkan DataGridView
                            DataGridView1.Rows.Clear()
                            MessageBox.Show("Data tidak ditemukan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End Using
                End Using
            End Using
        Else
            ' Jika input pencarian kosong, tampilkan pesan
            MessageBox.Show("Masukkan ID transaksi untuk melakukan pencarian.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub pbBack_Click(sender As Object, e As EventArgs) Handles pbBack.Click
        ' Sembunyikan Form Transaksi
        Me.Hide()

        ' Buat instance Form Dashboard Admin
        Dim DashboardForm As New Dashboard_Admin()

        ' Tampilkan Form Dashboard Admin
        Dashboard_Admin.Show()
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        ' Mengosongkan input fields
        ResetFields()

        ' Memuat data pada DataGridView
        LoadDataGrid()
    End Sub

End Class
