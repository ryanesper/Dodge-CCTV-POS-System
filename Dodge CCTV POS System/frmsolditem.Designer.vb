<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmsolditem
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
        Me.lviitems = New System.Windows.Forms.ListView()
        Me.lvirestock = New System.Windows.Forms.ListView()
        Me.nupitemqty = New System.Windows.Forms.NumericUpDown()
        Me.btnrestock = New System.Windows.Forms.Button()
        Me.btnselectfromstocks = New System.Windows.Forms.Button()
        Me.lvitotal = New System.Windows.Forms.ListView()
        Me.lvispecs = New System.Windows.Forms.ListView()
        Me.txttotalprice = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.btnok = New System.Windows.Forms.Button()
        Me.btnremove = New System.Windows.Forms.Button()
        Me.btncancel = New System.Windows.Forms.Button()
        Me.txtoprno = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lviremove = New System.Windows.Forms.ListView()
        CType(Me.nupitemqty, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lviitems
        '
        Me.lviitems.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lviitems.FullRowSelect = True
        Me.lviitems.Location = New System.Drawing.Point(14, 94)
        Me.lviitems.Name = "lviitems"
        Me.lviitems.Size = New System.Drawing.Size(1342, 360)
        Me.lviitems.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lviitems.TabIndex = 144
        Me.lviitems.UseCompatibleStateImageBehavior = False
        Me.lviitems.View = System.Windows.Forms.View.Details
        '
        'lvirestock
        '
        Me.lvirestock.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvirestock.FullRowSelect = True
        Me.lvirestock.Location = New System.Drawing.Point(14, 332)
        Me.lvirestock.Name = "lvirestock"
        Me.lvirestock.Size = New System.Drawing.Size(1342, 117)
        Me.lvirestock.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvirestock.TabIndex = 150
        Me.lvirestock.UseCompatibleStateImageBehavior = False
        Me.lvirestock.View = System.Windows.Forms.View.Details
        '
        'nupitemqty
        '
        Me.nupitemqty.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.nupitemqty.Enabled = False
        Me.nupitemqty.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nupitemqty.Location = New System.Drawing.Point(272, 694)
        Me.nupitemqty.Name = "nupitemqty"
        Me.nupitemqty.Size = New System.Drawing.Size(65, 27)
        Me.nupitemqty.TabIndex = 148
        '
        'btnrestock
        '
        Me.btnrestock.Enabled = False
        Me.btnrestock.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnrestock.Location = New System.Drawing.Point(186, 692)
        Me.btnrestock.Name = "btnrestock"
        Me.btnrestock.Size = New System.Drawing.Size(80, 30)
        Me.btnrestock.TabIndex = 149
        Me.btnrestock.Text = "Restock"
        Me.btnrestock.UseVisualStyleBackColor = True
        '
        'btnselectfromstocks
        '
        Me.btnselectfromstocks.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnselectfromstocks.Location = New System.Drawing.Point(14, 692)
        Me.btnselectfromstocks.Name = "btnselectfromstocks"
        Me.btnselectfromstocks.Size = New System.Drawing.Size(77, 30)
        Me.btnselectfromstocks.TabIndex = 147
        Me.btnselectfromstocks.Text = "Stocks"
        Me.btnselectfromstocks.UseVisualStyleBackColor = True
        '
        'lvitotal
        '
        Me.lvitotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvitotal.FullRowSelect = True
        Me.lvitotal.Location = New System.Drawing.Point(684, 453)
        Me.lvitotal.Name = "lvitotal"
        Me.lvitotal.Size = New System.Drawing.Size(672, 229)
        Me.lvitotal.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvitotal.TabIndex = 146
        Me.lvitotal.UseCompatibleStateImageBehavior = False
        Me.lvitotal.View = System.Windows.Forms.View.Details
        '
        'lvispecs
        '
        Me.lvispecs.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvispecs.FullRowSelect = True
        Me.lvispecs.Location = New System.Drawing.Point(14, 453)
        Me.lvispecs.Name = "lvispecs"
        Me.lvispecs.Size = New System.Drawing.Size(671, 229)
        Me.lvispecs.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvispecs.TabIndex = 145
        Me.lvispecs.UseCompatibleStateImageBehavior = False
        Me.lvispecs.View = System.Windows.Forms.View.Details
        '
        'txttotalprice
        '
        Me.txttotalprice.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotalprice.Location = New System.Drawing.Point(1160, 12)
        Me.txttotalprice.Name = "txttotalprice"
        Me.txttotalprice.ReadOnly = True
        Me.txttotalprice.Size = New System.Drawing.Size(196, 26)
        Me.txttotalprice.TabIndex = 143
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(1058, 18)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(105, 20)
        Me.Label24.TabIndex = 142
        Me.Label24.Text = "Grand Total : "
        '
        'btnok
        '
        Me.btnok.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnok.Location = New System.Drawing.Point(1190, 692)
        Me.btnok.Name = "btnok"
        Me.btnok.Size = New System.Drawing.Size(80, 30)
        Me.btnok.TabIndex = 141
        Me.btnok.Text = "Ok"
        Me.btnok.UseVisualStyleBackColor = True
        '
        'btnremove
        '
        Me.btnremove.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnremove.Location = New System.Drawing.Point(100, 692)
        Me.btnremove.Name = "btnremove"
        Me.btnremove.Size = New System.Drawing.Size(80, 30)
        Me.btnremove.TabIndex = 140
        Me.btnremove.Text = "Remove"
        Me.btnremove.UseVisualStyleBackColor = True
        '
        'btncancel
        '
        Me.btncancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncancel.Location = New System.Drawing.Point(1276, 692)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(80, 30)
        Me.btncancel.TabIndex = 139
        Me.btncancel.Text = "Close"
        Me.btncancel.UseVisualStyleBackColor = True
        '
        'txtoprno
        '
        Me.txtoprno.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtoprno.Location = New System.Drawing.Point(140, 9)
        Me.txtoprno.Name = "txtoprno"
        Me.txtoprno.ReadOnly = True
        Me.txtoprno.Size = New System.Drawing.Size(180, 29)
        Me.txtoprno.TabIndex = 138
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 23)
        Me.Label2.TabIndex = 137
        Me.Label2.Text = "Operation No."
        '
        'lviremove
        '
        Me.lviremove.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lviremove.FullRowSelect = True
        Me.lviremove.Location = New System.Drawing.Point(14, 216)
        Me.lviremove.Name = "lviremove"
        Me.lviremove.Size = New System.Drawing.Size(1342, 110)
        Me.lviremove.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lviremove.TabIndex = 151
        Me.lviremove.UseCompatibleStateImageBehavior = False
        Me.lviremove.View = System.Windows.Forms.View.Details
        '
        'frmsolditem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1366, 730)
        Me.Controls.Add(Me.lviitems)
        Me.Controls.Add(Me.lviremove)
        Me.Controls.Add(Me.lvirestock)
        Me.Controls.Add(Me.nupitemqty)
        Me.Controls.Add(Me.btnrestock)
        Me.Controls.Add(Me.btnselectfromstocks)
        Me.Controls.Add(Me.lvitotal)
        Me.Controls.Add(Me.lvispecs)
        Me.Controls.Add(Me.txttotalprice)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.btnok)
        Me.Controls.Add(Me.btnremove)
        Me.Controls.Add(Me.btncancel)
        Me.Controls.Add(Me.txtoprno)
        Me.Controls.Add(Me.Label2)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmsolditem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmsolditem"
        CType(Me.nupitemqty, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lviitems As System.Windows.Forms.ListView
    Friend WithEvents lvirestock As System.Windows.Forms.ListView
    Friend WithEvents nupitemqty As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnrestock As System.Windows.Forms.Button
    Friend WithEvents btnselectfromstocks As System.Windows.Forms.Button
    Friend WithEvents lvitotal As System.Windows.Forms.ListView
    Friend WithEvents lvispecs As System.Windows.Forms.ListView
    Friend WithEvents txttotalprice As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents btnok As System.Windows.Forms.Button
    Friend WithEvents btnremove As System.Windows.Forms.Button
    Friend WithEvents btncancel As System.Windows.Forms.Button
    Friend WithEvents txtoprno As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lviremove As System.Windows.Forms.ListView
End Class
