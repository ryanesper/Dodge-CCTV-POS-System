Imports MySql.Data.MySqlClient

Public Class frmmain

    Dim finalizeid As String
    Dim selecteditemid As String
    Dim contractamount As Decimal
    Dim completionamount As Decimal

    Private Sub frmmain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '==================== INSTALLATION TAB ====================
        lviopr.Columns.Add("OPR No.", 100, HorizontalAlignment.Left)
        lviopr.Columns.Add("Contract Name", 150, HorizontalAlignment.Left)
        lviopr.Columns.Add("Client", 145, HorizontalAlignment.Left)
        lviopr.Columns.Add("Location", 150, HorizontalAlignment.Left)
        lviopr.Columns.Add("Status", 111, HorizontalAlignment.Left)
        lviassignpersonel.Columns.Add("Assign Technical Personel", 300, HorizontalAlignment.Left)
        lviitems.Columns.Add("Devices and Equipment Used", 300, HorizontalAlignment.Left)

        cbosearch.Text = "Operation No."

        '==================== STOCKS TAB ====================
        lvistocks.Columns.Add("Product Name", 165, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Type", 135, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Brand", 115, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Supplier", 115, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Serial", 155, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Model", 230, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Arrival Date", 90, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Qty", 0, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Unit", 0, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Unit Price", 110, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Quantity", 70, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Total Price", 110, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Product ID", 0, HorizontalAlignment.Left)

        lviremoveorrestock.Columns.Clear()
        lviremoveorrestock.Columns.Add("Product Name", 40, HorizontalAlignment.Left)
        lviremoveorrestock.Columns.Add("Type", 40, HorizontalAlignment.Left)
        lviremoveorrestock.Columns.Add("Brand", 40, HorizontalAlignment.Left)
        lviremoveorrestock.Columns.Add("Supplier", 40, HorizontalAlignment.Left)
        lviremoveorrestock.Columns.Add("Serial", 40, HorizontalAlignment.Left)
        lviremoveorrestock.Columns.Add("Model", 40, HorizontalAlignment.Left)
        lviremoveorrestock.Columns.Add("Arrival Date", 40, HorizontalAlignment.Left)
        lviremoveorrestock.Columns.Add("Qty", 40, HorizontalAlignment.Left)
        lviremoveorrestock.Columns.Add("Unit", 40, HorizontalAlignment.Left)
        lviremoveorrestock.Columns.Add("Unit Price", 40, HorizontalAlignment.Left)
        lviremoveorrestock.Columns.Add("Quantity", 40, HorizontalAlignment.Left)
        lviremoveorrestock.Columns.Add("Total Price", 40, HorizontalAlignment.Left)
        lviremoveorrestock.Columns.Add("Product ID", 40, HorizontalAlignment.Left)
        lviremoveorrestock.Columns.Add("Specification", 40, HorizontalAlignment.Left)
        lviremoveorrestock.Columns.Add("Status", 40, HorizontalAlignment.Left)

        '==================== SALES TAB ====================
        lvisales.Columns.Add("Transaction No.", 110, HorizontalAlignment.Left)
        lvisales.Columns.Add("Date Sold", 90, HorizontalAlignment.Left)
        lvisales.Columns.Add("Client", 145, HorizontalAlignment.Left)
        lvisales.Columns.Add("Address", 125, HorizontalAlignment.Left)
        lvisales.Columns.Add("Contact No.", 100, HorizontalAlignment.Left)
        lvisales.Columns.Add("Product Name", 125, HorizontalAlignment.Left)
        lvisales.Columns.Add("Type", 0, HorizontalAlignment.Left)
        lvisales.Columns.Add("Selling Price", 100, HorizontalAlignment.Left)
        lvisales.Columns.Add("Quantity", 70, HorizontalAlignment.Left)
        lvisales.Columns.Add("Total Price", 100, HorizontalAlignment.Left)

        lvitotal.Columns.Add("Items to Sell", 250, HorizontalAlignment.Left)

        cbosearch.Text = "Operation No."
        cbosearchstocks.Text = "Serial"
        cboview.Text = "Expand"
        ComboBox1.Text = "Transaction No."
        displayoperation()
        loadproductname()
        displaystocks()
        operationitemsalesexpanddipslay()

    End Sub

    Private Sub loadproductname()
        openconnection()
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

    Private Sub lviopr_Click(sender As Object, e As EventArgs) Handles lviopr.Click

        openconnection()
        cmd = New MySqlCommand("select * from tbl_operations where operation_id = '" & lviopr.SelectedItems.Item(0).SubItems(0).Text & "'", con)
        reader = cmd.ExecuteReader
        While (reader.Read())
            txtoprno.Text = reader("operation_id").ToString()
            dtpstartoperation.Text = reader("date_started").ToString()
            txtcontractname.Text = reader("contract_name").ToString()
            txtclient.Text = reader("client").ToString()
            txtlocation.Text = reader("location").ToString()
            txtcontactno.Text = reader("contact").ToString()
            txtworknature.Text = reader("work_nature").ToString()
            txtdescription.Text = reader("description").ToString()
            txtcontractamount.Text = reader("contract_amount").ToString()
            lblstatus.Text = reader("status").ToString()
            dtpendoperation.Text = reader("date_finished").ToString()
            txtduration.Text = reader("duration").ToString()
            txtcompletionamount.Text = reader("completion_amount").ToString()
            txtcompletionpercent.Text = reader("completion_percent").ToString()
        End While
        reader.Close()

        lviassignpersonel.Items.Clear()
        openconnection()
        cmd = New MySqlCommand("select * from tbl_operation_assigned_personel where operation_id = '" & lviopr.SelectedItems.Item(0).SubItems(0).Text & "'", con)
        reader = cmd.ExecuteReader
        While (reader.Read())
            Dim personel As New ListViewItem(reader("fullname").ToString())
            lviassignpersonel.Items.Add(personel)
        End While
        reader.Close()

        lviitems.Items.Clear()
        openconnection()
        cmd = New MySqlCommand("select * from tbl_operation_item_total where operation_id = '" & lviopr.SelectedItems.Item(0).SubItems(0).Text & "'", con)
        reader = cmd.ExecuteReader
        While (reader.Read())
            Dim items As New ListViewItem(reader("quantity").ToString() & " - " & reader("items").ToString())
            lviitems.Items.Add(items)
        End While
        reader.Close()
        btnchoosepersonel.Enabled = True
        btnchoosedevice.Enabled = True
        button3.Enabled = True

        If lviopr.SelectedItems.Item(0).SubItems(4).Text = "Ongoing" Then
            button2.Enabled = True
            button3.Text = "Stop"
            button4.Enabled = False
        ElseIf lviopr.SelectedItems.Item(0).SubItems(4).Text = "Completed" Then
            button2.Enabled = False
            button3.Text = "Delete"
            button4.Enabled = True
        End If

    End Sub

    Private Sub lviopr_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lviopr.SelectedIndexChanged

    End Sub

    Private Sub txtcontractamount_LostFocus(sender As Object, e As EventArgs) Handles txtcontractamount.LostFocus

        If txtcontractamount.Text <> "" Then
            If contractamount > 999 Then
                txtcontractamount.Text = "Php " & Format((contractamount), "0,00.00")
            ElseIf contractamount < 1000 Then
                txtcontractamount.Text = "Php " & Format((contractamount), "0.00")
            End If
        End If

    End Sub

    Private Sub txtcontractamount_TextChanged(sender As Object, e As EventArgs) Handles txtcontractamount.TextChanged
        If txtcontractamount.Text <> "" Then
            Try
                contractamount = txtcontractamount.Text.Replace("Php ", "")
            Catch ex As Exception
                txtcontractamount.Text = ""
                MessageBox.Show("Contract amout must only contain a number!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub txtcompletionamount_LostFocus(sender As Object, e As EventArgs) Handles txtcompletionamount.LostFocus

        If txtcompletionamount.Text <> "" Then
            If completionamount > 999 Then
                txtcompletionamount.Text = Format((completionamount), "0,00.00")
            ElseIf completionamount < 1000 Then
                txtcompletionamount.Text = Format((completionamount), "0.00")
            End If
        End If

    End Sub

    Private Sub txtcompletionamount_TextChanged(sender As Object, e As EventArgs) Handles txtcompletionamount.TextChanged
        If txtcompletionamount.Text <> "" Then
            Try
                completionamount = txtcompletionamount.Text.Replace("Php ", "")
            Catch ex As Exception
                txtcompletionamount.Text = ""
                MessageBox.Show("Completion amount amout must only contain a number!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub btnprintpreview_Click(sender As Object, e As EventArgs) Handles btnprintpreview.Click

        Dim stitle As String
        stitle = txtoprno.Text
        Dim frm As New frmoperationsprintpreview(stitle)
        frm.ShowDialog()

    End Sub

    Private Sub btnnew_Click(sender As Object, e As EventArgs) Handles btnnew.Click

        If btnnew.Text = "New" Then
            btnnew.Text = "Start"
            operationidgenerator()
            operationnumber = finalizeid
            txtoprno.Text = operationnumber
            dtpstartoperation.Text = ""
            txtcontractname.Text = ""
            txtclient.Text = ""
            txtlocation.Text = ""
            txtcontactno.Text = ""
            txtworknature.Text = ""
            txtdescription.Text = ""
            txtcontractamount.Text = ""
            lblstatus.Text = ""
            dtpendoperation.Text = ""
            txtduration.Text = ""
            txtcompletionamount.Text = ""
            txtcompletionpercent.Text = ""
            button4.Text = "Edit"
            lviassignpersonel.Items.Clear()
            lviitems.Items.Clear()
            lviopr.Enabled = False
            dtpstartoperation.Enabled = True
            txtcontractname.ReadOnly = False
            txtclient.ReadOnly = False
            txtlocation.ReadOnly = False
            txtcontactno.ReadOnly = False
            txtcontractamount.ReadOnly = False
            txtworknature.ReadOnly = False
            txtdescription.ReadOnly = False
            button3.Enabled = False
            button4.Enabled = False
            btncancel.Enabled = True
            btnchoosepersonel.Enabled = True
            btnchoosedevice.Enabled = True
            button2.Enabled = False
            frmchooseitemsandpersonel.txttotalprice.Text = ""
            frmchooseitemsandpersonel.lviitems.Items.Clear()
            frmchooseitemsandpersonel.lviassignpersonel.Items.Clear()
            frmchooseitemsandpersonel.lvispecs.Items.Clear()
            frmchooseitemsandpersonel.lvitotal.Items.Clear()
        ElseIf btnnew.Text = "Start" Then
            confirm = MessageBox.Show("Are you sure you want to start the operation?", "Stop Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If confirm = vbYes Then
                openconnection()
                cmd = New MySqlCommand("INSERT INTO `tbl_operations`(`operation_id`,`date_started`,`contract_name`,`client`,`location`,`contact`,`work_nature`,`description`,`contract_amount`,`status`) VALUES ('" & txtoprno.Text & "','" & dtpstartoperation.Text.Replace("'", "") & "','" & txtcontractname.Text.Replace("'", "") & "','" & txtclient.Text.Replace("'", "") & "','" & txtlocation.Text.Replace("'", "") & "','" & txtcontactno.Text.Replace("'", "") & "','" & txtworknature.Text.Replace("'", "") & "','" & txtdescription.Text.Replace("'", "") & "','" & "Php " & txtcontractamount.Text & "','" & "Ongoing" & "')", con)
                cmd.ExecuteNonQuery()

                For Each item As ListViewItem In frmchooseitemsandpersonel.lviitems.Items
                    Dim specification = ""
                    openconnection()
                    cmd.CommandText = "Select specification from tbl_stocks where product_id = '" & item.SubItems(13).Text & "'"
                    reader = cmd.ExecuteReader
                    If reader.HasRows Then
                        While (reader.Read())
                            specification = reader("specification").ToString.Replace("\", "\\")
                        End While
                    End If
                    reader.Close()
                    con.Close()
                    productidgeneratorversion2()
                    Dim unitprice As Decimal = item.SubItems(9).Text.Replace("Php ", "")
                    Dim sellingprice As Decimal = item.SubItems(10).Text.Replace("Php ", "")
                    Dim totalprice As Decimal = item.SubItems(12).Text.Replace("Php ", "")
                    If item.SubItems(4).Text <> "" Then
                        cmd = New MySqlCommand("INSERT INTO `tbl_operation_item_used`(`operation_id`,`product_id`,`product`,`type`,`brand`,`supplier`,`serial`,`model`,`arrival_date`,`quantity`,`unit`,`unit_price`,`selling_price`,`quantity_unit`,`total_price`,`specification`,`status`) VALUES ('" & txtoprno.Text & "','" & productfinalizeid & "','" & item.SubItems(0).Text & "','" & item.SubItems(1).Text & "','" & item.SubItems(2).Text & "','" & item.SubItems(3).Text & "','" & item.SubItems(4).Text & "','" & item.SubItems(5).Text & "','" & item.SubItems(6).Text & "','" & item.SubItems(7).Text & "','" & item.SubItems(8).Text & "','" & unitprice & "','" & sellingprice & "','" & item.SubItems(11).Text & "','" & totalprice & "','" & specification & "','" & "installed" & "')", con)
                        cmd.ExecuteNonQuery()
                    Else
                        cmd = New MySqlCommand("INSERT INTO `tbl_operation_item_used`(`operation_id`,`product_id`,`product`,`type`,`brand`,`supplier`,`model`,`arrival_date`,`quantity`,`unit`,`unit_price`,`selling_price`,`quantity_unit`,`total_price`,`specification`,`status`) VALUES ('" & txtoprno.Text & "','" & productfinalizeid & "','" & item.SubItems(0).Text & "','" & item.SubItems(1).Text & "','" & item.SubItems(2).Text & "','" & item.SubItems(3).Text & "','" & item.SubItems(5).Text & "','" & item.SubItems(6).Text & "','" & item.SubItems(7).Text & "','" & item.SubItems(8).Text & "','" & unitprice & "','" & sellingprice & "','" & item.SubItems(11).Text & "','" & totalprice & "','" & specification & "','" & "installed" & "')", con)
                        cmd.ExecuteNonQuery()
                    End If

                    Dim currentquantity As Integer
                    Dim currenttotalprice As Decimal
                    cmd.CommandText = "Select * from tbl_stocks where product_id = '" & item.SubItems(13).Text & "'"
                    reader = cmd.ExecuteReader
                    If reader.HasRows Then
                        While (reader.Read())
                            currentquantity = reader("quantity").ToString
                            currenttotalprice = reader("totalprice").ToString
                        End While
                    End If
                    reader.Close()
                    Dim newquantityinstocks As Integer = currentquantity - item.SubItems(7).Text
                    Dim oldtotalprice As Decimal = item.SubItems(7).Text * item.SubItems(9).Text.Replace("Php ", "")
                    Dim newtotalprice As Decimal = currenttotalprice - oldtotalprice
                    If newquantityinstocks > 0 Then
                        'MsgBox("1. newquantityinstocks: " & newquantityinstocks)
                        cmd = New MySqlCommand("UPDATE `tbl_stocks` SET `quantity`= '" & newquantityinstocks & "' ,`quantity_unit`= '" & newquantityinstocks & " " & item.SubItems(8).Text & "' , `totalprice`= '" & newtotalprice & "' where product_id='" & item.SubItems(13).Text & "'", con)
                        cmd.ExecuteNonQuery()
                    ElseIf newquantityinstocks = 0 Then
                        'MsgBox("2. newquantityinstocks: " & newquantityinstocks)
                        cmddelete = "DELETE FROM `tbl_stocks` where product_id='" & item.SubItems(13).Text & "'"
                        sqlda = New MySqlDataAdapter(cmddelete, con)
                        ds = New DataSet()
                        sqlda.Fill(ds)
                    End If
                    item.Remove()
                Next

                For Each assignedpersonel As ListViewItem In frmchooseitemsandpersonel.lviassignpersonel.Items
                    cmd = New MySqlCommand("INSERT INTO `tbl_operation_assigned_personel`(`operation_id`,`fullname`) VALUES ('" & txtoprno.Text & "','" & assignedpersonel.SubItems(0).Text & "')", con)
                    cmd.ExecuteNonQuery()
                    reader.Close()
                    assignedpersonel.Remove()
                Next

                For Each totalitem As ListViewItem In frmchooseitemsandpersonel.lvitotal.Items
                    cmd = New MySqlCommand("INSERT INTO `tbl_operation_item_total`(`operation_id`,`qty`,`quantity`,`items`) VALUES ('" & txtoprno.Text & "','" & totalitem.SubItems(0).Text & "','" & totalitem.SubItems(1).Text & "','" & totalitem.SubItems(2).Text & "')", con)
                    cmd.ExecuteNonQuery()
                    reader.Close()
                    totalitem.Remove()
                Next
                frmchooseitemsandpersonel.txttotalprice.Text = ""
                frmchooseitemsandpersonel.lviitems.Items.Clear()
                frmchooseitemsandpersonel.lviassignpersonel.Items.Clear()
                frmchooseitemsandpersonel.lvispecs.Items.Clear()
                frmchooseitemsandpersonel.lvitotal.Items.Clear()
                lviassignpersonel.Items.Clear()
                lviitems.Items.Clear()
                frmchooseitemsandpersonel.Close()

                btnnew.Text = "New"
                txtoprno.Text = ""
                txtcontractname.Text = ""
                txtclient.Text = ""
                txtlocation.Text = ""
                txtcontactno.Text = ""
                txtcontractamount.Text = ""
                txtworknature.Text = ""
                txtdescription.Text = ""
                dtpstartoperation.Enabled = False
                txtcontractname.ReadOnly = True
                txtclient.ReadOnly = True
                txtlocation.ReadOnly = True
                txtcontactno.ReadOnly = True
                txtcontractamount.ReadOnly = True
                txtworknature.ReadOnly = True
                txtdescription.ReadOnly = True
                btncancel.Enabled = False
                lviopr.Enabled = True
                displayoperation()
                displaystocks()
                operationitemsalesexpanddipslay()

                MessageBox.Show("Operation has been started!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub

    Private Sub operationidgenerator()

        openconnection()
        Dim idinitial As String = "OPR"
        Dim counter As Integer = 1
        Dim idnumber As String = "00"
        finalizeid = idinitial & idnumber & counter.ToString
        Dim isidexists As Boolean = True

        reader.Close()
        cmd.CommandText = "select operation_id from tbl_operations where operation_id = '" & finalizeid & "'"
        reader = cmd.ExecuteReader
        If reader.HasRows = False Then
            reader.Close()
            'cmd = New MySqlCommand("INSERT INTO `id`(`id`) VALUES ('" & finalizeid & "')", con)
            'cmd.ExecuteNonQuery()
            finalizeid = idinitial & idnumber & counter.ToString
        Else
            Do Until isidexists = False
                reader.Close()
                counter += 1
                If counter > 9 And counter < 100 Then
                    idnumber = "0"
                ElseIf counter > 99 Then
                    idnumber = ""
                End If
                finalizeid = idinitial & idnumber & counter.ToString
                cmd.CommandText = "select operation_id from tbl_operations where operation_id = '" & finalizeid & "'"
                reader = cmd.ExecuteReader
                If reader.HasRows = True Then
                    isidexists = True
                Else
                    isidexists = False
                End If
            Loop
            reader.Close()
            'cmd = New MySqlCommand("INSERT INTO `id`(`id`) VALUES ('" & finalizeid & "')", con)
            'cmd.ExecuteNonQuery()
        End If
    End Sub

    Private Sub productidgeneratorversion2()

        openconnection()
        Dim idinitial As String = "v2PROD"
        Dim counter As Integer = 1
        Dim idnumber As String = "00"
        productfinalizeid = idinitial & idnumber & counter.ToString
        Dim isidexists As Boolean = True

        reader.Close()
        cmd.CommandText = "select product_id from tbl_operation_item_used where product_id = '" & productfinalizeid & "'"
        reader = cmd.ExecuteReader
        If reader.HasRows = False Then
            reader.Close()
            productfinalizeid = idinitial & idnumber & counter.ToString
        Else
            Do Until isidexists = False
                reader.Close()
                counter += 1
                If counter > 9 And counter < 100 Then
                    idnumber = "0"
                ElseIf counter > 99 Then
                    idnumber = ""
                End If
                productfinalizeid = idinitial & idnumber & counter.ToString
                cmd.CommandText = "select product_id from tbl_operation_item_used where product_id = '" & productfinalizeid & "'"
                reader = cmd.ExecuteReader
                If reader.HasRows = True Then
                    isidexists = True
                Else
                    isidexists = False
                End If
            Loop
            reader.Close()
        End If

    End Sub

    Private Sub button2_Click(sender As Object, e As EventArgs) Handles button2.Click

        If button2.Text = "Finalize" Then
            lviopr.Enabled = False
            dtpstartoperation.Enabled = True
            txtcontractname.ReadOnly = False
            txtclient.ReadOnly = False
            txtlocation.ReadOnly = False
            txtcontactno.ReadOnly = False
            txtcontractamount.ReadOnly = False
            txtcontractamount.Text = txtcontractamount.Text.Replace("Php ", "")
            dtpendoperation.Enabled = True
            txtduration.ReadOnly = False
            txtcompletionamount.ReadOnly = False
            txtcompletionpercent.ReadOnly = False
            txtworknature.ReadOnly = False
            txtdescription.ReadOnly = False
            btnchoosepersonel.Enabled = True
            btnchoosedevice.Enabled = True
            btnnew.Enabled = False
            btncancel.Enabled = True
            button2.Text = "Finish"

            Dim date1 As Date
            Dim date2 As Date
            Dim difference As TimeSpan
            date1 = Convert.ToDateTime(dtpstartoperation.Value)
            date2 = Convert.ToDateTime(dtpendoperation.Value)
            difference = date2.Subtract(date1)
            Dim totaldays As Integer = FormatNumber(difference.TotalDays, 0) + 1
            If totaldays = 1 Then
                txtduration.Text = totaldays & " working day"
            ElseIf totaldays > 1 Then
                txtduration.Text = totaldays & " working days"
            End If

        ElseIf button2.Text = "Finish" Then
            openconnection()
            cmddelete = "DELETE FROM `tbl_operations` where operation_id='" & txtoprno.Text & "'"
            sqlda = New MySqlDataAdapter(cmddelete, con)
            ds = New DataSet()
            sqlda.Fill(ds)
            Dim contractamount1 As String = "Php " & txtcontractamount.Text
            Dim completionamount1 As String = "Php " & txtcompletionamount.Text
            cmd = New MySqlCommand("INSERT INTO `tbl_operations`(`operation_id`,`date_started`,`contract_name`,`client`,`location`,`contact`,`work_nature`,`description`,`contract_amount`,`status`,`date_finished`,`duration`,`completion_amount`,`completion_percent`) VALUES ('" & txtoprno.Text & "','" & dtpstartoperation.Text.Replace("'", "") & "','" & txtcontractname.Text.Replace("'", "") & "','" & txtclient.Text.Replace("'", "") & "','" & txtlocation.Text.Replace("'", "") & "','" & txtcontactno.Text.Replace("'", "") & "','" & txtworknature.Text.Replace("'", "") & "','" & txtdescription.Text.Replace("'", "") & "','" & contractamount1 & "','" & "Completed" & "','" & dtpendoperation.Text.Replace("'", "") & "','" & txtduration.Text.Replace("'", "") & "','" & completionamount1 & "','" & txtcompletionpercent.Text.Replace("'", "") & "')", con)
            cmd.ExecuteNonQuery()

            displayoperation()
            txtcontractamount.Text = "Php " & txtcontractamount.Text
            txtcompletionamount.Text = "Php " & txtcompletionamount.Text
            lviopr.Enabled = True
            dtpstartoperation.Enabled = False
            txtcontractname.ReadOnly = True
            txtclient.ReadOnly = True
            txtlocation.ReadOnly = True
            txtcontactno.ReadOnly = True
            txtcontractamount.ReadOnly = True
            dtpendoperation.Enabled = False
            txtduration.ReadOnly = True
            txtcompletionamount.ReadOnly = True
            txtcompletionpercent.ReadOnly = True
            txtworknature.ReadOnly = True
            txtdescription.ReadOnly = True
            btnchoosepersonel.Enabled = False
            btnchoosedevice.Enabled = False
            btnnew.Enabled = True
            btncancel.Enabled = False
            button2.Text = "Finalize"
            operationitemsalesexpanddipslay()
            con.Close()
            MessageBox.Show("Operation successfully finished!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub button3_Click(sender As Object, e As EventArgs) Handles button3.Click

        If button3.Text = "Stop" Then
            confirm = MessageBox.Show("Are you sure you want to stop this ongoing operation?", "Stop Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If confirm = vbYes Then
                removeorrestockallitemusedinoperation()
                cmddelete = "DELETE FROM `tbl_operations` where operation_id='" & txtoprno.Text & "'"
                sqlda = New MySqlDataAdapter(cmddelete, con)
                ds = New DataSet()
                sqlda.Fill(ds)

                cmddelete = "DELETE FROM `tbl_operation_item_used` where operation_id='" & txtoprno.Text & "'"
                sqlda = New MySqlDataAdapter(cmddelete, con)
                ds = New DataSet()
                sqlda.Fill(ds)

                cmddelete = "DELETE FROM `tbl_operation_assigned_personel` where operation_id='" & txtoprno.Text & "'"
                sqlda = New MySqlDataAdapter(cmddelete, con)
                ds = New DataSet()
                sqlda.Fill(ds)

                cmddelete = "DELETE FROM `tbl_operation_item_total` where operation_id='" & txtoprno.Text & "'"
                sqlda = New MySqlDataAdapter(cmddelete, con)
                ds = New DataSet()
                sqlda.Fill(ds)

                txtoprno.Text = ""
                dtpstartoperation.Value = Now
                txtcontractname.Text = ""
                txtclient.Text = ""
                txtlocation.Text = ""
                txtcontactno.Text = ""
                txtcontractamount.Text = ""
                txtduration.Text = ""
                txtcompletionamount.Text = ""
                txtcompletionpercent.Text = ""
                txtworknature.Text = ""
                txtdescription.Text = ""
                lviassignpersonel.Items.Clear()
                lviitems.Items.Clear()
                btnchoosedevice.Enabled = False
                btnchoosepersonel.Enabled = False
                displayoperation()

                MessageBox.Show("Operation successfully stoped!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        ElseIf button3.Text = "Delete" Then
            confirm = MessageBox.Show("Are you sure you want to delete this completed operation?", "Stop Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If confirm = vbYes Then
                removeorrestockallitemusedinoperation()
                cmddelete = "DELETE FROM `tbl_operations` where operation_id='" & txtoprno.Text & "'"
                sqlda = New MySqlDataAdapter(cmddelete, con)
                ds = New DataSet()
                sqlda.Fill(ds)

                cmddelete = "DELETE FROM `tbl_operation_item_used` where operation_id='" & txtoprno.Text & "'"
                sqlda = New MySqlDataAdapter(cmddelete, con)
                ds = New DataSet()
                sqlda.Fill(ds)

                cmddelete = "DELETE FROM `tbl_operation_assigned_personel` where operation_id='" & txtoprno.Text & "'"
                sqlda = New MySqlDataAdapter(cmddelete, con)
                ds = New DataSet()
                sqlda.Fill(ds)

                cmddelete = "DELETE FROM `tbl_operation_item_total` where operation_id='" & txtoprno.Text & "'"
                sqlda = New MySqlDataAdapter(cmddelete, con)
                ds = New DataSet()
                sqlda.Fill(ds)

                txtoprno.Text = ""
                dtpstartoperation.Value = Now
                txtcontractname.Text = ""
                txtclient.Text = ""
                txtlocation.Text = ""
                txtcontactno.Text = ""
                txtcontractamount.Text = ""
                txtduration.Text = ""
                txtcompletionamount.Text = ""
                txtcompletionpercent.Text = ""
                txtworknature.Text = ""
                txtdescription.Text = ""
                lviassignpersonel.Items.Clear()
                lviitems.Items.Clear()
                btnchoosedevice.Enabled = False
                btnchoosepersonel.Enabled = False
                displayoperation()

                MessageBox.Show("Operation successfully deleted!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        displaystocks()
        operationitemsalesexpanddipslay()

    End Sub

    Private Sub removeorrestockallitemusedinoperation()
        openconnection()
        cmd.CommandText = "Select * from tbl_operation_item_used where operation_id = '" & txtoprno.Text & "'"
        reader = cmd.ExecuteReader
        If reader.HasRows Then
            confirm = MessageBox.Show("Do you want to restock the item(s) used during this operation?", "Stop Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If confirm = vbYes Then
                reader.Close()
                cmd = New MySqlCommand("select * from tbl_operation_item_used where operation_id = '" & txtoprno.Text & "'", con)
                reader = cmd.ExecuteReader
                While (reader.Read())
                    Dim item As New ListViewItem(reader("product").ToString)
                    item.SubItems.Add(reader("type").ToString)
                    item.SubItems.Add(reader("brand").ToString)
                    item.SubItems.Add(reader("supplier").ToString)
                    item.SubItems.Add(reader("serial").ToString)
                    item.SubItems.Add(reader("model").ToString)
                    item.SubItems.Add(reader("arrival_date").ToString)
                    item.SubItems.Add(reader("quantity").ToString)
                    item.SubItems.Add(reader("unit").ToString)
                    item.SubItems.Add(reader("unit_price").ToString)
                    item.SubItems.Add(reader("quantity_unit").ToString)
                    Dim totalprice As Decimal = reader("quantity").ToString * reader("unit_price").ToString
                    item.SubItems.Add(totalprice)
                    item.SubItems.Add(reader("specification").ToString)
                    item.SubItems.Add(reader("status").ToString)
                    lviremoveorrestock.Items.Add(item)
                End While
                reader.Close()
            End If

            For Each item As ListViewItem In lviremoveorrestock.Items

                If item.SubItems(4).Text <> "" Then
                    cmd.CommandText = "Select * from tbl_stocks where product = '" & item.SubItems(0).Text & "' and type = '" & item.SubItems(1).Text & "' and brand = '" & item.SubItems(2).Text & "' and supplier = '" & item.SubItems(3).Text & "' and serial = '" & item.SubItems(4).Text & "' and model = '" & item.SubItems(5).Text & "' and arrival_date = '" & item.SubItems(6).Text & "' and unit = '" & item.SubItems(8).Text & "' and unit_price = '" & item.SubItems(9).Text & "' and specification = '" & item.SubItems(12).Text.Replace("\", "\\") & "'"
                Else
                    cmd.CommandText = "Select * from tbl_stocks where product = '" & item.SubItems(0).Text & "' and type = '" & item.SubItems(1).Text & "' and brand = '" & item.SubItems(2).Text & "' and supplier = '" & item.SubItems(3).Text & "' and model = '" & item.SubItems(5).Text & "' and arrival_date = '" & item.SubItems(6).Text & "' and unit = '" & item.SubItems(8).Text & "' and unit_price = '" & item.SubItems(9).Text & "' and specification = '" & item.SubItems(12).Text.Replace("\", "\\") & "'"
                End If
                reader = cmd.ExecuteReader
                If reader.HasRows Then
                    'MsgBox("Match found!")
                    reader.Read()
                    Dim iteminstockid As String = reader("product_id").ToString
                    Dim iteminstockquantity As Integer = reader("quantity").ToString
                    Dim iteminstockunit As String = reader("unit").ToString
                    Dim iteminstocktotalprice As Decimal = reader("totalprice").ToString
                    reader.Close()
                    Dim newtotalprice As Decimal = iteminstocktotalprice + item.SubItems(11).Text
                    cmd = New MySqlCommand("UPDATE `tbl_stocks` SET `quantity`= '" & iteminstockquantity + item.SubItems(7).Text & "' ,`quantity_unit`= '" & iteminstockquantity + item.SubItems(7).Text & " " & item.SubItems(8).Text & "' , `totalprice`= '" & newtotalprice & "' where product_id='" & iteminstockid & "'", con)
                    cmd.ExecuteNonQuery()
                Else
                    'MsgBox("No match found!")
                    productidgenerator0()
                    If item.SubItems(4).Text <> "" Then
                        cmd = New MySqlCommand("INSERT INTO `tbl_stocks`(`product_id`,`product`,`type`,`brand`,`supplier`,`serial`,`model`,`arrival_date`,`quantity`,`unit`,`unit_price`,`quantity_unit`,`totalprice`,`specification`,`status`) VALUES ('" & productfinalizeid & "','" & item.SubItems(0).Text & "','" & item.SubItems(1).Text & "','" & item.SubItems(2).Text & "','" & item.SubItems(3).Text & "','" & item.SubItems(4).Text & "','" & item.SubItems(5).Text & "','" & item.SubItems(6).Text & "','" & item.SubItems(7).Text & "','" & item.SubItems(8).Text & "','" & item.SubItems(9).Text & "','" & item.SubItems(10).Text & "','" & item.SubItems(11).Text & "','" & item.SubItems(12).Text.Replace("\", "\\") & "','" & "available" & "')", con)
                        cmd.ExecuteNonQuery()
                    Else
                        cmd = New MySqlCommand("INSERT INTO `tbl_stocks`(`product_id`,`product`,`type`,`brand`,`supplier`,`model`,`arrival_date`,`quantity`,`unit`,`unit_price`,`quantity_unit`,`totalprice`,`specification`,`status`) VALUES ('" & productfinalizeid & "','" & item.SubItems(0).Text & "','" & item.SubItems(1).Text & "','" & item.SubItems(2).Text & "','" & item.SubItems(3).Text & "','" & item.SubItems(5).Text & "','" & item.SubItems(6).Text & "','" & item.SubItems(7).Text & "','" & item.SubItems(8).Text & "','" & item.SubItems(9).Text & "','" & item.SubItems(10).Text & "','" & item.SubItems(11).Text & "','" & item.SubItems(12).Text.Replace("\", "\\") & "','" & "available" & "')", con)
                        cmd.ExecuteNonQuery()
                    End If
                End If
                item.Remove()
            Next
        End If
        reader.Close()
        con.Close()
    End Sub

    Private Sub productidgenerator0()

        openconnection()
        Dim idinitial As String = "PROD"
        Dim counter As Integer = 1
        Dim idnumber As String = "00"
        productfinalizeid = idinitial & idnumber & counter.ToString
        Dim isidexists As Boolean = True

        reader.Close()
        cmd.CommandText = "select product_id from tbl_stocks where product_id = '" & productfinalizeid & "'"
        reader = cmd.ExecuteReader
        If reader.HasRows = False Then
            reader.Close()
            'cmd = New MySqlCommand("INSERT INTO `id`(`id`) VALUES ('" & finalizeid & "')", con)
            'cmd.ExecuteNonQuery()
            productfinalizeid = idinitial & idnumber & counter.ToString
        Else
            Do Until isidexists = False
                reader.Close()
                counter += 1
                If counter > 9 And counter < 100 Then
                    idnumber = "0"
                ElseIf counter > 99 Then
                    idnumber = ""
                End If
                productfinalizeid = idinitial & idnumber & counter.ToString
                cmd.CommandText = "select product_id from tbl_stocks where product_id = '" & productfinalizeid & "'"
                reader = cmd.ExecuteReader
                If reader.HasRows = True Then
                    isidexists = True
                Else
                    isidexists = False
                End If
            Loop
            reader.Close()
            'cmd = New MySqlCommand("INSERT INTO `id`(`id`) VALUES ('" & finalizeid & "')", con)
            'cmd.ExecuteNonQuery()
        End If

    End Sub

    Private Sub button4_Click(sender As Object, e As EventArgs) Handles button4.Click

        If button4.Text = "Edit" Then
            button3.Enabled = False
            btncancel.Enabled = True
            button4.Text = "Save"
            lviopr.Enabled = False
            dtpstartoperation.Enabled = True
            txtcontractname.ReadOnly = False
            txtclient.ReadOnly = False
            txtlocation.ReadOnly = False
            txtcontactno.ReadOnly = False
            txtcontractamount.ReadOnly = False
            dtpendoperation.Enabled = True
            txtduration.ReadOnly = False
            txtcompletionamount.ReadOnly = False
            txtcompletionpercent.ReadOnly = False
            txtworknature.ReadOnly = False
            txtdescription.ReadOnly = False
            txtcontractamount.Text = txtcontractamount.Text.Replace("Php ", "")
            txtcompletionamount.Text = txtcompletionamount.Text.Replace("Php ", "")

        ElseIf button4.Text = "Save" Then
            button3.Enabled = True
            btncancel.Enabled = False
            button4.Text = "Edit"

            dtpstartoperation.Enabled = False
            txtcontractname.ReadOnly = True
            txtclient.ReadOnly = True
            txtlocation.ReadOnly = True
            txtcontactno.ReadOnly = True
            txtcontractamount.ReadOnly = True
            dtpendoperation.Enabled = False
            txtduration.ReadOnly = True
            txtcompletionamount.ReadOnly = True
            txtcompletionpercent.ReadOnly = True
            txtworknature.ReadOnly = True
            txtdescription.ReadOnly = True

            Dim contractamount As Long
            Dim completionamount As Long
            Try
                contractamount = txtcontractamount.Text
            Catch ex As Exception
                MessageBox.Show("Contract amount must only contain a number!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End Try
            Try
                completionamount = txtcompletionamount.Text
            Catch ex As Exception
                MessageBox.Show("Completion amount must only contain a number!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End Try

            cmd = New MySqlCommand("UPDATE `tbl_operations` SET `date_started`= '" & dtpstartoperation.Text & "' ,`contract_name`= '" & txtcontractname.Text & "' , `client`= '" & txtclient.Text & "' , `location`= '" & txtlocation.Text & "' , `contact`= '" & txtcontactno.Text & "' , `work_nature`= '" & txtworknature.Text & "' , `description`= '" & txtdescription.Text & "' , `contract_amount`= '" & "Php " & txtcontractamount.Text & "' , `date_finished`= '" & dtpendoperation.Text & "' , `duration`= '" & txtduration.Text & "' , `completion_amount`= '" & "Php " & txtcompletionamount.Text & "' , `completion_percent`= '" & txtcompletionpercent.Text & "' where operation_id ='" & txtoprno.Text & "'", con)
            cmd.ExecuteNonQuery()
            lviopr.Enabled = True
            displayoperation()
            txtoprno.Text = ""
            dtpstartoperation.Value = Now
            txtcontractname.Text = ""
            txtclient.Text = ""
            txtlocation.Text = ""
            txtcontactno.Text = ""
            txtcontractamount.Text = ""
            dtpendoperation.Value = Now
            txtduration.Text = ""
            txtcompletionamount.Text = ""
            txtcompletionpercent.Text = ""
            txtworknature.Text = ""
            txtdescription.Text = ""
            MessageBox.Show("Changes successfully saved!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click

        frmchooseitemsandpersonel.lviitems.Items.Clear()
        frmchooseitemsandpersonel.lviassignpersonel.Items.Clear()
        frmchooseitemsandpersonel.lvispecs.Items.Clear()
        frmchooseitemsandpersonel.lvitotal.Items.Clear()
        lviassignpersonel.Items.Clear()
        lviitems.Items.Clear()
        frmchooseitemsandpersonel.Close()

        lviopr.Enabled = True
        btnnew.Text = "New"
        button2.Text = "Finalize"
        button4.Text = "Edit"
        txtoprno.Text = ""
        txtoprno.Text = ""
        txtcontractname.Text = ""
        txtclient.Text = ""
        txtlocation.Text = ""
        txtcontactno.Text = ""
        txtcontractamount.Text = ""
        dtpstartoperation.Value = Now
        dtpendoperation.Value = Now
        txtduration.Text = ""
        txtcompletionamount.Text = ""
        txtcompletionpercent.Text = ""
        txtworknature.Text = ""
        txtdescription.Text = ""
        button4.Enabled = False
        dtpstartoperation.Enabled = False
        txtcontractname.ReadOnly = True
        txtclient.ReadOnly = True
        txtlocation.ReadOnly = True
        txtcontactno.ReadOnly = True
        txtcontractamount.ReadOnly = True
        txtworknature.ReadOnly = True
        txtdescription.ReadOnly = True
        btncancel.Enabled = False
        btnchoosepersonel.Enabled = False
        btnchoosedevice.Enabled = False
        dtpendoperation.Enabled = False
        txtduration.ReadOnly = True
        txtcompletionamount.ReadOnly = True
        txtcompletionpercent.ReadOnly = True
        btnnew.Enabled = True
        button2.Enabled = False
        button3.Enabled = False
        txtsearch.Focus()

    End Sub

    Private Sub btnrefresh_Click(sender As Object, e As EventArgs) Handles btnrefresh.Click

        lviopr.Enabled = True
        btnnew.Text = "New"
        button2.Text = "Finalize"
        button4.Text = "Edit"
        txtoprno.Text = ""
        txtoprno.Text = ""
        txtcontractname.Text = ""
        txtclient.Text = ""
        txtlocation.Text = ""
        txtcontactno.Text = ""
        txtcontractamount.Text = ""
        dtpstartoperation.Value = Now
        dtpendoperation.Value = Now
        txtduration.Text = ""
        txtcompletionamount.Text = ""
        txtcompletionpercent.Text = ""
        txtworknature.Text = ""
        txtdescription.Text = ""
        button4.Enabled = False
        dtpstartoperation.Enabled = False
        txtcontractname.ReadOnly = True
        txtclient.ReadOnly = True
        txtlocation.ReadOnly = True
        txtcontactno.ReadOnly = True
        txtcontractamount.ReadOnly = True
        txtworknature.ReadOnly = True
        txtdescription.ReadOnly = True
        btncancel.Enabled = False
        btnchoosepersonel.Enabled = False
        btnchoosedevice.Enabled = False
        dtpendoperation.Enabled = False
        txtduration.ReadOnly = True
        txtcompletionamount.ReadOnly = True
        txtcompletionpercent.ReadOnly = True
        btnnew.Enabled = True
        button2.Enabled = False
        button3.Enabled = False
        txtsearch.Focus()
        lviassignpersonel.Items.Clear()
        lviitems.Items.Clear()
        lviopr.Columns.Clear()
        lviopr.Items.Clear()
        lviopr.Columns.Add("OPR No.", 100, HorizontalAlignment.Left)
        lviopr.Columns.Add("Contract Name", 150, HorizontalAlignment.Left)
        lviopr.Columns.Add("Client", 145, HorizontalAlignment.Left)
        lviopr.Columns.Add("Location", 150, HorizontalAlignment.Left)
        lviopr.Columns.Add("Status", 111, HorizontalAlignment.Left)
        displayoperation()

    End Sub

    Private Sub dtpstartoperation_ValueChanged(sender As Object, e As EventArgs) Handles dtpstartoperation.ValueChanged
        If button2.Text = "Finish" Then
            Dim date1 As Date
            Dim date2 As Date
            Dim difference As TimeSpan
            date1 = Convert.ToDateTime(dtpstartoperation.Value)
            date2 = Convert.ToDateTime(dtpendoperation.Value)
            difference = date2.Subtract(date1)
            Dim totaldays As Integer = FormatNumber(difference.TotalDays, 0)
            If totaldays = 1 Then
                txtduration.Text = totaldays & " working day"
            ElseIf totaldays > 1 Then
                txtduration.Text = totaldays & " working days"
            ElseIf totaldays < 1 Then
                txtduration.Text = ""
            End If
        End If
    End Sub

    Private Sub btnminimize_Click(sender As Object, e As EventArgs) Handles btnminimize.Click

        Me.WindowState = FormWindowState.Minimized

    End Sub

    Private Sub btnexit_Click(sender As Object, e As EventArgs) Handles btnexit.Click

        frmlogin.Show()
        Me.Close()

    End Sub

    Private Sub dtpendoperation_ValueChanged(sender As Object, e As EventArgs) Handles dtpendoperation.ValueChanged

        Dim date1 As Date
        Dim date2 As Date
        Dim difference As TimeSpan
        date1 = Convert.ToDateTime(dtpstartoperation.Value)
        date2 = Convert.ToDateTime(dtpendoperation.Value)
        difference = date2.Subtract(date1)
        Dim totaldays As Integer = FormatNumber(difference.TotalDays, 0)
        If totaldays = 1 Then
            txtduration.Text = totaldays & " working day"
        ElseIf totaldays > 1 Then
            txtduration.Text = totaldays & " working days"
        ElseIf totaldays < 1 Then
            txtduration.Text = ""
        End If

    End Sub

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged

        If txtsearch.Text <> "" Then
            displayoperation()
            If cbosearch.Text = "Operation No." Then
                For Each operation As ListViewItem In lviopr.Items
                    If Not operation.SubItems(0).Text.ToLower.Contains(txtsearch.Text.ToLower) Then
                        operation.Remove()
                    End If
                Next
            ElseIf cbosearch.Text = "Contract Name" Then
                For Each operation As ListViewItem In lviopr.Items
                    If Not operation.SubItems(1).Text.ToLower.Contains(txtsearch.Text.ToLower) Then
                        operation.Remove()
                    End If
                Next
            ElseIf cbosearch.Text = "Client" Then
                For Each operation As ListViewItem In lviopr.Items
                    If Not operation.SubItems(2).Text.ToLower.Contains(txtsearch.Text.ToLower) Then
                        operation.Remove()
                    End If
                Next
            ElseIf cbosearch.Text = "Location" Then
                For Each operation As ListViewItem In lviopr.Items
                    If Not operation.SubItems(3).Text.ToLower.Contains(txtsearch.Text.ToLower) Then
                        operation.Remove()
                    End If
                Next
            End If
        Else
            displayoperation()
        End If

    End Sub

    Private Sub cbosearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbosearch.SelectedIndexChanged

        txtsearch.Text = ""

    End Sub

    Private Sub btnchoosepersonel_Click(sender As Object, e As EventArgs) Handles btnchoosepersonel.Click

        openconnection()
        cmd.CommandText = "Select operation_id from tbl_operations where operation_id = '" & txtoprno.Text & "'"
        reader = cmd.ExecuteReader
        If reader.HasRows Then
            loaduseditemsinoperation = True
        Else
            loaduseditemsinoperation = False
        End If
        reader.Close()
        con.Close()
        operationnumber = txtoprno.Text
        frmchooseitemsandpersonel.ShowInTaskbar = False
        frmchooseitemsandpersonel.ShowDialog()

    End Sub

    Private Sub btnchoosedevice_Click(sender As Object, e As EventArgs) Handles btnchoosedevice.Click

        openconnection()
        cmd.CommandText = "Select operation_id from tbl_operations where operation_id = '" & txtoprno.Text & "'"
        reader = cmd.ExecuteReader
        If reader.HasRows Then
            loaduseditemsinoperation = True
        Else
            loaduseditemsinoperation = False
        End If
        reader.Close()
        con.Close()
        operationnumber = txtoprno.Text
        frmchooseitemsandpersonel.ShowInTaskbar = False
        frmchooseitemsandpersonel.ShowDialog()

    End Sub

    Private Sub cboproduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboproduct.SelectedIndexChanged

        If cboproduct.Text = "" Then
            cbotype.Enabled = False
            cbobrand.Enabled = False
            txtsearchstocks.Text = ""
            displaystocks()
        Else
            cbotype.Enabled = True
            cbobrand.Enabled = True
            cbotype.Items.Clear()
            cbobrand.Items.Clear()
            loadproducttype()
            loadproductbrand()
            txtsearchstocks.Text = ""
            filterstocks()
        End If

    End Sub

    Private Sub loadproducttype()
        openconnection()
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

    Private Sub loadproductbrand()
        openconnection()
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

    Private Sub cbosearchstocks_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbosearchstocks.SelectedIndexChanged

        txtsearchstocks.ReadOnly = False
        txtsearchstocks.Text = ""

    End Sub

    Private Sub txtsearchstocks_TextChanged(sender As Object, e As EventArgs) Handles txtsearchstocks.TextChanged

        If txtsearchstocks.Text <> "" Then
            If cboproduct.Text = "" Then
                displaystocks()
            Else
                filterstocks()
            End If
            If cbosearchstocks.Text = "Serial" Then
                For Each Item As ListViewItem In lvistocks.Items
                    If Not Item.SubItems(4).Text.ToLower.Contains(txtsearchstocks.Text.ToLower) Then
                        Item.Remove()
                    End If
                Next
            ElseIf cbosearchstocks.Text = "Model" Then
                For Each Item As ListViewItem In lvistocks.Items
                    If Not Item.SubItems(5).Text.ToLower.Contains(txtsearchstocks.Text.ToLower) Then
                        Item.Remove()
                    End If
                Next
            End If
        Else
            If cboproduct.Text = "" Then
                displaystocks()
            Else
                filterstocks()
            End If
        End If

        txtquantity.Text = lvistocks.Items.Count
        Dim grandtotal As Decimal
        For Each item As ListViewItem In lvistocks.Items
            grandtotal += item.SubItems(11).Text.Replace("Php ", "")
        Next
        If grandtotal > 999 Then
            txttotalprice.Text = "Php " & Format((grandtotal), "0,00.00")
        ElseIf grandtotal > 0 And grandtotal < 1000 Then
            txttotalprice.Text = "Php " & Format((grandtotal), "0.00")
        ElseIf grandtotal = 0 Then
            txttotalprice.Text = ""
        End If

    End Sub

    Private Sub btnstocksrefresh_Click(sender As Object, e As EventArgs) Handles btnstocksrefresh.Click

        lvistocks.Columns.Clear()
        lvistocks.Columns.Add("Product Name", 165, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Type", 135, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Brand", 115, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Supplier", 115, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Serial", 155, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Model", 230, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Arrival Date", 90, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Qty", 0, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Unit", 0, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Unit Price", 110, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Quantity", 70, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Total Price", 110, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Product ID", 0, HorizontalAlignment.Left)

        cbotype.Enabled = False
        cbobrand.Enabled = False
        cboproduct.Text = ""
        cbotype.Text = ""
        cbobrand.Text = ""
        cbosearchstocks.Text = ""
        txtsearchstocks.Text = ""
        cboproduct.Items.Clear()
        cbotype.Items.Clear()
        cbobrand.Items.Clear()

        loadproductname()
        displaystocks()

    End Sub

    Private Sub lvistocks_DoubleClick(sender As Object, e As EventArgs) Handles lvistocks.DoubleClick

        frmproduct.Close()
        frmproduct.lblproduct.Text = "View Product"
        For Each item As ListViewItem In lvistocks.Items
            If lvistocks.SelectedItems.Count > 0 Then
                item = lvistocks.SelectedItems.Item(0)
                frmproduct.txtprodid.Text = item.SubItems(12).Text
                frmproduct.cboproduct.Text = item.SubItems(0).Text
                frmproduct.cbotype.Text = item.SubItems(1).Text
                frmproduct.cbobrand.Text = item.SubItems(2).Text
                frmproduct.dtparrivaldate.Text = item.SubItems(6).Text
                frmproduct.cbosupplier.Text = item.SubItems(3).Text
                frmproduct.nupquantity.Text = item.SubItems(7).Text
                frmproduct.cbounit.Text = item.SubItems(8).Text
                frmproduct.txtprice.Text = item.SubItems(9).Text
                frmproduct.txtserial.Text = item.SubItems(4).Text
                frmproduct.txtmodel.Text = item.SubItems(5).Text
                frmproduct.txttotalprice.Text = item.SubItems(11).Text
                selecteditemid = item.SubItems(12).Text

                frmproduct.cboproduct.Enabled = False
                frmproduct.cbotype.Enabled = False
                frmproduct.cbobrand.Enabled = False
                frmproduct.dtparrivaldate.Enabled = False
                frmproduct.cbosupplier.Enabled = False
                frmproduct.txtserial.Enabled = False
                frmproduct.txtmodel.Enabled = False
                frmproduct.nupquantity.Enabled = False
                frmproduct.cbounit.Enabled = False
                frmproduct.txtprice.Enabled = False
                frmproduct.cbospecs.Enabled = False
                frmproduct.btnadd.Enabled = False
                frmproduct.btnminus.Enabled = False
                item.Selected = False

                frmproduct.lvispecs.Items.Clear()
                Dim specslen As Integer = 0
                Dim trimmedtextlen As Integer = 0
                Dim trimmedtext As String = ""
                Dim specs As String = ""
                openconnection()
                cmd.CommandText = "Select specification from tbl_stocks where product_id = '" & selecteditemid & "'"
                reader = cmd.ExecuteReader
                If reader.HasRows Then
                    While (reader.Read())
                        specs = reader("specification").ToString
                    End While
                End If
                reader.Close()
                con.Close()

                specslen = Microsoft.VisualBasic.Len(specs)
                Do Until specslen < 1
                    Dim spliter As String() = specs.Split("\")
                    trimmedtext = spliter.Last.Trim
                    Dim lvi As New ListViewItem("- " & trimmedtext)
                    frmproduct.lvispecs.Items.Add(lvi)
                    trimmedtextlen = Microsoft.VisualBasic.Len(trimmedtext)
                    'MsgBox(trimmedtext)
                    'MsgBox(trimmedtextlen)
                    specslen = specslen - (trimmedtextlen + 1)
                    'MsgBox("New len of specs = " & specslen)
                    specs = Microsoft.VisualBasic.Left(specs, specslen)
                Loop
            End If
        Next

        'If frmproduct.txtprice.Text <> "" And frmproduct.nupquantity.Value <> 0 Then
        '    Dim unitprice As Long = frmproduct.txtprice.Text
        '    Dim quantity As Long = frmproduct.nupquantity.Value
        '    txttotalprice.Text = "Php " & Format((unitprice * quantity), "0,00")
        'End If

        productmode = "viewmode"
        loadcomboboxiteminproduct = True
        generateidforproduct = False
        frmproduct.ShowInTaskbar = False
        frmproduct.ShowDialog()

    End Sub

    Private Sub btnstocksadd_Click(sender As Object, e As EventArgs) Handles btnstocksadd.Click

        frmproduct.lblproduct.Text = "Add Product"
        frmproduct.btnaddandenter.Text = "Enter"
        frmproduct.cboproduct.Text = ""
        frmproduct.cbotype.Text = ""
        frmproduct.cbobrand.Text = ""
        frmproduct.cbosupplier.Text = ""
        frmproduct.cbounit.Text = ""
        frmproduct.txtprice.Text = ""
        frmproduct.txtserial.Text = ""
        frmproduct.txtmodel.Text = ""
        frmproduct.txttotalprice.Enabled = True
        frmproduct.btneditandupdate.Enabled = False
        frmproduct.btndelete.Enabled = False
        frmproduct.cboproduct.Focus()
        generateidforproduct = True

        loadcomboboxiteminproduct = True
        productmode = "Add Mode"
        frmproduct.ShowInTaskbar = False
        frmproduct.ShowDialog()
        'frmproduct.lblproduct.Text = "Add Product"
        'frmproduct.btnbutton.Text = "Enter"

    End Sub

    Private Sub btnstocksedit_Click(sender As Object, e As EventArgs) Handles btnstocksedit.Click

        If btnnew.Text <> "Start" Then
            Dim stoper As Integer = 1
            For Each item As ListViewItem In lvistocks.Items
                If lvistocks.SelectedItems.Count > 0 Then
                    If stoper > 0 Then
                        item = lvistocks.SelectedItems.Item(0)
                        frmproduct.txtprodid.Text = item.SubItems(12).Text
                        frmproduct.cboproduct.Text = item.SubItems(0).Text
                        frmproduct.cbotype.Text = item.SubItems(1).Text
                        frmproduct.cbobrand.Text = item.SubItems(2).Text
                        frmproduct.dtparrivaldate.Text = item.SubItems(6).Text
                        frmproduct.cbosupplier.Text = item.SubItems(3).Text
                        frmproduct.nupquantity.Text = item.SubItems(7).Text
                        frmproduct.cbounit.Text = item.SubItems(8).Text
                        frmproduct.txtprice.Text = item.SubItems(9).Text
                        frmproduct.txtserial.Text = item.SubItems(4).Text
                        frmproduct.txtmodel.Text = item.SubItems(5).Text
                        frmproduct.txttotalprice.Text = item.SubItems(11).Text
                        selecteditemid = item.SubItems(12).Text
                        item.Selected = False

                        frmproduct.cboproduct.Items.Clear()
                        frmproduct.cbotype.Items.Clear()
                        frmproduct.cbobrand.Items.Clear()
                        frmproduct.cbosupplier.Items.Clear()
                        frmproduct.cbospecs.Items.Clear()

                        frmproduct.loadproductname()
                        frmproduct.loadproducttype()
                        frmproduct.loadproductbrand()
                        frmproduct.loadproductsupplier()
                        frmproduct.loadproductspecification()

                        frmproduct.txtprice.Text = frmproduct.txtprice.Text.Replace("Php ", "")
                        frmproduct.txtprice.Text = frmproduct.txtprice.Text.Replace(",", "")

                        frmproduct.lvispecs.Items.Clear()
                        Dim specslen As Integer = 0
                        Dim trimmedtextlen As Integer = 0
                        Dim trimmedtext As String = ""
                        Dim specs As String = ""
                        openconnection()
                        cmd.CommandText = "Select specification from tbl_stocks where product_id = '" & selecteditemid & "'"
                        reader = cmd.ExecuteReader
                        If reader.HasRows Then
                            While (reader.Read())
                                specs = reader("specification").ToString
                            End While
                        End If
                        reader.Close()
                        con.Close()

                        specslen = Microsoft.VisualBasic.Len(specs)
                        Do Until specslen < 1
                            Dim spliter As String() = specs.Split("\")
                            trimmedtext = spliter.Last.Trim
                            Dim lvi As New ListViewItem("- " & trimmedtext)
                            frmproduct.lvispecs.Items.Add(lvi)
                            trimmedtextlen = Microsoft.VisualBasic.Len(trimmedtext)
                            'MsgBox(trimmedtext)
                            'MsgBox(trimmedtextlen)
                            specslen = specslen - (trimmedtextlen + 1)
                            'MsgBox("New len of specs = " & specslen)
                            specs = Microsoft.VisualBasic.Left(specs, specslen)
                        Loop


                        loadcomboboxiteminproduct = False
                        generateidforproduct = False
                        frmproduct.lblproduct.Text = "Edit Product"
                        frmproduct.btneditandupdate.Text = "Update"
                        productmode = "Edit Mode"
                        frmproduct.ShowInTaskbar = False
                        frmproduct.ShowDialog()
                    End If
                    stoper -= 1
                    Exit Sub
                Else
                    MessageBox.Show("Select na item to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Next
        Else
            MessageBox.Show("You can't edit an item while starting an operation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub btnstocksdelete_Click(sender As Object, e As EventArgs) Handles btnstocksdelete.Click

        If btnnew.Text <> "Start" Then
            confirm = MessageBox.Show("Are you sure?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
            If confirm = vbOK Then
                openconnection()
                For Each item As ListViewItem In lvistocks.Items
                    If lvistocks.SelectedItems.Count > 0 Then
                        item = lvistocks.SelectedItems.Item(0)
                        cmddelete = "DELETE FROM `tbl_stocks` where product_id='" & item.SubItems(12).Text & "'"
                        sqlda = New MySqlDataAdapter(cmddelete, con)
                        ds = New DataSet()
                        sqlda.Fill(ds)

                        'cmddelete = "DELETE FROM `tbl_stocks_specs` where product_id='" & item.SubItems(12).Text & "'"
                        'sqlda = New MySqlDataAdapter(cmddelete, con)
                        'ds = New DataSet()
                        'sqlda.Fill(ds)
                    End If
                    item.Remove()
                Next
                displaystocks()
            End If
        Else
            MessageBox.Show("You can't delete an item while starting an operation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub lvistocks_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvistocks.SelectedIndexChanged

    End Sub

    Private Sub cbofilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbofilter.SelectedIndexChanged

        openconnection()
        Dim initalgrandtotal1 As Decimal
        lvisales.Items.Clear()
        If cbofilter.Text = "Operations" Then
            cmd = New MySqlCommand("select tbl_operations.date_started, tbl_operation_item_used.operation_id, tbl_operations.client, tbl_operations.location, tbl_operations.contact, tbl_operation_item_used.product, tbl_operation_item_used.type, tbl_operation_item_used.selling_price, tbl_operation_item_used.quantity, tbl_operation_item_used.unit, tbl_operation_item_used.total_price from tbl_operation_item_used inner join tbl_operations on tbl_operation_item_used.operation_id = tbl_operations.operation_id", con)
            reader = cmd.ExecuteReader
            While (reader.Read())
                Dim item As New ListViewItem(reader("operation_id").ToString())
                item.SubItems.Add(reader("date_started").ToString())
                item.SubItems.Add(reader("client").ToString())
                item.SubItems.Add(reader("location").ToString())
                item.SubItems.Add(reader("contact").ToString())
                item.SubItems.Add(reader("product").ToString())
                item.SubItems.Add(reader("type").ToString())
                Dim selllingprice As Decimal = reader("selling_price").ToString()
                If selllingprice > 999 Then
                    item.SubItems.Add("Php " & Format((selllingprice), "0,00.00"))
                ElseIf selllingprice < 1000 Then
                    item.SubItems.Add("Php " & Format((selllingprice), "0.00"))
                End If
                item.SubItems.Add(reader("quantity").ToString() & " " & reader("unit").ToString())
                Dim totalprice As Decimal = reader("total_price").ToString()
                If totalprice > 999 Then
                    item.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
                ElseIf totalprice < 1000 Then
                    item.SubItems.Add("Php " & Format((totalprice), "0.00"))
                End If
                initalgrandtotal1 += reader("total_price").ToString().Replace("Php ", "")
                lvisales.Items.Add(item)
            End While
            reader.Close()
        ElseIf cbofilter.Text = "Transactions" Then
            cmd = New MySqlCommand("select tbl_transactions.transaction_id, tbl_transactions.date_sold, tbl_transactions.client, tbl_transactions.address, tbl_transactions.contact_number, tbl_transaction_item_sold.product, tbl_transaction_item_sold.type, tbl_transaction_item_sold.selling_price, tbl_transaction_item_sold.quantity, tbl_transaction_item_sold.unit, tbl_transaction_item_sold.total_price from tbl_transaction_item_sold inner join tbl_transactions on tbl_transaction_item_sold.transaction_id = tbl_transactions.transaction_id", con)
            reader = cmd.ExecuteReader
            While (reader.Read())
                Dim item As New ListViewItem(reader("transaction_id").ToString())
                item.SubItems.Add(reader("date_sold").ToString())
                item.SubItems.Add(reader("client").ToString())
                item.SubItems.Add(reader("address").ToString())
                item.SubItems.Add(reader("contact_number").ToString())
                item.SubItems.Add(reader("product").ToString())
                item.SubItems.Add(reader("type").ToString())
                Dim selllingprice As Decimal = reader("selling_price").ToString()
                If selllingprice > 999 Then
                    item.SubItems.Add("Php " & Format((selllingprice), "0,00.00"))
                ElseIf selllingprice < 1000 Then
                    item.SubItems.Add("Php " & Format((selllingprice), "0.00"))
                End If
                item.SubItems.Add(reader("quantity").ToString() & " " & reader("unit").ToString())
                Dim totalprice As Decimal = reader("total_price").ToString()
                If totalprice > 999 Then
                    item.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
                ElseIf totalprice < 1000 Then
                    item.SubItems.Add("Php " & Format((totalprice), "0.00"))
                End If
                initalgrandtotal1 += reader("total_price").ToString().Replace("Php ", "")
                lvisales.Items.Add(item)
            End While
            reader.Close()
        End If
        con.Close()

        Dim salesgrantotal As Decimal
        For Each sales As ListViewItem In lvisales.Items
            salesgrantotal += sales.SubItems(9).Text.Replace("Php ", "")
        Next
        If salesgrantotal > 999 Then
            txtgts.Text = "Php " & Format((salesgrantotal), "0,00.00")
        ElseIf salesgrantotal < 0 And salesgrantotal > 1000 Then
            txtgts.Text = "Php " & Format((salesgrantotal), "0.00")
        ElseIf salesgrantotal = 0 Then
            txtgts.Text = ""
        End If

    End Sub

    Private Sub cboview_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboview.SelectedIndexChanged

        If cboview.Text = "Expand" Then
            operationitemsalesexpanddipslay()
        ElseIf cboview.Text = "Collapse" Then
            operationitemsalescollapsedipslay()
        End If

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        txtsearchsales.Text = ""

    End Sub

    Private Sub txtsearchsales_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsearchsales.KeyDown

        If e.KeyCode = Keys.Back Then
            operationitemsalesexpanddipslay()
        End If

    End Sub


    Private Sub txtsearchsales_TextChanged(sender As Object, e As EventArgs) Handles txtsearchsales.TextChanged

        If txtsearchsales.Text <> "" Then
            'operationitemsalesexpanddipslay()
            If ComboBox1.Text = "Address" Then
                For Each sales As ListViewItem In lvisales.Items
                    If Not sales.SubItems(3).Text.ToLower.Contains(txtsearchsales.Text.ToLower) Then
                        sales.Remove()
                    End If
                Next
            ElseIf ComboBox1.Text = "Client" Then
                For Each sales As ListViewItem In lvisales.Items
                    If Not sales.SubItems(2).Text.ToLower.Contains(txtsearchsales.Text.ToLower) Then
                        sales.Remove()
                    End If
                Next
            ElseIf ComboBox1.Text = "Contact No." Then
                For Each sales As ListViewItem In lvisales.Items
                    If Not sales.SubItems(4).Text.ToLower.Contains(txtsearchsales.Text.ToLower) Then
                        sales.Remove()
                    End If
                Next
            ElseIf ComboBox1.Text = "Product Name" Then
                For Each sales As ListViewItem In lvisales.Items
                    If Not sales.SubItems(5).Text.ToLower.Contains(txtsearchsales.Text.ToLower) Then
                        sales.Remove()
                    End If
                Next
            ElseIf ComboBox1.Text = "Transaction No." Then
                For Each sales As ListViewItem In lvisales.Items
                    If Not sales.SubItems(0).Text.ToLower.Contains(txtsearchsales.Text.ToLower) Then
                        sales.Remove()
                    End If
                Next
            End If
        Else
            operationitemsalesexpanddipslay()
        End If

        Dim salesgrantotal As Decimal
        For Each sales As ListViewItem In lvisales.Items
            salesgrantotal += sales.SubItems(9).Text.Replace("Php ", "")
        Next
        If salesgrantotal > 999 Then
            txtgts.Text = "Php " & Format((salesgrantotal), "0,00.00")
        ElseIf salesgrantotal < 0 And salesgrantotal > 1000 Then
            txtgts.Text = "Php " & Format((salesgrantotal), "0.00")
        ElseIf salesgrantotal = 0 Then
            txtgts.Text = ""
        End If

    End Sub

    Private Sub txtrefreshsales_Click(sender As Object, e As EventArgs) Handles txtrefreshsales.Click

        lvisales.Columns.Clear()
        lvisales.Columns.Add("Transaction No.", 110, HorizontalAlignment.Left)
        lvisales.Columns.Add("Date Sold", 90, HorizontalAlignment.Left)
        lvisales.Columns.Add("Client", 145, HorizontalAlignment.Left)
        lvisales.Columns.Add("Address", 125, HorizontalAlignment.Left)
        lvisales.Columns.Add("Contact No.", 100, HorizontalAlignment.Left)
        lvisales.Columns.Add("Product Name", 125, HorizontalAlignment.Left)
        lvisales.Columns.Add("Type", 0, HorizontalAlignment.Left)
        lvisales.Columns.Add("Selling Price", 100, HorizontalAlignment.Left)
        lvisales.Columns.Add("Quantity", 70, HorizontalAlignment.Left)
        lvisales.Columns.Add("Total Price", 100, HorizontalAlignment.Left)
        cbofilter.Items.Clear()
        cbofilter.Text = ""
        operationitemsalesexpanddipslay()
        cbofilter.Items.Add("Operations")
        cbofilter.Items.Add("Transactions")
        txtsearchsales.Text = ""
        txtsearchsales.Focus()

    End Sub

    Private Sub lvisales_Click(sender As Object, e As EventArgs) Handles lvisales.Click

        txttrnno.Text = lvisales.SelectedItems.Item(0).SubItems(0).Text
        dtpdatesold.Text = lvisales.SelectedItems.Item(0).SubItems(1).Text
        txtsalesclient.Text = lvisales.SelectedItems.Item(0).SubItems(2).Text
        txtsalesaddress.Text = lvisales.SelectedItems.Item(0).SubItems(3).Text
        txtsalescontact.Text = lvisales.SelectedItems.Item(0).SubItems(4).Text
        If lvisales.SelectedItems.Item(0).SubItems(6).Text <> "" Then
            txtsalesproduct.Text = lvisales.SelectedItems.Item(0).SubItems(5).Text & " (" & lvisales.SelectedItems.Item(0).SubItems(6).Text & ")"
        Else
            txtsalesproduct.Text = lvisales.SelectedItems.Item(0).SubItems(5).Text
        End If
        txtsellingprice.Text = lvisales.SelectedItems.Item(0).SubItems(7).Text
        txtsalesquantity.Text = lvisales.SelectedItems.Item(0).SubItems(8).Text
        txtsalestotalprice.Text = lvisales.SelectedItems.Item(0).SubItems(9).Text

    End Sub

    Private Sub lvisales_DoubleClick(sender As Object, e As EventArgs) Handles lvisales.DoubleClick

        openconnection()

        If lvisales.SelectedItems.Item(0).SubItems(0).Text.Contains("OPR") Then
            loaduseditemsinoperationtosales = True
            loadsolditemsinoperationtosales = False
        ElseIf lvisales.SelectedItems.Item(0).SubItems(0).Text.Contains("TRN") Then
            loadsolditemsinoperationtosales = True
            loaduseditemsinoperationtosales = False
        End If
        selectedidinsales = lvisales.SelectedItems.Item(0).SubItems(0).Text

        con.Close()
        frmsolditem.ShowInTaskbar = False
        frmsolditem.ShowDialog()

    End Sub

    Private Sub btnitemstosell_Click(sender As Object, e As EventArgs) Handles btnitemstosell.Click
        frmsolditem.ShowInTaskbar = False
        frmsolditem.ShowDialog()
    End Sub

    Private Sub btnsell_Click(sender As Object, e As EventArgs) Handles btnsell.Click

        If btnsell.Text = "New" Then
            dtpdatesold.Value = Now
            dtpdatesold.Enabled = True
            txtsalesclient.ReadOnly = False
            txtsalesaddress.ReadOnly = False
            txtsalescontact.ReadOnly = False
            btnsell.Text = "Sell"
            btnitemstosell.Enabled = True
            btnsalescancel.Enabled = True
            lvisales.Enabled = False
            txtsalesclient.Text = ""
            txtsalesaddress.Text = ""
            txtsalescontact.Text = ""
            txtsalesproduct.Text = ""
            txtsellingprice.Text = ""
            txtsalesquantity.Text = ""
            txtsalestotalprice.Text = ""
            frmsolditem.lviitems.Items.Clear()
            frmsolditem.lvispecs.Items.Clear()
            frmsolditem.lvitotal.Items.Clear()
            lvitotal.Items.Clear()
            lvitotal.Visible = True
            btnitemstosell.Visible = True
            frmsolditem.txttotalprice.Text = ""
            newtransactioninsales = True
            btnedit.Enabled = False
            btndelete.Enabled = False
            loaduseditemsinoperationtosales = False
            loadsolditemsinoperationtosales = False
            transactionidgenerator()
            txttrnno.Text = finalizeid
        ElseIf btnsell.Text = "Sell" Then
            If lvitotal.Items.Count > 0 Then
                confirm = MessageBox.Show("Do want to sell the selected items?", "Selling Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If confirm = vbYes Then

                    openconnection()

                    cmd = New MySqlCommand("INSERT INTO `tbl_transactions`(`transaction_id`,`date_sold`,`client`,`address`,`contact_number`) VALUES ('" & txttrnno.Text & "','" & dtpdatesold.Text.Replace("'", "") & "','" & txtsalesclient.Text.Replace("'", "") & "','" & txtsalesaddress.Text.Replace("'", "") & "','" & txtsalescontact.Text.Replace("'", "") & "')", con)
                    cmd.ExecuteNonQuery()

                    For Each item As ListViewItem In frmsolditem.lviitems.Items
                        Dim specification = ""
                        openconnection()
                        cmd.CommandText = "Select specification from tbl_stocks where product_id = '" & item.SubItems(13).Text & "'"
                        reader = cmd.ExecuteReader
                        If reader.HasRows Then
                            While (reader.Read())
                                specification = reader("specification").ToString.Replace("\", "\\")
                            End While
                        End If
                        reader.Close()
                        con.Close()
                        productidgeneratorver3()
                        Dim unitprice As Decimal = item.SubItems(9).Text.Replace("Php ", "")
                        Dim sellingprice As Decimal = item.SubItems(10).Text.Replace("Php ", "")
                        Dim totalprice As Decimal = item.SubItems(12).Text.Replace("Php ", "")
                        If item.SubItems(4).Text <> "" Then
                            cmd = New MySqlCommand("INSERT INTO `tbl_transaction_item_sold`(`transaction_id`,`product_id`,`product`,`type`,`brand`,`supplier`,`serial`,`model`,`arrival_date`,`quantity`,`unit`,`unit_price`,`selling_price`,`quantity_unit`,`total_price`,`specification`,`status`) VALUES ('" & txttrnno.Text & "','" & productfinalizeid & "','" & item.SubItems(0).Text & "','" & item.SubItems(1).Text & "','" & item.SubItems(2).Text & "','" & item.SubItems(3).Text & "','" & item.SubItems(4).Text & "','" & item.SubItems(5).Text & "','" & item.SubItems(6).Text & "','" & item.SubItems(7).Text & "','" & item.SubItems(8).Text & "','" & unitprice & "','" & sellingprice & "','" & item.SubItems(11).Text & "','" & totalprice & "','" & specification & "','" & "sold" & "')", con)
                            cmd.ExecuteNonQuery()
                        Else
                            cmd = New MySqlCommand("INSERT INTO `tbl_transaction_item_sold`(`transaction_id`,`product_id`,`product`,`type`,`brand`,`supplier`,`model`,`arrival_date`,`quantity`,`unit`,`unit_price`,`selling_price`,`quantity_unit`,`total_price`,`specification`,`status`) VALUES ('" & txttrnno.Text & "','" & productfinalizeid & "','" & item.SubItems(0).Text & "','" & item.SubItems(1).Text & "','" & item.SubItems(2).Text & "','" & item.SubItems(3).Text & "','" & item.SubItems(5).Text & "','" & item.SubItems(6).Text & "','" & item.SubItems(7).Text & "','" & item.SubItems(8).Text & "','" & unitprice & "','" & sellingprice & "','" & item.SubItems(11).Text & "','" & totalprice & "','" & specification & "','" & "sold" & "')", con)
                            cmd.ExecuteNonQuery()
                        End If

                        Dim currentquantity As Integer
                        Dim currenttotalprice As Decimal
                        cmd.CommandText = "Select * from tbl_stocks where product_id = '" & item.SubItems(13).Text & "'"
                        reader = cmd.ExecuteReader
                        If reader.HasRows Then
                            While (reader.Read())
                                currentquantity = reader("quantity").ToString
                                currenttotalprice = reader("totalprice").ToString
                            End While
                        End If
                        reader.Close()
                        Dim newquantityinstocks As Integer = currentquantity - item.SubItems(7).Text
                        Dim oldtotalprice As Decimal = item.SubItems(7).Text * item.SubItems(9).Text.Replace("Php ", "")
                        Dim newtotalprice As Decimal = currenttotalprice - oldtotalprice
                        If newquantityinstocks > 0 Then
                            'MsgBox("1. newquantityinstocks: " & newquantityinstocks)
                            cmd = New MySqlCommand("UPDATE `tbl_stocks` SET `quantity`= '" & newquantityinstocks & "' ,`quantity_unit`= '" & newquantityinstocks & " " & item.SubItems(8).Text & "' , `totalprice`= '" & newtotalprice & "' where product_id='" & item.SubItems(13).Text & "'", con)
                            cmd.ExecuteNonQuery()
                        ElseIf newquantityinstocks = 0 Then
                            'MsgBox("2. newquantityinstocks: " & newquantityinstocks)
                            cmddelete = "DELETE FROM `tbl_stocks` where product_id='" & item.SubItems(13).Text & "'"
                            sqlda = New MySqlDataAdapter(cmddelete, con)
                            ds = New DataSet()
                            sqlda.Fill(ds)
                        End If
                        item.Remove()
                    Next

                    For Each totalitem As ListViewItem In frmsolditem.lvitotal.Items
                        cmd = New MySqlCommand("INSERT INTO `tbl_transaction_item_total`(`transaction_id`,`qty`,`quantity`,`items`) VALUES ('" & txttrnno.Text & "','" & totalitem.SubItems(0).Text & "','" & totalitem.SubItems(1).Text & "','" & totalitem.SubItems(2).Text & "')", con)
                        cmd.ExecuteNonQuery()
                        reader.Close()
                        totalitem.Remove()
                    Next

                    con.Close()

                    dtpdatesold.Value = Now
                    dtpdatesold.Enabled = False
                    txtsalesclient.ReadOnly = True
                    txtsalesaddress.ReadOnly = True
                    txtsalescontact.ReadOnly = True
                    btnsell.Text = "New"
                    btnitemstosell.Enabled = False
                    btnsalescancel.Enabled = False
                    lvisales.Enabled = True
                    txtsalesclient.Text = ""
                    txtsalesaddress.Text = ""
                    txtsalescontact.Text = ""
                    txtsalesproduct.Text = ""
                    txtsellingprice.Text = ""
                    txtsalesquantity.Text = ""
                    txtsalestotalprice.Text = ""
                    frmsolditem.lviitems.Items.Clear()
                    frmsolditem.lvispecs.Items.Clear()
                    frmsolditem.lvitotal.Items.Clear()
                    lvitotal.Items.Clear()
                    lvitotal.Visible = False
                    btnitemstosell.Visible = False
                    btnedit.Enabled = True
                    btndelete.Enabled = True
                    displaystocks()
                    operationitemsalesexpanddipslay()

                    MessageBox.Show("Items successfully sold.", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            ElseIf lvitotal.Items.Count = 0 Then
                MessageBox.Show("Please select an item to sell.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub

    Private Sub transactionidgenerator()

        openconnection()
        Dim idinitial As String = "TRN"
        Dim counter As Integer = 1
        Dim idnumber As String = "00"
        finalizeid = idinitial & idnumber & counter.ToString
        Dim isidexists As Boolean = True

        reader.Close()
        cmd.CommandText = "select transaction_id from tbl_transaction_item_sold where transaction_id = '" & finalizeid & "'"
        reader = cmd.ExecuteReader
        If reader.HasRows = False Then
            reader.Close()
            'cmd = New MySqlCommand("INSERT INTO `id`(`id`) VALUES ('" & finalizeid & "')", con)
            'cmd.ExecuteNonQuery()
            finalizeid = idinitial & idnumber & counter.ToString
        Else
            Do Until isidexists = False
                reader.Close()
                counter += 1
                If counter > 9 And counter < 100 Then
                    idnumber = "0"
                ElseIf counter > 99 Then
                    idnumber = ""
                End If
                finalizeid = idinitial & idnumber & counter.ToString
                cmd.CommandText = "select transaction_id from tbl_transaction_item_sold where transaction_id = '" & finalizeid & "'"
                reader = cmd.ExecuteReader
                If reader.HasRows = True Then
                    isidexists = True
                Else
                    isidexists = False
                End If
            Loop
            reader.Close()
            'cmd = New MySqlCommand("INSERT INTO `id`(`id`) VALUES ('" & finalizeid & "')", con)
            'cmd.ExecuteNonQuery()
        End If
    End Sub

    Private Sub btnitems_Click(sender As Object, e As EventArgs)
        frmsolditem.ShowInTaskbar = False
        frmsolditem.ShowDialog()
    End Sub

    Private Sub btnedit_Click(sender As Object, e As EventArgs) Handles btnedit.Click

        If txttrnno.Text <> "" Then
            openconnection()
            If btnedit.Text = "Edit" Then
                btnedit.Text = "Save"
                btnsalescancel.Enabled = True
                dtpdatesold.Enabled = True
                txtsalesclient.ReadOnly = False
                txtsalesaddress.ReadOnly = False
                txtsalescontact.ReadOnly = False
            ElseIf btnedit.Text = "Save" Then
                btnedit.Text = "Edit"
                dtpdatesold.Enabled = False
                txtsalesclient.ReadOnly = True
                txtsalesaddress.ReadOnly = True
                txtsalescontact.ReadOnly = True
                If txttrnno.Text.Contains("OPR") Then
                    cmd = New MySqlCommand("UPDATE `tbl_operations` SET `date_started`= '" & dtpdatesold.Text & "' , `client`= '" & txtsalesclient.Text & "' , `location`= '" & txtsalesaddress.Text & "' , `contact`= '" & txtsalescontact.Text & "' where operation_id ='" & txttrnno.Text & "'", con)
                    cmd.ExecuteNonQuery()
                ElseIf txttrnno.Text.Contains("TRN") Then
                    cmd = New MySqlCommand("UPDATE `tbl_transactions` SET `date_sold`= '" & dtpdatesold.Text & "' , `client`= '" & txtsalesclient.Text & "' , `address`= '" & txtsalesaddress.Text & "' , `contact_number`= '" & txtsalescontact.Text & "' where transaction_id ='" & txttrnno.Text & "'", con)
                    cmd.ExecuteNonQuery()
                End If
                MessageBox.Show("Changes successfully saved!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            con.Close()
            operationitemsalesexpanddipslay()
        End If

    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click

        If txttrnno.Text <> "" Then
            If txttrnno.Text.Contains("OPR") Then
                confirm = MessageBox.Show("Are you sure you want to delete the operation " & txttrnno.Text & "?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If confirm = vbYes Then
                    removeorrestockallitemusedinoperationforsales()
                    cmddelete = "DELETE FROM `tbl_operations` where operation_id='" & txttrnno.Text & "'"
                    sqlda = New MySqlDataAdapter(cmddelete, con)
                    ds = New DataSet()
                    sqlda.Fill(ds)

                    cmddelete = "DELETE FROM `tbl_operation_item_used` where operation_id='" & txttrnno.Text & "'"
                    sqlda = New MySqlDataAdapter(cmddelete, con)
                    ds = New DataSet()
                    sqlda.Fill(ds)

                    cmddelete = "DELETE FROM `tbl_operation_assigned_personel` where operation_id='" & txttrnno.Text & "'"
                    sqlda = New MySqlDataAdapter(cmddelete, con)
                    ds = New DataSet()
                    sqlda.Fill(ds)

                    cmddelete = "DELETE FROM `tbl_operation_item_total` where operation_id='" & txttrnno.Text & "'"
                    sqlda = New MySqlDataAdapter(cmddelete, con)
                    ds = New DataSet()
                    sqlda.Fill(ds)

                    MessageBox.Show("Operation successfully deleted!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Exit Sub
                End If
            ElseIf txttrnno.Text.Contains("TRN") Then
                confirm = MessageBox.Show("Are you sure you want to delete the transaction " & txttrnno.Text & "?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If confirm = vbYes Then
                    removeorrestockallitemusedinoperationforsales()
                    cmddelete = "DELETE FROM `tbl_transactions` where transaction_id='" & txttrnno.Text & "'"
                    sqlda = New MySqlDataAdapter(cmddelete, con)
                    ds = New DataSet()
                    sqlda.Fill(ds)

                    cmddelete = "DELETE FROM `tbl_transaction_item_sold` where transaction_id='" & txttrnno.Text & "'"
                    sqlda = New MySqlDataAdapter(cmddelete, con)
                    ds = New DataSet()
                    sqlda.Fill(ds)

                    cmddelete = "DELETE FROM `tbl_transaction_item_total` where transaction_id='" & txttrnno.Text & "'"
                    sqlda = New MySqlDataAdapter(cmddelete, con)
                    ds = New DataSet()
                    sqlda.Fill(ds)

                    MessageBox.Show("Transaction successfully deleted!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Exit Sub
                End If
            End If
            txttrnno.Text = ""
            dtpdatesold.Value = Now
            dtpdatesold.Enabled = False
            txtsalesclient.Text = ""
            txtsalesclient.ReadOnly = True
            txtsalesaddress.Text = ""
            txtsalesaddress.ReadOnly = True
            txtsalescontact.Text = ""
            txtsalescontact.ReadOnly = True
            txtsalesproduct.Text = ""
            txtsellingprice.Text = ""
            txtsalesquantity.Text = ""
            txtsalestotalprice.Text = ""
            displayoperation()
            operationitemsalesexpanddipslay()
        End If

    End Sub

    Private Sub removeorrestockallitemusedinoperationforsales()

        If txttrnno.Text.Contains("OPR") Then

            openconnection()
            cmd.CommandText = "Select * from tbl_operation_item_used where operation_id = '" & txttrnno.Text & "'"
            reader = cmd.ExecuteReader
            If reader.HasRows Then
                confirm = MessageBox.Show("Do you want to restock the item(s) used during this operation?", "Stop Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If confirm = vbYes Then
                    reader.Close()
                    cmd = New MySqlCommand("select * from tbl_operation_item_used where operation_id = '" & txttrnno.Text & "'", con)
                    reader = cmd.ExecuteReader
                    While (reader.Read())
                        Dim item As New ListViewItem(reader("product").ToString)
                        item.SubItems.Add(reader("type").ToString)
                        item.SubItems.Add(reader("brand").ToString)
                        item.SubItems.Add(reader("supplier").ToString)
                        item.SubItems.Add(reader("serial").ToString)
                        item.SubItems.Add(reader("model").ToString)
                        item.SubItems.Add(reader("arrival_date").ToString)
                        item.SubItems.Add(reader("quantity").ToString)
                        item.SubItems.Add(reader("unit").ToString)
                        item.SubItems.Add(reader("unit_price").ToString)
                        item.SubItems.Add(reader("quantity_unit").ToString)
                        Dim totalprice As Decimal = reader("quantity").ToString * reader("unit_price").ToString
                        item.SubItems.Add(totalprice)
                        item.SubItems.Add(reader("specification").ToString)
                        item.SubItems.Add(reader("status").ToString)
                        lviremoveorrestock.Items.Add(item)
                    End While
                    reader.Close()
                End If

                For Each item As ListViewItem In lviremoveorrestock.Items

                    If item.SubItems(4).Text <> "" Then
                        cmd.CommandText = "Select * from tbl_stocks where product = '" & item.SubItems(0).Text & "' and type = '" & item.SubItems(1).Text & "' and brand = '" & item.SubItems(2).Text & "' and supplier = '" & item.SubItems(3).Text & "' and serial = '" & item.SubItems(4).Text & "' and model = '" & item.SubItems(5).Text & "' and arrival_date = '" & item.SubItems(6).Text & "' and unit = '" & item.SubItems(8).Text & "' and unit_price = '" & item.SubItems(9).Text & "' and specification = '" & item.SubItems(12).Text.Replace("\", "\\") & "'"
                    Else
                        cmd.CommandText = "Select * from tbl_stocks where product = '" & item.SubItems(0).Text & "' and type = '" & item.SubItems(1).Text & "' and brand = '" & item.SubItems(2).Text & "' and supplier = '" & item.SubItems(3).Text & "' and model = '" & item.SubItems(5).Text & "' and arrival_date = '" & item.SubItems(6).Text & "' and unit = '" & item.SubItems(8).Text & "' and unit_price = '" & item.SubItems(9).Text & "' and specification = '" & item.SubItems(12).Text.Replace("\", "\\") & "'"
                    End If
                    reader = cmd.ExecuteReader
                    If reader.HasRows Then
                        'MsgBox("Match found!")
                        reader.Read()
                        Dim iteminstockid As String = reader("product_id").ToString
                        Dim iteminstockquantity As Integer = reader("quantity").ToString
                        Dim iteminstockunit As String = reader("unit").ToString
                        Dim iteminstocktotalprice As Decimal = reader("totalprice").ToString
                        reader.Close()
                        Dim newtotalprice As Decimal = iteminstocktotalprice + item.SubItems(11).Text
                        cmd = New MySqlCommand("UPDATE `tbl_stocks` SET `quantity`= '" & iteminstockquantity + item.SubItems(7).Text & "' ,`quantity_unit`= '" & iteminstockquantity + item.SubItems(7).Text & " " & item.SubItems(8).Text & "' , `totalprice`= '" & newtotalprice & "' where product_id='" & iteminstockid & "'", con)
                        cmd.ExecuteNonQuery()
                    Else
                        'MsgBox("No match found!")
                        productidgenerator0()
                        If item.SubItems(4).Text <> "" Then
                            cmd = New MySqlCommand("INSERT INTO `tbl_stocks`(`product_id`,`product`,`type`,`brand`,`supplier`,`serial`,`model`,`arrival_date`,`quantity`,`unit`,`unit_price`,`quantity_unit`,`totalprice`,`specification`,`status`) VALUES ('" & productfinalizeid & "','" & item.SubItems(0).Text & "','" & item.SubItems(1).Text & "','" & item.SubItems(2).Text & "','" & item.SubItems(3).Text & "','" & item.SubItems(4).Text & "','" & item.SubItems(5).Text & "','" & item.SubItems(6).Text & "','" & item.SubItems(7).Text & "','" & item.SubItems(8).Text & "','" & item.SubItems(9).Text & "','" & item.SubItems(10).Text & "','" & item.SubItems(11).Text & "','" & item.SubItems(12).Text.Replace("\", "\\") & "','" & "available" & "')", con)
                            cmd.ExecuteNonQuery()
                        Else
                            cmd = New MySqlCommand("INSERT INTO `tbl_stocks`(`product_id`,`product`,`type`,`brand`,`supplier`,`model`,`arrival_date`,`quantity`,`unit`,`unit_price`,`quantity_unit`,`totalprice`,`specification`,`status`) VALUES ('" & productfinalizeid & "','" & item.SubItems(0).Text & "','" & item.SubItems(1).Text & "','" & item.SubItems(2).Text & "','" & item.SubItems(3).Text & "','" & item.SubItems(5).Text & "','" & item.SubItems(6).Text & "','" & item.SubItems(7).Text & "','" & item.SubItems(8).Text & "','" & item.SubItems(9).Text & "','" & item.SubItems(10).Text & "','" & item.SubItems(11).Text & "','" & item.SubItems(12).Text.Replace("\", "\\") & "','" & "available" & "')", con)
                            cmd.ExecuteNonQuery()
                        End If
                    End If
                    item.Remove()
                Next
            End If
            reader.Close()

        ElseIf txttrnno.Text.Contains("TRN") Then

            openconnection()
            cmd.CommandText = "Select * from tbl_transaction_item_sold where transaction_id = '" & txttrnno.Text & "'"
            reader = cmd.ExecuteReader
            If reader.HasRows Then
                confirm = MessageBox.Show("Do you want to restock the item(s) used on this transaction?", "Stop Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If confirm = vbYes Then
                    reader.Close()
                    cmd = New MySqlCommand("select * from tbl_transaction_item_sold where transaction_id = '" & txttrnno.Text & "'", con)
                    reader = cmd.ExecuteReader
                    While (reader.Read())
                        Dim item As New ListViewItem(reader("product").ToString)
                        item.SubItems.Add(reader("type").ToString)
                        item.SubItems.Add(reader("brand").ToString)
                        item.SubItems.Add(reader("supplier").ToString)
                        item.SubItems.Add(reader("serial").ToString)
                        item.SubItems.Add(reader("model").ToString)
                        item.SubItems.Add(reader("arrival_date").ToString)
                        item.SubItems.Add(reader("quantity").ToString)
                        item.SubItems.Add(reader("unit").ToString)
                        item.SubItems.Add(reader("unit_price").ToString)
                        item.SubItems.Add(reader("quantity_unit").ToString)
                        Dim totalprice As Decimal = reader("quantity").ToString * reader("unit_price").ToString
                        item.SubItems.Add(totalprice)
                        item.SubItems.Add(reader("specification").ToString)
                        item.SubItems.Add(reader("status").ToString)
                        lviremoveorrestock.Items.Add(item)
                    End While
                    reader.Close()
                End If

                For Each item As ListViewItem In lviremoveorrestock.Items

                    If item.SubItems(4).Text <> "" Then
                        cmd.CommandText = "Select * from tbl_stocks where product = '" & item.SubItems(0).Text & "' and type = '" & item.SubItems(1).Text & "' and brand = '" & item.SubItems(2).Text & "' and supplier = '" & item.SubItems(3).Text & "' and serial = '" & item.SubItems(4).Text & "' and model = '" & item.SubItems(5).Text & "' and arrival_date = '" & item.SubItems(6).Text & "' and unit = '" & item.SubItems(8).Text & "' and unit_price = '" & item.SubItems(9).Text & "' and specification = '" & item.SubItems(12).Text.Replace("\", "\\") & "'"
                    Else
                        cmd.CommandText = "Select * from tbl_stocks where product = '" & item.SubItems(0).Text & "' and type = '" & item.SubItems(1).Text & "' and brand = '" & item.SubItems(2).Text & "' and supplier = '" & item.SubItems(3).Text & "' and model = '" & item.SubItems(5).Text & "' and arrival_date = '" & item.SubItems(6).Text & "' and unit = '" & item.SubItems(8).Text & "' and unit_price = '" & item.SubItems(9).Text & "' and specification = '" & item.SubItems(12).Text.Replace("\", "\\") & "'"
                    End If
                    reader = cmd.ExecuteReader
                    If reader.HasRows Then
                        'MsgBox("Match found!")
                        reader.Read()
                        Dim iteminstockid As String = reader("product_id").ToString
                        Dim iteminstockquantity As Integer = reader("quantity").ToString
                        Dim iteminstockunit As String = reader("unit").ToString
                        Dim iteminstocktotalprice As Decimal = reader("totalprice").ToString
                        reader.Close()
                        Dim newtotalprice As Decimal = iteminstocktotalprice + item.SubItems(11).Text
                        cmd = New MySqlCommand("UPDATE `tbl_stocks` SET `quantity`= '" & iteminstockquantity + item.SubItems(7).Text & "' ,`quantity_unit`= '" & iteminstockquantity + item.SubItems(7).Text & " " & item.SubItems(8).Text & "' , `totalprice`= '" & newtotalprice & "' where product_id='" & iteminstockid & "'", con)
                        cmd.ExecuteNonQuery()
                    Else
                        'MsgBox("No match found!")
                        productidgenerator0()
                        If item.SubItems(4).Text <> "" Then
                            cmd = New MySqlCommand("INSERT INTO `tbl_stocks`(`product_id`,`product`,`type`,`brand`,`supplier`,`serial`,`model`,`arrival_date`,`quantity`,`unit`,`unit_price`,`quantity_unit`,`totalprice`,`specification`,`status`) VALUES ('" & productfinalizeid & "','" & item.SubItems(0).Text & "','" & item.SubItems(1).Text & "','" & item.SubItems(2).Text & "','" & item.SubItems(3).Text & "','" & item.SubItems(4).Text & "','" & item.SubItems(5).Text & "','" & item.SubItems(6).Text & "','" & item.SubItems(7).Text & "','" & item.SubItems(8).Text & "','" & item.SubItems(9).Text & "','" & item.SubItems(10).Text & "','" & item.SubItems(11).Text & "','" & item.SubItems(12).Text.Replace("\", "\\") & "','" & "available" & "')", con)
                            cmd.ExecuteNonQuery()
                        Else
                            cmd = New MySqlCommand("INSERT INTO `tbl_stocks`(`product_id`,`product`,`type`,`brand`,`supplier`,`model`,`arrival_date`,`quantity`,`unit`,`unit_price`,`quantity_unit`,`totalprice`,`specification`,`status`) VALUES ('" & productfinalizeid & "','" & item.SubItems(0).Text & "','" & item.SubItems(1).Text & "','" & item.SubItems(2).Text & "','" & item.SubItems(3).Text & "','" & item.SubItems(5).Text & "','" & item.SubItems(6).Text & "','" & item.SubItems(7).Text & "','" & item.SubItems(8).Text & "','" & item.SubItems(9).Text & "','" & item.SubItems(10).Text & "','" & item.SubItems(11).Text & "','" & item.SubItems(12).Text.Replace("\", "\\") & "','" & "available" & "')", con)
                            cmd.ExecuteNonQuery()
                        End If
                    End If
                    item.Remove()
                Next
            End If
            reader.Close()

        End If
        displaystocks()

    End Sub

    Private Sub btnsalescancel_Click(sender As Object, e As EventArgs) Handles btnsalescancel.Click

        dtpdatesold.Enabled = False
        txtsalesclient.ReadOnly = True
        txtsalesaddress.ReadOnly = True
        txtsalescontact.ReadOnly = True
        btnsell.Text = "New"
        btnedit.Text = "Edit"
        btnitemstosell.Enabled = False
        btnsalescancel.Enabled = False
        lvisales.Enabled = True
        txttrnno.Text = ""
        txtsalesclient.Text = ""
        txtsalesaddress.Text = ""
        txtsalescontact.Text = ""
        txtsalesproduct.Text = ""
        txtsellingprice.Text = ""
        txtsalesquantity.Text = ""
        txtsalestotalprice.Text = ""
        newtransactioninsales = False
        lvitotal.Visible = False
        lvitotal.Items.Clear()
        btnitemstosell.Visible = False
        btnedit.Enabled = True
        btndelete.Enabled = True
        btnsalescancel.Enabled = False
        txtsearchsales.Focus()

    End Sub

    Private Sub lvisales_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvisales.SelectedIndexChanged

    End Sub

End Class