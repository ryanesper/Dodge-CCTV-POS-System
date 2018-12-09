Imports MySql.Data.MySqlClient

Public Class frmproduct

    Private Sub frmproduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If generateidforproduct = True Then
            productidgenerator()
            txtprodid.Text = productfinalizeid
        End If

        lvispecs.Columns.Clear()
        lvispecs.Columns.Add("Specification", 450, HorizontalAlignment.Left)

        If loadcomboboxiteminproduct = True Then
            loadproductname()
        End If

        If productmode = "Add Mode" Then
            cboproduct.Enabled = True
            cbotype.Enabled = True
            cbobrand.Enabled = True
            dtparrivaldate.Enabled = True
            cbosupplier.Enabled = True
            txtmodel.Enabled = True
            txtserial.Enabled = True
            txtprice.Enabled = True
            nupquantity.Enabled = True
            cbounit.Enabled = True
            btnadd.Enabled = True
            btnminus.Enabled = True
            cbotype.Items.Clear()
            cbobrand.Items.Clear()
            cbosupplier.Items.Clear()
            cbounit.Items.Clear()
        End If

        If productmode = "Edit Mode" Then
            cbospecs.Enabled = True
            loadproductspecification()
        End If

        If productmode = "Add Others Mode" Then
            
        End If

        For Each specs As ListViewItem In lvispecs.Items
            Dim specslen As String = Microsoft.VisualBasic.Len(specs.SubItems(0).Text)
            Dim finalspecs As String = Microsoft.VisualBasic.Right(specs.SubItems(0).Text, specslen - 2)
            cbospecs.Items.Remove(finalspecs)
        Next

        cboproduct.Focus()

    End Sub

    Public Sub loadproductname()
        openconnection()
        cboproduct.Items.Clear()
        Dim ds As New DataSet
        Dim sql As String

        sql = "select name from tbl_product_name"
        sqlda = New MySqlDataAdapter(sql, con)

        sqlda.Fill(ds, "fms")
        For Each r As DataRow In ds.Tables(0).Rows
            cboproduct.Items.Add(r("name"))
        Next

        con.Close()
    End Sub

    Public Sub loadproducttype()
        openconnection()
        cbotype.Items.Clear()
        Dim ds As New DataSet
        Dim sql As String

        sql = "select type from tbl_product_type where product_name = '" & cboproduct.Text & "'"
        sqlda = New MySqlDataAdapter(sql, con)

        sqlda.Fill(ds, "fms")
        For Each r As DataRow In ds.Tables(0).Rows
            cbotype.Items.Add(r("type"))
        Next

        con.Close()
    End Sub

    Public Sub loadproductbrand()
        openconnection()
        cbobrand.Items.Clear()
        Dim ds As New DataSet
        Dim sql As String

        sql = "select brand from tbl_product_brand where product_name = '" & cboproduct.Text & "'"
        sqlda = New MySqlDataAdapter(sql, con)

        sqlda.Fill(ds, "fms")
        For Each r As DataRow In ds.Tables(0).Rows
            cbobrand.Items.Add(r("brand"))
        Next

        con.Close()
    End Sub

    Public Sub loadproductsupplier()
        openconnection()
        cbosupplier.Items.Clear()
        Dim ds As New DataSet
        Dim sql As String

        sql = "select supplier from tbl_product_supplier where product_name = '" & cboproduct.Text & "'"
        sqlda = New MySqlDataAdapter(sql, con)

        sqlda.Fill(ds, "fms")
        For Each r As DataRow In ds.Tables(0).Rows
            cbosupplier.Items.Add(r("supplier"))
        Next

        con.Close()
    End Sub

    Public Sub loadunit()
        openconnection()
        cbounit.Items.Clear()
        Dim counter As Integer = 0
        Dim ds As New DataSet
        Dim sql As String

        sql = "select quantity_unit from tbl_product_quantity_unit where product_name = '" & cboproduct.Text & "'"
        sqlda = New MySqlDataAdapter(sql, con)

        sqlda.Fill(ds, "fms")
        For Each r As DataRow In ds.Tables(0).Rows
            If r("quantity_unit") = "" Then
                If counter = 1 Then
                    counter = 1
                Else
                    counter = 0
                End If
            Else
                counter = 1
            End If
            cbounit.Items.Add(r("quantity_unit"))
        Next

        If counter = 0 Then
            cbounit.Text = "unit"
        Else
            cbounit.Text = ""
        End If

        con.Close()

        For Each item In cbounit.Items
            cbounit.Text = item
            Exit Sub
        Next

    End Sub

    Public Sub loadproductspecification()
        openconnection()
        cbospecs.Items.Clear()
        Dim ds As New DataSet
        Dim sql As String

        sql = "select specification from tbl_product_specs  where product_name = '" & cboproduct.Text & "'"
        sqlda = New MySqlDataAdapter(sql, con)

        sqlda.Fill(ds, "fms")
        For Each r As DataRow In ds.Tables(0).Rows
            cbospecs.Items.Add(r("specification"))
        Next

        For Each item1 As ListViewItem In lvispecs.Items
            cbospecs.Items.Remove(item1.SubItems.Item(0).Text)
        Next

        con.Close()
    End Sub

    Private Sub cboproduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboproduct.SelectedIndexChanged

        cbotype.Text = ""
        cbobrand.Text = ""
        cbosupplier.Text = ""
        txtserial.Text = ""
        txtmodel.Text = ""
        txtprice.Text = ""
        cbospecs.Text = ""
        cbospecs.Enabled = True
        lvispecs.Items.Clear()

        loadproducttype()
        loadproductbrand()
        loadproductsupplier()
        loadunit()
        loadproductspecification()

        If cboproduct.Text <> "" Then
            nupquantity.Maximum = 1000000
            nupquantity.Minimum = 1
            nupquantity.Value = 1
        Else
            nupquantity.Minimum = 0
            nupquantity.Value = 0
        End If

    End Sub

    Private Sub cboproduct_TextChanged(sender As Object, e As EventArgs) Handles cboproduct.TextChanged

        cbotype.Text = ""
        cbobrand.Text = ""
        cbosupplier.Text = ""
        txtserial.Text = ""
        txtmodel.Text = ""
        txtprice.Text = ""
        cbounit.Text = ""
        cbospecs.Text = ""
        cbospecs.Enabled = True
        lvispecs.Items.Clear()

        loadproducttype()
        loadproductbrand()
        loadproductsupplier()
        loadunit()
        loadproductspecification()

        If cboproduct.Text <> "" Then
            nupquantity.Maximum = 1000000
            nupquantity.Minimum = 1
            nupquantity.Value = 1
        Else
            nupquantity.Maximum = 0
            nupquantity.Minimum = 0
            nupquantity.Value = 0
            cbospecs.Enabled = False
            cbounit.Items.Clear()
            cbounit.Text = ""
        End If

    End Sub

    Private Sub txtprice_TextChanged(sender As Object, e As EventArgs) Handles txtprice.TextChanged

        Try
            If nupquantity.Value <> 0 Then
                If txtprice.Text <> "" Then
                    Dim unitprice As Decimal = txtprice.Text.Replace("Php ", "")
                    Dim quantity As Long = nupquantity.Value
                    Dim totalprice As Decimal
                    totalprice = unitprice * quantity
                    If totalprice > 999 Then
                        txttotalprice.Text = "Php " & Format((totalprice), "0,00.00")
                    ElseIf totalprice < 1000 Then
                        txttotalprice.Text = "Php " & Format((totalprice), "0.00")
                    End If
                Else
                    txttotalprice.Text = "Php "
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Price must only contain a number 0 - 9!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtprice.Text = ""
        End Try

    End Sub

    Private Sub nupquantity_ValueChanged(sender As Object, e As EventArgs) Handles nupquantity.ValueChanged

        If txtprice.Text <> "" Then
            Try
                If nupquantity.Value <> 0 Then
                    If txtprice.Text <> "" Then
                        Dim unitprice As Decimal = txtprice.Text
                        Dim quantity As Long = nupquantity.Value
                        Dim totalprice As Decimal
                        totalprice = unitprice * quantity
                        If totalprice > 999 Then
                            txttotalprice.Text = "Php " & Format((totalprice), "0,00.00")
                        ElseIf totalprice < 1000 Then
                            txttotalprice.Text = "Php " & Format((totalprice), "0.00")
                        End If
                    Else
                        txttotalprice.Text = "Php "
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Price must only contain a number 0 - 9!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtprice.Text = ""
            End Try
        End If

    End Sub

    Private Sub cbospecs_KeyDown(sender As Object, e As KeyEventArgs) Handles cbospecs.KeyDown

        If e.KeyCode = Keys.Enter Then
            Dim lvi As New ListViewItem("- " & cbospecs.Text)
            lvispecs.Items.Add(lvi)
            lvispecs.Columns.Clear()
            lvispecs.Columns.Add("Specification", 450, HorizontalAlignment.Left)
            cbospecs.Text = ""
        End If

    End Sub

    Private Sub cbospecs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbospecs.SelectedIndexChanged

        If cbospecs.Text <> "" Then
            Dim lvi1 As New ListViewItem("- " & cbospecs.Text)
            lvispecs.Items.Add(lvi1)
            lvispecs.Columns.Clear()
            lvispecs.Columns.Add("Specification", 450, HorizontalAlignment.Left)
            cbospecs.Items.Remove(cbospecs.Text)
        End If

    End Sub

    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click

        If cbospecs.Text <> "" Then
            Dim lvi As New ListViewItem("- " & cbospecs.Text)
            lvispecs.Items.Add(lvi)
            cbospecs.Text = ""
        End If

    End Sub

    Private Sub btnminus_Click(sender As Object, e As EventArgs) Handles btnminus.Click

        For Each item As ListViewItem In lvispecs.Items
            If lvispecs.SelectedItems.Count > 0 Then
                item = lvispecs.SelectedItems.Item(0)
                If item.SubItems(0).Text <> "" Then
                    Dim specslen As String = Microsoft.VisualBasic.Len(item.SubItems(0).Text)
                    Dim finalspecs As String = Microsoft.VisualBasic.Right(item.SubItems(0).Text, specslen - 2)
                    cbospecs.Items.Add(finalspecs)
                End If
                item.Remove()
            End If
        Next

    End Sub

    Private Sub btnaddandenter_Click(sender As Object, e As EventArgs) Handles btnaddandenter.Click

        If btnaddandenter.Text = "Add" Then
            lblproduct.Text = "Add Product"
            cboproduct.Enabled = True
            cboproduct.Text = ""
            loadproductname()
            cbotype.Enabled = True
            cbotype.Text = ""
            loadproducttype()
            cbobrand.Enabled = True
            cbobrand.Text = ""
            loadproductbrand()
            dtparrivaldate.Enabled = True
            cbosupplier.Enabled = True
            cbosupplier.Text = ""
            loadproductsupplier()
            txtmodel.Enabled = True
            txtmodel.Text = ""
            txtserial.Enabled = True
            txtserial.Text = ""
            nupquantity.Enabled = True
            nupquantity.Value = 0
            cbounit.Enabled = True
            cbounit.Text = ""
            cbounit.Items.Clear()
            txtprice.Enabled = True
            txtprice.Text = ""
            txttotalprice.Enabled = True
            txttotalprice.Text = "Php "
            cbospecs.Enabled = False
            cbospecs.Text = ""
            lvispecs.Items.Clear()
            btnaddandenter.Text = "Enter"
            btneditandupdate.Enabled = False
            btndelete.Enabled = False
            productidgenerator()
            txtprodid.Text = productfinalizeid
            cboproduct.Focus()

        ElseIf btnaddandenter.Text = "Enter" Then
            If cboproduct.Text = "" Then
                MessageBox.Show("Product name cannot be empty!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                openconnection()

                cmd.CommandText = "select serial from tbl_stocks where serial = '" & txtserial.Text & "'"
                reader = cmd.ExecuteReader
                If reader.HasRows Then
                    MessageBox.Show("Serial already entered in the system.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    reader.Close()
                    Exit Sub
                Else
                    reader.Close()
                    cmd.CommandText = "Select * from tbl_product_name where name = '" & cboproduct.Text & "'"
                    reader = cmd.ExecuteReader
                    If reader.HasRows = False Then
                        reader.Close()
                        cmd = New MySqlCommand("INSERT INTO `tbl_product_name`(`name`) VALUES ('" & cboproduct.Text & "')", con)
                        cmd.ExecuteNonQuery()
                    End If
                    reader.Close()

                    If cbotype.Text <> "" Then
                        cmd.CommandText = "Select * from tbl_product_type where type = '" & cbotype.Text & "' and product_name = '" & cboproduct.Text & "'"
                        reader = cmd.ExecuteReader
                        If reader.HasRows = False Then
                            reader.Close()
                            cmd = New MySqlCommand("INSERT INTO `tbl_product_type`(`product_name`,`type`) VALUES ('" & cboproduct.Text & "','" & cbotype.Text & "')", con)
                            cmd.ExecuteNonQuery()
                        End If
                        reader.Close()
                    End If

                    If cbobrand.Text <> "" Then
                        cmd.CommandText = "Select * from tbl_product_brand where brand = '" & cbobrand.Text & "' and product_name = '" & cboproduct.Text & "'"
                        reader = cmd.ExecuteReader
                        If reader.HasRows = False Then
                            reader.Close()
                            cmd = New MySqlCommand("INSERT INTO `tbl_product_brand`(`product_name`,`brand`) VALUES ('" & cboproduct.Text & "','" & cbobrand.Text & "')", con)
                            cmd.ExecuteNonQuery()
                        End If
                        reader.Close()
                    End If

                    If cbounit.Text <> "" Then
                        cmd.CommandText = "Select * from tbl_product_quantity_unit where quantity_unit = '" & cbounit.Text & "' and product_name = '" & cboproduct.Text & "'"
                        reader = cmd.ExecuteReader
                        If reader.HasRows = False Then
                            reader.Close()
                            cmd = New MySqlCommand("INSERT INTO `tbl_product_quantity_unit`(`product_name`,`quantity_unit`) VALUES ('" & cboproduct.Text & "','" & cbounit.Text & "')", con)
                            cmd.ExecuteNonQuery()
                        End If
                        reader.Close()
                    End If

                    If cbosupplier.Text <> "" Then
                        cmd.CommandText = "Select * from tbl_product_supplier where supplier = '" & cbosupplier.Text & "' and product_name = '" & cboproduct.Text & "'"
                        reader = cmd.ExecuteReader
                        If reader.HasRows = False Then
                            reader.Close()
                            cmd = New MySqlCommand("INSERT INTO `tbl_product_supplier`(`product_name`,`supplier`) VALUES ('" & cboproduct.Text & "','" & cbosupplier.Text & "')", con)
                            cmd.ExecuteNonQuery()
                        End If
                        reader.Close()
                    End If

                    Dim specification = ""
                    For Each item As ListViewItem In lvispecs.Items
                        If lvispecs.Items.Count > 0 Then
                            item = lvispecs.Items.Item(0)
                            Dim specslen As String = Microsoft.VisualBasic.Len(item.SubItems(0).Text)
                            Dim finalspecs As String = Microsoft.VisualBasic.Right(item.SubItems(0).Text, specslen - 2)
                            specification += "\\" & finalspecs
                            cmd.CommandText = "Select * from tbl_product_specs where specification = '" & finalspecs & "' and product_name = '" & cboproduct.Text & "'"
                            reader = cmd.ExecuteReader
                            If reader.HasRows = False Then
                                reader.Close()
                                cmd = New MySqlCommand("INSERT INTO `tbl_product_specs`(`product_name`,`specification`) VALUES ('" & cboproduct.Text & "','" & finalspecs & "')", con)
                                cmd.ExecuteNonQuery()
                            End If
                            reader.Close()
                            item.Remove()
                        End If
                    Next
                    'reader.Close()
                    'If specification <> "" Then
                    '    cmd = New MySqlCommand("INSERT INTO `tbl_stocks_specs`(`product_id`,`specification`) VALUES ('" & txtprodid.Text & "','" & specification & "')", con)
                    '    cmd.ExecuteNonQuery()
                    '    reader.Close()
                    'End If

                    reader.Close()
                    Dim unit_price As Decimal
                    Dim total_price As Decimal
                    Try
                        unit_price = txtprice.Text
                        total_price = txttotalprice.Text.Replace("Php ", "")
                    Catch ex As Exception
                        MessageBox.Show("Inputed price is not valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End Try
                    If txtserial.Text <> "" Then
                        cmd = New MySqlCommand("INSERT INTO `tbl_stocks`(`product_id`,`product`,`type`,`brand`,`supplier`,`serial`,`model`,`arrival_date`,`quantity`,`unit`,`unit_price`,`quantity_unit`,`totalprice`,`specification`,`status`) VALUES ('" & productfinalizeid & "','" & cboproduct.Text & "','" & cbotype.Text & "','" & cbobrand.Text & "','" & cbosupplier.Text & "','" & txtserial.Text & "','" & txtmodel.Text & "','" & dtparrivaldate.Text & "','" & nupquantity.Text & "','" & cbounit.Text & "','" & unit_price & "','" & nupquantity.Text & " " & cbounit.Text & "','" & total_price & "','" & specification & "','" & "available" & "')", con)
                        cmd.ExecuteNonQuery()
                    Else
                        cmd = New MySqlCommand("INSERT INTO `tbl_stocks`(`product_id`,`product`,`type`,`brand`,`supplier`,`model`,`arrival_date`,`quantity`,`unit`,`unit_price`,`quantity_unit`,`totalprice`,`specification`,`status`) VALUES ('" & productfinalizeid & "','" & cboproduct.Text & "','" & cbotype.Text & "','" & cbobrand.Text & "','" & cbosupplier.Text & "','" & txtmodel.Text & "','" & dtparrivaldate.Text & "','" & nupquantity.Text & "','" & cbounit.Text & "','" & unit_price & "','" & nupquantity.Text & " " & cbounit.Text & "','" & total_price & "','" & specification & "','" & "available" & "')", con)
                        cmd.ExecuteNonQuery()
                    End If
                    MessageBox.Show("Item Successfully added.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    displaystocks()
                    productidgenerator()
                    txtprodid.Text = productfinalizeid

                    cboproduct.Items.Clear()
                    cbotype.Items.Clear()
                    cbobrand.Items.Clear()
                    cbosupplier.Items.Clear()
                    cbospecs.Items.Clear()

                    loadproductname()

                    cboproduct.Text = ""
                    cbotype.Text = ""
                    cbobrand.Text = ""
                    cbosupplier.Text = ""
                    txtprice.Text = ""
                    txtserial.Text = ""
                    txtmodel.Text = ""
                    cbospecs.Text = ""
                    cbounit.Text = ""
                    nupquantity.Minimum = 0
                    nupquantity.Value = 0
                    con.Close()
                End If
            End If
        End If

    End Sub

    Private Sub btneditandupdate_Click(sender As Object, e As EventArgs) Handles btneditandupdate.Click

        If frmmain.btnnew.Text <> "Start" Then
            If btneditandupdate.Text = "Edit" Then
                lblproduct.Text = "Edit Product"
                btneditandupdate.Text = "Update"
                cboproduct.Enabled = True
                cbotype.Enabled = True
                cbobrand.Enabled = True
                dtparrivaldate.Enabled = True
                cbosupplier.Enabled = True
                nupquantity.Enabled = True
                cbounit.Enabled = True
                txtprice.Enabled = True
                txtprice.Text = txtprice.Text.Replace("Php ", "")
                txtprice.Text = txtprice.Text.Replace(",", "")
                txtserial.Enabled = True
                txtmodel.Enabled = True
                txttotalprice.Enabled = True
                cbospecs.Enabled = True
                btnadd.Enabled = True
                btnminus.Enabled = True
                lblproduct.Text = "Edit Product"
                loadproductspecification()
                For Each specs As ListViewItem In lvispecs.Items
                    Dim specslen As String = Microsoft.VisualBasic.Len(specs.SubItems(0).Text)
                    Dim finalspecs As String = Microsoft.VisualBasic.Right(specs.SubItems(0).Text, specslen - 2)
                    cbospecs.Items.Remove(finalspecs)
                Next
            ElseIf btneditandupdate.Text = "Update" Then
                confirm = MessageBox.Show("Are you sure you want to update?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                If confirm = vbOK Then
                    openconnection()

                    reader.Close()
                    cmd.CommandText = "Select * from tbl_product_name where name = '" & cboproduct.Text & "'"
                    reader = cmd.ExecuteReader
                    If reader.HasRows = False Then
                        reader.Close()
                        cmd = New MySqlCommand("INSERT INTO `tbl_product_name`(`name`) VALUES ('" & cboproduct.Text & "')", con)
                        cmd.ExecuteNonQuery()
                    End If
                    reader.Close()

                    If cbotype.Text <> "" Then
                        cmd.CommandText = "Select * from tbl_product_type where type = '" & cbotype.Text & "' and product_name = '" & cboproduct.Text & "'"
                        reader = cmd.ExecuteReader
                        If reader.HasRows = False Then
                            reader.Close()
                            cmd = New MySqlCommand("INSERT INTO `tbl_product_type`(`product_name`,`type`) VALUES ('" & cboproduct.Text & "','" & cbotype.Text & "')", con)
                            cmd.ExecuteNonQuery()
                        End If
                        reader.Close()
                    End If

                    If cbobrand.Text <> "" Then
                        cmd.CommandText = "Select * from tbl_product_brand where brand = '" & cbobrand.Text & "' and product_name = '" & cboproduct.Text & "'"
                        reader = cmd.ExecuteReader
                        If reader.HasRows = False Then
                            reader.Close()
                            cmd = New MySqlCommand("INSERT INTO `tbl_product_brand`(`product_name`,`brand`) VALUES ('" & cboproduct.Text & "','" & cbobrand.Text & "')", con)
                            cmd.ExecuteNonQuery()
                        End If
                        reader.Close()
                    End If

                    If cbosupplier.Text <> "" Then
                        cmd.CommandText = "Select * from tbl_product_supplier where supplier = '" & cbosupplier.Text & "' and product_name = '" & cboproduct.Text & "'"
                        reader = cmd.ExecuteReader
                        If reader.HasRows = False Then
                            reader.Close()
                            cmd = New MySqlCommand("INSERT INTO `tbl_product_supplier`(`product_name`,`supplier`) VALUES ('" & cboproduct.Text & "','" & cbosupplier.Text & "')", con)
                            cmd.ExecuteNonQuery()
                        End If
                        reader.Close()
                    End If

                    Dim specification = ""
                    For Each item As ListViewItem In lvispecs.Items
                        If lvispecs.Items.Count > 0 Then
                            item = lvispecs.Items.Item(0)
                            Dim specslen As String = Microsoft.VisualBasic.Len(item.SubItems(0).Text)
                            Dim finalspecs As String = Microsoft.VisualBasic.Right(item.SubItems(0).Text, specslen - 2)
                            specification += "\\" & finalspecs
                            cmd.CommandText = "Select * from tbl_product_specs where specification = '" & finalspecs & "' and product_name = '" & cboproduct.Text & "'"
                            reader = cmd.ExecuteReader
                            If reader.HasRows = False Then
                                reader.Close()
                                cmd = New MySqlCommand("INSERT INTO `tbl_product_specs`(`product_name`,`specification`) VALUES ('" & cboproduct.Text & "','" & finalspecs & "')", con)
                                cmd.ExecuteNonQuery()
                            End If
                            reader.Close()
                            item.Remove()
                        End If
                    Next

                    Dim unit_price As Decimal
                    Dim total_price As Decimal
                    Try
                        unit_price = txtprice.Text
                        total_price = txttotalprice.Text.Replace("Php ", "")
                    Catch ex As Exception
                        MessageBox.Show("Inputed price is not valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End Try
                    If txtserial.Text <> "" Then
                        cmd = New MySqlCommand("UPDATE `tbl_stocks` SET `product`= '" & cboproduct.Text & "' ,`type`= '" & cbotype.Text & "' ,`brand`= '" & cbobrand.Text & "' , `supplier`= '" & cbosupplier.Text & "' ,`serial`= '" & txtserial.Text & "' ,`model`= '" & txtmodel.Text & "' , `arrival_date`= '" & dtparrivaldate.Text & "' , `quantity`= '" & nupquantity.Text & "' ,`unit`= '" & cbounit.Text & "' ,`unit_price`= '" & unit_price & "' ,`quantity_unit`= '" & nupquantity.Text & " " & cbounit.Text & "' , `totalprice`= '" & total_price & "' , `specification`= '" & specification & "' where product_id='" & txtprodid.Text & "'", con)
                        cmd.ExecuteNonQuery()
                    Else
                        cmd = New MySqlCommand("UPDATE `tbl_stocks` SET `product`= '" & cboproduct.Text & "' ,`type`= '" & cbotype.Text & "' ,`brand`= '" & cbobrand.Text & "' , `supplier`= '" & cbosupplier.Text & "' ,`model`= '" & txtmodel.Text & "' , `arrival_date`= '" & dtparrivaldate.Text & "' , `quantity`= '" & nupquantity.Text & "' ,`unit`= '" & cbounit.Text & "' ,`unit_price`= '" & unit_price & "' ,`quantity_unit`= '" & nupquantity.Text & " " & cbounit.Text & "' , `specification`= '" & specification & "' , `totalprice`= '" & total_price & "' where product_id='" & txtprodid.Text & "'", con)
                        cmd.ExecuteNonQuery()
                    End If
                    reader.Close()
                    displayitemspecs()
                    con.Close()
                    MessageBox.Show("Product has been successfully updated.", "information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    displaystocks()
                    btneditandupdate.Text = "Edit"
                    cboproduct.Enabled = False
                    cbotype.Enabled = False
                    cbobrand.Enabled = False
                    dtparrivaldate.Enabled = False
                    cbosupplier.Enabled = False
                    nupquantity.Enabled = False
                    cbounit.Enabled = False
                    txtprice.Enabled = False
                    txtserial.Enabled = False
                    txtmodel.Enabled = False
                    cbospecs.Enabled = False
                    btnadd.Enabled = False
                    btnminus.Enabled = False

                    cboproduct.Items.Clear()
                    cbotype.Items.Clear()
                    cbobrand.Items.Clear()
                    cbosupplier.Items.Clear()
                    cbospecs.Items.Clear()
                    loadproductname()
                    loadproducttype()
                    loadproductbrand()
                    loadproductsupplier()
                    loadproductspecification()
                End If
            End If
        Else
            MessageBox.Show("You can't edit an item while starting an operation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub displayitemspecs()

        openconnection()
        lvispecs.Items.Clear()
        Dim specslen As Integer = 0
        Dim trimmedtextlen As Integer = 0
        Dim trimmedtext As String = ""
        Dim specs As String = ""
        cmd.CommandText = "Select specification from tbl_stocks where product_id = '" & txtprodid.Text & "'"
        reader = cmd.ExecuteReader
        If reader.HasRows Then
            While (reader.Read())
                specs = reader("specification").ToString
            End While
        End If
        reader.Close()

        specslen = Microsoft.VisualBasic.Len(specs)
        Do Until specslen < 1
            Dim spliter As String() = specs.Split("\")
            trimmedtext = spliter.Last.Trim
            Dim lvi As New ListViewItem("- " & trimmedtext)
            lvispecs.Items.Add(lvi)
            trimmedtextlen = Microsoft.VisualBasic.Len(trimmedtext)

            specslen = specslen - (trimmedtextlen + 1)
            specs = Microsoft.VisualBasic.Left(specs, specslen)
        Loop

        For Each item1 As ListViewItem In lvispecs.Items
            cbospecs.Items.Remove(item1.SubItems.Item(0).Text.Replace("- ", ""))
        Next
        con.Close()

    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click

        If frmmain.btnnew.Text <> "Start" Then
            If productmode = "viewmode" Then
                confirm = MessageBox.Show("Are you sure?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                If confirm = vbOK Then
                    openconnection()
                    cmddelete = "DELETE FROM `tbl_stocks` where product_id='" & txtprodid.Text & "'"
                    sqlda = New MySqlDataAdapter(cmddelete, con)
                    ds = New DataSet()
                    sqlda.Fill(ds)

                    'cmddelete = "DELETE FROM `tbl_stocks_specs` where product_id='" & txtprodid.Text & "'"
                    'sqlda = New MySqlDataAdapter(cmddelete, con)3e
                    'ds = New DataSet()
                    'sqlda.Fill(ds)

                    con.Close()
                    displaystocks()
                    productmode = ""
                    Me.Close()
                End If
            End If
        Else
            MessageBox.Show("You can't delete an item while starting an operation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub
End Class