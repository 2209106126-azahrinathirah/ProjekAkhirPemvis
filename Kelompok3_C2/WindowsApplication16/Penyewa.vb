Imports MySql.Data.MySqlClient

Public Class Penyewa
    Private dataPenyewaForm As DataPenyewa
    Private currentusername As String

    ' Constructor untuk form Penyewa
    Public Sub New(dataPenyewaForm As DataPenyewa, username As String)
        InitializeComponent()
        Me.dataPenyewaForm = dataPenyewaForm
        Me.currentUsername = username
    End Sub

    Sub Kosong()
        txtNama.Clear()
        txtNIK.Clear()
        txtNoHp.Clear()
        rbLakiLaki.Checked = False
        rbPerempuan.Checked = False
        txtSearch.Clear()
        txtNama.Focus()
    End Sub

    Sub tampilPenyewa()
        Dim query As String = "SELECT id, username, nama, no_hp, jenis_kelamin FROM penyewa WHERE username = @username"
        Dim DA As New MySqlDataAdapter(query, CONN)
        Dim DS As New DataSet()

        ' Menyertakan parameter username dalam kueri
        DA.SelectCommand.Parameters.AddWithValue("@username", GlobalVariables.CurrentUsername)

        DS.Clear()
        DA.Fill(DS, "penyewa")
        DataGridView1.DataSource = DS.Tables("penyewa")
        DataGridView1.Refresh()
    End Sub

    Sub aturGrid()
        DataGridView1.Columns(0).Width = 60 ' Lebar kolom NIK
        DataGridView1.Columns(1).Width = 75 ' Lebar kolom Username
        DataGridView1.Columns(2).Width = 75 ' Lebar kolom Nama
        DataGridView1.Columns(3).Width = 175 ' Lebar kolom No. HP
        DataGridView1.Columns(4).Width = 75 ' Lebar kolom Jenis Kelamin

        DataGridView1.Columns(0).HeaderText = "NIK"
        DataGridView1.Columns(1).HeaderText = "Username"
        DataGridView1.Columns(2).HeaderText = "Nama"
        DataGridView1.Columns(3).HeaderText = "No. HP"
        DataGridView1.Columns(4).HeaderText = "Jenis Kelamin"
    End Sub

    Private Sub Penyewa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set nilai GlobalVariables.CurrentUsername
        GlobalVariables.CurrentUsername = currentUsername

        ' Panggil tampilPenyewa setelah menetapkan nilai GlobalVariables.CurrentUsername
        tampilPenyewa()

        ' Sisanya dari kode
        Kosong()
        aturGrid()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtNama.Text = "" Or txtNIK.Text = "" Or txtNoHp.Text = "" Or (Not rbLakiLaki.Checked And Not rbPerempuan.Checked) Then
            MsgBox("Data Belum Lengkap")
            txtNama.Focus()
        Else
            Dim CMD As MySqlCommand
            Dim RD As MySqlDataReader

            ' Periksa apakah NIK sudah ada di tabel penyewa
            CMD = New MySqlCommand("SELECT * FROM penyewa WHERE id = @id", CONN)
            CMD.Parameters.AddWithValue("@id", txtNIK.Text)
            RD = CMD.ExecuteReader

            If Not RD.HasRows Then
                RD.Close()
                Dim jenisKelamin As String = If(rbLakiLaki.Checked, "Laki-laki", "Perempuan")

                ' Tambahkan penyewa baru jika NIK belum ada
                CMD = New MySqlCommand("INSERT INTO penyewa (nama, id, no_hp, jenis_kelamin, username) VALUES (@nama, @id, @no_hp, @jenis_kelamin, @username)", CONN)
                CMD.Parameters.AddWithValue("@nama", txtNama.Text)
                CMD.Parameters.AddWithValue("@id", txtNIK.Text)
                CMD.Parameters.AddWithValue("@no_hp", txtNoHp.Text)
                CMD.Parameters.AddWithValue("@jenis_kelamin", jenisKelamin)
                CMD.Parameters.AddWithValue("@username", GlobalVariables.CurrentUsername)
                CMD.ExecuteNonQuery()
                MsgBox("Data Berhasil Disimpan!")
                tampilPenyewa()
                Kosong()
                txtNama.Focus()
            Else
                RD.Close()
                MsgBox("NIK Sudah Ada")
            End If
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If txtNama.Text = "" Or txtNIK.Text = "" Or txtNoHp.Text = "" Or (Not rbLakiLaki.Checked And Not rbPerempuan.Checked) Then
            MsgBox("Lengkapi semua informasi terlebih dahulu")
            Return
        End If

        Dim NIKToUpdate As String = txtNIK.Text.Trim()

        ' Periksa apakah NIK ada di tabel penyewa
        Dim checkQuery As String = "SELECT COUNT(*) FROM penyewa WHERE id = @id AND username = @username"
        Dim NIKExists As Boolean = False

        Try
            Using CMD As New MySqlCommand(checkQuery, CONN)
                CMD.Parameters.AddWithValue("@id", NIKToUpdate)
                CMD.Parameters.AddWithValue("@username", GlobalVariables.CurrentUsername)
                CONN.Open()
                NIKExists = Convert.ToInt32(CMD.ExecuteScalar()) > 0
            End Using
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            If CONN.State = ConnectionState.Open Then
                CONN.Close()
            End If
        End Try

        ' Jika NIK ada, lanjutkan dengan pembaruan
        If NIKExists Then
            Dim updateQuery As String = "UPDATE penyewa SET nama = @nama, no_hp = @no_hp, jenis_kelamin = @jenis_kelamin WHERE id = @id AND username = @username"

            Try
                Using CMD As New MySqlCommand(updateQuery, CONN)
                    CMD.Parameters.AddWithValue("@nama", txtNama.Text)
                    CMD.Parameters.AddWithValue("@no_hp", txtNoHp.Text)
                    Dim jenisKelamin As String = If(rbLakiLaki.Checked, "Laki-laki", "Perempuan")
                    CMD.Parameters.AddWithValue("@jenis_kelamin", jenisKelamin)
                    CMD.Parameters.AddWithValue("@id", NIKToUpdate)
                    CMD.Parameters.AddWithValue("@username", GlobalVariables.CurrentUsername)
                    CONN.Open()
                    CMD.ExecuteNonQuery()
                    MsgBox("Data berhasil diubah")
                    tampilPenyewa()
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
            MsgBox("NIK tidak tersedia.")
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If txtNIK.Text = "" Then
            MsgBox("NIK belum diisi")
            txtNIK.Focus()
        Else
            Dim NIKToDelete As String = txtNIK.Text.Trim()

            ' Periksa apakah NIK ada dalam database
            Dim checkQuery As String = "SELECT COUNT(*) FROM penyewa WHERE id = @id AND username = @username"
            Dim NIKExists As Boolean = False

            Try
                Using CMD As New MySqlCommand(checkQuery, CONN)
                    CMD.Parameters.AddWithValue("@id", NIKToDelete)
                    CMD.Parameters.AddWithValue("@username", GlobalVariables.CurrentUsername)
                    CONN.Open()
                    NIKExists = Convert.ToInt32(CMD.ExecuteScalar()) > 0
                End Using
            Catch ex As Exception
                MsgBox("Error: " & ex.Message)
            Finally
                If CONN.State = ConnectionState.Open Then
                    CONN.Close()
                End If
            End Try

            ' Jika NIK tidak ditemukan, tampilkan pesan
            If Not NIKExists Then
                MsgBox("NIK tidak tersedia.")
                Return
            End If

            ' Jika NIK ada, lanjutkan dengan proses penghapusan
            Dim result As DialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus data dengan NIK " & NIKToDelete & "?", "Konfirmasi Hapus Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Try
                    Dim deleteQuery As String = "DELETE FROM penyewa WHERE id = @id"
                    Dim CMD As New MySqlCommand(deleteQuery, CONN)
                    CMD.Parameters.AddWithValue("@id", NIKToDelete)
                    CONN.Open()
                    CMD.ExecuteNonQuery()
                    CONN.Close()
                    MsgBox("Data berhasil dihapus")

                    ' Perbarui tampilan DataGridView setelah menghapus data
                    tampilPenyewa()
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
                Dim DA As New MySqlDataAdapter("SELECT * FROM penyewa WHERE id LIKE '%" & searchQuery & "%'", CONN)
                Dim DS As New DataSet()
                DS.Clear()
                DA.Fill(DS, "penyewa")

                If DS.Tables("penyewa").Rows.Count > 0 Then
                    DataGridView1.DataSource = DS.Tables("penyewa")
                    DataGridView1.Refresh()
                Else
                    MsgBox("Data tidak ditemukan.")
                    ' Hapus semua baris dari DataTable tetapi pertahankan struktur kolom
                    DS.Tables("penyewa").Rows.Clear()
                    DataGridView1.DataSource = DS.Tables("penyewa")
                End If
            Catch ex As Exception
                MsgBox("Error: " & ex.Message)
            End Try
        Else
            MsgBox("Masukkan NIK untuk melakukan pencarian.")
        End If
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Kosong()
        tampilPenyewa()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

            ' Menampilkan data yang sesuai di inputan
            txtNIK.Text = selectedRow.Cells("id").Value.ToString()
            txtNama.Text = selectedRow.Cells("nama").Value.ToString()
            txtNoHp.Text = selectedRow.Cells("no_hp").Value.ToString()
            Dim jenisKelamin As String = selectedRow.Cells("jenis_kelamin").Value.ToString()
            If jenisKelamin = "Laki-laki" Then
                rbLakiLaki.Checked = True
            ElseIf jenisKelamin = "Perempuan" Then
                rbPerempuan.Checked = True
            End If
        End If
    End Sub

    Private Sub pbBack_Click(sender As Object, e As EventArgs) Handles pbBack.Click
        ' Sembunyikan Form Penyewa
        Me.Hide()

        ' Buat instance Form Dashboard Penyewa
        Dim DashboardForm As New Dashboard_Penyewa()

        ' Tampilkan Form Dashboard Penyewa
        Dashboard_Penyewa.Show()
    End Sub

End Class

