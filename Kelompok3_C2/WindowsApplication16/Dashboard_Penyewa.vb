Public Class Dashboard_Penyewa

    Private Sub DataPenyewaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataPenyewaToolStripMenuItem.Click
        ' Buat objek dari kelas Penyewa dengan meneruskan objek dataPenyewaForm dan currentUsername
        Dim penyewaForm As New Penyewa(DataPenyewa, CurrentUsername)

        ' Sembunyikan form saat ini
        Me.Hide()

        ' Tampilkan objek Penyewa yang telah dibuat
        penyewaForm.Show()
    End Sub

    Private Sub KeluhanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KeluhanToolStripMenuItem.Click
        Me.Hide()
        Keluhan.Show()
    End Sub

    Private Sub KeluarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KeluarToolStripMenuItem.Click
        ' Sembunyikan Form Dashboard Admin
        Me.Hide()
        FormLogin.Show()
    End Sub

End Class