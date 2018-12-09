<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmproduct
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txttotalprice = New System.Windows.Forms.TextBox()
        Me.btnaddandenter = New System.Windows.Forms.Button()
        Me.btneditandupdate = New System.Windows.Forms.Button()
        Me.btndelete = New System.Windows.Forms.Button()
        Me.cbounit = New System.Windows.Forms.ComboBox()
        Me.nupquantity = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtprodid = New System.Windows.Forms.TextBox()
        Me.btnminus = New System.Windows.Forms.Button()
        Me.btnadd = New System.Windows.Forms.Button()
        Me.cbospecs = New System.Windows.Forms.ComboBox()
        Me.dtparrivaldate = New System.Windows.Forms.DateTimePicker()
        Me.lblproduct = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtmodel = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtserial = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtprice = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.cbosupplier = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cbobrand = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cbotype = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cboproduct = New System.Windows.Forms.ComboBox()
        Me.lvispecs = New System.Windows.Forms.ListView()
        CType(Me.nupquantity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 425)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 18)
        Me.Label3.TabIndex = 181
        Me.Label3.Text = "Total Price"
        '
        'txttotalprice
        '
        Me.txttotalprice.Enabled = False
        Me.txttotalprice.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotalprice.Location = New System.Drawing.Point(118, 419)
        Me.txttotalprice.Name = "txttotalprice"
        Me.txttotalprice.ReadOnly = True
        Me.txttotalprice.Size = New System.Drawing.Size(270, 24)
        Me.txttotalprice.TabIndex = 162
        Me.txttotalprice.Text = "Php "
        '
        'btnaddandenter
        '
        Me.btnaddandenter.Location = New System.Drawing.Point(636, 474)
        Me.btnaddandenter.Name = "btnaddandenter"
        Me.btnaddandenter.Size = New System.Drawing.Size(90, 31)
        Me.btnaddandenter.TabIndex = 167
        Me.btnaddandenter.Text = "Add"
        Me.btnaddandenter.UseVisualStyleBackColor = True
        '
        'btneditandupdate
        '
        Me.btneditandupdate.Location = New System.Drawing.Point(732, 474)
        Me.btneditandupdate.Name = "btneditandupdate"
        Me.btneditandupdate.Size = New System.Drawing.Size(90, 31)
        Me.btneditandupdate.TabIndex = 168
        Me.btneditandupdate.Text = "Edit"
        Me.btneditandupdate.UseVisualStyleBackColor = True
        '
        'btndelete
        '
        Me.btndelete.Location = New System.Drawing.Point(828, 474)
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(90, 31)
        Me.btndelete.TabIndex = 169
        Me.btndelete.Text = "Delete"
        Me.btndelete.UseVisualStyleBackColor = True
        '
        'cbounit
        '
        Me.cbounit.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbounit.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbounit.FormattingEnabled = True
        Me.cbounit.Location = New System.Drawing.Point(185, 384)
        Me.cbounit.Name = "cbounit"
        Me.cbounit.Size = New System.Drawing.Size(203, 26)
        Me.cbounit.Sorted = True
        Me.cbounit.TabIndex = 161
        '
        'nupquantity
        '
        Me.nupquantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nupquantity.Location = New System.Drawing.Point(118, 386)
        Me.nupquantity.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.nupquantity.Name = "nupquantity"
        Me.nupquantity.Size = New System.Drawing.Size(61, 24)
        Me.nupquantity.TabIndex = 160
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 392)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 18)
        Me.Label2.TabIndex = 180
        Me.Label2.Text = "Quantity"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 18)
        Me.Label1.TabIndex = 179
        Me.Label1.Text = "Product ID"
        '
        'txtprodid
        '
        Me.txtprodid.Enabled = False
        Me.txtprodid.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtprodid.Location = New System.Drawing.Point(118, 79)
        Me.txtprodid.Name = "txtprodid"
        Me.txtprodid.ReadOnly = True
        Me.txtprodid.Size = New System.Drawing.Size(270, 24)
        Me.txtprodid.TabIndex = 151
        '
        'btnminus
        '
        Me.btnminus.FlatAppearance.BorderSize = 0
        Me.btnminus.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnminus.Location = New System.Drawing.Point(892, 76)
        Me.btnminus.Name = "btnminus"
        Me.btnminus.Size = New System.Drawing.Size(26, 26)
        Me.btnminus.TabIndex = 165
        Me.btnminus.Text = "-"
        Me.btnminus.UseVisualStyleBackColor = True
        '
        'btnadd
        '
        Me.btnadd.FlatAppearance.BorderSize = 0
        Me.btnadd.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnadd.Location = New System.Drawing.Point(864, 76)
        Me.btnadd.Name = "btnadd"
        Me.btnadd.Size = New System.Drawing.Size(26, 26)
        Me.btnadd.TabIndex = 164
        Me.btnadd.Text = "+"
        Me.btnadd.UseVisualStyleBackColor = True
        '
        'cbospecs
        '
        Me.cbospecs.Enabled = False
        Me.cbospecs.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbospecs.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbospecs.FormattingEnabled = True
        Me.cbospecs.Location = New System.Drawing.Point(413, 76)
        Me.cbospecs.Name = "cbospecs"
        Me.cbospecs.Size = New System.Drawing.Size(447, 26)
        Me.cbospecs.Sorted = True
        Me.cbospecs.TabIndex = 163
        '
        'dtparrivaldate
        '
        Me.dtparrivaldate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtparrivaldate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtparrivaldate.Location = New System.Drawing.Point(118, 217)
        Me.dtparrivaldate.Name = "dtparrivaldate"
        Me.dtparrivaldate.Size = New System.Drawing.Size(270, 24)
        Me.dtparrivaldate.TabIndex = 155
        '
        'lblproduct
        '
        Me.lblproduct.BackColor = System.Drawing.Color.Purple
        Me.lblproduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblproduct.ForeColor = System.Drawing.Color.White
        Me.lblproduct.Location = New System.Drawing.Point(-1, 0)
        Me.lblproduct.Name = "lblproduct"
        Me.lblproduct.Size = New System.Drawing.Size(945, 52)
        Me.lblproduct.TabIndex = 178
        Me.lblproduct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(18, 291)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(49, 18)
        Me.Label31.TabIndex = 177
        Me.Label31.Text = "Model"
        '
        'txtmodel
        '
        Me.txtmodel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmodel.Location = New System.Drawing.Point(118, 285)
        Me.txtmodel.Name = "txtmodel"
        Me.txtmodel.Size = New System.Drawing.Size(270, 24)
        Me.txtmodel.TabIndex = 157
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(18, 324)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(45, 18)
        Me.Label30.TabIndex = 176
        Me.Label30.Text = "Serial"
        '
        'txtserial
        '
        Me.txtserial.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtserial.Location = New System.Drawing.Point(118, 318)
        Me.txtserial.Name = "txtserial"
        Me.txtserial.Size = New System.Drawing.Size(270, 24)
        Me.txtserial.TabIndex = 158
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(18, 357)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(72, 18)
        Me.Label29.TabIndex = 175
        Me.Label29.Text = "Unit Price"
        '
        'txtprice
        '
        Me.txtprice.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtprice.Location = New System.Drawing.Point(118, 351)
        Me.txtprice.Name = "txtprice"
        Me.txtprice.Size = New System.Drawing.Size(270, 24)
        Me.txtprice.TabIndex = 159
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(18, 258)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(65, 18)
        Me.Label28.TabIndex = 174
        Me.Label28.Text = "Supplier "
        '
        'cbosupplier
        '
        Me.cbosupplier.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbosupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbosupplier.FormattingEnabled = True
        Me.cbosupplier.Location = New System.Drawing.Point(118, 250)
        Me.cbosupplier.Name = "cbosupplier"
        Me.cbosupplier.Size = New System.Drawing.Size(270, 26)
        Me.cbosupplier.Sorted = True
        Me.cbosupplier.TabIndex = 156
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(18, 223)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(87, 18)
        Me.Label27.TabIndex = 173
        Me.Label27.Text = "Arrival Date "
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(18, 190)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(47, 18)
        Me.Label24.TabIndex = 172
        Me.Label24.Text = "Brand"
        '
        'cbobrand
        '
        Me.cbobrand.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbobrand.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbobrand.FormattingEnabled = True
        Me.cbobrand.Location = New System.Drawing.Point(118, 182)
        Me.cbobrand.Name = "cbobrand"
        Me.cbobrand.Size = New System.Drawing.Size(270, 26)
        Me.cbobrand.Sorted = True
        Me.cbobrand.TabIndex = 154
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(18, 155)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(40, 18)
        Me.Label25.TabIndex = 171
        Me.Label25.Text = "Type"
        '
        'cbotype
        '
        Me.cbotype.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbotype.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbotype.FormattingEnabled = True
        Me.cbotype.Location = New System.Drawing.Point(118, 147)
        Me.cbotype.Name = "cbotype"
        Me.cbotype.Size = New System.Drawing.Size(270, 26)
        Me.cbotype.Sorted = True
        Me.cbotype.TabIndex = 153
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(18, 120)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(64, 18)
        Me.Label26.TabIndex = 170
        Me.Label26.Text = "Product "
        '
        'cboproduct
        '
        Me.cboproduct.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboproduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboproduct.FormattingEnabled = True
        Me.cboproduct.Location = New System.Drawing.Point(118, 112)
        Me.cboproduct.Name = "cboproduct"
        Me.cboproduct.Size = New System.Drawing.Size(270, 26)
        Me.cboproduct.Sorted = True
        Me.cboproduct.TabIndex = 152
        '
        'lvispecs
        '
        Me.lvispecs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvispecs.FullRowSelect = True
        Me.lvispecs.Location = New System.Drawing.Point(413, 112)
        Me.lvispecs.Name = "lvispecs"
        Me.lvispecs.Size = New System.Drawing.Size(505, 331)
        Me.lvispecs.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvispecs.TabIndex = 166
        Me.lvispecs.UseCompatibleStateImageBehavior = False
        Me.lvispecs.View = System.Windows.Forms.View.Details
        '
        'frmproduct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(943, 522)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txttotalprice)
        Me.Controls.Add(Me.btnaddandenter)
        Me.Controls.Add(Me.btneditandupdate)
        Me.Controls.Add(Me.btndelete)
        Me.Controls.Add(Me.cbounit)
        Me.Controls.Add(Me.nupquantity)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtprodid)
        Me.Controls.Add(Me.btnminus)
        Me.Controls.Add(Me.btnadd)
        Me.Controls.Add(Me.cbospecs)
        Me.Controls.Add(Me.dtparrivaldate)
        Me.Controls.Add(Me.lblproduct)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.txtmodel)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.txtserial)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.txtprice)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.cbosupplier)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.cbobrand)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.cbotype)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.cboproduct)
        Me.Controls.Add(Me.lvispecs)
        Me.Name = "frmproduct"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmproduct"
        CType(Me.nupquantity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txttotalprice As System.Windows.Forms.TextBox
    Friend WithEvents btnaddandenter As System.Windows.Forms.Button
    Friend WithEvents btneditandupdate As System.Windows.Forms.Button
    Friend WithEvents btndelete As System.Windows.Forms.Button
    Friend WithEvents cbounit As System.Windows.Forms.ComboBox
    Friend WithEvents nupquantity As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtprodid As System.Windows.Forms.TextBox
    Friend WithEvents btnminus As System.Windows.Forms.Button
    Friend WithEvents btnadd As System.Windows.Forms.Button
    Friend WithEvents cbospecs As System.Windows.Forms.ComboBox
    Friend WithEvents dtparrivaldate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblproduct As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtmodel As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtserial As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtprice As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents cbosupplier As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cbobrand As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cbotype As System.Windows.Forms.ComboBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cboproduct As System.Windows.Forms.ComboBox
    Friend WithEvents lvispecs As System.Windows.Forms.ListView
End Class
