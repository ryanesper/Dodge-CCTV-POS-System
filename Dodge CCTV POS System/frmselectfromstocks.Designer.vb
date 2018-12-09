<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmselectfromstocks
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
        Me.lvispecs = New System.Windows.Forms.ListView()
        Me.btncancel = New System.Windows.Forms.Button()
        Me.cboproduct = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtsearchstocks = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cbosearchstocks = New System.Windows.Forms.ComboBox()
        Me.btnstocksrefresh = New System.Windows.Forms.Button()
        Me.txttotalprice = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.lvistocks = New System.Windows.Forms.ListView()
        Me.btnselect = New System.Windows.Forms.Button()
        Me.nupitemqty = New System.Windows.Forms.NumericUpDown()
        CType(Me.nupitemqty, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lvispecs
        '
        Me.lvispecs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvispecs.FullRowSelect = True
        Me.lvispecs.Location = New System.Drawing.Point(14, 465)
        Me.lvispecs.MultiSelect = False
        Me.lvispecs.Name = "lvispecs"
        Me.lvispecs.Size = New System.Drawing.Size(1286, 165)
        Me.lvispecs.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvispecs.TabIndex = 129
        Me.lvispecs.UseCompatibleStateImageBehavior = False
        Me.lvispecs.View = System.Windows.Forms.View.Details
        '
        'btncancel
        '
        Me.btncancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncancel.Location = New System.Drawing.Point(1220, 640)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(80, 30)
        Me.btncancel.TabIndex = 126
        Me.btncancel.Text = "Cancel"
        Me.btncancel.UseVisualStyleBackColor = True
        '
        'cboproduct
        '
        Me.cboproduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboproduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboproduct.FormattingEnabled = True
        Me.cboproduct.Location = New System.Drawing.Point(90, 76)
        Me.cboproduct.Name = "cboproduct"
        Me.cboproduct.Size = New System.Drawing.Size(170, 24)
        Me.cboproduct.Sorted = True
        Me.cboproduct.TabIndex = 125
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(11, 84)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(74, 16)
        Me.Label20.TabIndex = 124
        Me.Label20.Text = "Filter item : "
        '
        'txtsearchstocks
        '
        Me.txtsearchstocks.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsearchstocks.Location = New System.Drawing.Point(1033, 76)
        Me.txtsearchstocks.Name = "txtsearchstocks"
        Me.txtsearchstocks.Size = New System.Drawing.Size(236, 24)
        Me.txtsearchstocks.TabIndex = 123
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(807, 83)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(57, 16)
        Me.Label19.TabIndex = 122
        Me.Label19.Text = "Search :"
        '
        'cbosearchstocks
        '
        Me.cbosearchstocks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbosearchstocks.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cbosearchstocks.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbosearchstocks.FormattingEnabled = True
        Me.cbosearchstocks.Items.AddRange(New Object() {"Model", "Serial"})
        Me.cbosearchstocks.Location = New System.Drawing.Point(870, 76)
        Me.cbosearchstocks.Name = "cbosearchstocks"
        Me.cbosearchstocks.Size = New System.Drawing.Size(157, 24)
        Me.cbosearchstocks.Sorted = True
        Me.cbosearchstocks.TabIndex = 121
        '
        'btnstocksrefresh
        '
        Me.btnstocksrefresh.BackgroundImage = Global.Dodge_CCTV_POS_System.My.Resources.Resources.refresh_png2
        Me.btnstocksrefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnstocksrefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnstocksrefresh.Location = New System.Drawing.Point(1275, 76)
        Me.btnstocksrefresh.Name = "btnstocksrefresh"
        Me.btnstocksrefresh.Size = New System.Drawing.Size(25, 25)
        Me.btnstocksrefresh.TabIndex = 120
        Me.btnstocksrefresh.UseVisualStyleBackColor = True
        '
        'txttotalprice
        '
        Me.txttotalprice.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotalprice.Location = New System.Drawing.Point(1071, 12)
        Me.txttotalprice.Name = "txttotalprice"
        Me.txttotalprice.ReadOnly = True
        Me.txttotalprice.Size = New System.Drawing.Size(229, 26)
        Me.txttotalprice.TabIndex = 119
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(969, 18)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(105, 20)
        Me.Label24.TabIndex = 118
        Me.Label24.Text = "Grand Total : "
        '
        'lvistocks
        '
        Me.lvistocks.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvistocks.FullRowSelect = True
        Me.lvistocks.Location = New System.Drawing.Point(14, 106)
        Me.lvistocks.MultiSelect = False
        Me.lvistocks.Name = "lvistocks"
        Me.lvistocks.Size = New System.Drawing.Size(1286, 360)
        Me.lvistocks.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvistocks.TabIndex = 117
        Me.lvistocks.UseCompatibleStateImageBehavior = False
        Me.lvistocks.View = System.Windows.Forms.View.Details
        '
        'btnselect
        '
        Me.btnselect.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnselect.Location = New System.Drawing.Point(14, 640)
        Me.btnselect.Name = "btnselect"
        Me.btnselect.Size = New System.Drawing.Size(80, 30)
        Me.btnselect.TabIndex = 127
        Me.btnselect.Text = "Select"
        Me.btnselect.UseVisualStyleBackColor = True
        '
        'nupitemqty
        '
        Me.nupitemqty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nupitemqty.Enabled = False
        Me.nupitemqty.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nupitemqty.Location = New System.Drawing.Point(100, 641)
        Me.nupitemqty.Name = "nupitemqty"
        Me.nupitemqty.Size = New System.Drawing.Size(65, 29)
        Me.nupitemqty.TabIndex = 128
        '
        'frmselectfromstocks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1310, 678)
        Me.Controls.Add(Me.lvispecs)
        Me.Controls.Add(Me.nupitemqty)
        Me.Controls.Add(Me.btncancel)
        Me.Controls.Add(Me.cboproduct)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtsearchstocks)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.cbosearchstocks)
        Me.Controls.Add(Me.btnstocksrefresh)
        Me.Controls.Add(Me.txttotalprice)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.lvistocks)
        Me.Controls.Add(Me.btnselect)
        Me.MaximumSize = New System.Drawing.Size(1326, 716)
        Me.MinimumSize = New System.Drawing.Size(1326, 716)
        Me.Name = "frmselectfromstocks"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmselectfromstocks"
        CType(Me.nupitemqty, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvispecs As System.Windows.Forms.ListView
    Friend WithEvents btncancel As System.Windows.Forms.Button
    Friend WithEvents cboproduct As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtsearchstocks As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cbosearchstocks As System.Windows.Forms.ComboBox
    Friend WithEvents btnstocksrefresh As System.Windows.Forms.Button
    Friend WithEvents txttotalprice As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents lvistocks As System.Windows.Forms.ListView
    Friend WithEvents btnselect As System.Windows.Forms.Button
    Friend WithEvents nupitemqty As System.Windows.Forms.NumericUpDown
End Class
