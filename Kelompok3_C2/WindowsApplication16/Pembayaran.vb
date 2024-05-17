Imports MySql.Data.MySqlClient

Public Class Pembayaran

    Private Sub pbBack_Click(sender As Object, e As EventArgs) Handles pbBack.Click
        ' Sembunyikan Form Pembayaran
        Me.Hide()

        ' Buat instance Form Dashboard Admin
        Dim DashboardForm As New Dashboard_Admin()

        ' Tampilkan Form Dashboard Admin
        Dashboard_Admin.Show()
    End Sub

    Private Sub Pembayaran_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Memuat data ke ComboBox saat form dimuat
        LoadData()

        ' Menambahkan kolom-kolom ke DataGridView
        DataGridView1.Columns.Add("IdPembayaranColumn", "ID Pembayaran")
        DataGridView1.Columns.Add("IdTransaksiColumn", "ID Transaksi")
        DataGridView1.Columns.Add("NamaPenyewaColumn", "Nama Penyewa")
        DataGridView1.Columns.Add("NomorKamarColumn", "Nomor Kamar")
        DataGridView1.Columns.Add("LamaSewaColumn", "Lama Sewa")
        DataGridView1.Columns.Add("MetodeBayarColumn", "Metode Pembayaran")
        DataGridView1.Columns.Add("TotalColumn", "Total")
        DataGridView1.Columns.Add("TglBayarColumn", "Tanggal Bayar")

        ' Memuat data pada DataGridView saat form dimuat
        LoadDataGrid()
    End Sub

    Private Sub LoadData()
        ' Mengisi ComboBox ID Transaksi
        Dim adapter As New MySqlDataAdapter("SELECT id_transaksi FROM transaksi", CONN)
        Dim dt As New DataTable()
        adapter.Fill(dt)
        cbIdTransaksi.DataSource = dt
        cbIdTransaksi.DisplayMember = "id_transaksi"
        cbIdTransaksi.ValueMember = "id_transaksi"

        ' Menambahkan pilihan metode pembayaran ke ComboBox
        cbMetodeBayar.Items.Add("Transfer")
        cbMetodeBayar.Items.Add("Tunai")
    End Sub

    Private Sub LoadDataGrid()
        ' Membersihkan DataGridView sebelum memuat data baru
        DataGridView1.Rows.Clear()

        ' Memuat data dari database ke DataGridView
        Dim query As String = "SELECT * FROM pembayaran"
        Using connection As New MySqlConnection(CONN.ConnectionString)
            Using command As New MySqlCommand(query, connection)
                connection.Open()
                Using reader As MySqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        Dim idPembayaran As String = reader("id_pembayaran").ToString()
                        Dim idTransaksi As String = reader("id_transaksi").ToString()
                        Dim nama As String = reader("nama").ToString()
                        Dim noKamar As String = reader("no_kamar").ToString()
                        Dim lamaSewa As String = reader("lama_sewa").ToString()
                        Dim metodeBayar As String = reader("metode_bayar").ToString()
                        Dim total As String = reader("total").ToString()
                        Dim tglBayar As String = DateTime.Parse(reader("tgl_bayar").ToString()).ToShortDateString()
                        DataGridView1.Rows.Add(idPembayaran, idTransaksi, nama, noKamar, lamaSewa, metodeBayar, total, tglBayar)
                    End While
                End Using
            End Using
        End Using
    End Sub

    Private Sub cbIdTransaksi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbIdTransaksi.SelectedIndexChanged
        ' Pastikan ada nilai yang dipilih dalam ComboBox
        If cbIdTransaksi.SelectedItem IsNot Nothing Then
            ' Mengambil ID transaksi yang dipilih
            Dim selectedIdTransaksi As String = cbIdTransaksi.SelectedValue.ToString()

            ' Melakukan pengambilan data berdasarkan ID transaksi
            Dim query As String = "SELECT penyewa.nama, kamar.no_kamar, transaksi.lama_sewa, transaksi.total " &
                                  "FROM transaksi " &
                                  "JOIN penyewa ON transaksi.id = penyewa.id " &
                                  "JOIN kamar ON transaksi.no_kamar = kamar.no_kamar " &
                                  "WHERE transaksi.id_transaksi = @idTransaksi"

            Using connection As New MySqlConnection(CONN.ConnectionString)
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@idTransaksi", selectedIdTransaksi)
                    connection.Open()

                    Using reader As MySqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            ' Menampilkan informasi transaksi di TextBox atau kontrol lainnya
                            txtNama.Text = reader("nama").ToString()
                            txtNoKamar.Text = reader("no_kamar").ToString()
                            txtLamaSewa.Text = reader("lama_sewa").ToString()
                            txtTotal.Text = reader("total").ToString()
                        End If
                    End Using
                End Using
            End Using
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        ' Mendapatkan indeks baris yang diklik
        Dim rowIndex As Integer = e.RowIndex

        If rowIndex >= 0 Then ' Pastikan baris yang diklik adalah baris yang valid
            ' Mendapatkan nilai dari kolom-kolom yang diklik
            Dim idPembayaran As String = DataGridView1.Rows(rowIndex).Cells("IdPembayaranColumn").Value.ToString()
            Dim idTransaksi As String = DataGridView1.Rows(rowIndex).Cells("IdTransaksiColumn").Value.ToString()
            Dim nama As String = DataGridView1.Rows(rowIndex).Cells("NamaPenyewaColumn").Value.ToString()
            Dim noKamar As String = DataGridView1.Rows(rowIndex).Cells("NomorKamarColumn").Value.ToString()
            Dim lamaSewa As String = DataGridView1.Rows(rowIndex).Cells("LamaSewaColumn").Value.ToString()
            Dim metodeBayar As String = DataGridView1.Rows(rowIndex).Cells("MetodeBayarColumn").Value.ToString()
            Dim total As String = DataGridView1.Rows(rowIndex).Cells("TotalColumn").Value.ToString()
            Dim tglBayar As String = DataGridView1.Rows(rowIndex).Cells("TglBayarColumn").Value.ToString()

            ' Menampilkan nilai dari baris yang diklik di inputan
            txtIdPembayaran.Text = idPembayaran
            cbIdTransaksi.SelectedValue = idTransaksi
            txtNama.Text = nama
            txtNoKamar.Text = noKamar
            txtLamaSewa.Text = lamaSewa
            cbMetodeBayar.SelectedItem = metodeBayar
            txtTotal.Text = total
            DtmTanggalBayar.Value = DateTime.Parse(tglBayar)
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        ' Mendapatkan nilai dari inputan
        Dim idPembayaran As String = txtIdPembayaran.Text.Trim()
        Dim idTransaksi As String = cbIdTransaksi.SelectedValue.ToString()
        ' Melakukan query ke database untuk mendapatkan data transaksi berdasarkan ID transaksi
        Dim queryTransaksi As String = "SELECT * FROM transaksi WHERE id_transaksi = @idTransaksi"
        Dim noKamar As String = ""
        Dim nama As String = ""
        Dim lamaSewa As String = ""
        Using connection As New MySqlConnection(CONN.ConnectionString)
            Using command As New MySqlCommand(queryTransaksi, connection)
                command.Parameters.AddWithValue("@idTransaksi", idTransaksi)
                connection.Open()
                Using reader As MySqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        noKamar = reader("no_kamar").ToString()
                        nama = reader("nama").ToString()
                        lamaSewa = reader("lama_sewa").ToString()
                    End If
                End Using
            End Using
        End Using
        Dim total As Integer = Convert.ToInt32(txtTotal.Text)

        ' Mengambil nilai dari inputan metode pembayaran dan tanggal bayar
        Dim metodeBayar As String = cbMetodeBayar.SelectedItem.ToString()
        Dim tglBayar As String = DtmTanggalBayar.Value.ToString("yyyy-MM-dd")

        ' Menyimpan data pembayaran ke dalam database
        Dim queryInsert As String = "INSERT INTO pembayaran (id_pembayaran, id_transaksi, nama, no_kamar, lama_sewa, metode_bayar, total, tgl_bayar) VALUES (@idPembayaran, @idTransaksi, @nama, @noKamar, @lamaSewa, @metodeBayar, @total, @tglBayar)"
        Using connection As New MySqlConnection(CONN.ConnectionString)
            Using command As New MySqlCommand(queryInsert, connection)
                command.Parameters.AddWithValue("@idPembayaran", idPembayaran)
                command.Parameters.AddWithValue("@idTransaksi", idTransaksi)
                command.Parameters.AddWithValue("@nama", nama)
                command.Parameters.AddWithValue("@noKamar", noKamar)
                command.Parameters.AddWithValue("@lamaSewa", lamaSewa)
                command.Parameters.AddWithValue("@metodeBayar", metodeBayar)
                command.Parameters.AddWithValue("@total", total)
                command.Parameters.AddWithValue("@tglBayar", tglBayar)
                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using

        ' Memuat kembali data ke dalam DataGridView setelah penambahan
        LoadDataGrid()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' Mendapatkan ID pembayaran yang akan dihapus
        Dim idPembayaran As String = txtIdPembayaran.Text

        ' Konfirmasi penghapusan
        Dim result As DialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus data pembayaran dengan ID " & idPembayaran & "?", "Konfirmasi Hapus Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            ' Jika pengguna yakin, lanjutkan dengan penghapusan
            Dim query As String = "DELETE FROM pembayaran WHERE id_pembayaran = @idPembayaran"
            Using connection As New MySqlConnection(CONN.ConnectionString)
                Using command As New MySqlCommand(query, connection)
                    ' Menambahkan parameter
                    command.Parameters.AddWithValue("@idPembayaran", idPembayaran)

                    ' Membuka koneksi dan menjalankan perintah SQL
                    connection.Open()
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()

                    ' Menampilkan pesan berdasarkan hasil eksekusi perintah SQL
                    If rowsAffected > 0 Then
                        MessageBox.Show("Data berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' Memuat ulang data DataGridView
                        LoadDataGrid()
                    Else
                        MessageBox.Show("Gagal menghapus data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            End Using
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ' Mendapatkan nilai dari inputan untuk melakukan pencarian
        Dim searchText As String = txtSearch.Text.Trim()

        If searchText <> "" Then
            ' Mencari data berdasarkan kriteria pencarian
            Dim query As String = "SELECT * FROM pembayaran WHERE id_pembayaran = @searchText"
            Using connection As New MySqlConnection(CONN.ConnectionString)
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@searchText", searchText)
                    connection.Open()

                    Using reader As MySqlDataReader = command.ExecuteReader()
                        If reader.HasRows Then
                            ' Kosongkan DataGridView
                            DataGridView1.Rows.Clear()

                            ' Tampilkan hasil pencarian pada DataGridView
                            While reader.Read()
                                Dim idPembayaran As String = reader("id_pembayaran").ToString()
                                Dim idTransaksi As String = reader("id_transaksi").ToString()
                                Dim nama As String = reader("nama").ToString()
                                Dim noKamar As String = reader("no_kamar").ToString()
                                Dim lamaSewa As String = reader("lama_sewa").ToString()
                                Dim metodeBayar As String = reader("metode_bayar").ToString()
                                Dim total As String = reader("total").ToString()
                                Dim tglBayar As String = reader("tgl_bayar").ToString()
                                DataGridView1.Rows.Add(idPembayaran, idTransaksi, nama, noKamar, lamaSewa, metodeBayar, total, tglBayar)
                            End While
                        Else
                            ' Jika data tidak ditemukan, tampilkan pesan
                            DataGridView1.Rows.Clear()
                            MessageBox.Show("Data tidak ditemukan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End Using
                End Using
            End Using
        Else
            ' Jika input pencarian kosong, muat ulang semua data pada DataGridView
            LoadDataGrid()
        End If
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        ' Mengosongkan nilai pada inputan dan ComboBox
        txtIdPembayaran.Clear()
        cbIdTransaksi.SelectedIndex = -1
        txtNama.Clear()
        txtNoKamar.Clear()
        txtLamaSewa.Clear()
        cbMetodeBayar.SelectedIndex = -1
        txtTotal.Clear()
        txtSearch.Clear()
        DtmTanggalBayar.Value = DateTime.Now ' Set tanggal bayar kembali ke tanggal saat ini

        LoadDataGrid()
    End Sub

End Class
