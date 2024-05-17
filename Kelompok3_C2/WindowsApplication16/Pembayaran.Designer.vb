<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pembayaran
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Pembayaran))
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnBatal = New System.Windows.Forms.Button()
        Me.cbMetodeBayar = New System.Windows.Forms.ComboBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.txtNama = New System.Windows.Forms.TextBox()
        Me.DtmTanggalBayar = New System.Windows.Forms.DateTimePicker()
        Me.txtLamaSewa = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIdPembayaran = New System.Windows.Forms.TextBox()
        Me.cbIdTransaksi = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNoKamar = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.pbBack = New System.Windows.Forms.PictureBox()
        Me.Panel3.SuspendLayout
        Me.Panel2.SuspendLayout
        CType(Me.DataGridView1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.pbBack,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'Label12
        '
        Me.Label12.AutoSize = true
        Me.Label12.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label12.Font = New System.Drawing.Font("STHupo", 22!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(134,Byte))
        Me.Label12.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label12.Location = New System.Drawing.Point(372, 33)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(280, 45)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "Karinti House"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnBatal)
        Me.Panel3.Controls.Add(Me.cbMetodeBayar)
        Me.Panel3.Controls.Add(Me.txtSearch)
        Me.Panel3.Controls.Add(Me.btnSearch)
        Me.Panel3.Controls.Add(Me.txtTotal)
        Me.Panel3.Controls.Add(Me.btnAdd)
        Me.Panel3.Controls.Add(Me.btnDelete)
        Me.Panel3.Controls.Add(Me.txtNama)
        Me.Panel3.Controls.Add(Me.DtmTanggalBayar)
        Me.Panel3.Controls.Add(Me.txtLamaSewa)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.txtIdPembayaran)
        Me.Panel3.Controls.Add(Me.cbIdTransaksi)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.txtNoKamar)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Location = New System.Drawing.Point(34, 175)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(964, 232)
        Me.Panel3.TabIndex = 42
        '
        'btnBatal
        '
        Me.btnBatal.BackColor = System.Drawing.Color.LightSlateGray
        Me.btnBatal.ForeColor = System.Drawing.Color.White
        Me.btnBatal.Location = New System.Drawing.Point(792, 77)
        Me.btnBatal.Name = "btnBatal"
        Me.btnBatal.Size = New System.Drawing.Size(86, 33)
        Me.btnBatal.TabIndex = 71
        Me.btnBatal.Text = "Batal"
        Me.btnBatal.UseVisualStyleBackColor = false
        '
        'cbMetodeBayar
        '
        Me.cbMetodeBayar.FormattingEnabled = true
        Me.cbMetodeBayar.Location = New System.Drawing.Point(530, 119)
        Me.cbMetodeBayar.Name = "cbMetodeBayar"
        Me.cbMetodeBayar.Size = New System.Drawing.Size(192, 28)
        Me.cbMetodeBayar.TabIndex = 70
        '
        'txtSearch
        '
        Me.txtSearch.BackColor = System.Drawing.Color.LightSlateGray
        Me.txtSearch.ForeColor = System.Drawing.Color.White
        Me.txtSearch.Location = New System.Drawing.Point(754, 136)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(86, 26)
        Me.txtSearch.TabIndex = 69
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.LightSlateGray
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(846, 129)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(86, 41)
        Me.btnSearch.TabIndex = 68
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = false
        '
        'txtTotal
        '
        Me.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotal.Location = New System.Drawing.Point(530, 71)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(192, 26)
        Me.txtTotal.TabIndex = 66
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.LightSlateGray
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(754, 23)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(86, 41)
        Me.btnAdd.TabIndex = 43
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = false
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.LightSlateGray
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Location = New System.Drawing.Point(846, 23)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(86, 40)
        Me.btnDelete.TabIndex = 45
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = false
        '
        'txtNama
        '
        Me.txtNama.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNama.Location = New System.Drawing.Point(173, 116)
        Me.txtNama.Name = "txtNama"
        Me.txtNama.Size = New System.Drawing.Size(192, 26)
        Me.txtNama.TabIndex = 65
        '
        'DtmTanggalBayar
        '
        Me.DtmTanggalBayar.Location = New System.Drawing.Point(530, 164)
        Me.DtmTanggalBayar.Name = "DtmTanggalBayar"
        Me.DtmTanggalBayar.Size = New System.Drawing.Size(192, 26)
        Me.DtmTanggalBayar.TabIndex = 62
        '
        'txtLamaSewa
        '
        Me.txtLamaSewa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLamaSewa.Location = New System.Drawing.Point(530, 23)
        Me.txtLamaSewa.Name = "txtLamaSewa"
        Me.txtLamaSewa.Size = New System.Drawing.Size(192, 26)
        Me.txtLamaSewa.TabIndex = 61
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.Location = New System.Drawing.Point(408, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 20)
        Me.Label4.TabIndex = 58
        Me.Label4.Text = "Total"
        '
        'Label5
        '
        Me.Label5.AutoSize = true
        Me.Label5.Location = New System.Drawing.Point(408, 123)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 20)
        Me.Label5.TabIndex = 57
        Me.Label5.Text = "Metode Bayar"
        '
        'Label9
        '
        Me.Label9.AutoSize = true
        Me.Label9.Location = New System.Drawing.Point(408, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 20)
        Me.Label9.TabIndex = 56
        Me.Label9.Text = "Lama Sewa"
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Location = New System.Drawing.Point(409, 169)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 20)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "Tgl Bayar"
        '
        'txtIdPembayaran
        '
        Me.txtIdPembayaran.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdPembayaran.Location = New System.Drawing.Point(173, 23)
        Me.txtIdPembayaran.Name = "txtIdPembayaran"
        Me.txtIdPembayaran.Size = New System.Drawing.Size(192, 26)
        Me.txtIdPembayaran.TabIndex = 53
        '
        'cbIdTransaksi
        '
        Me.cbIdTransaksi.FormattingEnabled = true
        Me.cbIdTransaksi.Location = New System.Drawing.Point(173, 65)
        Me.cbIdTransaksi.Name = "cbIdTransaksi"
        Me.cbIdTransaksi.Size = New System.Drawing.Size(192, 28)
        Me.cbIdTransaksi.TabIndex = 51
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(31, 164)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 20)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "No Kamar"
        '
        'Label6
        '
        Me.Label6.AutoSize = true
        Me.Label6.Location = New System.Drawing.Point(31, 119)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 20)
        Me.Label6.TabIndex = 49
        Me.Label6.Text = "Nama"
        '
        'txtNoKamar
        '
        Me.txtNoKamar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNoKamar.Location = New System.Drawing.Point(173, 158)
        Me.txtNoKamar.Name = "txtNoKamar"
        Me.txtNoKamar.Size = New System.Drawing.Size(192, 26)
        Me.txtNoKamar.TabIndex = 48
        '
        'Label7
        '
        Me.Label7.AutoSize = true
        Me.Label7.Location = New System.Drawing.Point(31, 73)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 20)
        Me.Label7.TabIndex = 47
        Me.Label7.Text = "ID Transaksi"
        '
        'Label8
        '
        Me.Label8.AutoSize = true
        Me.Label8.Location = New System.Drawing.Point(31, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(119, 20)
        Me.Label8.TabIndex = 46
        Me.Label8.Text = "ID Pembayaran"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Location = New System.Drawing.Point(34, 126)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(964, 54)
        Me.Panel2.TabIndex = 41
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Location = New System.Drawing.Point(347, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(137, 20)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Data Pembayaran"
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.LightSteelBlue
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.GridColor = System.Drawing.Color.LightSteelBlue
        Me.DataGridView1.Location = New System.Drawing.Point(34, 425)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 28
        Me.DataGridView1.Size = New System.Drawing.Size(964, 249)
        Me.DataGridView1.TabIndex = 47
        '
        'pbBack
        '
        Me.pbBack.BackColor = System.Drawing.Color.Transparent
        Me.pbBack.Image = CType(resources.GetObject("pbBack.Image"),System.Drawing.Image)
        Me.pbBack.Location = New System.Drawing.Point(34, 33)
        Me.pbBack.Name = "pbBack"
        Me.pbBack.Size = New System.Drawing.Size(53, 42)
        Me.pbBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbBack.TabIndex = 54
        Me.pbBack.TabStop = false
        '
        'Pembayaran
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9!, 20!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(1033, 715)
        Me.Controls.Add(Me.pbBack)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label12)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Pembayaran"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form5"
        Me.Panel3.ResumeLayout(false)
        Me.Panel3.PerformLayout
        Me.Panel2.ResumeLayout(false)
        Me.Panel2.PerformLayout
        CType(Me.DataGridView1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.pbBack,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtLamaSewa As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIdPembayaran As System.Windows.Forms.TextBox
    Friend WithEvents cbIdTransaksi As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNoKamar As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DtmTanggalBayar As System.Windows.Forms.DateTimePicker
    Friend WithEvents pbBack As System.Windows.Forms.PictureBox
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtNama As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents cbMetodeBayar As System.Windows.Forms.ComboBox
    Friend WithEvents btnBatal As System.Windows.Forms.Button
End Class
