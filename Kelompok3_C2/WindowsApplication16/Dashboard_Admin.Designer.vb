<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dashboard_Admin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dashboard_Admin))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.LaporanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LihatLaporanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CetakLaporanPembayaranToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KeluarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnDataPembayaran = New System.Windows.Forms.Button()
        Me.btnDataTransaksi = New System.Windows.Forms.Button()
        Me.btnDataKamar = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnDataKeluhan = New System.Windows.Forms.Button()
        Me.btnDataPenyewa = New System.Windows.Forms.Button()
        Me.PrintDataPembayaran = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.MenuStrip1.SuspendLayout
        Me.SuspendLayout
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LaporanToolStripMenuItem, Me.KeluarToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(971, 36)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'LaporanToolStripMenuItem
        '
        Me.LaporanToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LihatLaporanToolStripMenuItem, Me.CetakLaporanPembayaranToolStripMenuItem})
        Me.LaporanToolStripMenuItem.Name = "LaporanToolStripMenuItem"
        Me.LaporanToolStripMenuItem.Size = New System.Drawing.Size(88, 29)
        Me.LaporanToolStripMenuItem.Text = "Laporan"
        '
        'LihatLaporanToolStripMenuItem
        '
        Me.LihatLaporanToolStripMenuItem.BackColor = System.Drawing.Color.AliceBlue
        Me.LihatLaporanToolStripMenuItem.Name = "LihatLaporanToolStripMenuItem"
        Me.LihatLaporanToolStripMenuItem.Size = New System.Drawing.Size(299, 30)
        Me.LihatLaporanToolStripMenuItem.Text = "Laporan Pembayaran"
        '
        'CetakLaporanPembayaranToolStripMenuItem
        '
        Me.CetakLaporanPembayaranToolStripMenuItem.BackColor = System.Drawing.Color.AliceBlue
        Me.CetakLaporanPembayaranToolStripMenuItem.Name = "CetakLaporanPembayaranToolStripMenuItem"
        Me.CetakLaporanPembayaranToolStripMenuItem.Size = New System.Drawing.Size(299, 30)
        Me.CetakLaporanPembayaranToolStripMenuItem.Text = "Cetak Laporan Pembayaran"
        '
        'KeluarToolStripMenuItem
        '
        Me.KeluarToolStripMenuItem.Name = "KeluarToolStripMenuItem"
        Me.KeluarToolStripMenuItem.Size = New System.Drawing.Size(81, 29)
        Me.KeluarToolStripMenuItem.Text = "Logout"
        '
        'btnDataPembayaran
        '
        Me.btnDataPembayaran.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnDataPembayaran.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDataPembayaran.Location = New System.Drawing.Point(286, 353)
        Me.btnDataPembayaran.Name = "btnDataPembayaran"
        Me.btnDataPembayaran.Size = New System.Drawing.Size(156, 147)
        Me.btnDataPembayaran.TabIndex = 3
        Me.btnDataPembayaran.Text = "Data Pembayaran"
        Me.btnDataPembayaran.UseVisualStyleBackColor = False
        '
        'btnDataTransaksi
        '
        Me.btnDataTransaksi.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnDataTransaksi.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDataTransaksi.Location = New System.Drawing.Point(537, 353)
        Me.btnDataTransaksi.Name = "btnDataTransaksi"
        Me.btnDataTransaksi.Size = New System.Drawing.Size(156, 147)
        Me.btnDataTransaksi.TabIndex = 2
        Me.btnDataTransaksi.Text = "Data Transaksi"
        Me.btnDataTransaksi.UseVisualStyleBackColor = False
        '
        'btnDataKamar
        '
        Me.btnDataKamar.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnDataKamar.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDataKamar.Location = New System.Drawing.Point(183, 172)
        Me.btnDataKamar.Name = "btnDataKamar"
        Me.btnDataKamar.Size = New System.Drawing.Size(156, 147)
        Me.btnDataKamar.TabIndex = 0
        Me.btnDataKamar.Text = "Data Kamar"
        Me.btnDataKamar.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label12.Font = New System.Drawing.Font("Stencil", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label12.Location = New System.Drawing.Point(277, 74)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(429, 52)
        Me.Label12.TabIndex = 47
        Me.Label12.Text = "Dashboard Admin"
        '
        'btnDataKeluhan
        '
        Me.btnDataKeluhan.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnDataKeluhan.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDataKeluhan.Location = New System.Drawing.Point(632, 172)
        Me.btnDataKeluhan.Name = "btnDataKeluhan"
        Me.btnDataKeluhan.Size = New System.Drawing.Size(155, 147)
        Me.btnDataKeluhan.TabIndex = 48
        Me.btnDataKeluhan.Text = "Data Keluhan"
        Me.btnDataKeluhan.UseVisualStyleBackColor = False
        '
        'btnDataPenyewa
        '
        Me.btnDataPenyewa.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnDataPenyewa.Font = New System.Drawing.Font("Malgun Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDataPenyewa.Location = New System.Drawing.Point(405, 172)
        Me.btnDataPenyewa.Name = "btnDataPenyewa"
        Me.btnDataPenyewa.Size = New System.Drawing.Size(156, 147)
        Me.btnDataPenyewa.TabIndex = 1
        Me.btnDataPenyewa.Text = "Data Penyewa"
        Me.btnDataPenyewa.UseVisualStyleBackColor = False
        '
        'PrintDataPembayaran
        '
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'Dashboard_Admin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(971, 594)
        Me.Controls.Add(Me.btnDataKeluhan)
        Me.Controls.Add(Me.btnDataPembayaran)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.btnDataTransaksi)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.btnDataPenyewa)
        Me.Controls.Add(Me.btnDataKamar)
        Me.Font = New System.Drawing.Font("Malgun Gothic", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Dashboard_Admin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dashboard"
        Me.MenuStrip1.ResumeLayout(false)
        Me.MenuStrip1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents KeluarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LaporanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LihatLaporanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CetakLaporanPembayaranToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnDataPembayaran As System.Windows.Forms.Button
    Friend WithEvents btnDataTransaksi As System.Windows.Forms.Button
    Friend WithEvents btnDataKamar As System.Windows.Forms.Button
    Friend WithEvents btnDataKeluhan As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnDataPenyewa As System.Windows.Forms.Button
    Friend WithEvents PrintDataPembayaran As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
End Class
