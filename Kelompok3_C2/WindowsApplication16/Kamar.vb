Imports MySql.Data.MySqlClient

Public Class Kamar

    Sub Kosong()
        txtTipeKamar.Clear()
        txtNoKamar.Clear()
        txtHargaSewa.Clear()
        txtSearch.Clear()
        cbLantai.SelectedIndex = -1
        txtTipeKamar.Focus()
    End Sub

    Sub tampilKamar()
        Dim DA As New MySqlDataAdapter("SELECT * FROM kamar", CONN)
        Dim DS As New DataSet()

        DS.Clear()
        DA.Fill(DS, "kamar")
        DataGridView2.DataSource = DS.Tables("kamar")
        DataGridView2.Refresh()
    End Sub

    Sub aturGrid()
        DataGridView2.Columns(0).Width = 75
        DataGridView2.Columns(1).Width = 75
        DataGridView2.Columns(2).Width = 75
        DataGridView2.Columns(3).Width = 75
        DataGridView2.Columns(0).HeaderText = "No. Kamar"
        DataGridView2.Columns(1).HeaderText = "Lantai"
        DataGridView2.Columns(2).HeaderText = "Tipe Kamar"
        DataGridView2.Columns(3).HeaderText = "Harga"
    End Sub

    Private Sub Kamar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        tampilKamar()
        Kosong()
        aturGrid()

        ' Isi ComboBox lantai
        cbLantai.Items.AddRange({"Lantai 1", "Lantai 2", "Lantai 3"})
    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView2.Rows(e.RowIndex)

            ' Menampilkan data yang sesuai di inputan
            cbLantai.SelectedItem = selectedRow.Cells("lantai").Value.ToString()
            txtTipeKamar.Text = selectedRow.Cells("tipe_kamar").Value.ToString() ' Menggunakan nama kolom yang sama dengan dataset
            txtHargaSewa.Text = selectedRow.Cells("harga").Value.ToString()
            txtNoKamar.Text = selectedRow.Cells("no_kamar").Value.ToString()
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtTipeKamar.Text = "" Or txtNoKamar.Text = "" Or txtHargaSewa.Text = "" Or cbLantai.SelectedIndex = -1 Then
            MsgBox("Data Belum Lengkap")
            txtTipeKamar.Focus()
            Return
        End If

        Dim CMD As MySqlCommand
        Dim RD As MySqlDataReader

        ' Periksa apakah nomor kamar sudah ada di seluruh tabel kamar
        CMD = New MySqlCommand("SELECT * FROM kamar WHERE no_kamar = @no_kamar", CONN)
        CMD.Parameters.AddWithValue("@no_kamar", txtNoKamar.Text)

        Try
            CONN.Open()
            RD = CMD.ExecuteReader

            If Not RD.HasRows Then
                RD.Close()
                ' Nomor kamar belum ada, maka bisa disimpan
                CMD = New MySqlCommand("INSERT INTO kamar (no_kamar, lantai, tipe_kamar, harga) VALUES (@no_kamar, @lantai, @tipe_kamar, @harga)", CONN)
                CMD.Parameters.AddWithValue("@no_kamar", txtNoKamar.Text)
                CMD.Parameters.AddWithValue("@lantai", cbLantai.SelectedItem.ToString())
                CMD.Parameters.AddWithValue("@tipe_kamar", txtTipeKamar.Text)
                CMD.Parameters.AddWithValue("@harga", txtHargaSewa.Text)
                CMD.ExecuteNonQuery()
                tampilKamar()
                Kosong()
                MsgBox("Simpan Data Sukses!")
                txtTipeKamar.Focus()
            Else
                RD.Close()
                MsgBox("Nomor Kamar Sudah Ada")
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            CONN.Close()
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If txtNoKamar.Text = "" Or cbLantai.SelectedIndex = -1 Or txtTipeKamar.Text = "" Or txtHargaSewa.Text = "" Then
            MsgBox("Lengkapi semua informasi terlebih dahulu")
            Return
        End If

        Dim noKamarToUpdate As String = txtNoKamar.Text.Trim()

        ' Check if the room number exists in the database
        Dim checkQuery As String = "SELECT COUNT(*) FROM kamar WHERE no_kamar = @no_kamar"
        Dim roomExists As Boolean = False

        Try
            Using CMD As New MySqlCommand(checkQuery, CONN)
                CMD.Parameters.AddWithValue("@no_kamar", noKamarToUpdate)
                CONN.Open()
                roomExists = Convert.ToInt32(CMD.ExecuteScalar()) > 0
            End Using
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            If CONN.State = ConnectionState.Open Then
                CONN.Close()
            End If
        End Try

        ' If the room exists, proceed with the update
        If roomExists Then
            Dim updateQuery As String = "UPDATE kamar SET lantai = @lantai, tipe_kamar = @tipe_kamar, harga = @harga WHERE no_kamar = @no_kamar"

            Try
                Using CMD As New MySqlCommand(updateQuery, CONN)
                    CMD.Parameters.AddWithValue("@lantai", cbLantai.SelectedItem.ToString())
                    CMD.Parameters.AddWithValue("@tipe_kamar", txtTipeKamar.Text)
                    CMD.Parameters.AddWithValue("@harga", txtHargaSewa.Text)
                    CMD.Parameters.AddWithValue("@no_kamar", noKamarToUpdate)
                    CONN.Open()
                    CMD.ExecuteNonQuery()
                    MsgBox("Data berhasil diubah")
                    tampilKamar()
                    Kosong()
                End Using
            Catch ex As Exception
                MsgBox("Error: " & ex.Message)
            Finally
                If CONN.State = ConnectionState.Open Then
                    CONN.Close()
                End If
            End Try
        Else
            MsgBox("Nomor Kamar tidak tersedia.")
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If txtNoKamar.Text = "" Then
            MsgBox("Nomor Kamar belum diisi")
            txtNoKamar.Focus()
        Else
            Dim noKamar As String = txtNoKamar.Text.Trim()

            ' Periksa apakah nomor kamar ada dalam database
            Dim checkQuery As String = "SELECT COUNT(*) FROM kamar WHERE no_kamar = @no_kamar"
            Dim kamarExists As Boolean = False

            Try
                Using CMD As New MySqlCommand(checkQuery, CONN)
                    CMD.Parameters.AddWithValue("@no_kamar", noKamar)
                    CONN.Open()
                    kamarExists = Convert.ToInt32(CMD.ExecuteScalar()) > 0
                End Using
            Catch ex As Exception
                MsgBox("Error: " & ex.Message)
            Finally
                If CONN.State = ConnectionState.Open Then
                    CONN.Close()
                End If
            End Try

            ' Jika nomor kamar tidak ditemukan, tampilkan pesan
            If Not kamarExists Then
                MsgBox("Nomor Kamar tidak tersedia.")
                Return
            End If

            ' Jika nomor kamar ada, lanjutkan dengan proses penghapusan
            Dim result As DialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus data dengan nomor kamar " & noKamar & "?", "Konfirmasi Hapus Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Try
                    Dim deleteQuery As String = "DELETE FROM kamar WHERE no_kamar = @no_kamar"
                    Dim CMD As New MySqlCommand(deleteQuery, CONN)
                    CMD.Parameters.AddWithValue("@no_kamar", noKamar)
                    CONN.Open()
                    CMD.ExecuteNonQuery()
                    CONN.Close()
                    MsgBox("Data berhasil dihapus")
                    tampilKamar()
                    Kosong()
                Catch ex As Exception
                    MsgBox("Error: " & ex.Message)
                Finally
                    If CONN.State = ConnectionState.Open Then
                        CONN.Close()
                    End If
                End Try
            End If
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim searchQuery As String = txtSearch.Text.Trim()
        If searchQuery <> "" Then
            Try
                Dim DA As New MySqlDataAdapter("SELECT * FROM kamar WHERE no_kamar LIKE '%" & searchQuery & "%'", CONN)
                Dim DS As New DataSet()
                DS.Clear()
                DA.Fill(DS, "kamar")

                If DS.Tables("kamar").Rows.Count > 0 Then
                    DataGridView2.DataSource = DS.Tables("kamar")
                    DataGridView2.Refresh()
                Else
                    MsgBox("Data tidak ditemukan.")
                    ' Hapus semua baris dari DataTable tetapi pertahankan struktur kolom
                    DS.Tables("kamar").Rows.Clear()
                    DataGridView2.DataSource = DS.Tables("kamar")
                End If
            Catch ex As Exception
                MsgBox("Error: " & ex.Message)
            End Try
        Else
            MsgBox("Masukkan nomor kamar untuk melakukan pencarian.")
        End If
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Kosong()
        tampilKamar()
    End Sub

    Private Sub pbBack_Click(sender As Object, e As EventArgs) Handles pbBack.Click
        ' Sembunyikan Form Kamar
        Me.Hide()

        ' Buat instance Form Dashboard Admin
        Dim DashboardForm As New Dashboard_Admin()

        ' Tampilkan Form Dashboard Admin
        Dashboard_Admin.Show()
    End Sub

End Class
