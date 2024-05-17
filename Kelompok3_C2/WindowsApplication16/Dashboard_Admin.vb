Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Tab

Public Class Dashboard_Admin

    Private Sub btnDataKamar_Click(sender As Object, e As EventArgs) Handles btnDataKamar.Click
        Me.Hide()
        Kamar.Show()
    End Sub

    Private Sub btnDataPenyewa_Click(sender As Object, e As EventArgs) Handles btnDataPenyewa.Click
        Me.Hide()
        DataPenyewa.Show()
    End Sub

    Private Sub btnDataTransaksi_Click(sender As Object, e As EventArgs) Handles btnDataTransaksi.Click
        Me.Hide()
        Transaksi.Show()
    End Sub

    Private Sub btnDataPembayaran_Click(sender As Object, e As EventArgs) Handles btnDataPembayaran.Click
        Me.Hide()
        Pembayaran.Show()
    End Sub

    Private Sub btnDataKeluhan_Click(sender As Object, e As EventArgs) Handles btnDataKeluhan.Click
        FormDataKeluhan.Show()
    End Sub

    Dim pageWidth As Integer = 1169 ' A4 Landscape width in pixels
    Dim pageHeight As Integer = 827 ' A4 Landscape height in pixels
    Dim listPembayaran As New List(Of List(Of String))()
    Dim currentPage, totalPage, totalItem, marginPixels, y, x, marginRight
    Dim marginInch As Single

    Private Sub readDataPembayaran()
        CMD = New MySqlCommand("SELECT nama, no_kamar, lama_sewa, metode_bayar, tgl_bayar, total FROM pembayaran ORDER BY id_pembayaran", CONN)
        RD = CMD.ExecuteReader
        totalItem = 0
        Do While RD.Read
            Dim dataPembayaran As New List(Of String)()
            dataPembayaran.Add(RD("nama").ToString)
            dataPembayaran.Add(RD("no_kamar").ToString)
            dataPembayaran.Add(RD("lama_sewa").ToString)
            dataPembayaran.Add(RD("metode_bayar").ToString)
            dataPembayaran.Add(DateTime.Parse(RD("tgl_bayar").ToString()).ToShortDateString())
            dataPembayaran.Add(RD("total").ToString)
            listPembayaran.Add(dataPembayaran)
            totalItem += 1
        Loop
        totalPage = Math.Ceiling(totalItem / 15) ' Adjust the number of items per page if needed
        RD.Close()
    End Sub

    Private Sub LihatLaporanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LihatLaporanToolStripMenuItem.Click
        readDataPembayaran()
        currentPage = 1
        PrintPreviewDialog1.Document = PrintDataPembayaran
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub CetakLaporanPembayaranToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CetakLaporanPembayaranToolStripMenuItem.Click
        readDataPembayaran()
        currentPage = 1
        PrintDataPembayaran.Print()
    End Sub

    Private Sub PrintDataPembayaran_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDataPembayaran.PrintPage
        Dim Fheader As New Font("Times New Roman", 24, FontStyle.Bold) 'font header
        Dim FBodyB As New Font("Times New Roman", 14, FontStyle.Bold) 'fontBodyBold
        Dim FBody As New Font("Times New Roman", 14, FontStyle.Regular) 'font body
        Dim black As SolidBrush = New SolidBrush(Color.Black) 'tipe dan warna teks
        ' alignment
        Dim center As New StringFormat()
        center.Alignment = StringAlignment.Center
        Dim leftAlign As New StringFormat()
        leftAlign.Alignment = StringAlignment.Near
        Dim posY, i As Integer
        Dim hitung As Integer = 0

        ' Set landscape mode
        e.PageSettings.Landscape = True

        ' Pemeriksaan jika data kosong
        If listPembayaran.Count = 0 Then
            e.Graphics.DrawString("Data pembayaran kosong.", FBodyB, black, e.MarginBounds.Left, e.MarginBounds.Top, leftAlign)
            Return
        End If

        If currentPage <= 1 Then
            marginInch = 2.54F 'margin 1 inci/2.54 cm
            marginPixels = CInt(e.PageSettings.PrinterResolution.X * marginInch) 'convert margin ke pixel
            e.PageSettings.Margins = New Margins(marginPixels, marginPixels, marginPixels, marginPixels) 'inisiasi margin
            ' koordinat awal
            x = e.MarginBounds.Left
            y = e.MarginBounds.Top
            marginRight = e.MarginBounds.Right
            pageWidth = e.MarginBounds.Width
            'judul
            e.Graphics.DrawString("Data Pembayaran", Fheader, black, pageWidth / 2, y + 30, center)
            'header kolom
            e.Graphics.DrawLine(Pens.Black, x, y + 150, marginRight, y + 150)
            e.Graphics.DrawString("Nama", FBodyB, black, x + 10, y + 160, leftAlign)
            e.Graphics.DrawString("No Kamar", FBodyB, black, x + 90, y + 160, leftAlign)
            e.Graphics.DrawString("Sewa(bln)", FBodyB, black, x + 200, y + 160, leftAlign)
            e.Graphics.DrawString("Metode", FBodyB, black, x + 320, y + 160, leftAlign)
            e.Graphics.DrawString("Tanggal", FBodyB, black, x + 410, y + 160, leftAlign) 
            e.Graphics.DrawString("Total", FBodyB, black, x + 570, y + 160, leftAlign)
            e.Graphics.DrawLine(Pens.Black, x, y + 200, marginRight, y + 200)

            e.Graphics.DrawLine(Pens.Black, x, y + 150, x, y + 200)
            e.Graphics.DrawLine(Pens.Black, x + 80, y + 150, x + 80, y + 200)
            e.Graphics.DrawLine(Pens.Black, x + 190, y + 150, x + 190, y + 200)
            e.Graphics.DrawLine(Pens.Black, x + 310, y + 150, x + 310, y + 200)
            e.Graphics.DrawLine(Pens.Black, x + 400, y + 150, x + 400, y + 200)
            e.Graphics.DrawLine(Pens.Black, x + 560, y + 150, x + 560, y + 200)
            posY = y + 210
        Else
            posY = y
            e.Graphics.DrawLine(Pens.Black, x, posY, marginRight, posY)
        End If

        For i = (currentPage - 1) * 15 To listPembayaran.Count - 1
            Dim dataPembayaran As List(Of String) = listPembayaran(i)
            e.Graphics.DrawLine(Pens.Black, x, posY + 30, marginRight, posY + 30)
            e.Graphics.DrawString(dataPembayaran(0), FBody, black, x + 10, posY, leftAlign)
            e.Graphics.DrawString(dataPembayaran(1), FBody, black, x + 90, posY, leftAlign)
            e.Graphics.DrawString(dataPembayaran(2), FBody, black, x + 200, posY, leftAlign)
            e.Graphics.DrawString(dataPembayaran(3), FBody, black, x + 320, posY, leftAlign)
            e.Graphics.DrawString(dataPembayaran(4), FBody, black, x + 410, posY, leftAlign)
            e.Graphics.DrawString(dataPembayaran(5), FBody, black, x + 570, posY, leftAlign)
            ' Tarik garis vertikal di antara kolom
            e.Graphics.DrawLine(Pens.Black, x + 80, posY, x + 80, posY + 30)
            e.Graphics.DrawLine(Pens.Black, x + 190, posY, x + 190, posY + 30)
            e.Graphics.DrawLine(Pens.Black, x + 310, posY, x + 310, posY + 30)
            e.Graphics.DrawLine(Pens.Black, x + 400, posY, x + 400, posY + 30)
            e.Graphics.DrawLine(Pens.Black, x + 560, posY, x + 560, posY + 30)
            posY += 40
            hitung += 1
            If hitung >= 15 Then
                Exit For
            End If
        Next

        If currentPage <= 1 Then
            e.Graphics.DrawLine(Pens.Black, x, y + 150, x, posY - 10)
            e.Graphics.DrawLine(Pens.Black, marginRight, y + 150, marginRight, posY - 10)
        Else
            e.Graphics.DrawLine(Pens.Black, x, y, x, posY - 10)
            e.Graphics.DrawLine(Pens.Black, marginRight, y, marginRight, posY - 10)
        End If

        currentPage += 1
        e.HasMorePages = currentPage <= totalPage
    End Sub

    Private Sub KeluarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KeluarToolStripMenuItem.Click
        ' Sembunyikan Form Dashboard Admin
        Me.Hide()
        FormLogin.Show()
    End Sub

    Private Sub Dashboard_Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
    End Sub
End Class
