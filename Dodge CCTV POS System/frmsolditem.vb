Imports MySql.Data.MySqlClient

Public Class frmsolditem

    Dim specification As String
    Dim finalizeid As String
    Dim col0 As String
    Dim col1 = "", col2 = "", col3 = "", col4 = "", col5 = "", col6 = "", col7 = "", col8 = "", col9 = "", col10 = "", col11 = "", col12 = "", col13 = "", col14 As String = ""
    Dim isselecteditemequaltoone As Boolean
    Dim quantitytoremove As Integer

    Private Sub frmsolditem_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lviitems.Columns.Clear()
        lviitems.Columns.Add("Product Name", 145, HorizontalAlignment.Left)
        lviitems.Columns.Add("Type", 125, HorizontalAlignment.Left)
        lviitems.Columns.Add("Brand", 105, HorizontalAlignment.Left)
        lviitems.Columns.Add("Supplier", 105, HorizontalAlignment.Left)
        lviitems.Columns.Add("Serial", 155, HorizontalAlignment.Left)
        lviitems.Columns.Add("Model", 230, HorizontalAlignment.Left)
        lviitems.Columns.Add("Arrival Date", 82, HorizontalAlignment.Left)
        lviitems.Columns.Add("Qty", 0, HorizontalAlignment.Left)
        lviitems.Columns.Add("Unit", 0, HorizontalAlignment.Left)
        lviitems.Columns.Add("Unit Price", 95, HorizontalAlignment.Left)
        lviitems.Columns.Add("Selling Price", 95, HorizontalAlignment.Left)
        lviitems.Columns.Add("Quantity", 63, HorizontalAlignment.Left)
        lviitems.Columns.Add("Total Price", 95, HorizontalAlignment.Left)
        lviitems.Columns.Add("Product ID", 0, HorizontalAlignment.Left)
        lviitems.Columns.Add("status", 0, HorizontalAlignment.Left)

        lviremove.Columns.Clear()
        lviremove.Columns.Add("Product Name", 145, HorizontalAlignment.Left)
        lviremove.Columns.Add("Type", 125, HorizontalAlignment.Left)
        lviremove.Columns.Add("Brand", 105, HorizontalAlignment.Left)
        lviremove.Columns.Add("Supplier", 105, HorizontalAlignment.Left)
        lviremove.Columns.Add("Serial", 155, HorizontalAlignment.Left)
        lviremove.Columns.Add("Model", 230, HorizontalAlignment.Left)
        lviremove.Columns.Add("Arrival Date", 82, HorizontalAlignment.Left)
        lviremove.Columns.Add("Qty", 0, HorizontalAlignment.Left)
        lviremove.Columns.Add("Unit", 0, HorizontalAlignment.Left)
        lviremove.Columns.Add("Unit Price", 95, HorizontalAlignment.Left)
        lviremove.Columns.Add("Selling Price", 95, HorizontalAlignment.Left)
        lviremove.Columns.Add("Quantity", 63, HorizontalAlignment.Left)
        lviremove.Columns.Add("Total Price", 95, HorizontalAlignment.Left)
        lviremove.Columns.Add("Product ID", 0, HorizontalAlignment.Left)
        lviremove.Columns.Add("status", 0, HorizontalAlignment.Left)

        lvirestock.Columns.Clear()
        lvirestock.Columns.Add("Product Name", 145, HorizontalAlignment.Left)
        lvirestock.Columns.Add("Type", 125, HorizontalAlignment.Left)
        lvirestock.Columns.Add("Brand", 105, HorizontalAlignment.Left)
        lvirestock.Columns.Add("Supplier", 105, HorizontalAlignment.Left)
        lvirestock.Columns.Add("Serial", 155, HorizontalAlignment.Left)
        lvirestock.Columns.Add("Model", 230, HorizontalAlignment.Left)
        lvirestock.Columns.Add("Arrival Date", 82, HorizontalAlignment.Left)
        lvirestock.Columns.Add("Qty", 0, HorizontalAlignment.Left)
        lvirestock.Columns.Add("Unit", 0, HorizontalAlignment.Left)
        lvirestock.Columns.Add("Unit Price", 95, HorizontalAlignment.Left)
        lvirestock.Columns.Add("Selling Price", 95, HorizontalAlignment.Left)
        lvirestock.Columns.Add("Quantity", 63, HorizontalAlignment.Left)
        lvirestock.Columns.Add("Total Price", 95, HorizontalAlignment.Left)
        lvirestock.Columns.Add("Product ID", 0, HorizontalAlignment.Left)
        lvirestock.Columns.Add("status", 0, HorizontalAlignment.Left)

        lvispecs.Columns.Clear()
        lvispecs.Columns.Add("Specification", 370, HorizontalAlignment.Left)

        lvitotal.Columns.Clear()
        lvitotal.Columns.Add("Qty", 0, HorizontalAlignment.Left)
        lvitotal.Columns.Add("Qty.", 70, HorizontalAlignment.Left)
        lvitotal.Columns.Add("Items", 300, HorizontalAlignment.Left)
        'MsgBox("loaduseditemsinoperationtosales: " & loaduseditemsinoperationtosales)
        If loaduseditemsinoperationtosales = True Then
            Label2.Text = "Operation No."
            txtoprno.Text = selectedidinsales
            loadinstalleditemsinsales()
            load_operation_item_total()
            btnok.Text = "Edit"
            btncancel.Text = "Close"
            Label2.Text = "Operation No."
            btnselectfromstocks.Enabled = False
            btnremove.Enabled = False
            btnrestock.Enabled = False
            btnok.Enabled = True
        End If
        'MsgBox("loadsolditemsinoperation: " & loadsolditemsinoperationtosales)
        If loadsolditemsinoperationtosales = True Then
            Label2.Text = "Transaction No."
            txtoprno.Text = selectedidinsales
            loadsolditemsinsales()
            load_transaction_item_total()
            btnok.Text = "Edit"
            btncancel.Text = "Close"
            Label2.Text = "Operation No."
            btnselectfromstocks.Enabled = False
            btnremove.Enabled = False
            btnrestock.Enabled = False
            btnok.Enabled = True
        End If
        'MsgBox("newtransactioninsales: " & newtransactioninsales)
        If newtransactioninsales = True Then
            lviitems.Items.Clear()
            lvispecs.Items.Clear()
            lvitotal.Items.Clear()
            txttotalprice.Text = ""
            btnselectfromstocks.Enabled = True
            btnremove.Enabled = True
            btnrestock.Enabled = True
            nupitemqty.Enabled = True
            btnok.Text = "Ok"
            Label2.Text = "Transaction No."
            txtoprno.Text = frmmain.txttrnno.Text
        End If

    End Sub

    Public Sub loadinstalleditemsinsales()

        openconnection()
        Dim grandtotal As Decimal
        lviitems.Items.Clear()
        cmd = New MySqlCommand("select * from tbl_operation_item_used where operation_id = '" & selectedidinsales & "'", con)
        reader = cmd.ExecuteReader
        While (reader.Read())
            Dim item As New ListViewItem(reader("product").ToString())
            item.SubItems.Add(reader("type").ToString())
            item.SubItems.Add(reader("brand").ToString())
            item.SubItems.Add(reader("supplier").ToString())
            item.SubItems.Add(reader("serial").ToString())
            item.SubItems.Add(reader("model").ToString())
            item.SubItems.Add(reader("arrival_date").ToString())
            item.SubItems.Add(reader("quantity").ToString())
            item.SubItems.Add(reader("unit").ToString())
            Dim unitprice As Decimal = reader("unit_price").ToString()
            If unitprice > 999 Then
                item.SubItems.Add("Php " & Format((unitprice), "0,00.00"))
            ElseIf unitprice < 1000 Then
                item.SubItems.Add("Php " & Format((unitprice), "0.00"))
            End If
            Dim sellingprice As Decimal = reader("selling_price").ToString()
            If sellingprice > 999 Then
                item.SubItems.Add("Php " & Format((sellingprice), "0,00.00"))
            ElseIf sellingprice < 1000 Then
                item.SubItems.Add("Php " & Format((sellingprice), "0.00"))
            End If
            item.SubItems.Add(reader("quantity_unit").ToString())
            Dim totalprice As Decimal = reader("total_price").ToString()
            If totalprice > 999 Then
                item.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
            ElseIf totalprice < 1000 Then
                item.SubItems.Add("Php " & Format((totalprice), "0.00"))
            End If
            grandtotal += reader("total_price").ToString().Replace("Php ", "")
            item.SubItems.Add(reader("product_id").ToString())
            item.SubItems.Add(reader("status").ToString())
            lviitems.Items.Add(item)
        End While
        If grandtotal > 999 Then
            txttotalprice.Text = "Php " & Format((grandtotal), "0,00.00")
        ElseIf grandtotal > 0 And grandtotal < 1000 Then
            txttotalprice.Text = "Php " & Format((grandtotal), "0.00")
        ElseIf grandtotal = 0 Then
            txttotalprice.Text = ""
        End If
        reader.Close()
        con.Close()

    End Sub

    Public Sub loadsolditemsinsales()

        openconnection()
        Dim grandtotal As Decimal
        lviitems.Items.Clear()
        cmd = New MySqlCommand("select * from tbl_transaction_item_sold where transaction_id = '" & selectedidinsales & "'", con)
        reader = cmd.ExecuteReader
        While (reader.Read())
            Dim item As New ListViewItem(reader("product").ToString())
            item.SubItems.Add(reader("type").ToString())
            item.SubItems.Add(reader("brand").ToString())
            item.SubItems.Add(reader("supplier").ToString())
            item.SubItems.Add(reader("serial").ToString())
            item.SubItems.Add(reader("model").ToString())
            item.SubItems.Add(reader("arrival_date").ToString())
            item.SubItems.Add(reader("quantity").ToString())
            item.SubItems.Add(reader("unit").ToString())
            Dim unitprice As Decimal = reader("unit_price").ToString()
            If unitprice > 999 Then
                item.SubItems.Add("Php " & Format((unitprice), "0,00.00"))
            ElseIf unitprice < 1000 Then
                item.SubItems.Add("Php " & Format((unitprice), "0.00"))
            End If
            Dim sellingprice As Decimal = reader("selling_price").ToString()
            If sellingprice > 999 Then
                item.SubItems.Add("Php " & Format((sellingprice), "0,00.00"))
            ElseIf sellingprice < 1000 Then
                item.SubItems.Add("Php " & Format((sellingprice), "0.00"))
            End If
            item.SubItems.Add(reader("quantity_unit").ToString())
            Dim totalprice As Decimal = reader("total_price").ToString()
            If totalprice > 999 Then
                item.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
            ElseIf totalprice < 1000 Then
                item.SubItems.Add("Php " & Format((totalprice), "0.00"))
            End If
            grandtotal += reader("total_price").ToString().Replace("Php ", "")
            item.SubItems.Add(reader("product_id").ToString())
            item.SubItems.Add(reader("status").ToString())
            lviitems.Items.Add(item)
        End While
        If grandtotal > 999 Then
            txttotalprice.Text = "Php " & Format((grandtotal), "0,00.00")
        ElseIf grandtotal > 0 And grandtotal < 1000 Then
            txttotalprice.Text = "Php " & Format((grandtotal), "0.00")
        ElseIf grandtotal = 0 Then
            txttotalprice.Text = ""
        End If
        reader.Close()
        con.Close()

    End Sub

    Private Sub load_operation_item_total()

        openconnection()
        lvitotal.Items.Clear()
        cmd = New MySqlCommand("select * from tbl_operation_item_total where operation_id = '" & selectedidinsales & "'", con)
        reader = cmd.ExecuteReader
        While (reader.Read())
            Dim itemtotal As New ListViewItem(reader("qty").ToString())
            itemtotal.SubItems.Add(reader("quantity").ToString())
            itemtotal.SubItems.Add(reader("items").ToString())
            lvitotal.Items.Add(itemtotal)
        End While
        reader.Close()
        con.Close()

    End Sub

    Private Sub load_transaction_item_total()

        openconnection()
        lvitotal.Items.Clear()
        cmd = New MySqlCommand("select * from tbl_transaction_item_total where transaction_id = '" & selectedidinsales & "'", con)
        reader = cmd.ExecuteReader
        While (reader.Read())
            Dim itemtotal As New ListViewItem(reader("qty").ToString())
            itemtotal.SubItems.Add(reader("quantity").ToString())
            itemtotal.SubItems.Add(reader("items").ToString())
            lvitotal.Items.Add(itemtotal)
        End While
        reader.Close()
        con.Close()

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
                cmd.CommandText = "select transaction_id from tbl_transaction_item_sold where operation_id = '" & finalizeid & "'"
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

    Private Sub lviitems_Click(sender As Object, e As EventArgs) Handles lviitems.Click

        openconnection()
        lvispecs.Items.Clear()
        Dim specslen As Integer = 0
        Dim trimmedtextlen As Integer = 0
        Dim trimmedtext As String = ""
        Dim specs As String = ""
        If lviitems.SelectedItems.Item(0).SubItems(14).Text = "available" Then
            cmd = New MySqlCommand("select specification from tbl_stocks where product_id = '" & lviitems.SelectedItems.Item(0).SubItems(13).Text & "'", con)
        ElseIf lviitems.SelectedItems.Item(0).SubItems(14).Text = "installed" Then
            cmd = New MySqlCommand("select specification from tbl_operation_item_used where product_id = '" & lviitems.SelectedItems.Item(0).SubItems(13).Text & "'", con)
        ElseIf lviitems.SelectedItems.Item(0).SubItems(14).Text = "sold" Then
            cmd = New MySqlCommand("select specification from tbl_transaction_item_sold where product_id = '" & lviitems.SelectedItems.Item(0).SubItems(13).Text & "'", con)
        End If
        reader = cmd.ExecuteReader
        While (reader.Read())
            specs = reader("specification").ToString
        End While
        reader.Close()
        con.Close()
        If specs <> "" Then
            specslen = Microsoft.VisualBasic.Len(specs)
            Do Until specslen < 1
                Dim spliter As String() = specs.Split("\")
                trimmedtext = spliter.Last.Trim
                Dim lvi As New ListViewItem("- " & trimmedtext)
                lvispecs.Items.Add(lvi)
                trimmedtextlen = Microsoft.VisualBasic.Len(trimmedtext)
                'MsgBox(trimmedtext)
                'MsgBox(trimmedtextlen)
                specslen = specslen - (trimmedtextlen + 1)
                'MsgBox("New len of specs = " & specslen)
                specs = Microsoft.VisualBasic.Left(specs, specslen)
            Loop
        End If

    End Sub

    Private Sub lviitems_DoubleClick(sender As Object, e As EventArgs) Handles lviitems.DoubleClick

        If btnok.Text <> "Edit" Then
            retialin = "itemtoinsell"
            rtl0 = lviitems.SelectedItems.Item(0).SubItems(0).Text
            rtl1 = lviitems.SelectedItems.Item(0).SubItems(1).Text
            rtl2 = lviitems.SelectedItems.Item(0).SubItems(2).Text
            rtl3 = lviitems.SelectedItems.Item(0).SubItems(3).Text
            rtl4 = lviitems.SelectedItems.Item(0).SubItems(4).Text
            rtl5 = lviitems.SelectedItems.Item(0).SubItems(5).Text
            rtl6 = lviitems.SelectedItems.Item(0).SubItems(6).Text
            rtl7 = lviitems.SelectedItems.Item(0).SubItems(7).Text
            rtl8 = lviitems.SelectedItems.Item(0).SubItems(8).Text
            rtl9 = lviitems.SelectedItems.Item(0).SubItems(9).Text
            rtl10 = lviitems.SelectedItems.Item(0).SubItems(10).Text.Replace("Php ", "")
            rtl11 = lviitems.SelectedItems.Item(0).SubItems(11).Text
            rtl12 = lviitems.SelectedItems.Item(0).SubItems(12).Text
            rtl13 = lviitems.SelectedItems.Item(0).SubItems(13).Text
            rtl14 = lviitems.SelectedItems.Item(0).SubItems(14).Text
            frmretailprice.txtitemname.Text = rtl0
            frmretailprice.txtunitprice.Text = rtl9
            frmretailprice.txtretailprice.Text = rtl10.Replace(",", "")
            frmretailprice.Label1.Text = "Retail price by " & rtl8
            frmretailprice.txtretailprice.Focus()
            frmretailprice.ShowInTaskbar = False
            frmretailprice.ShowDialog()
        End If

    End Sub

    Private Sub lviitems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lviitems.SelectedIndexChanged

        If btnok.Text <> "Edit" Then
            For Each item As ListViewItem In lviitems.Items
                If lviitems.SelectedItems.Count = 1 Then
                    nupitemqty.Enabled = True
                    item = lviitems.SelectedItems.Item(0)
                    nupitemqty.Minimum = 1
                    nupitemqty.Maximum = item.SubItems(7).Text
                    nupitemqty.Value = 1
                    'MsgBox("selected item is 1")
                ElseIf lviitems.SelectedItems.Count > 1 Then
                    nupitemqty.Maximum = lviitems.SelectedItems.Count
                    nupitemqty.Value = lviitems.SelectedItems.Count
                    nupitemqty.Enabled = False
                    'MsgBox("selected item is greater than 1")
                ElseIf lviitems.SelectedItems.Count = 0 Then
                    nupitemqty.Enabled = False
                    nupitemqty.Minimum = 0
                    nupitemqty.Value = 0
                    'MsgBox("selected item is 0")
                End If
            Next
        End If

    End Sub

    Private Sub btnselectfromstocks_Click(sender As Object, e As EventArgs) Handles btnselectfromstocks.Click

        processtooperationortransaction = "transaction"
        frmselectfromstocks.ShowInTaskbar = False
        frmselectfromstocks.ShowDialog()

    End Sub

    Private Sub btnremove_Click(sender As Object, e As EventArgs) Handles btnremove.Click

        If lviitems.SelectedItems.Count = 1 Then
            isselecteditemequaltoone = True
            'MsgBox("Selected item is equal to 1")
        ElseIf lviitems.SelectedItems.Count > 1 Then
            isselecteditemequaltoone = False
            'MsgBox("Selected item is greater than 1")
        End If

        ' ==================== SELECTED ITEMS IS EQUAL TO 1 ====================
        If isselecteditemequaltoone = True Then
            For Each item As ListViewItem In lviitems.Items
                Dim quantitytominus As Integer = nupitemqty.Value
                quantitytoremove = quantitytominus
                If lviitems.SelectedItems.Count = 1 Then
                    'MsgBox("Quantity of selected item is equal to 1")
                    item = lviitems.SelectedItems.Item(0)
                    col0 = item.SubItems(0).Text
                    col1 = item.SubItems(1).Text
                    col2 = item.SubItems(2).Text
                    col3 = item.SubItems(3).Text
                    col4 = item.SubItems(4).Text
                    col5 = item.SubItems(5).Text
                    col6 = item.SubItems(6).Text
                    col7 = item.SubItems(7).Text
                    col8 = item.SubItems(8).Text
                    col9 = item.SubItems(9).Text
                    col10 = item.SubItems(10).Text
                    col11 = item.SubItems(11).Text
                    col12 = item.SubItems(12).Text
                    col13 = item.SubItems(13).Text
                    col14 = item.SubItems(14).Text

                    Dim totalcol0 As Integer
                    Dim totalcol1 = "", totalcol2 As String = ""
                    Dim indexofitemtoremove As Integer = -1
                    Dim stoper As Boolean = False
                    For Each itemtotal As ListViewItem In lvitotal.Items
                        If lvitotal.Items.Count > 0 Then
                            'MsgBox("QTY > 0 : lvitotal item count is greater than 1")
                            If itemtotal.SubItems(2).Text = item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")" Then
                                'MsgBox(itemtotal.SubItems(2).Text & " IS EQUAL TO " & item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                                totalcol0 = itemtotal.SubItems.Item(0).Text
                                totalcol1 = itemtotal.SubItems.Item(1).Text
                                totalcol2 = itemtotal.SubItems.Item(2).Text
                                indexofitemtoremove += 1
                                stoper = True
                                'MsgBox("QTY > 0 : index of item to remove " & indexofitemtoremove)
                            Else
                                'MsgBox(itemtotal.SubItems(2).Text & " IS NOT EQUAL TO " & item.SubItems(0).Text & " " & item.SubItems(1).Text)
                                If stoper <> True Then
                                    indexofitemtoremove += 1
                                End If
                                'MsgBox("QTY > 0 : index of item to remove " & indexofitemtoremove)
                            End If
                        Else
                            'MsgBox("QTY > 0 : lvitotal item count is less than zero")
                        End If
                    Next
                    lvitotal.Items.Item(indexofitemtoremove).Remove()
                    Dim deleteornor As Integer = totalcol0 - nupitemqty.Value
                    'MsgBox(totalcol0 & " - 1 = " & deleteornor)
                    If deleteornor > 0 Then
                        'MsgBox("Current quantity is: " & deleteornor)
                        Dim item1 As New ListViewItem(totalcol0 - nupitemqty.Value)
                        item1.SubItems.Add(totalcol0 - nupitemqty.Value & " " & item.SubItems(8).Text)
                        item1.SubItems.Add(totalcol2)
                        lvitotal.Items.Add(item1)
                    End If

                    item.Remove()
                    openconnection()
                    Dim newquantity As Long = col7 - quantitytominus
                    If newquantity > 0 Then
                        Dim item2 As New ListViewItem(col0)
                        item2.SubItems.Add(col1)
                        item2.SubItems.Add(col2)
                        item2.SubItems.Add(col3)
                        item2.SubItems.Add(col4)
                        item2.SubItems.Add(col5)
                        item2.SubItems.Add(col6)
                        item2.SubItems.Add(newquantity)
                        item2.SubItems.Add(col8)
                        item2.SubItems.Add(col9)
                        item2.SubItems.Add(col10)
                        item2.SubItems.Add(col7 - quantitytominus & " " & col8)
                        Dim totalprice As Decimal = col12.Replace("Php ", "") - (quantitytominus * col10.Replace("Php ", ""))
                        item2.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
                        item2.SubItems.Add(col13)
                        item2.SubItems.Add(col14)
                        'MsgBox("New quantity: " & newquantity)
                        lviitems.Items.Add(item2)
                        item.Selected = False
                        nupitemqty.Value = 1
                        nupitemqty.Enabled = False
                        'cmd = New MySqlCommand("UPDATE `tbl_operation_item_used` SET `quantity`= '" & newquantity & "' ,`quantity_unit`= '" & col7 - quantitytominus & " " & col8 & "' , `total_price`= '" & "Php " & Format((totalprice), "0,00") & "' where product_id='" & col12 & "'", con)
                        'cmd.ExecuteNonQuery()
                        'updatetotalitems()
                    ElseIf newquantity = 0 Then
                        'cmddelete = "DELETE FROM `tbl_operation_item_used` where product_id='" & col12 & "'"
                        'sqlda = New MySqlDataAdapter(cmddelete, con)
                        'ds = New DataSet()
                        'sqlda.Fill(ds)
                        'updatetotalitems()
                    End If
                    movetolistviewremove()
                    'load_operation_item_total()
                    con.Close()
                    'MsgBox("Grand total: " & txttotalprice.Text.Replace("Php ", "") & " - " & (quantitytominus * item.SubItems(9).Text.Replace("Php ", "")))
                    lvispecs.Items.Clear()
                End If
            Next

            ' ==================== SELECTED ITEMS IS GREATER THAN 1 ====================
        ElseIf isselecteditemequaltoone = False Then
            For Each item As ListViewItem In lviitems.Items
                If lviitems.SelectedItems.Count > 0 Then
                    item = lviitems.SelectedItems.Item(0)
                    If item.SubItems(7).Text > 1 Then
                        'MsgBox("Quantity of selected item is greater than 1")
                        col0 = item.SubItems(0).Text
                        col1 = item.SubItems(1).Text
                        col2 = item.SubItems(2).Text
                        col3 = item.SubItems(3).Text
                        col4 = item.SubItems(4).Text
                        col5 = item.SubItems(5).Text
                        col6 = item.SubItems(6).Text
                        col7 = item.SubItems(7).Text
                        col8 = item.SubItems(8).Text
                        col9 = item.SubItems(9).Text
                        col10 = item.SubItems(10).Text
                        col11 = item.SubItems(11).Text
                        col12 = item.SubItems(12).Text
                        col13 = item.SubItems(13).Text
                        col14 = item.SubItems(14).Text
                        Dim totalcol0 As Integer
                        Dim totalcol1 = "", totalcol2 As String = ""
                        Dim indexofitemtoremove As Integer = -1
                        Dim stoper As Boolean = False
                        For Each itemtotal As ListViewItem In lvitotal.Items
                            If lvitotal.Items.Count > 0 Then
                                'MsgBox("QTY > 0 : lvitotal item count is greater than 1")
                                If itemtotal.SubItems(2).Text = item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")" Then
                                    'MsgBox(itemtotal.SubItems(2).Text & " IS EQUAL TO " & item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                                    totalcol0 = itemtotal.SubItems.Item(0).Text
                                    totalcol1 = itemtotal.SubItems.Item(1).Text
                                    totalcol2 = itemtotal.SubItems.Item(2).Text
                                    indexofitemtoremove += 1
                                    stoper = True
                                    'MsgBox("QTY > 0 : index of item to remove " & indexofitemtoremove)
                                Else
                                    'MsgBox(itemtotal.SubItems(2).Text & " IS NOT EQUAL TO " & item.SubItems(0).Text & " " & item.SubItems(1).Text)
                                    If stoper <> True Then
                                        indexofitemtoremove += 1
                                    End If
                                    'MsgBox("QTY > 0 : index of item to remove " & indexofitemtoremove)
                                End If
                            Else
                                'MsgBox("QTY > 0 : lvitotal item count is less than zero")
                            End If
                        Next
                        'MsgBox("Finalize of index of item to remove: " & indexofitemtoremove)
                        lvitotal.Items.Item(indexofitemtoremove).Remove()
                        Dim deleteornor As Integer = totalcol0 - 1
                        'MsgBox(totalcol0 & " - 1 = " & deleteornor)
                        If deleteornor > 0 Then
                            'MsgBox("Current quantity is: " & deleteornor)
                            Dim item1 As New ListViewItem(totalcol0 - 1)
                            item1.SubItems.Add(totalcol0 - 1 & " " & item.SubItems(8).Text)
                            item1.SubItems.Add(totalcol2)
                            lvitotal.Items.Add(item1)
                        End If
                        item.Remove()
                        Dim item2 As New ListViewItem(col0)
                        item2.SubItems.Add(col1)
                        item2.SubItems.Add(col2)
                        item2.SubItems.Add(col3)
                        item2.SubItems.Add(col4)
                        item2.SubItems.Add(col5)
                        item2.SubItems.Add(col6)
                        item2.SubItems.Add(col7 - 1)
                        item2.SubItems.Add(col8)
                        item2.SubItems.Add(col9)
                        item2.SubItems.Add(col10)
                        item2.SubItems.Add(col7 - 1 & " " & col8)
                        Dim totalprice As Decimal = col12.Replace("Php ", "") - col10.Replace("Php ", "")
                        item2.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
                        item2.SubItems.Add(col13)
                        item2.SubItems.Add(col14)
                        lviitems.Items.Add(item2)

                        movetolistviewremove()
                        'openconnection()
                        'cmd = New MySqlCommand("UPDATE `tbl_operation_item_used` SET `quantity`= '" & col7 - 1 & "' ,`quantity_unit`= '" & col7 - 1 & " " & col8 & " " & col8 & "' , `total_price`= '" & "Php " & Format((totalprice), "0,00") & "' where product_id='" & col12 & "'", con)
                        'cmd.ExecuteNonQuery()
                        'updatetotalitems()
                        'load_operation_item_total()
                        'MsgBox("FROM 0 = Selected item count: " & lviitems.SelectedItems.Count)
                    ElseIf item.SubItems(7).Text = 1 Then
                        'MsgBox("Quantity of selected item is equal to 1")
                        col0 = item.SubItems(0).Text
                        col1 = item.SubItems(1).Text
                        col2 = item.SubItems(2).Text
                        col3 = item.SubItems(3).Text
                        col4 = item.SubItems(4).Text
                        col5 = item.SubItems(5).Text
                        col6 = item.SubItems(6).Text
                        col7 = item.SubItems(7).Text
                        col8 = item.SubItems(8).Text
                        col9 = item.SubItems(9).Text
                        col10 = item.SubItems(10).Text
                        col11 = item.SubItems(11).Text
                        col12 = item.SubItems(12).Text
                        col13 = item.SubItems(13).Text
                        col14 = item.SubItems(14).Text
                        Dim totalcol0 As Integer
                        Dim totalcol1 = "", totalcol2 As String = ""
                        Dim indexofitemtoremove As Integer = -1
                        Dim stoper As Boolean = False
                        For Each itemtotal As ListViewItem In lvitotal.Items
                            If lvitotal.Items.Count > 0 Then
                                'MsgBox("QTY = 1 : lvitotal item count is greater than zero")
                                If item.SubItems(1).Text <> "" Then
                                    If itemtotal.SubItems(2).Text = item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")" Then
                                        'MsgBox(itemtotal.SubItems(2).Text & " IS EQUAL TO " & item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                                        totalcol0 = itemtotal.SubItems.Item(0).Text
                                        totalcol1 = itemtotal.SubItems.Item(1).Text
                                        totalcol2 = itemtotal.SubItems.Item(2).Text
                                        indexofitemtoremove += 1
                                        stoper = True
                                        'MsgBox("QTY = 1 : Initial index of item to remove " & indexofitemtoremove)
                                    Else
                                        'MsgBox(itemtotal.SubItems(2).Text & " IS NOT EQUAL TO " & item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                                        'MsgBox(stoper)
                                        If stoper = False Then
                                            indexofitemtoremove += 1
                                        End If
                                        'MsgBox("QTY = 1 : Initial index of item to remove " & indexofitemtoremove)
                                    End If
                                Else
                                    If itemtotal.SubItems(2).Text = item.SubItems(0).Text Then
                                        'MsgBox(itemtotal.SubItems(2).Text & " IS EQUAL TO " & item.SubItems(0).Text)
                                        totalcol0 = itemtotal.SubItems.Item(0).Text
                                        totalcol1 = itemtotal.SubItems.Item(1).Text
                                        totalcol2 = itemtotal.SubItems.Item(2).Text
                                        indexofitemtoremove += 1
                                        stoper = True
                                        'MsgBox("QTY = 1 : Initial index of item to remove " & indexofitemtoremove)
                                    Else
                                        'MsgBox(itemtotal.SubItems(2).Text & " IS NOT EQUAL TO " & item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                                        'MsgBox(stoper)
                                        If stoper = False Then
                                            indexofitemtoremove += 1
                                        End If
                                        'MsgBox("QTY = 1 : Initial index of item to remove " & indexofitemtoremove)
                                    End If
                                End If
                            Else
                                'MsgBox("QTY = 1 : lvitotal item count is less than zero")
                            End If
                        Next
                        'MsgBox("QTY = 1 : Final index of item to remove " & indexofitemtoremove)
                        lvitotal.Items.Item(indexofitemtoremove).Remove()
                        Dim deleteornor As Integer = totalcol0 - 1
                        'MsgBox(totalcol0 & " - 1 = " & deleteornor)
                        If deleteornor > 0 Then
                            'MsgBox("Current quantity is: " & deleteornor)
                            Dim item1 As New ListViewItem(totalcol0 - 1)
                            item1.SubItems.Add(totalcol0 - 1 & " " & item.SubItems(8).Text)
                            item1.SubItems.Add(totalcol2)
                            lvitotal.Items.Add(item1)
                        End If
                        item.Remove()
                        movetolistviewremove()
                        'cmddelete = "DELETE FROM `tbl_operation_item_used` where product_id='" & col12 & "'"
                        'sqlda = New MySqlDataAdapter(cmddelete, con)
                        'ds = New DataSet()
                        'sqlda.Fill(ds)
                        'updatetotalitems()
                        'load_operation_item_total()
                        'MsgBox("FROM 1 = Selected item count: " & lviitems.SelectedItems.Count)
                    End If
                End If
            Next
        End If
        con.Close()

        Dim grandtotal As Decimal
        For Each item As ListViewItem In lviitems.Items
            grandtotal += item.SubItems(12).Text.Replace("Php ", "")
        Next
        If grandtotal <> 0 Then
            If grandtotal > 999 Then
                txttotalprice.Text = "Php " & Format((grandtotal), "0,00.00")
            ElseIf grandtotal < 1000 Then
                txttotalprice.Text = "Php " & Format((grandtotal), "0.00")
            End If
        Else
            txttotalprice.Text = ""
        End If
        nupitemqty.Minimum = 0
        nupitemqty.Value = 0
        frmmain.lviitems.Items.Clear()

        lvispecs.Items.Clear()

    End Sub

    Private Sub movetolistviewremove()

        If isselecteditemequaltoone = True Then
            If col14 = "installed" Or col14 = "sold" Then
                Dim itemtoremove As New ListViewItem(col0)
                itemtoremove.SubItems.Add(col1)
                itemtoremove.SubItems.Add(col2)
                itemtoremove.SubItems.Add(col3)
                itemtoremove.SubItems.Add(col4)
                itemtoremove.SubItems.Add(col5)
                itemtoremove.SubItems.Add(col6)
                itemtoremove.SubItems.Add(quantitytoremove)
                itemtoremove.SubItems.Add(col8)
                itemtoremove.SubItems.Add(col9)
                itemtoremove.SubItems.Add(col10)
                itemtoremove.SubItems.Add(quantitytoremove & " " & col8)
                Dim totalprice As Decimal = quantitytoremove * col10.Replace("Php ", "")
                If totalprice > 999 Then
                    itemtoremove.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
                ElseIf totalprice < 1000 Then
                    itemtoremove.SubItems.Add("Php " & Format((totalprice), "0.00"))
                End If
                itemtoremove.SubItems.Add(col13)
                itemtoremove.SubItems.Add(col14)
                lviremove.Items.Add(itemtoremove)
            End If
        ElseIf isselecteditemequaltoone = False Then
            If col14 = "installed" Or col14 = "sold" Then
                Dim itemtoremove As New ListViewItem(col0)
                itemtoremove.SubItems.Add(col1)
                itemtoremove.SubItems.Add(col2)
                itemtoremove.SubItems.Add(col3)
                itemtoremove.SubItems.Add(col4)
                itemtoremove.SubItems.Add(col5)
                itemtoremove.SubItems.Add(col6)
                itemtoremove.SubItems.Add("1")
                itemtoremove.SubItems.Add(col8)
                itemtoremove.SubItems.Add(col9)
                itemtoremove.SubItems.Add(col10)
                itemtoremove.SubItems.Add("1 " & col8)
                Dim totalprice As Decimal = 1 * col10.Replace("Php ", "")
                If totalprice > 999 Then
                    itemtoremove.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
                ElseIf totalprice < 1000 Then
                    itemtoremove.SubItems.Add("Php " & Format((totalprice), "0.00"))
                End If
                itemtoremove.SubItems.Add(col13)
                itemtoremove.SubItems.Add(col14)
                lviremove.Items.Add(itemtoremove)
            End If
        End If

    End Sub

    Private Sub btnrestock_Click(sender As Object, e As EventArgs) Handles btnrestock.Click

        If lviitems.SelectedItems.Count = 1 Then
            isselecteditemequaltoone = True
            'MsgBox("Selected item is equal to 1")
        ElseIf lviitems.SelectedItems.Count > 1 Then
            isselecteditemequaltoone = False
            'MsgBox("Selected item is greater than 1")
        End If

        ' ==================== SELECTED ITEMS IS EQUAL TO 1 ====================
        If isselecteditemequaltoone = True Then
            For Each item As ListViewItem In lviitems.Items
                Dim quantitytominus As Integer = nupitemqty.Value
                quantitytoremove = quantitytominus
                If lviitems.SelectedItems.Count = 1 Then
                    item = lviitems.SelectedItems.Item(0)
                    col0 = item.SubItems(0).Text
                    col1 = item.SubItems(1).Text
                    col2 = item.SubItems(2).Text
                    col3 = item.SubItems(3).Text
                    col4 = item.SubItems(4).Text
                    col5 = item.SubItems(5).Text
                    col6 = item.SubItems(6).Text
                    col7 = item.SubItems(7).Text
                    col8 = item.SubItems(8).Text
                    col9 = item.SubItems(9).Text
                    col10 = item.SubItems(10).Text
                    col11 = item.SubItems(11).Text
                    col12 = item.SubItems(12).Text
                    col13 = item.SubItems(13).Text
                    col14 = item.SubItems(14).Text

                    Dim totalcol0 As Integer
                    Dim totalcol1 = "", totalcol2 As String = ""
                    Dim indexofitemtoremove As Integer = -1
                    Dim stoper As Boolean = False
                    For Each itemtotal As ListViewItem In lvitotal.Items
                        If lvitotal.Items.Count > 0 Then
                            'MsgBox("QTY > 0 : lvitotal item count is greater than 1")
                            If itemtotal.SubItems(2).Text = item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")" Then
                                'MsgBox(itemtotal.SubItems(2).Text & " IS EQUAL TO " & item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                                totalcol0 = itemtotal.SubItems.Item(0).Text
                                totalcol1 = itemtotal.SubItems.Item(1).Text
                                totalcol2 = itemtotal.SubItems.Item(2).Text
                                indexofitemtoremove += 1
                                stoper = True
                                'MsgBox("QTY > 0 : index of item to remove " & indexofitemtoremove)
                            Else
                                'MsgBox(itemtotal.SubItems(2).Text & " IS NOT EQUAL TO " & item.SubItems(0).Text & " " & item.SubItems(1).Text)
                                If stoper <> True Then
                                    indexofitemtoremove += 1
                                End If
                                'MsgBox("QTY > 0 : index of item to remove " & indexofitemtoremove)
                            End If
                        Else
                            'MsgBox("QTY > 0 : lvitotal item count is less than zero")
                        End If
                    Next
                    lvitotal.Items.Item(indexofitemtoremove).Remove()
                    Dim deleteornor As Integer = totalcol0 - nupitemqty.Value
                    'MsgBox(totalcol0 & " - 1 = " & deleteornor)
                    If deleteornor > 0 Then
                        'MsgBox("Current quantity is: " & deleteornor)
                        Dim item1 As New ListViewItem(totalcol0 - nupitemqty.Value)
                        item1.SubItems.Add(totalcol0 - nupitemqty.Value & " " & item.SubItems(8).Text)
                        item1.SubItems.Add(totalcol2)
                        lvitotal.Items.Add(item1)
                    End If

                    item.Remove()
                    openconnection()
                    Dim newquantity As Long = col7 - quantitytominus
                    If newquantity > 0 Then
                        Dim item2 As New ListViewItem(col0)
                        item2.SubItems.Add(col1)
                        item2.SubItems.Add(col2)
                        item2.SubItems.Add(col3)
                        item2.SubItems.Add(col4)
                        item2.SubItems.Add(col5)
                        item2.SubItems.Add(col6)
                        item2.SubItems.Add(newquantity)
                        item2.SubItems.Add(col8)
                        item2.SubItems.Add(col9)
                        item2.SubItems.Add(col10)
                        item2.SubItems.Add(col7 - quantitytominus & " " & col8)
                        Dim totalprice As Decimal = col12.Replace("Php ", "") - (quantitytominus * col10.Replace("Php ", ""))
                        item2.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
                        item2.SubItems.Add(col13)
                        item2.SubItems.Add(col14)
                        'MsgBox("New quantity: " & newquantity)
                        lviitems.Items.Add(item2)
                        item.Selected = False
                        nupitemqty.Value = 1
                        nupitemqty.Enabled = False
                        'cmd = New MySqlCommand("UPDATE `tbl_operation_item_used` SET `quantity`= '" & newquantity & "' ,`quantity_unit`= '" & col7 - quantitytominus & " " & col8 & "' , `total_price`= '" & "Php " & Format((totalprice), "0,00") & "' where product_id='" & col12 & "'", con)
                        'cmd.ExecuteNonQuery()
                        'updatetotalitems()
                    ElseIf newquantity = 0 Then
                        'cmddelete = "DELETE FROM `tbl_operation_item_used` where product_id='" & col12 & "'"
                        'sqlda = New MySqlDataAdapter(cmddelete, con)
                        'ds = New DataSet()
                        'sqlda.Fill(ds)
                        'updatetotalitems()
                    End If
                    movetolistviewrestock()
                    'load_operation_item_total()
                    con.Close()
                    'MsgBox("Grand total: " & txttotalprice.Text.Replace("Php ", "") & " - " & (quantitytominus * item.SubItems(9).Text.Replace("Php ", "")))
                    lvispecs.Items.Clear()
                End If
            Next

            ' ==================== SELECTED ITEMS IS GREATER THAN 1 ====================
        ElseIf isselecteditemequaltoone = False Then
            For Each item As ListViewItem In lviitems.Items
                If lviitems.SelectedItems.Count > 0 Then
                    item = lviitems.SelectedItems.Item(0)
                    If item.SubItems(7).Text > 1 Then
                        'MsgBox("Quantity of selected item is greater than 1")
                        col0 = item.SubItems(0).Text
                        col1 = item.SubItems(1).Text
                        col2 = item.SubItems(2).Text
                        col3 = item.SubItems(3).Text
                        col4 = item.SubItems(4).Text
                        col5 = item.SubItems(5).Text
                        col6 = item.SubItems(6).Text
                        col7 = item.SubItems(7).Text
                        col8 = item.SubItems(8).Text
                        col9 = item.SubItems(9).Text
                        col10 = item.SubItems(10).Text
                        col11 = item.SubItems(11).Text
                        col12 = item.SubItems(12).Text
                        col13 = item.SubItems(13).Text
                        col14 = item.SubItems(14).Text
                        Dim totalcol0 As Integer
                        Dim totalcol1 = "", totalcol2 As String = ""
                        Dim indexofitemtoremove As Integer = -1
                        Dim stoper As Boolean = False
                        For Each itemtotal As ListViewItem In lvitotal.Items
                            If lvitotal.Items.Count > 0 Then
                                'MsgBox("QTY > 0 : lvitotal item count is greater than 1")
                                If itemtotal.SubItems(2).Text = item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")" Then
                                    'MsgBox(itemtotal.SubItems(2).Text & " IS EQUAL TO " & item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                                    totalcol0 = itemtotal.SubItems.Item(0).Text
                                    totalcol1 = itemtotal.SubItems.Item(1).Text
                                    totalcol2 = itemtotal.SubItems.Item(2).Text
                                    indexofitemtoremove += 1
                                    stoper = True
                                    'MsgBox("QTY > 0 : index of item to remove " & indexofitemtoremove)
                                Else
                                    'MsgBox(itemtotal.SubItems(2).Text & " IS NOT EQUAL TO " & item.SubItems(0).Text & " " & item.SubItems(1).Text)
                                    If stoper <> True Then
                                        indexofitemtoremove += 1
                                    End If
                                    'MsgBox("QTY > 0 : index of item to remove " & indexofitemtoremove)
                                End If
                            Else
                                'MsgBox("QTY > 0 : lvitotal item count is less than zero")
                            End If
                        Next
                        'MsgBox("Finalize of index of item to remove: " & indexofitemtoremove)
                        lvitotal.Items.Item(indexofitemtoremove).Remove()
                        Dim deleteornor As Integer = totalcol0 - 1
                        'MsgBox(totalcol0 & " - 1 = " & deleteornor)
                        If deleteornor > 0 Then
                            'MsgBox("Current quantity is: " & deleteornor)
                            Dim item1 As New ListViewItem(totalcol0 - 1)
                            item1.SubItems.Add(totalcol0 - 1 & " " & item.SubItems(8).Text)
                            item1.SubItems.Add(totalcol2)
                            lvitotal.Items.Add(item1)
                        End If
                        item.Remove()
                        Dim item2 As New ListViewItem(col0)
                        item2.SubItems.Add(col1)
                        item2.SubItems.Add(col2)
                        item2.SubItems.Add(col3)
                        item2.SubItems.Add(col4)
                        item2.SubItems.Add(col5)
                        item2.SubItems.Add(col6)
                        item2.SubItems.Add(col7 - 1)
                        item2.SubItems.Add(col8)
                        item2.SubItems.Add(col9)
                        item2.SubItems.Add(col10)
                        item2.SubItems.Add(col7 - 1 & " " & col8)
                        Dim totalprice As Decimal = col12.Replace("Php ", "") - col10.Replace("Php ", "")
                        item2.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
                        item2.SubItems.Add(col13)
                        item2.SubItems.Add(col14)
                        lviitems.Items.Add(item2)

                        movetolistviewrestock()
                        'openconnection()
                        'cmd = New MySqlCommand("UPDATE `tbl_operation_item_used` SET `quantity`= '" & col7 - 1 & "' ,`quantity_unit`= '" & col7 - 1 & " " & col8 & " " & col8 & "' , `total_price`= '" & "Php " & Format((totalprice), "0,00") & "' where product_id='" & col12 & "'", con)
                        'cmd.ExecuteNonQuery()
                        'updatetotalitems()
                        'load_operation_item_total()
                        'MsgBox("FROM 0 = Selected item count: " & lviitems.SelectedItems.Count)
                    ElseIf item.SubItems(7).Text = 1 Then
                        'MsgBox("Quantity of selected item is equal to 1")
                        col0 = item.SubItems(0).Text
                        col1 = item.SubItems(1).Text
                        col2 = item.SubItems(2).Text
                        col3 = item.SubItems(3).Text
                        col4 = item.SubItems(4).Text
                        col5 = item.SubItems(5).Text
                        col6 = item.SubItems(6).Text
                        col7 = item.SubItems(7).Text
                        col8 = item.SubItems(8).Text
                        col9 = item.SubItems(9).Text
                        col10 = item.SubItems(10).Text
                        col11 = item.SubItems(11).Text
                        col12 = item.SubItems(12).Text
                        col13 = item.SubItems(13).Text
                        col14 = item.SubItems(14).Text
                        Dim totalcol0 As Integer
                        Dim totalcol1 = "", totalcol2 As String = ""
                        Dim indexofitemtoremove As Integer = -1
                        Dim stoper As Boolean = False
                        For Each itemtotal As ListViewItem In lvitotal.Items
                            If lvitotal.Items.Count > 0 Then
                                'MsgBox("QTY = 1 : lvitotal item count is greater than zero")
                                If item.SubItems(1).Text <> "" Then
                                    If itemtotal.SubItems(2).Text = item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")" Then
                                        'MsgBox(itemtotal.SubItems(2).Text & " IS EQUAL TO " & item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                                        totalcol0 = itemtotal.SubItems.Item(0).Text
                                        totalcol1 = itemtotal.SubItems.Item(1).Text
                                        totalcol2 = itemtotal.SubItems.Item(2).Text
                                        indexofitemtoremove += 1
                                        stoper = True
                                        'MsgBox("QTY = 1 : Initial index of item to remove " & indexofitemtoremove)
                                    Else
                                        'MsgBox(itemtotal.SubItems(2).Text & " IS NOT EQUAL TO " & item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                                        'MsgBox(stoper)
                                        If stoper = False Then
                                            indexofitemtoremove += 1
                                        End If
                                        'MsgBox("QTY = 1 : Initial index of item to remove " & indexofitemtoremove)
                                    End If
                                Else
                                    If itemtotal.SubItems(2).Text = item.SubItems(0).Text Then
                                        'MsgBox(itemtotal.SubItems(2).Text & " IS EQUAL TO " & item.SubItems(0).Text)
                                        totalcol0 = itemtotal.SubItems.Item(0).Text
                                        totalcol1 = itemtotal.SubItems.Item(1).Text
                                        totalcol2 = itemtotal.SubItems.Item(2).Text
                                        indexofitemtoremove += 1
                                        stoper = True
                                        'MsgBox("QTY = 1 : Initial index of item to remove " & indexofitemtoremove)
                                    Else
                                        'MsgBox(itemtotal.SubItems(2).Text & " IS NOT EQUAL TO " & item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                                        'MsgBox(stoper)
                                        If stoper = False Then
                                            indexofitemtoremove += 1
                                        End If
                                        'MsgBox("QTY = 1 : Initial index of item to remove " & indexofitemtoremove)
                                    End If
                                End If
                            Else
                                'MsgBox("QTY = 1 : lvitotal item count is less than zero")
                            End If
                        Next
                        'MsgBox("QTY = 1 : Final index of item to remove " & indexofitemtoremove)
                        lvitotal.Items.Item(indexofitemtoremove).Remove()
                        Dim deleteornor As Integer = totalcol0 - 1
                        'MsgBox(totalcol0 & " - 1 = " & deleteornor)
                        If deleteornor > 0 Then
                            'MsgBox("Current quantity is: " & deleteornor)
                            Dim item1 As New ListViewItem(totalcol0 - 1)
                            item1.SubItems.Add(totalcol0 - 1 & " " & item.SubItems(8).Text)
                            item1.SubItems.Add(totalcol2)
                            lvitotal.Items.Add(item1)
                        End If
                        item.Remove()
                        movetolistviewrestock()
                    End If
                End If
            Next
        End If
        con.Close()

        Dim grandtotal As Decimal
        For Each item As ListViewItem In lviitems.Items
            grandtotal += item.SubItems(12).Text.Replace("Php ", "")
        Next
        If grandtotal <> 0 Then
            If grandtotal > 999 Then
                txttotalprice.Text = "Php " & Format((grandtotal), "0,00.00")
            ElseIf grandtotal < 1000 Then
                txttotalprice.Text = "Php " & Format((grandtotal), "0.00")
            End If
        Else
            txttotalprice.Text = ""
        End If
        nupitemqty.Minimum = 0
        nupitemqty.Value = 0
        frmmain.lviitems.Items.Clear()

        lvispecs.Items.Clear()

    End Sub

    Private Sub movetolistviewrestock()

        If isselecteditemequaltoone = True Then
            If col14 = "installed" Or col14 = "sold" Then
                Dim itemtorestock As New ListViewItem(col0)
                itemtorestock.SubItems.Add(col1)
                itemtorestock.SubItems.Add(col2)
                itemtorestock.SubItems.Add(col3)
                itemtorestock.SubItems.Add(col4)
                itemtorestock.SubItems.Add(col5)
                itemtorestock.SubItems.Add(col6)
                itemtorestock.SubItems.Add(quantitytoremove)
                itemtorestock.SubItems.Add(col8)
                itemtorestock.SubItems.Add(col9)
                itemtorestock.SubItems.Add(col10)
                itemtorestock.SubItems.Add(quantitytoremove & " " & col8)
                Dim totalprice As Decimal = quantitytoremove * col10.Replace("Php ", "")
                If totalprice > 999 Then
                    itemtorestock.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
                ElseIf totalprice < 1000 Then
                    itemtorestock.SubItems.Add("Php " & Format((totalprice), "0.00"))
                End If
                itemtorestock.SubItems.Add(col13)
                itemtorestock.SubItems.Add(col14)
                lvirestock.Items.Add(itemtorestock)
            Else
                'MsgBox("Woal")
            End If
        ElseIf isselecteditemequaltoone = False Then
            If col14 = "installed" Or col14 = "sold" Then
                Dim itemtorestock As New ListViewItem(col0)
                itemtorestock.SubItems.Add(col1)
                itemtorestock.SubItems.Add(col2)
                itemtorestock.SubItems.Add(col3)
                itemtorestock.SubItems.Add(col4)
                itemtorestock.SubItems.Add(col5)
                itemtorestock.SubItems.Add(col6)
                itemtorestock.SubItems.Add("1")
                itemtorestock.SubItems.Add(col8)
                itemtorestock.SubItems.Add(col9)
                itemtorestock.SubItems.Add(col10)
                itemtorestock.SubItems.Add("1 " & col8)
                Dim totalprice As Decimal = 1 * col10.Replace("Php ", "")
                If totalprice > 999 Then
                    itemtorestock.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
                ElseIf totalprice < 1000 Then
                    itemtorestock.SubItems.Add("Php " & Format((totalprice), "0.00"))
                End If
                itemtorestock.SubItems.Add(col13)
                itemtorestock.SubItems.Add(col14)
                lvirestock.Items.Add(itemtorestock)
            End If
        End If

    End Sub

    Private Sub btnok_Click(sender As Object, e As EventArgs) Handles btnok.Click

        If btnok.Text = "Ok" Then
            newtransactioninsales = False
            Me.Hide()
        ElseIf btnok.Text = "Edit" Then
            btnok.Text = "Save"
            btncancel.Text = "Cancel"
            btnselectfromstocks.Enabled = True
            btnremove.Enabled = True
            btnrestock.Enabled = True
            'btnok.Enabled = False
            If loaduseditemsinoperationtosales = True Then
                loadinstalleditemsinsales()
            ElseIf loadsolditemsinoperationtosales = True Then
                loadsolditemsinsales()
            End If
        ElseIf btnok.Text = "Save" Then
            confirm = MessageBox.Show("Are you sure?", "Save Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
            If confirm = vbOK Then
                btnok.Text = "Edit"
                btnselectfromstocks.Enabled = False
                btnremove.Enabled = False
                btnrestock.Enabled = False
                updateretailprice()
                performadditem()
                performremoveitem()
                perfromrestockitem()

                'updateassignedpersonel()
                updatetotalitems()
                If loaduseditemsinoperationtosales = True Then
                    loadinstalleditemsinsales()
                ElseIf loadsolditemsinoperationtosales = True Then
                    loadsolditemsinsales()
                End If
                operationitemsalesexpanddipslay()
                loadoperationitemtotal()

                MessageBox.Show("Changes successfully saved!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Exit Sub
            End If
        End If

        displaystocks()

    End Sub

    Private Sub updateretailprice()
        openconnection()
        If loaduseditemsinoperationtosales = True Then
            'MsgBox("mag retail ta sa mga used items")
            For Each item As ListViewItem In lviitems.Items
                Dim retailedprice As Decimal = item.SubItems(10).Text.Replace("Php ", "")
                cmd = New MySqlCommand("UPDATE `tbl_operation_item_used` SET `selling_price`= '" & retailedprice & "' ,`total_price`= '" & item.SubItems(7).Text * retailedprice & "' where product_id='" & item.SubItems(13).Text & "'", con)
                cmd.ExecuteNonQuery()
            Next
        ElseIf loadsolditemsinoperationtosales = True Then
            'MsgBox("mag retail ta sa mga sold items")
            For Each item As ListViewItem In lviitems.Items
                Dim retailedprice As Decimal = item.SubItems(10).Text.Replace("Php ", "")
                cmd = New MySqlCommand("UPDATE `tbl_transaction_item_sold` SET `selling_price`= '" & retailedprice & "' ,`total_price`= '" & item.SubItems(7).Text * retailedprice & "' where product_id='" & item.SubItems(13).Text & "'", con)
                cmd.ExecuteNonQuery()
            Next
        End If
        con.Close()
    End Sub

    Private Sub performadditem()

        If loaduseditemsinoperationtosales = True Then
            'MsgBox("ADD ITEMS IN TBL_OPERATION_ITEM_USED")
            openconnection()
            For Each itemtoadd As ListViewItem In lviitems.Items
                If itemtoadd.SubItems(14).Text = "available" Then
                    'MsgBox(itemtoadd.SubItems(0).Text & " is available in stocks")
                    Dim specification = ""
                    cmd.CommandText = "Select specification from tbl_stocks where product_id = '" & itemtoadd.SubItems(13).Text & "'"
                    reader = cmd.ExecuteReader
                    If reader.HasRows Then
                        While (reader.Read())
                            specification = reader("specification").ToString.Replace("\", "\\")
                        End While
                    End If
                    reader.Close()

                    Dim matchproductidininstalleditem As String
                    Dim matchquantityininstalleditem As String
                    Dim matchunitininstalleditem As String
                    Dim matchtotalpriceininstalleditem As Decimal

                    If itemtoadd.SubItems(4).Text <> "" Then
                        Dim unitprice As Decimal = itemtoadd.SubItems(9).Text.Replace("Php ", "")
                        Dim sellingprice As Decimal = itemtoadd.SubItems(10).Text.Replace("Php ", "")
                        cmd.CommandText = "Select * from tbl_operation_item_used where operation_id = '" & txtoprno.Text & "' and product = '" & itemtoadd.SubItems(0).Text & "' and type = '" & itemtoadd.SubItems(1).Text & "' and brand = '" & itemtoadd.SubItems(2).Text & "' and supplier = '" & itemtoadd.SubItems(3).Text & "' and serial = '" & itemtoadd.SubItems(4).Text & "' and model = '" & itemtoadd.SubItems(5).Text & "' and arrival_date = '" & itemtoadd.SubItems(6).Text & "' and unit = '" & itemtoadd.SubItems(8).Text & "' and unit_price = '" & unitprice & "' and selling_price = '" & sellingprice & "' and specification = '" & specification & "'"
                        reader = cmd.ExecuteReader
                        'MsgBox("QUERY WITH SERIAL: Select * from tbl_operation_item_used where operation_id = '" & txtoprno.Text & "' and product = '" & itemtoadd.SubItems(0).Text & "' and type = '" & itemtoadd.SubItems(1).Text & "' and brand = '" & itemtoadd.SubItems(2).Text & "' and supplier = '" & itemtoadd.SubItems(3).Text & "' and serial = '" & itemtoadd.SubItems(4).Text & "' and model = '" & itemtoadd.SubItems(5).Text & "' and arrival_date = '" & itemtoadd.SubItems(6).Text & "' and unit = '" & itemtoadd.SubItems(8).Text & "' and unit_price = '" & itemtoadd.SubItems(9).Text & "' and specification = '" & specification & "'")
                    Else
                        Dim unitprice As Decimal = itemtoadd.SubItems(9).Text.Replace("Php ", "")
                        Dim sellingprice As Decimal = itemtoadd.SubItems(10).Text.Replace("Php ", "")
                        cmd.CommandText = "Select * from tbl_operation_item_used where operation_id = '" & txtoprno.Text & "' and product = '" & itemtoadd.SubItems(0).Text & "' and type = '" & itemtoadd.SubItems(1).Text & "' and brand = '" & itemtoadd.SubItems(2).Text & "' and supplier = '" & itemtoadd.SubItems(3).Text & "' and model = '" & itemtoadd.SubItems(5).Text & "' and arrival_date = '" & itemtoadd.SubItems(6).Text & "' and unit = '" & itemtoadd.SubItems(8).Text & "' and unit_price = '" & unitprice & "' and selling_price = '" & sellingprice & "' and specification = '" & specification & "'"
                        reader = cmd.ExecuteReader
                        'MsgBox("QUERY WITHOUT SERIAL: Select * from tbl_operation_item_used where operation_id = '" & txtoprno.Text & "' and product = '" & itemtoadd.SubItems(0).Text & "' and type = '" & itemtoadd.SubItems(1).Text & "' and brand = '" & itemtoadd.SubItems(2).Text & "' and supplier = '" & itemtoadd.SubItems(3).Text & "' and model = '" & itemtoadd.SubItems(5).Text & "' and arrival_date = '" & itemtoadd.SubItems(6).Text & "' and unit = '" & itemtoadd.SubItems(8).Text & "' and unit_price = '" & itemtoadd.SubItems(9).Text & "' and specification = '" & specification & "'")
                    End If
                    If reader.HasRows Then
                        'MsgBox("Naay ka match sa na installed, so mag update ta")
                        reader.Read()
                        matchproductidininstalleditem = reader("product_id").ToString
                        matchquantityininstalleditem = reader("quantity").ToString
                        matchunitininstalleditem = reader("unit").ToString
                        matchtotalpriceininstalleditem = reader("total_price").ToString
                        'MsgBox("matchproductidininstalleditem: " & matchproductidininstalleditem & " and matchquantityininstalleditem: " & matchquantityininstalleditem & " and matchunitininstalleditem: " & matchunitininstalleditem & " and matchtotalpriceininstalleditem: " & matchtotalpriceininstalleditem)
                        reader.Close()
                        Dim matchquantityinlistview As Integer = itemtoadd.SubItems(7).Text
                        Dim matchunitpriceinlistview As Decimal = itemtoadd.SubItems(12).Text.Replace("Php ", "")
                        cmd = New MySqlCommand("UPDATE `tbl_operation_item_used` SET `quantity`= '" & matchquantityininstalleditem + matchquantityinlistview & "' ,`quantity_unit`= '" & matchquantityininstalleditem + matchquantityinlistview & " " & itemtoadd.SubItems(8).Text & "' , `total_price`= '" & matchtotalpriceininstalleditem + matchunitpriceinlistview & "' where product_id='" & matchproductidininstalleditem & "'", con)
                        cmd.ExecuteNonQuery()
                    Else
                        'MsgBox("Walay ka match sa na installed, so mag insert tag new")
                        productidgeneratorver2()
                        Dim unitprice As Decimal = itemtoadd.SubItems(9).Text.Replace("Php", "")
                        Dim sellingprice As Decimal = itemtoadd.SubItems(10).Text.Replace("Php", "")
                        Dim totalprice As Decimal = itemtoadd.SubItems(12).Text.Replace("Php", "")
                        If itemtoadd.SubItems(4).Text <> "" Then
                            'MsgBox("and it has a serial")
                            cmd = New MySqlCommand("INSERT INTO `tbl_operation_item_used`(`operation_id`,`product_id`,`product`,`type`,`brand`,`supplier`,`serial`,`model`,`arrival_date`,`quantity`,`unit`,`unit_price`,`selling_price`,`quantity_unit`,`total_price`,`specification`,`status`) VALUES ('" & txtoprno.Text & "','" & productfinalizeid & "','" & itemtoadd.SubItems(0).Text & "','" & itemtoadd.SubItems(1).Text & "','" & itemtoadd.SubItems(2).Text & "','" & itemtoadd.SubItems(3).Text & "','" & itemtoadd.SubItems(4).Text & "','" & itemtoadd.SubItems(5).Text & "','" & itemtoadd.SubItems(6).Text & "','" & itemtoadd.SubItems(7).Text & "','" & itemtoadd.SubItems(8).Text & "','" & unitprice & "','" & sellingprice & "','" & itemtoadd.SubItems(11).Text & "','" & totalprice & "','" & specification & "','" & "installed" & "')", con)
                            cmd.ExecuteNonQuery()
                        ElseIf itemtoadd.SubItems(4).Text = "" Then
                            'MsgBox("and it has no serial")
                            cmd = New MySqlCommand("INSERT INTO `tbl_operation_item_used`(`operation_id`,`product_id`,`product`,`type`,`brand`,`supplier`,`model`,`arrival_date`,`quantity`,`unit`,`unit_price`,`selling_price`,`quantity_unit`,`total_price`,`specification`,`status`) VALUES ('" & txtoprno.Text & "','" & productfinalizeid & "','" & itemtoadd.SubItems(0).Text & "','" & itemtoadd.SubItems(1).Text & "','" & itemtoadd.SubItems(2).Text & "','" & itemtoadd.SubItems(3).Text & "','" & itemtoadd.SubItems(5).Text & "','" & itemtoadd.SubItems(6).Text & "','" & itemtoadd.SubItems(7).Text & "','" & itemtoadd.SubItems(8).Text & "','" & unitprice & "','" & sellingprice & "','" & itemtoadd.SubItems(11).Text & "','" & totalprice & "','" & specification & "','" & "installed" & "')", con)
                            cmd.ExecuteNonQuery()
                        End If
                    End If

                    'MsgBox("magtangtang nata sa stocks kung unsay ge add nato")
                    Dim currentquantity As Integer
                    Dim currenttotalprice As Decimal
                    cmd.CommandText = "Select * from tbl_stocks where product_id = '" & itemtoadd.SubItems(13).Text & "'"
                    reader = cmd.ExecuteReader
                    If reader.HasRows Then
                        While (reader.Read())
                            currentquantity = reader("quantity").ToString
                            currenttotalprice = reader("totalprice").ToString
                        End While
                    End If
                    reader.Close()
                    Dim newquantityinstocks As Integer = currentquantity - itemtoadd.SubItems(7).Text
                    Dim oldtotalprice As Decimal = itemtoadd.SubItems(7).Text * itemtoadd.SubItems(9).Text.Replace("Php ", "")
                    Dim newtotalpriceinstocks As Decimal = currenttotalprice - oldtotalprice
                    If newquantityinstocks > 0 Then
                        'MsgBox("newquantityinstocks: " & newquantityinstocks)
                        cmd = New MySqlCommand("UPDATE `tbl_stocks` SET `quantity`= '" & newquantityinstocks & "' ,`quantity_unit`= '" & newquantityinstocks & " " & itemtoadd.SubItems(8).Text & "' , `totalprice`= '" & newtotalpriceinstocks & "' where product_id='" & itemtoadd.SubItems(13).Text & "'", con)
                        cmd.ExecuteNonQuery()
                    ElseIf newquantityinstocks = 0 Then
                        'MsgBox("newquantityinstocks: " & newquantityinstocks)
                        cmddelete = "DELETE FROM `tbl_stocks` where product_id='" & itemtoadd.SubItems(13).Text & "'"
                        sqlda = New MySqlDataAdapter(cmddelete, con)
                        ds = New DataSet()
                        sqlda.Fill(ds)
                    End If
                End If
                itemtoadd.Remove()
            Next
            con.Close()
        ElseIf loadsolditemsinoperationtosales = True Then
            'MsgBox("ADD ITEMS IN TBL_TRANSACTION_ITEM_SOLD")
            openconnection()
            For Each itemtoadd As ListViewItem In lviitems.Items
                If itemtoadd.SubItems(14).Text = "available" Then
                    'MsgBox(itemtoadd.SubItems(0).Text & " is available in stocks")
                    Dim specification = ""
                    cmd.CommandText = "Select specification from tbl_stocks where product_id = '" & itemtoadd.SubItems(13).Text & "'"
                    reader = cmd.ExecuteReader
                    If reader.HasRows Then
                        While (reader.Read())
                            specification = reader("specification").ToString.Replace("\", "\\")
                        End While
                    End If
                    reader.Close()

                    Dim matchproductidininstalleditem As String
                    Dim matchquantityininstalleditem As String
                    Dim matchunitininstalleditem As String
                    Dim matchtotalpriceininstalleditem As Decimal

                    If itemtoadd.SubItems(4).Text <> "" Then
                        Dim unitprice As Decimal = itemtoadd.SubItems(9).Text.Replace("Php ", "")
                        Dim sellingprice As Decimal = itemtoadd.SubItems(10).Text.Replace("Php ", "")
                        cmd.CommandText = "Select * from tbl_transaction_item_sold where transaction_id = '" & txtoprno.Text & "' and product = '" & itemtoadd.SubItems(0).Text & "' and type = '" & itemtoadd.SubItems(1).Text & "' and brand = '" & itemtoadd.SubItems(2).Text & "' and supplier = '" & itemtoadd.SubItems(3).Text & "' and serial = '" & itemtoadd.SubItems(4).Text & "' and model = '" & itemtoadd.SubItems(5).Text & "' and arrival_date = '" & itemtoadd.SubItems(6).Text & "' and unit = '" & itemtoadd.SubItems(8).Text & "' and unit_price = '" & unitprice & "' and selling_price = '" & sellingprice & "' and specification = '" & specification & "'"
                        reader = cmd.ExecuteReader
                        'MsgBox("QUERY WITH SERIAL: Select * from tbl_operation_item_used where operation_id = '" & txtoprno.Text & "' and product = '" & itemtoadd.SubItems(0).Text & "' and type = '" & itemtoadd.SubItems(1).Text & "' and brand = '" & itemtoadd.SubItems(2).Text & "' and supplier = '" & itemtoadd.SubItems(3).Text & "' and serial = '" & itemtoadd.SubItems(4).Text & "' and model = '" & itemtoadd.SubItems(5).Text & "' and arrival_date = '" & itemtoadd.SubItems(6).Text & "' and unit = '" & itemtoadd.SubItems(8).Text & "' and unit_price = '" & itemtoadd.SubItems(9).Text & "' and specification = '" & specification & "'")
                    Else
                        Dim unitprice As Decimal = itemtoadd.SubItems(9).Text.Replace("Php ", "")
                        Dim sellingprice As Decimal = itemtoadd.SubItems(10).Text.Replace("Php ", "")
                        cmd.CommandText = "Select * from tbl_transaction_item_sold where transaction_id = '" & txtoprno.Text & "' and product = '" & itemtoadd.SubItems(0).Text & "' and type = '" & itemtoadd.SubItems(1).Text & "' and brand = '" & itemtoadd.SubItems(2).Text & "' and supplier = '" & itemtoadd.SubItems(3).Text & "' and model = '" & itemtoadd.SubItems(5).Text & "' and arrival_date = '" & itemtoadd.SubItems(6).Text & "' and unit = '" & itemtoadd.SubItems(8).Text & "' and unit_price = '" & unitprice & "' and selling_price = '" & sellingprice & "' and specification = '" & specification & "'"
                        reader = cmd.ExecuteReader
                        'MsgBox("QUERY WITHOUT SERIAL: Select * from tbl_operation_item_used where operation_id = '" & txtoprno.Text & "' and product = '" & itemtoadd.SubItems(0).Text & "' and type = '" & itemtoadd.SubItems(1).Text & "' and brand = '" & itemtoadd.SubItems(2).Text & "' and supplier = '" & itemtoadd.SubItems(3).Text & "' and model = '" & itemtoadd.SubItems(5).Text & "' and arrival_date = '" & itemtoadd.SubItems(6).Text & "' and unit = '" & itemtoadd.SubItems(8).Text & "' and unit_price = '" & itemtoadd.SubItems(9).Text & "' and specification = '" & specification & "'")
                    End If
                    If reader.HasRows Then
                        'MsgBox("Naay ka match sa na installed, so mag update ta")
                        reader.Read()
                        matchproductidininstalleditem = reader("product_id").ToString
                        matchquantityininstalleditem = reader("quantity").ToString
                        matchunitininstalleditem = reader("unit").ToString
                        matchtotalpriceininstalleditem = reader("total_price").ToString
                        'MsgBox("matchproductidininstalleditem: " & matchproductidininstalleditem & " and matchquantityininstalleditem: " & matchquantityininstalleditem & " and matchunitininstalleditem: " & matchunitininstalleditem & " and matchtotalpriceininstalleditem: " & matchtotalpriceininstalleditem)
                        reader.Close()
                        Dim matchquantityinlistview As Integer = itemtoadd.SubItems(7).Text
                        Dim matchunitpriceinlistview As Decimal = itemtoadd.SubItems(12).Text.Replace("Php ", "")
                        cmd = New MySqlCommand("UPDATE `tbl_transaction_item_sold` SET `quantity`= '" & matchquantityininstalleditem + matchquantityinlistview & "' ,`quantity_unit`= '" & matchquantityininstalleditem + matchquantityinlistview & " " & itemtoadd.SubItems(8).Text & "' , `total_price`= '" & matchtotalpriceininstalleditem + matchunitpriceinlistview & "' where product_id='" & matchproductidininstalleditem & "'", con)
                        cmd.ExecuteNonQuery()
                    Else
                        'MsgBox("Walay ka match sa na installed, so mag insert tag new")
                        productidgeneratorver3()
                        Dim unitprice As Decimal = itemtoadd.SubItems(9).Text.Replace("Php", "")
                        Dim sellingprice As Decimal = itemtoadd.SubItems(10).Text.Replace("Php", "")
                        Dim totalprice As Decimal = itemtoadd.SubItems(12).Text.Replace("Php", "")
                        If itemtoadd.SubItems(4).Text <> "" Then
                            'MsgBox("and it has a serial")
                            cmd = New MySqlCommand("INSERT INTO `tbl_transaction_item_sold`(`transaction_id`,`product_id`,`product`,`type`,`brand`,`supplier`,`serial`,`model`,`arrival_date`,`quantity`,`unit`,`unit_price`,`selling_price`,`quantity_unit`,`total_price`,`specification`,`status`) VALUES ('" & txtoprno.Text & "','" & productfinalizeid & "','" & itemtoadd.SubItems(0).Text & "','" & itemtoadd.SubItems(1).Text & "','" & itemtoadd.SubItems(2).Text & "','" & itemtoadd.SubItems(3).Text & "','" & itemtoadd.SubItems(4).Text & "','" & itemtoadd.SubItems(5).Text & "','" & itemtoadd.SubItems(6).Text & "','" & itemtoadd.SubItems(7).Text & "','" & itemtoadd.SubItems(8).Text & "','" & unitprice & "','" & sellingprice & "','" & itemtoadd.SubItems(11).Text & "','" & totalprice & "','" & specification & "','" & "sold" & "')", con)
                            cmd.ExecuteNonQuery()
                        ElseIf itemtoadd.SubItems(4).Text = "" Then
                            'MsgBox("and it has no serial")
                            cmd = New MySqlCommand("INSERT INTO `tbl_transaction_item_sold`(`transaction_id`,`product_id`,`product`,`type`,`brand`,`supplier`,`model`,`arrival_date`,`quantity`,`unit`,`unit_price`,`selling_price`,`quantity_unit`,`total_price`,`specification`,`status`) VALUES ('" & txtoprno.Text & "','" & productfinalizeid & "','" & itemtoadd.SubItems(0).Text & "','" & itemtoadd.SubItems(1).Text & "','" & itemtoadd.SubItems(2).Text & "','" & itemtoadd.SubItems(3).Text & "','" & itemtoadd.SubItems(5).Text & "','" & itemtoadd.SubItems(6).Text & "','" & itemtoadd.SubItems(7).Text & "','" & itemtoadd.SubItems(8).Text & "','" & unitprice & "','" & sellingprice & "','" & itemtoadd.SubItems(11).Text & "','" & totalprice & "','" & specification & "','" & "sold" & "')", con)
                            cmd.ExecuteNonQuery()
                        End If
                    End If

                    'MsgBox("magtangtang nata sa stocks kung unsay ge add nato")
                    Dim currentquantity As Integer
                    Dim currenttotalprice As Decimal
                    cmd.CommandText = "Select * from tbl_stocks where product_id = '" & itemtoadd.SubItems(13).Text & "'"
                    reader = cmd.ExecuteReader
                    If reader.HasRows Then
                        While (reader.Read())
                            currentquantity = reader("quantity").ToString
                            currenttotalprice = reader("totalprice").ToString
                        End While
                    End If
                    reader.Close()
                    Dim newquantityinstocks As Integer = currentquantity - itemtoadd.SubItems(7).Text
                    Dim oldtotalprice As Decimal = itemtoadd.SubItems(7).Text * itemtoadd.SubItems(9).Text.Replace("Php ", "")
                    Dim newtotalpriceinstocks As Decimal = currenttotalprice - oldtotalprice
                    If newquantityinstocks > 0 Then
                        'MsgBox("newquantityinstocks: " & newquantityinstocks)
                        cmd = New MySqlCommand("UPDATE `tbl_stocks` SET `quantity`= '" & newquantityinstocks & "' ,`quantity_unit`= '" & newquantityinstocks & " " & itemtoadd.SubItems(8).Text & "' , `totalprice`= '" & newtotalpriceinstocks & "' where product_id='" & itemtoadd.SubItems(13).Text & "'", con)
                        cmd.ExecuteNonQuery()
                    ElseIf newquantityinstocks = 0 Then
                        'MsgBox("newquantityinstocks: " & newquantityinstocks)
                        cmddelete = "DELETE FROM `tbl_stocks` where product_id='" & itemtoadd.SubItems(13).Text & "'"
                        sqlda = New MySqlDataAdapter(cmddelete, con)
                        ds = New DataSet()
                        sqlda.Fill(ds)
                    End If
                End If
                itemtoadd.Remove()
            Next
            con.Close()

        End If

    End Sub

    Private Sub performremoveitem()

        openconnection()
        If loaduseditemsinoperationtosales = True Then
            For Each itemtoremove As ListViewItem In lviremove.Items
                If lviremove.Items.Count > 0 Then
                    Dim currentquantity As Integer
                    Dim sellingprice As Decimal
                    cmd.CommandText = "Select * from tbl_operation_item_used where product_id = '" & itemtoremove.SubItems(13).Text & "'"
                    reader = cmd.ExecuteReader
                    If reader.HasRows Then
                        While (reader.Read())
                            currentquantity = reader("quantity").ToString
                            sellingprice = reader("selling_price").ToString
                        End While
                    End If
                    reader.Close()
                    Dim removeitemnewquantity As Integer = currentquantity - itemtoremove.SubItems(7).Text
                    If removeitemnewquantity > 0 Then
                        Dim removeitemtotalprice As Decimal = sellingprice * removeitemnewquantity
                        cmd = New MySqlCommand("UPDATE `tbl_operation_item_used` SET `quantity`= '" & removeitemnewquantity & "' ,`quantity_unit`= '" & removeitemnewquantity & " " & itemtoremove.SubItems(8).Text & "' , `total_price`= '" & removeitemtotalprice & "' where product_id='" & itemtoremove.SubItems(13).Text & "'", con)
                        cmd.ExecuteNonQuery()
                    ElseIf removeitemnewquantity = 0 Then
                        cmddelete = "DELETE FROM `tbl_operation_item_used` where product_id='" & itemtoremove.SubItems(13).Text & "'"
                        sqlda = New MySqlDataAdapter(cmddelete, con)
                        ds = New DataSet()
                        sqlda.Fill(ds)
                    End If
                End If
            Next
        ElseIf loadsolditemsinoperationtosales = True Then
            For Each itemtoremove As ListViewItem In lviremove.Items
                If lviremove.Items.Count > 0 Then
                    Dim currentquantity As Integer
                    Dim sellingprice As Decimal
                    cmd.CommandText = "Select * from tbl_transaction_item_sold where product_id = '" & itemtoremove.SubItems(13).Text & "'"
                    reader = cmd.ExecuteReader
                    If reader.HasRows Then
                        While (reader.Read())
                            currentquantity = reader("quantity").ToString
                            sellingprice = reader("selling_price").ToString
                        End While
                    End If
                    reader.Close()
                    Dim removeitemnewquantity As Integer = currentquantity - itemtoremove.SubItems(7).Text
                    If removeitemnewquantity > 0 Then
                        Dim removeitemtotalprice As Decimal = sellingprice * removeitemnewquantity
                        cmd = New MySqlCommand("UPDATE `tbl_transaction_item_sold` SET `quantity`= '" & removeitemnewquantity & "' ,`quantity_unit`= '" & removeitemnewquantity & " " & itemtoremove.SubItems(8).Text & "' , `total_price`= '" & removeitemtotalprice & "' where product_id='" & itemtoremove.SubItems(13).Text & "'", con)
                        cmd.ExecuteNonQuery()
                    ElseIf removeitemnewquantity = 0 Then
                        cmddelete = "DELETE FROM `tbl_transaction_item_sold` where product_id='" & itemtoremove.SubItems(13).Text & "'"
                        sqlda = New MySqlDataAdapter(cmddelete, con)
                        ds = New DataSet()
                        sqlda.Fill(ds)
                    End If
                End If
            Next
        End If
        con.Close()
        lviremove.Items.Clear()

    End Sub

    Private Sub perfromrestockitem()

        openconnection()
        If loaduseditemsinoperationtosales = True Then
            For Each itemtorestock As ListViewItem In lvirestock.Items
                If lvirestock.Items.Count > 0 Then
                    'MsgBox("Item to proccess: " & itemtorestock.SubItems(0).Text & " with the product id of: " & itemtorestock.SubItems(13).Text)
                    cmd.CommandText = "Select specification from tbl_operation_item_used where product_id = '" & itemtorestock.SubItems(13).Text & "'"
                    reader = cmd.ExecuteReader
                    If reader.HasRows Then
                        While (reader.Read())
                            specification = reader("specification").ToString.Replace("\", "\\")
                        End While
                    End If
                    'MsgBox("Specification of prodname: " & itemtorestock.SubItems(0).Text & " = " & specification)
                    reader.Close()
                    If itemtorestock.SubItems(4).Text <> "" Then
                        Dim unitprice As Decimal = itemtorestock.SubItems(9).Text.Replace("Php ", "")
                        cmd.CommandText = "Select * from tbl_stocks where product = '" & itemtorestock.SubItems(0).Text & "' and type = '" & itemtorestock.SubItems(1).Text & "' and brand = '" & itemtorestock.SubItems(2).Text & "' and supplier = '" & itemtorestock.SubItems(3).Text & "' and serial = '" & itemtorestock.SubItems(4).Text & "' and model = '" & itemtorestock.SubItems(5).Text & "' and arrival_date = '" & itemtorestock.SubItems(6).Text & "' and unit = '" & itemtorestock.SubItems(8).Text & "' and unit_price = '" & unitprice & "' and specification = '" & specification & "'"
                    Else
                        Dim unitprice As Decimal = itemtorestock.SubItems(9).Text.Replace("Php ", "")
                        cmd.CommandText = "Select * from tbl_stocks where product = '" & itemtorestock.SubItems(0).Text & "' and type = '" & itemtorestock.SubItems(1).Text & "' and brand = '" & itemtorestock.SubItems(2).Text & "' and supplier = '" & itemtorestock.SubItems(3).Text & "' and model = '" & itemtorestock.SubItems(5).Text & "' and arrival_date = '" & itemtorestock.SubItems(6).Text & "' and unit = '" & itemtorestock.SubItems(8).Text & "' and unit_price = '" & unitprice & "' and specification = '" & specification & "'"
                    End If
                    reader = cmd.ExecuteReader
                    If reader.HasRows Then
                        'MsgBox("Naa syay ka equal sa stocks, so mag update ta")
                        reader.Read()
                        Dim iteminstockid As String = reader("product_id").ToString
                        Dim iteminstockquantity As Integer = reader("quantity").ToString
                        Dim iteminstockunit As String = reader("unit").ToString
                        Dim iteminstocktotalrice As Decimal = reader("totalprice").ToString
                        Dim newtotalprice As Decimal = iteminstocktotalrice + (itemtorestock.SubItems(7).Text * itemtorestock.SubItems(9).Text.Replace("Php", ""))
                        reader.Close()
                        cmd = New MySqlCommand("UPDATE `tbl_stocks` SET `quantity`= '" & iteminstockquantity + itemtorestock.SubItems(7).Text & "' ,`quantity_unit`= '" & iteminstockquantity + itemtorestock.SubItems(7).Text & " " & itemtorestock.SubItems(8).Text & "' , `totalprice`= '" & newtotalprice & "' where product_id='" & iteminstockid & "'", con)
                        cmd.ExecuteNonQuery()
                    Else
                        'MsgBox("Wala syay ka equal sa stocks, so mag new ta")
                        productidgenerator()
                        If itemtorestock.SubItems(4).Text <> "" Then
                            Dim unitprice As Decimal = itemtorestock.SubItems(9).Text.Replace("Php", "")
                            Dim totalprice As Decimal = unitprice * itemtorestock.SubItems(7).Text
                            cmd = New MySqlCommand("INSERT INTO `tbl_stocks`(`product_id`,`product`,`type`,`brand`,`supplier`,`serial`,`model`,`arrival_date`,`quantity`,`unit`,`unit_price`,`quantity_unit`,`totalprice`,`specification`,`status`) VALUES ('" & productfinalizeid & "','" & itemtorestock.SubItems(0).Text & "','" & itemtorestock.SubItems(1).Text & "','" & itemtorestock.SubItems(2).Text & "','" & itemtorestock.SubItems(3).Text & "','" & itemtorestock.SubItems(4).Text & "','" & itemtorestock.SubItems(5).Text & "','" & itemtorestock.SubItems(6).Text & "','" & itemtorestock.SubItems(7).Text & "','" & itemtorestock.SubItems(8).Text & "','" & unitprice & "','" & itemtorestock.SubItems(7).Text & " " & itemtorestock.SubItems(8).Text & "','" & totalprice & "','" & specification & "','" & "available" & "')", con)
                            cmd.ExecuteNonQuery()
                        Else
                            Dim unitprice As Decimal = itemtorestock.SubItems(9).Text.Replace("Php", "")
                            Dim totalprice As Decimal = unitprice * itemtorestock.SubItems(7).Text
                            cmd = New MySqlCommand("INSERT INTO `tbl_stocks`(`product_id`,`product`,`type`,`brand`,`supplier`,`model`,`arrival_date`,`quantity`,`unit`,`unit_price`,`quantity_unit`,`totalprice`,`specification`,`status`) VALUES ('" & productfinalizeid & "','" & itemtorestock.SubItems(0).Text & "','" & itemtorestock.SubItems(1).Text & "','" & itemtorestock.SubItems(2).Text & "','" & itemtorestock.SubItems(3).Text & "','" & itemtorestock.SubItems(5).Text & "','" & itemtorestock.SubItems(6).Text & "','" & itemtorestock.SubItems(7).Text & "','" & itemtorestock.SubItems(8).Text & "','" & unitprice & "','" & itemtorestock.SubItems(7).Text & " " & itemtorestock.SubItems(8).Text & "','" & totalprice & "','" & specification & "','" & "available" & "')", con)
                            cmd.ExecuteNonQuery()
                        End If
                    End If

                    'MsgBox("mag minus nata sa tbl_operation_item_used kung unsay ge restock nato")
                    Dim currentquantity As Integer
                    cmd.CommandText = "Select quantity from tbl_operation_item_used where product_id = '" & itemtorestock.SubItems(13).Text & "'"
                    reader = cmd.ExecuteReader
                    If reader.HasRows Then
                        While (reader.Read())
                            currentquantity = reader("quantity").ToString
                        End While
                    End If
                    reader.Close()
                    Dim newquantityinitemused As Integer = currentquantity - itemtorestock.SubItems(7).Text
                    'MsgBox(itemtorestock.SubItems(0).Text & " newquantityinitemused sa tbl_operation_item_used: " & newquantityinitemused)
                    If newquantityinitemused > 0 Then
                        Dim removeitemtotalprice As Decimal = itemtorestock.SubItems(10).Text.Replace("Php ", "") * newquantityinitemused
                        cmd = New MySqlCommand("UPDATE `tbl_operation_item_used` SET `quantity`= '" & newquantityinitemused & "' ,`quantity_unit`= '" & newquantityinitemused & " " & itemtorestock.SubItems(8).Text & "' , `total_price`= '" & removeitemtotalprice & "' where product_id='" & itemtorestock.SubItems(13).Text & "'", con)
                        cmd.ExecuteNonQuery()
                    ElseIf newquantityinitemused = 0 Then
                        cmddelete = "DELETE FROM `tbl_operation_item_used` where product_id='" & itemtorestock.SubItems(13).Text & "'"
                        sqlda = New MySqlDataAdapter(cmddelete, con)
                        ds = New DataSet()
                        sqlda.Fill(ds)
                    End If
                End If
            Next
        ElseIf loadsolditemsinoperationtosales = True Then
            For Each itemtorestock As ListViewItem In lvirestock.Items
                If lvirestock.Items.Count > 0 Then
                    'MsgBox("Item to proccess: " & itemtorestock.SubItems(0).Text & " with the product id of: " & itemtorestock.SubItems(13).Text)
                    cmd.CommandText = "Select specification from tbl_transaction_item_sold where product_id = '" & itemtorestock.SubItems(13).Text & "'"
                    reader = cmd.ExecuteReader
                    If reader.HasRows Then
                        While (reader.Read())
                            specification = reader("specification").ToString.Replace("\", "\\")
                        End While
                    End If
                    'MsgBox("Specification of prodname: " & itemtorestock.SubItems(0).Text & " = " & specification)
                    reader.Close()
                    If itemtorestock.SubItems(4).Text <> "" Then
                        Dim unitprice As Decimal = itemtorestock.SubItems(9).Text.Replace("Php ", "")
                        cmd.CommandText = "Select * from tbl_stocks where product = '" & itemtorestock.SubItems(0).Text & "' and type = '" & itemtorestock.SubItems(1).Text & "' and brand = '" & itemtorestock.SubItems(2).Text & "' and supplier = '" & itemtorestock.SubItems(3).Text & "' and serial = '" & itemtorestock.SubItems(4).Text & "' and model = '" & itemtorestock.SubItems(5).Text & "' and arrival_date = '" & itemtorestock.SubItems(6).Text & "' and unit = '" & itemtorestock.SubItems(8).Text & "' and unit_price = '" & unitprice & "' and specification = '" & specification & "'"
                    Else
                        Dim unitprice As Decimal = itemtorestock.SubItems(9).Text.Replace("Php ", "")
                        cmd.CommandText = "Select * from tbl_stocks where product = '" & itemtorestock.SubItems(0).Text & "' and type = '" & itemtorestock.SubItems(1).Text & "' and brand = '" & itemtorestock.SubItems(2).Text & "' and supplier = '" & itemtorestock.SubItems(3).Text & "' and model = '" & itemtorestock.SubItems(5).Text & "' and arrival_date = '" & itemtorestock.SubItems(6).Text & "' and unit = '" & itemtorestock.SubItems(8).Text & "' and unit_price = '" & unitprice & "' and specification = '" & specification & "'"
                    End If
                    reader = cmd.ExecuteReader
                    If reader.HasRows Then
                        'MsgBox("Naa syay ka equal sa stocks, so mag update ta")
                        reader.Read()
                        Dim iteminstockid As String = reader("product_id").ToString
                        Dim iteminstockquantity As Integer = reader("quantity").ToString
                        Dim iteminstockunit As String = reader("unit").ToString
                        Dim iteminstocktotalrice As Decimal = reader("totalprice").ToString
                        Dim newtotalprice As Decimal = iteminstocktotalrice + (itemtorestock.SubItems(7).Text * itemtorestock.SubItems(9).Text.Replace("Php", ""))
                        reader.Close()
                        cmd = New MySqlCommand("UPDATE `tbl_stocks` SET `quantity`= '" & iteminstockquantity + itemtorestock.SubItems(7).Text & "' ,`quantity_unit`= '" & iteminstockquantity + itemtorestock.SubItems(7).Text & " " & itemtorestock.SubItems(8).Text & "' , `totalprice`= '" & newtotalprice & "' where product_id='" & iteminstockid & "'", con)
                        cmd.ExecuteNonQuery()
                    Else
                        'MsgBox("Wala syay ka equal sa stocks, so mag new ta")
                        productidgenerator()
                        If itemtorestock.SubItems(4).Text <> "" Then
                            Dim unitprice As Decimal = itemtorestock.SubItems(9).Text.Replace("Php", "")
                            Dim totalprice As Decimal = unitprice * itemtorestock.SubItems(7).Text
                            cmd = New MySqlCommand("INSERT INTO `tbl_stocks`(`product_id`,`product`,`type`,`brand`,`supplier`,`serial`,`model`,`arrival_date`,`quantity`,`unit`,`unit_price`,`quantity_unit`,`totalprice`,`specification`,`status`) VALUES ('" & productfinalizeid & "','" & itemtorestock.SubItems(0).Text & "','" & itemtorestock.SubItems(1).Text & "','" & itemtorestock.SubItems(2).Text & "','" & itemtorestock.SubItems(3).Text & "','" & itemtorestock.SubItems(4).Text & "','" & itemtorestock.SubItems(5).Text & "','" & itemtorestock.SubItems(6).Text & "','" & itemtorestock.SubItems(7).Text & "','" & itemtorestock.SubItems(8).Text & "','" & unitprice & "','" & itemtorestock.SubItems(7).Text & " " & itemtorestock.SubItems(8).Text & "','" & totalprice & "','" & specification & "','" & "available" & "')", con)
                            cmd.ExecuteNonQuery()
                        Else
                            Dim unitprice As Decimal = itemtorestock.SubItems(9).Text.Replace("Php", "")
                            Dim totalprice As Decimal = unitprice * itemtorestock.SubItems(7).Text
                            cmd = New MySqlCommand("INSERT INTO `tbl_stocks`(`product_id`,`product`,`type`,`brand`,`supplier`,`model`,`arrival_date`,`quantity`,`unit`,`unit_price`,`quantity_unit`,`totalprice`,`specification`,`status`) VALUES ('" & productfinalizeid & "','" & itemtorestock.SubItems(0).Text & "','" & itemtorestock.SubItems(1).Text & "','" & itemtorestock.SubItems(2).Text & "','" & itemtorestock.SubItems(3).Text & "','" & itemtorestock.SubItems(5).Text & "','" & itemtorestock.SubItems(6).Text & "','" & itemtorestock.SubItems(7).Text & "','" & itemtorestock.SubItems(8).Text & "','" & unitprice & "','" & itemtorestock.SubItems(7).Text & " " & itemtorestock.SubItems(8).Text & "','" & totalprice & "','" & specification & "','" & "available" & "')", con)
                            cmd.ExecuteNonQuery()
                        End If
                    End If

                    'MsgBox("mag minus nata sa tbl_transaction_item_sold kung unsay ge restock nato")
                    Dim currentquantity As Integer
                    cmd.CommandText = "Select quantity from tbl_transaction_item_sold where product_id = '" & itemtorestock.SubItems(13).Text & "'"
                    reader = cmd.ExecuteReader
                    If reader.HasRows Then
                        While (reader.Read())
                            currentquantity = reader("quantity").ToString
                        End While
                    End If
                    reader.Close()
                    Dim newquantityinitemused As Integer = currentquantity - itemtorestock.SubItems(7).Text
                    'MsgBox(itemtorestock.SubItems(0).Text & " newquantityinitemused sa tbl_operation_item_used: " & newquantityinitemused)
                    If newquantityinitemused > 0 Then
                        Dim removeitemtotalprice As Decimal = itemtorestock.SubItems(10).Text.Replace("Php ", "") * newquantityinitemused
                        cmd = New MySqlCommand("UPDATE `tbl_transaction_item_sold` SET `quantity`= '" & newquantityinitemused & "' ,`quantity_unit`= '" & newquantityinitemused & " " & itemtorestock.SubItems(8).Text & "' , `total_price`= '" & removeitemtotalprice & "' where product_id='" & itemtorestock.SubItems(13).Text & "'", con)
                        cmd.ExecuteNonQuery()
                    ElseIf newquantityinitemused = 0 Then
                        cmddelete = "DELETE FROM `tbl_transaction_item_sold` where product_id='" & itemtorestock.SubItems(13).Text & "'"
                        sqlda = New MySqlDataAdapter(cmddelete, con)
                        ds = New DataSet()
                        sqlda.Fill(ds)
                    End If
                End If
            Next
        End If
        con.Close()
        lvirestock.Items.Clear()

    End Sub

    Private Sub updatetotalitems()
        openconnection()
        If loaduseditemsinoperationtosales = True Then
            cmddelete = "DELETE FROM `tbl_operation_item_total` where operation_id='" & txtoprno.Text & "'"
            sqlda = New MySqlDataAdapter(cmddelete, con)
            ds = New DataSet()
            sqlda.Fill(ds)
            For Each totalitem As ListViewItem In lvitotal.Items
                cmd = New MySqlCommand("INSERT INTO `tbl_operation_item_total`(`operation_id`,`qty`,`quantity`,`items`) VALUES ('" & txtoprno.Text & "','" & totalitem.SubItems(0).Text & "','" & totalitem.SubItems(1).Text & "','" & totalitem.SubItems(2).Text & "')", con)
                cmd.ExecuteNonQuery()
                reader.Close()
                totalitem.Remove()
            Next
        ElseIf loadsolditemsinoperationtosales = True Then
            cmddelete = "DELETE FROM `tbl_transaction_item_total` where transaction_id='" & txtoprno.Text & "'"
            sqlda = New MySqlDataAdapter(cmddelete, con)
            ds = New DataSet()
            sqlda.Fill(ds)
            For Each totalitem As ListViewItem In lvitotal.Items
                cmd = New MySqlCommand("INSERT INTO `tbl_transaction_item_total`(`transaction_id`,`qty`,`quantity`,`items`) VALUES ('" & txtoprno.Text & "','" & totalitem.SubItems(0).Text & "','" & totalitem.SubItems(1).Text & "','" & totalitem.SubItems(2).Text & "')", con)
                cmd.ExecuteNonQuery()
                reader.Close()
                totalitem.Remove()
            Next
        End If
        con.Close()
    End Sub

    Private Sub loadoperationitemtotal()
        openconnection()
        If loaduseditemsinoperationtosales = True Then
            lvitotal.Items.Clear()
            cmd = New MySqlCommand("select * from tbl_operation_item_total where operation_id = '" & txtoprno.Text & "'", con)
            reader = cmd.ExecuteReader
            While (reader.Read())
                Dim itemtotal As New ListViewItem(reader("qty").ToString())
                itemtotal.SubItems.Add(reader("quantity").ToString())
                itemtotal.SubItems.Add(reader("items").ToString())
                lvitotal.Items.Add(itemtotal)
            End While
            reader.Close()
        ElseIf loadsolditemsinoperationtosales = True Then
            lvitotal.Items.Clear()
            cmd = New MySqlCommand("select * from tbl_transaction_item_total where transaction_id = '" & txtoprno.Text & "'", con)
            reader = cmd.ExecuteReader
            While (reader.Read())
                Dim itemtotal As New ListViewItem(reader("qty").ToString())
                itemtotal.SubItems.Add(reader("quantity").ToString())
                itemtotal.SubItems.Add(reader("items").ToString())
                lvitotal.Items.Add(itemtotal)
            End While
            reader.Close()
        End If
        con.Close()
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click

        newtransactioninsales = False
        lviremove.Items.Clear()
        lvirestock.Items.Clear()
        lvispecs.Items.Clear()
        Me.Close()

    End Sub

End Class