Imports MySql.Data.MySqlClient

Public Class DataPenyewa

    Sub TampilPenyewa()
        Dim DA As New MySqlDataAdapter("SELECT * FROM penyewa", CONN)
        Dim DS As New DataSet()

        DS.Clear()
        DA.Fill(DS, "penyewa")
        DataGridView1.DataSource = DS.Tables("penyewa")
        DataGridView1.Refresh()
    End Sub

    Private Sub DataPenyewa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TampilPenyewa()
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

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' Pastikan ada baris yang dipilih
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)

            ' Dapatkan nilai ID dari kolom pertama (misalnya)
            Dim id As String = selectedRow.Cells("id").Value.ToString()

            ' Konfirmasi penghapusan
            Dim result As DialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus data ini?", "Konfirmasi Penghapusan", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                ' Hapus baris dari DataGridView
                DataGridView1.Rows.Remove(selectedRow)

                ' Hapus baris dari database (jika perlu)
                Try
                    Dim deleteCommand As New MySqlCommand("DELETE FROM penyewa WHERE id = @id", CONN)
                    deleteCommand.Parameters.AddWithValue("@id", id)
                    deleteCommand.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox("Error: " & ex.Message)
                End Try
            End If
        Else
            MsgBox("Pilih baris yang ingin Anda hapus.")
        End If
    End Sub

    Private Sub pbBack_Click(sender As Object, e As EventArgs) Handles pbBack.Click
        ' Sembunyikan Form Penyewa
        Me.Hide()

        ' Buat instance Form Dashboard Admin
        Dim DashboardForm As New Dashboard_Admin()

        ' Tampilkan Form Dashboard Admin
        Dashboard_Admin.Show()
    End Sub

End Class
