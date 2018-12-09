Imports MySql.Data.MySqlClient

Public Class frmselectfromstocks

    Private Sub frmselectfromstocks_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lvistocks.Columns.Clear()
        lvistocks.Columns.Add("Product Name", 145, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Type", 125, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Brand", 105, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Supplier", 105, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Serial", 155, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Model", 230, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Arrival Date", 82, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Qty", 0, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Unit", 0, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Unit Price", 95, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Quantity", 80, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Total Price", 95, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Product ID", 0, HorizontalAlignment.Left)
        lvistocks.Columns.Add("status", 0, HorizontalAlignment.Left)

        lvispecs.Columns.Clear()
        lvispecs.Items.Clear()
        lvispecs.Columns.Add("Specification", 1240, HorizontalAlignment.Left)

        loadproductname()
        displayitemtouse()
        undisplayselecteditems()

        cbosearchstocks.Text = "Serial"

    End Sub

    Private Sub loadproductname()
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

    Private Sub undisplayselecteditems()

        If processtooperationortransaction = "operation" Then
            undisplayselectediteminoperation()
        ElseIf processtooperationortransaction = "transaction" Then
            undisplayselecteditemintransaction()
        End If

    End Sub

    Private Sub undisplayselectediteminoperation()

        Dim itemquantity As Integer
        Dim col7 As Integer
        Dim col11 As Decimal
        Dim totalprice As Decimal
        Dim col0 = "", col1 = "", col2 = "", col3 = "", col4 = "", col5 = "", col6 = "", col8 = "", col9 = "", col10 = "", col12 = "", col13 As String = ""
        Dim newqty As Integer
        Dim selecteditemcounter As Integer = frmchooseitemsandpersonel.lviitems.Items.Count
        For Each selecteditem As ListViewItem In frmchooseitemsandpersonel.lviitems.Items
            Dim indexofitemtoremove As Integer = -1
            Dim stoper As Boolean = False
            Dim executeremoval As Boolean = False
            If frmchooseitemsandpersonel.lviitems.Items.Count > 0 Then
                If selecteditemcounter <> 0 Then
                    'MsgBox("Selected item is greater than zero")
                    For Each stocks As ListViewItem In lvistocks.Items
                        If selecteditem.SubItems(13).Text = stocks.SubItems(12).Text Then
                            indexofitemtoremove += 1
                            stoper = True

                            itemquantity = selecteditem.SubItems(7).Text
                            totalprice = selecteditem.SubItems(12).Text.Replace("Php ", "")
                            newqty = stocks.SubItems(7).Text - selecteditem.SubItems(7).Text
                            'MsgBox("New quantity is: " & newqty)
                            If newqty > 0 Then
                                col0 = stocks.SubItems(0).Text
                                col1 = stocks.SubItems(1).Text
                                col2 = stocks.SubItems(2).Text
                                col3 = stocks.SubItems(3).Text
                                col4 = stocks.SubItems(4).Text
                                col5 = stocks.SubItems(5).Text
                                col6 = stocks.SubItems(6).Text
                                col7 = stocks.SubItems(7).Text
                                col8 = stocks.SubItems(8).Text
                                col9 = stocks.SubItems(9).Text
                                col10 = stocks.SubItems(10).Text
                                col11 = stocks.SubItems(11).Text.Replace("Php ", "")
                                col12 = stocks.SubItems(12).Text
                                col13 = stocks.SubItems(13).Text
                            End If

                            executeremoval = True
                            'MsgBox(selecteditem.SubItems(12).Text & " is equal to " & stocks.SubItems(12).Text & " ||||| indexofitemtoremove is " & indexofitemtoremove)
                        Else
                            If stoper = False Then
                                indexofitemtoremove += 1
                            End If
                            'MsgBox(selecteditem.SubItems(12).Text & " is not equal to " & stocks.SubItems(12).Text & " ||||| indexofitemtoremove is " & indexofitemtoremove)
                        End If
                    Next
                    'MsgBox("Finalize index of item to remove = " & indexofitemtoremove)
                    If executeremoval = True Then
                        'MsgBox("Execute removeal = " & executeremoval)
                        lvistocks.Items.Item(indexofitemtoremove).Remove()

                        If newqty > 0 Then
                            Dim item As New ListViewItem(col0)
                            item.SubItems.Add(col1)
                            item.SubItems.Add(col2)
                            item.SubItems.Add(col3)
                            item.SubItems.Add(col4)
                            item.SubItems.Add(col5)
                            item.SubItems.Add(col6)
                            item.SubItems.Add(col7 - itemquantity)
                            item.SubItems.Add(col8)
                            item.SubItems.Add(col9)
                            item.SubItems.Add(col7 - itemquantity & " " & col8)
                            Dim newtotalprice As Decimal = col11 - totalprice
                            item.SubItems.Add("Php " & newtotalprice)
                            item.SubItems.Add(col12)
                            item.SubItems.Add(col13)
                            lvistocks.Items.Add(item)
                        End If
                    Else
                        'MsgBox("Execute removeal = " & executeremoval)
                    End If
                    selecteditemcounter = -1
                End If
            End If
        Next


        If lvistocks.Items.Count = 0 Then
            txttotalprice.Text = ""
        Else
            Dim grandtotal1 As Decimal
            For Each item As ListViewItem In lvistocks.Items
                grandtotal1 += item.SubItems(11).Text.Replace("Php", "")
            Next
            If grandtotal1 > 999 Then
                txttotalprice.Text = "Php " & Format((grandtotal1), "0,00.00")
            ElseIf grandtotal1 < 1000 Then
                txttotalprice.Text = "Php " & Format((grandtotal1), "0.00")
            End If
        End If

    End Sub

    Private Sub undisplayselecteditemintransaction()

        Dim itemquantity As Integer
        Dim col7 As Integer
        Dim col11 As Decimal
        Dim totalprice As Decimal
        Dim col0 = "", col1 = "", col2 = "", col3 = "", col4 = "", col5 = "", col6 = "", col8 = "", col9 = "", col10 = "", col12 = "", col13 As String = ""
        Dim newqty As Integer
        Dim selecteditemcounter As Integer = frmsolditem.lviitems.Items.Count
        For Each selecteditem As ListViewItem In frmsolditem.lviitems.Items
            Dim indexofitemtoremove As Integer = -1
            Dim stoper As Boolean = False
            Dim executeremoval As Boolean = False
            If frmsolditem.lviitems.Items.Count > 0 Then
                If selecteditemcounter <> 0 Then
                    'MsgBox("Selected item is greater than zero")
                    For Each stocks As ListViewItem In lvistocks.Items
                        If selecteditem.SubItems(13).Text = stocks.SubItems(12).Text Then
                            indexofitemtoremove += 1
                            stoper = True

                            itemquantity = selecteditem.SubItems(7).Text
                            totalprice = selecteditem.SubItems(12).Text.Replace("Php ", "")
                            newqty = stocks.SubItems(7).Text - selecteditem.SubItems(7).Text
                            'MsgBox("New quantity is: " & newqty)
                            If newqty > 0 Then
                                col0 = stocks.SubItems(0).Text
                                col1 = stocks.SubItems(1).Text
                                col2 = stocks.SubItems(2).Text
                                col3 = stocks.SubItems(3).Text
                                col4 = stocks.SubItems(4).Text
                                col5 = stocks.SubItems(5).Text
                                col6 = stocks.SubItems(6).Text
                                col7 = stocks.SubItems(7).Text
                                col8 = stocks.SubItems(8).Text
                                col9 = stocks.SubItems(9).Text
                                col10 = stocks.SubItems(10).Text
                                col11 = stocks.SubItems(11).Text.Replace("Php ", "")
                                col12 = stocks.SubItems(12).Text
                                col13 = stocks.SubItems(13).Text
                            End If

                            executeremoval = True
                            'MsgBox(selecteditem.SubItems(12).Text & " is equal to " & stocks.SubItems(12).Text & " ||||| indexofitemtoremove is " & indexofitemtoremove)
                        Else
                            If stoper = False Then
                                indexofitemtoremove += 1
                            End If
                            'MsgBox(selecteditem.SubItems(12).Text & " is not equal to " & stocks.SubItems(12).Text & " ||||| indexofitemtoremove is " & indexofitemtoremove)
                        End If
                    Next
                    'MsgBox("Finalize index of item to remove = " & indexofitemtoremove)
                    If executeremoval = True Then
                        'MsgBox("Execute removeal = " & executeremoval)
                        lvistocks.Items.Item(indexofitemtoremove).Remove()

                        If newqty > 0 Then
                            Dim item As New ListViewItem(col0)
                            item.SubItems.Add(col1)
                            item.SubItems.Add(col2)
                            item.SubItems.Add(col3)
                            item.SubItems.Add(col4)
                            item.SubItems.Add(col5)
                            item.SubItems.Add(col6)
                            item.SubItems.Add(col7 - itemquantity)
                            item.SubItems.Add(col8)
                            item.SubItems.Add(col9)
                            item.SubItems.Add(col7 - itemquantity & " " & col8)
                            Dim newtotalprice As Decimal = col11 - totalprice
                            item.SubItems.Add("Php " & newtotalprice)
                            item.SubItems.Add(col12)
                            item.SubItems.Add(col13)
                            lvistocks.Items.Add(item)
                        End If
                    Else
                        'MsgBox("Execute removeal = " & executeremoval)
                    End If
                    selecteditemcounter = -1
                End If
            End If
        Next


        If lvistocks.Items.Count = 0 Then
            txttotalprice.Text = ""
        Else
            Dim grandtotal1 As Decimal
            For Each item As ListViewItem In lvistocks.Items
                grandtotal1 += item.SubItems(11).Text.Replace("Php", "")
            Next
            If grandtotal1 > 999 Then
                txttotalprice.Text = "Php " & Format((grandtotal1), "0,00.00")
            ElseIf grandtotal1 < 1000 Then
                txttotalprice.Text = "Php " & Format((grandtotal1), "0.00")
            End If
        End If

    End Sub

    Private Sub cboproduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboproduct.SelectedIndexChanged

        filteritemtouse()
        undisplayselecteditems()

    End Sub

    Private Sub txtsearchstocks_TextChanged(sender As Object, e As EventArgs) Handles txtsearchstocks.TextChanged

        If txtsearchstocks.Text <> "" Then
            If cboproduct.Text = "" Then
                displayitemtouse()
            Else
                filteritemtouse()
            End If


            If cbosearchstocks.Text = "Serial" Then
                For Each Item As ListViewItem In lvistocks.Items
                    If Not Item.SubItems(4).Text.ToLower.Contains(txtsearchstocks.Text.ToLower) Then
                        Item.Remove()
                    End If
                Next
                Dim totalpricecounter As Integer = 0
                For Each item As ListViewItem In lvistocks.Items
                    If lvistocks.Items.Count > 0 Then
                        totalpricecounter += item.SubItems(11).Text.Replace("Php ", "")
                    End If
                Next
                txttotalprice.Text = "Php " & Format((totalpricecounter), "0,00")

            ElseIf cbosearchstocks.Text = "Model" Then
                For Each Item As ListViewItem In lvistocks.Items
                    If Not Item.SubItems(5).Text.ToLower.Contains(txtsearchstocks.Text.ToLower) Then
                        Item.Remove()
                    End If
                Next
                Dim totalpricecounter As Integer = 0
                For Each item As ListViewItem In lvistocks.Items
                    If lvistocks.Items.Count > 0 Then
                        totalpricecounter += item.SubItems(11).Text.Replace("Php ", "")
                    End If
                Next
                txttotalprice.Text = "Php " & Format((totalpricecounter), "0,00")
            End If
        Else
            If cboproduct.Text = "" Then
                displayitemtouse()
            Else
                filteritemtouse()
            End If
        End If
        undisplayselecteditems()

    End Sub

    Private Sub btnstocksrefresh_Click(sender As Object, e As EventArgs) Handles btnstocksrefresh.Click

        lvistocks.Columns.Clear()
        lvistocks.Columns.Add("Product Name", 145, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Type", 125, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Brand", 105, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Supplier", 105, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Serial", 155, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Model", 230, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Arrival Date", 82, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Qty", 0, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Unit", 0, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Unit Price", 95, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Quantity", 80, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Total Price", 95, HorizontalAlignment.Left)
        lvistocks.Columns.Add("Product ID", 0, HorizontalAlignment.Left)
        lvistocks.Columns.Add("status", 0, HorizontalAlignment.Left)

        cboproduct.Text = ""
        txtsearchstocks.Text = ""
        cboproduct.Items.Clear()
        loadproductname()
        displayitemtouse()
        undisplayselecteditems()

    End Sub

    Private Sub lvistocks_Click(sender As Object, e As EventArgs) Handles lvistocks.Click

        'txtsellingprice.ReadOnly = False
        'If txtprodid.Text <> lvistocks.SelectedItems.Item(0).SubItems(12).Text Then
        '    txtprodid.Text = lvistocks.SelectedItems.Item(0).SubItems(12).Text
        '    txtselecteditemname.Text = lvistocks.SelectedItems.Item(0).SubItems(0).Text
        '    txtsellingprice.Text = lvistocks.SelectedItems.Item(0).SubItems(9).Text.Replace("Php ", "")
        '    txttotalsellingprice.Text = "Php " & Format((txtsellingprice.Text * nupitemqty.Value), "0,00")
        'End If
        lvispecs.Items.Clear()
        Dim specslen As Integer = 0
        Dim trimmedtextlen As Integer = 0
        Dim trimmedtext As String = ""
        Dim specs As String = ""
        openconnection()
        cmd.CommandText = "Select specification from tbl_stocks where product_id = '" & lvistocks.SelectedItems.Item(0).SubItems(12).Text & "'"
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
            lvispecs.Items.Add(lvi)
            trimmedtextlen = Microsoft.VisualBasic.Len(trimmedtext)
            'MsgBox(trimmedtext)
            'MsgBox(trimmedtextlen)
            specslen = specslen - (trimmedtextlen + 1)
            'MsgBox("New len of specs = " & specslen)
            specs = Microsoft.VisualBasic.Left(specs, specslen)
        Loop

    End Sub

    Private Sub lvistocks_DoubleClick(sender As Object, e As EventArgs) Handles lvistocks.DoubleClick

        If processtooperationortransaction = "operation" Then
            doubleclickprocessoperation()
        ElseIf processtooperationortransaction = "transaction" Then
            doubleclickprocesstransaction()
        End If

    End Sub

    Private Sub doubleclickprocessoperation()
        Dim counter As Integer = 0
        Dim quantity As Integer = 0
        Dim itemtoremove As Integer = 0
        Dim allowexecution As Boolean
        Dim startcounter As Boolean
        Dim stopcounter As Boolean
        For Each item As ListViewItem In lvistocks.Items
            If lvistocks.SelectedItems.Count > 0 Then
                item = lvistocks.SelectedItems.Item(0)

                If frmchooseitemsandpersonel.lviitems.Items.Count = 0 Then
                    'MsgBox("Walay item sa chooseitemandpersonel")
                    Dim lvi As New ListViewItem(item.SubItems(0).Text)
                    lvi.SubItems.Add(item.SubItems(1).Text)
                    lvi.SubItems.Add(item.SubItems(2).Text)
                    lvi.SubItems.Add(item.SubItems(3).Text)
                    lvi.SubItems.Add(item.SubItems(4).Text)
                    lvi.SubItems.Add(item.SubItems(5).Text)
                    lvi.SubItems.Add(item.SubItems(6).Text)
                    lvi.SubItems.Add("1")
                    lvi.SubItems.Add(item.SubItems(8).Text)
                    lvi.SubItems.Add(item.SubItems(9).Text)
                    lvi.SubItems.Add(item.SubItems(9).Text)
                    lvi.SubItems.Add("1 " & item.SubItems(8).Text)
                    Dim unitprice As Decimal = item.SubItems(9).Text.Replace("Php ", "")
                    Dim totalprice As Decimal = unitprice * 1
                    If totalprice > 999 Then
                        lvi.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
                    ElseIf totalprice < 1000 Then
                        lvi.SubItems.Add("Php " & Format((totalprice), "0.00"))
                    End If
                    lvi.SubItems.Add(item.SubItems(12).Text)
                    lvi.SubItems.Add(item.SubItems(13).Text)
                    frmchooseitemsandpersonel.lviitems.Items.Add(lvi)
                    Dim totallvi As New ListViewItem("1")
                    totallvi.SubItems.Add("1 " & item.SubItems(8).Text)
                    If item.SubItems(1).Text <> "" Then
                        totallvi.SubItems.Add(item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                    Else
                        totallvi.SubItems.Add(item.SubItems(0).Text)
                    End If
                    frmchooseitemsandpersonel.lvitotal.Items.Add(totallvi)
                    allowexecution = False
                ElseIf frmchooseitemsandpersonel.lviitems.Items.Count > 0 Then
                    allowexecution = True
                    'MsgBox("Naay item sa chooseitemandpersonel")
                    For Each item1 As ListViewItem In frmchooseitemsandpersonel.lviitems.Items
                        item1.Selected = True
                    Next
                    For Each item1 As ListViewItem In frmchooseitemsandpersonel.lviitems.Items
                        item1 = frmchooseitemsandpersonel.lviitems.SelectedItems.Item(0)
                        If item1.SubItems(13).Text <> item.SubItems(12).Text Then
                            If counter = 1 Then
                                counter = 1
                            Else
                                counter = 0
                            End If

                            If stopcounter = False Then
                                If startcounter = False Then
                                    itemtoremove = 0
                                    startcounter = True
                                    quantity = item1.SubItems(7).Text
                                Else
                                    itemtoremove += 1
                                    startcounter = True
                                    quantity = item1.SubItems(7).Text
                                End If
                            End If

                            'MsgBox("counter : " & counter)
                            'MsgBox(item1.SubItems(12).Text & " are not equal to " & item.SubItems(12).Text & " so counter is equals to " & counter)
                        ElseIf item1.SubItems(13).Text = item.SubItems(12).Text Then
                            counter = 1

                            If stopcounter = False Then
                                If startcounter = False Then
                                    itemtoremove = 0
                                    startcounter = True
                                    stopcounter = True
                                    quantity = item1.SubItems(7).Text
                                Else
                                    itemtoremove += 1
                                    startcounter = True
                                    stopcounter = True
                                    quantity = item1.SubItems(7).Text
                                End If
                            End If

                            'MsgBox("counter : " & counter)
                            'MsgBox(item1.SubItems(12).Text & " are equal to " & item.SubItems(12).Text & " so counter is equals to " & counter)
                        End If
                        item1.Selected = False
                    Next
                End If

                If allowexecution = True Then
                    If counter = 0 Then
                        'MsgBox("Counter 0 function will be executed.")
                        Dim lvi1 As New ListViewItem(item.SubItems(0).Text)
                        lvi1.SubItems.Add(item.SubItems(1).Text)
                        lvi1.SubItems.Add(item.SubItems(2).Text)
                        lvi1.SubItems.Add(item.SubItems(3).Text)
                        lvi1.SubItems.Add(item.SubItems(4).Text)
                        lvi1.SubItems.Add(item.SubItems(5).Text)
                        lvi1.SubItems.Add(item.SubItems(6).Text)
                        lvi1.SubItems.Add("1")
                        lvi1.SubItems.Add(item.SubItems(8).Text)
                        lvi1.SubItems.Add(item.SubItems(9).Text)
                        lvi1.SubItems.Add(item.SubItems(9).Text)
                        lvi1.SubItems.Add("1 " & item.SubItems(8).Text)
                        Dim unitprice As Decimal = item.SubItems(9).Text.Replace("Php ", "")
                        Dim totalprice As Decimal = unitprice * 1
                        If totalprice > 999 Then
                            lvi1.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
                        ElseIf totalprice < 1000 Then
                            lvi1.SubItems.Add("Php " & Format((totalprice), "0.00"))
                        End If
                        lvi1.SubItems.Add(item.SubItems(12).Text)
                        lvi1.SubItems.Add(item.SubItems(13).Text)
                        frmchooseitemsandpersonel.lviitems.Items.Add(lvi1)

                        Dim totalitemquantity As Integer = 0
                        Dim indexofitemtoberemove As Integer = -1
                        Dim allowremove As Boolean
                        Dim stoper As Boolean
                        If item.SubItems(1).Text <> "" Then
                            'MsgBox("Naay type")
                            For Each totalitem As ListViewItem In frmchooseitemsandpersonel.lvitotal.Items
                                If totalitem.SubItems(2).Text = item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")" Then
                                    'MsgBox(totalitem.SubItems(2).Text & " is equal to " & item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                                    totalitemquantity = totalitem.SubItems(0).Text
                                    indexofitemtoberemove += 1
                                    stoper = True
                                    allowremove = True
                                    'MsgBox("Initial index of item to remove is: " & indexofitemtoberemove)
                                Else
                                    'MsgBox(totalitem.SubItems(2).Text & " is not equal to " & item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                                    If stoper <> True Then
                                        stoper = False
                                        indexofitemtoberemove += 1
                                    End If
                                    If allowremove <> True Then
                                        allowremove = False
                                    End If
                                    'MsgBox("Initial index of item to remove is: " & indexofitemtoberemove)
                                End If
                            Next
                        ElseIf item.SubItems(1).Text = "" Then
                            'MsgBox("Walay type")
                            For Each totalitem As ListViewItem In frmchooseitemsandpersonel.lvitotal.Items
                                If totalitem.SubItems(2).Text = item.SubItems(0).Text Then
                                    'MsgBox(totalitem.SubItems(2).Text & " is equal to " & item.SubItems(0).Text)
                                    totalitemquantity = totalitem.SubItems(0).Text
                                    indexofitemtoberemove += 1
                                    stoper = True
                                    allowremove = True
                                    'MsgBox("Initial index of item to remove is: " & indexofitemtoberemove)
                                Else
                                    'MsgBox(totalitem.SubItems(2).Text & " is not equal to " & item.SubItems(0).Text)
                                    If stoper <> True Then
                                        stoper = False
                                        indexofitemtoberemove += 1
                                    End If
                                    If allowremove <> True Then
                                        allowremove = False
                                    End If
                                    'MsgBox("Initial index of item to remove is: " & indexofitemtoberemove)
                                End If
                            Next
                        End If

                        If allowremove = True Then
                            'MsgBox("FINAL INDEX OF ITEM TO REMOVE: " & indexofitemtoberemove)
                            frmchooseitemsandpersonel.lvitotal.Items.Item(indexofitemtoberemove).Remove()
                        End If
                        Dim totalitem1 As New ListViewItem(totalitemquantity + 1)
                        totalitem1.SubItems.Add("" & (totalitemquantity + 1) & " " & item.SubItems(8).Text)
                        If item.SubItems(1).Text <> "" Then
                            totalitem1.SubItems.Add(item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                        Else
                            totalitem1.SubItems.Add(item.SubItems(0).Text)
                        End If
                        frmchooseitemsandpersonel.lvitotal.Items.Add(totalitem1)
                    ElseIf counter = 1 Then
                        'MsgBox("Counter 1 function will be executed.")
                        'MsgBox("Overwrite the index of " & itemtoremove & " with the quantity of " & quantity)
                        frmchooseitemsandpersonel.lviitems.Items.Item(itemtoremove).Remove()
                        Dim lvi2 As New ListViewItem(item.SubItems(0).Text)
                        lvi2.SubItems.Add(item.SubItems(1).Text)
                        lvi2.SubItems.Add(item.SubItems(2).Text)
                        lvi2.SubItems.Add(item.SubItems(3).Text)
                        lvi2.SubItems.Add(item.SubItems(4).Text)
                        lvi2.SubItems.Add(item.SubItems(5).Text)
                        lvi2.SubItems.Add(item.SubItems(6).Text)
                        lvi2.SubItems.Add(quantity + 1)
                        lvi2.SubItems.Add(item.SubItems(8).Text)
                        lvi2.SubItems.Add(item.SubItems(9).Text)
                        lvi2.SubItems.Add(item.SubItems(9).Text)
                        lvi2.SubItems.Add(quantity + 1 & " " & item.SubItems(8).Text)
                        Dim unitprice As Decimal = item.SubItems(9).Text.Replace("Php ", "")
                        Dim totalprice As Decimal = unitprice * 1
                        If totalprice > 999 Then
                            lvi2.SubItems.Add("Php " & Format((totalprice * (quantity + 1)), "0,00.00"))
                        ElseIf totalprice < 1000 Then
                            lvi2.SubItems.Add("Php " & Format((totalprice * (quantity + 1)), "0.00"))
                        End If
                        lvi2.SubItems.Add(item.SubItems(12).Text)
                        lvi2.SubItems.Add(item.SubItems(13).Text)
                        frmchooseitemsandpersonel.lviitems.Items.Add(lvi2)

                        Dim totalitemquantity As Integer = 0
                        Dim indexofitemtoberemove As Integer = -1
                        Dim allowremove As Boolean
                        Dim stoper As Boolean
                        If item.SubItems(1).Text <> "" Then
                            'MsgBox("Naay type")
                            For Each totalitem As ListViewItem In frmchooseitemsandpersonel.lvitotal.Items
                                If totalitem.SubItems(2).Text = item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")" Then
                                    'MsgBox(totalitem.SubItems(2).Text & " is equal to " & item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                                    totalitemquantity = totalitem.SubItems(0).Text
                                    indexofitemtoberemove += 1
                                    stoper = True
                                    allowremove = True
                                    'MsgBox("Initial index of item to remove is: " & indexofitemtoberemove)
                                Else
                                    'MsgBox(totalitem.SubItems(2).Text & " is not equal to " & item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                                    If stoper <> True Then
                                        stoper = False
                                        indexofitemtoberemove += 1
                                    End If
                                    If allowremove <> True Then
                                        allowremove = False
                                    End If
                                    'MsgBox("Initial index of item to remove is: " & indexofitemtoberemove)
                                End If
                            Next
                        ElseIf item.SubItems(1).Text = "" Then
                            'MsgBox("Walay type")
                            For Each totalitem As ListViewItem In frmchooseitemsandpersonel.lvitotal.Items
                                If totalitem.SubItems(2).Text = item.SubItems(0).Text Then
                                    'MsgBox(totalitem.SubItems(2).Text & " is equal to " & item.SubItems(0).Text)
                                    totalitemquantity = totalitem.SubItems(0).Text
                                    indexofitemtoberemove += 1
                                    stoper = True
                                    allowremove = True
                                    'MsgBox("Initial index of item to remove is: " & indexofitemtoberemove)
                                Else
                                    'MsgBox(totalitem.SubItems(2).Text & " is not equal to " & item.SubItems(0).Text)
                                    If stoper <> True Then
                                        stoper = False
                                        indexofitemtoberemove += 1
                                    End If
                                    If allowremove <> True Then
                                        allowremove = False
                                    End If
                                    'MsgBox("Initial index of item to remove is: " & indexofitemtoberemove)
                                End If
                            Next
                        End If

                        If allowremove = True Then
                            'MsgBox("FINAL INDEX OF ITEM TO REMOVE: " & indexofitemtoberemove)
                            frmchooseitemsandpersonel.lvitotal.Items.Item(indexofitemtoberemove).Remove()
                        End If
                        Dim totalitem1 As New ListViewItem(totalitemquantity + 1)
                        totalitem1.SubItems.Add("" & (totalitemquantity + 1) & " " & item.SubItems(8).Text)
                        If item.SubItems(1).Text <> "" Then
                            totalitem1.SubItems.Add(item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                        Else
                            totalitem1.SubItems.Add(item.SubItems(0).Text)
                        End If
                        frmchooseitemsandpersonel.lvitotal.Items.Add(totalitem1)
                    End If
                End If

                If item.SubItems(7).Text = 1 Then
                    item.Remove()
                ElseIf item.SubItems(7).Text > 1 Then
                    Dim lvi2 As New ListViewItem(item.SubItems(0).Text)
                    lvi2.SubItems.Add(item.SubItems(1).Text)
                    lvi2.SubItems.Add(item.SubItems(2).Text)
                    lvi2.SubItems.Add(item.SubItems(3).Text)
                    lvi2.SubItems.Add(item.SubItems(4).Text)
                    lvi2.SubItems.Add(item.SubItems(5).Text)
                    lvi2.SubItems.Add(item.SubItems(6).Text)
                    lvi2.SubItems.Add(item.SubItems(7).Text - 1)
                    lvi2.SubItems.Add(item.SubItems(8).Text)
                    lvi2.SubItems.Add(item.SubItems(9).Text)
                    lvi2.SubItems.Add(item.SubItems(7).Text - 1 & " " & item.SubItems(8).Text)
                    Dim unitprice As Decimal = item.SubItems(9).Text.Replace("Php ", "")
                    Dim totalprice As Decimal = item.SubItems(11).Text.Replace("Php ", "") - unitprice
                    If totalprice > 999 Then
                        lvi2.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
                    ElseIf totalprice < 1000 Then
                        lvi2.SubItems.Add("Php " & Format((totalprice), "0.00"))
                    End If
                    lvi2.SubItems.Add(item.SubItems(12).Text)
                    lvi2.SubItems.Add(item.SubItems(13).Text)
                    lvistocks.Items.Add(lvi2)
                    item.Remove()
                End If
            End If
        Next
        lvispecs.Items.Clear()

        frmmain.lviitems.Items.Clear()
        For Each totalitem As ListViewItem In frmchooseitemsandpersonel.lvitotal.Items
            Dim assignedpersonel As New ListViewItem(totalitem.SubItems(1).Text & " - " & totalitem.SubItems(2).Text)
            frmmain.lviitems.Items.Add(assignedpersonel)
        Next

        Dim newgrandtotalinstocks As Decimal
        For Each remainingitems As ListViewItem In lvistocks.Items
            newgrandtotalinstocks += remainingitems.SubItems(11).Text.Replace("Php ", "")
        Next
        If newgrandtotalinstocks > 999 Then
            txttotalprice.Text = "Php " & Format((newgrandtotalinstocks), "0,00.00")
        ElseIf newgrandtotalinstocks > 0 And newgrandtotalinstocks < 1000 Then
            txttotalprice.Text = "Php " & Format((newgrandtotalinstocks), "0.00")
        ElseIf newgrandtotalinstocks = 0 Then
            txttotalprice.Text = ""
        End If

        Dim grandtotal As Decimal
        For Each selecteditem As ListViewItem In frmchooseitemsandpersonel.lviitems.Items
            grandtotal += selecteditem.SubItems(12).Text.Replace("Php ", "")
        Next
        If grandtotal > 999 Then
            frmchooseitemsandpersonel.txttotalprice.Text = "Php " & Format((grandtotal), "0,00.00")
        ElseIf grandtotal > 0 And grandtotal < 1000 Then
            frmchooseitemsandpersonel.txttotalprice.Text = "Php " & Format((grandtotal), "0.00")
        ElseIf grandtotal = 0 Then
            frmchooseitemsandpersonel.txttotalprice.Text = ""
        End If
        lvistocks.Sort()
    End Sub

    Private Sub doubleclickprocesstransaction()

        Dim counter As Integer = 0
        Dim quantity As Integer = 0
        Dim itemtoremove As Integer = 0
        Dim allowexecution As Boolean
        Dim startcounter As Boolean
        Dim stopcounter As Boolean
        For Each item As ListViewItem In lvistocks.Items
            If lvistocks.SelectedItems.Count > 0 Then
                item = lvistocks.SelectedItems.Item(0)

                If frmsolditem.lviitems.Items.Count = 0 Then
                    'MsgBox("Walay item sa chooseitemandpersonel")
                    Dim lvi As New ListViewItem(item.SubItems(0).Text)
                    lvi.SubItems.Add(item.SubItems(1).Text)
                    lvi.SubItems.Add(item.SubItems(2).Text)
                    lvi.SubItems.Add(item.SubItems(3).Text)
                    lvi.SubItems.Add(item.SubItems(4).Text)
                    lvi.SubItems.Add(item.SubItems(5).Text)
                    lvi.SubItems.Add(item.SubItems(6).Text)
                    lvi.SubItems.Add("1")
                    lvi.SubItems.Add(item.SubItems(8).Text)
                    lvi.SubItems.Add(item.SubItems(9).Text)
                    lvi.SubItems.Add(item.SubItems(9).Text)
                    lvi.SubItems.Add("1 " & item.SubItems(8).Text)
                    Dim unitprice As Decimal = item.SubItems(9).Text.Replace("Php ", "")
                    Dim totalprice As Decimal = unitprice * 1
                    If totalprice > 999 Then
                        lvi.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
                    ElseIf totalprice < 1000 Then
                        lvi.SubItems.Add("Php " & Format((totalprice), "0.00"))
                    End If
                    lvi.SubItems.Add(item.SubItems(12).Text)
                    lvi.SubItems.Add(item.SubItems(13).Text)
                    frmsolditem.lviitems.Items.Add(lvi)
                    Dim totallvi As New ListViewItem("1")
                    totallvi.SubItems.Add("1 " & item.SubItems(8).Text)
                    If item.SubItems(1).Text <> "" Then
                        totallvi.SubItems.Add(item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                    Else
                        totallvi.SubItems.Add(item.SubItems(0).Text)
                    End If
                    frmsolditem.lvitotal.Items.Add(totallvi)
                    allowexecution = False
                ElseIf frmsolditem.lviitems.Items.Count > 0 Then
                    allowexecution = True
                    'MsgBox("Naay item sa chooseitemandpersonel")
                    For Each item1 As ListViewItem In frmsolditem.lviitems.Items
                        item1.Selected = True
                    Next
                    For Each item1 As ListViewItem In frmsolditem.lviitems.Items
                        item1 = frmsolditem.lviitems.SelectedItems.Item(0)
                        If item1.SubItems(13).Text <> item.SubItems(12).Text Then
                            If counter = 1 Then
                                counter = 1
                            Else
                                counter = 0
                            End If

                            If stopcounter = False Then
                                If startcounter = False Then
                                    itemtoremove = 0
                                    startcounter = True
                                    quantity = item1.SubItems(7).Text
                                Else
                                    itemtoremove += 1
                                    startcounter = True
                                    quantity = item1.SubItems(7).Text
                                End If
                            End If

                            'MsgBox("counter : " & counter)
                            'MsgBox(item1.SubItems(12).Text & " are not equal to " & item.SubItems(12).Text & " so counter is equals to " & counter)
                        ElseIf item1.SubItems(13).Text = item.SubItems(12).Text Then
                            counter = 1

                            If stopcounter = False Then
                                If startcounter = False Then
                                    itemtoremove = 0
                                    startcounter = True
                                    stopcounter = True
                                    quantity = item1.SubItems(7).Text
                                Else
                                    itemtoremove += 1
                                    startcounter = True
                                    stopcounter = True
                                    quantity = item1.SubItems(7).Text
                                End If
                            End If

                            'MsgBox("counter : " & counter)
                            'MsgBox(item1.SubItems(12).Text & " are equal to " & item.SubItems(12).Text & " so counter is equals to " & counter)
                        End If
                        item1.Selected = False
                    Next
                End If

                If allowexecution = True Then
                    If counter = 0 Then
                        'MsgBox("Counter 0 function will be executed.")
                        Dim lvi1 As New ListViewItem(item.SubItems(0).Text)
                        lvi1.SubItems.Add(item.SubItems(1).Text)
                        lvi1.SubItems.Add(item.SubItems(2).Text)
                        lvi1.SubItems.Add(item.SubItems(3).Text)
                        lvi1.SubItems.Add(item.SubItems(4).Text)
                        lvi1.SubItems.Add(item.SubItems(5).Text)
                        lvi1.SubItems.Add(item.SubItems(6).Text)
                        lvi1.SubItems.Add("1")
                        lvi1.SubItems.Add(item.SubItems(8).Text)
                        lvi1.SubItems.Add(item.SubItems(9).Text)
                        lvi1.SubItems.Add(item.SubItems(9).Text)
                        lvi1.SubItems.Add("1 " & item.SubItems(8).Text)
                        Dim unitprice As Decimal = item.SubItems(9).Text.Replace("Php ", "")
                        Dim totalprice As Decimal = unitprice * 1
                        If totalprice > 999 Then
                            lvi1.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
                        ElseIf totalprice < 1000 Then
                            lvi1.SubItems.Add("Php " & Format((totalprice), "0.00"))
                        End If
                        lvi1.SubItems.Add(item.SubItems(12).Text)
                        lvi1.SubItems.Add(item.SubItems(13).Text)
                        frmsolditem.lviitems.Items.Add(lvi1)

                        Dim totalitemquantity As Integer = 0
                        Dim indexofitemtoberemove As Integer = -1
                        Dim allowremove As Boolean
                        Dim stoper As Boolean
                        If item.SubItems(1).Text <> "" Then
                            'MsgBox("Naay type")
                            For Each totalitem As ListViewItem In frmsolditem.lvitotal.Items
                                If totalitem.SubItems(2).Text = item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")" Then
                                    'MsgBox(totalitem.SubItems(2).Text & " is equal to " & item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                                    totalitemquantity = totalitem.SubItems(0).Text
                                    indexofitemtoberemove += 1
                                    stoper = True
                                    allowremove = True
                                    'MsgBox("Initial index of item to remove is: " & indexofitemtoberemove)
                                Else
                                    'MsgBox(totalitem.SubItems(2).Text & " is not equal to " & item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                                    If stoper <> True Then
                                        stoper = False
                                        indexofitemtoberemove += 1
                                    End If
                                    If allowremove <> True Then
                                        allowremove = False
                                    End If
                                    'MsgBox("Initial index of item to remove is: " & indexofitemtoberemove)
                                End If
                            Next
                        ElseIf item.SubItems(1).Text = "" Then
                            'MsgBox("Walay type")
                            For Each totalitem As ListViewItem In frmsolditem.lvitotal.Items
                                If totalitem.SubItems(2).Text = item.SubItems(0).Text Then
                                    'MsgBox(totalitem.SubItems(2).Text & " is equal to " & item.SubItems(0).Text)
                                    totalitemquantity = totalitem.SubItems(0).Text
                                    indexofitemtoberemove += 1
                                    stoper = True
                                    allowremove = True
                                    'MsgBox("Initial index of item to remove is: " & indexofitemtoberemove)
                                Else
                                    'MsgBox(totalitem.SubItems(2).Text & " is not equal to " & item.SubItems(0).Text)
                                    If stoper <> True Then
                                        stoper = False
                                        indexofitemtoberemove += 1
                                    End If
                                    If allowremove <> True Then
                                        allowremove = False
                                    End If
                                    'MsgBox("Initial index of item to remove is: " & indexofitemtoberemove)
                                End If
                            Next
                        End If

                        If allowremove = True Then
                            'MsgBox("FINAL INDEX OF ITEM TO REMOVE: " & indexofitemtoberemove)
                            frmsolditem.lvitotal.Items.Item(indexofitemtoberemove).Remove()
                        End If
                        Dim totalitem1 As New ListViewItem(totalitemquantity + 1)
                        totalitem1.SubItems.Add("" & (totalitemquantity + 1) & " " & item.SubItems(8).Text)
                        If item.SubItems(1).Text <> "" Then
                            totalitem1.SubItems.Add(item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                        Else
                            totalitem1.SubItems.Add(item.SubItems(0).Text)
                        End If
                        frmsolditem.lvitotal.Items.Add(totalitem1)
                    ElseIf counter = 1 Then
                        'MsgBox("Counter 1 function will be executed.")
                        'MsgBox("Overwrite the index of " & itemtoremove & " with the quantity of " & quantity)
                        frmsolditem.lviitems.Items.Item(itemtoremove).Remove()
                        Dim lvi2 As New ListViewItem(item.SubItems(0).Text)
                        lvi2.SubItems.Add(item.SubItems(1).Text)
                        lvi2.SubItems.Add(item.SubItems(2).Text)
                        lvi2.SubItems.Add(item.SubItems(3).Text)
                        lvi2.SubItems.Add(item.SubItems(4).Text)
                        lvi2.SubItems.Add(item.SubItems(5).Text)
                        lvi2.SubItems.Add(item.SubItems(6).Text)
                        lvi2.SubItems.Add(quantity + 1)
                        lvi2.SubItems.Add(item.SubItems(8).Text)
                        lvi2.SubItems.Add(item.SubItems(9).Text)
                        lvi2.SubItems.Add(item.SubItems(9).Text)
                        lvi2.SubItems.Add(quantity + 1 & " " & item.SubItems(8).Text)
                        Dim unitprice As Decimal = item.SubItems(9).Text.Replace("Php ", "")
                        Dim totalprice As Decimal = unitprice * 1
                        If totalprice > 999 Then
                            lvi2.SubItems.Add("Php " & Format((totalprice * (quantity + 1)), "0,00.00"))
                        ElseIf totalprice < 1000 Then
                            lvi2.SubItems.Add("Php " & Format((totalprice * (quantity + 1)), "0.00"))
                        End If
                        lvi2.SubItems.Add(item.SubItems(12).Text)
                        lvi2.SubItems.Add(item.SubItems(13).Text)
                        frmsolditem.lviitems.Items.Add(lvi2)

                        Dim totalitemquantity As Integer = 0
                        Dim indexofitemtoberemove As Integer = -1
                        Dim allowremove As Boolean
                        Dim stoper As Boolean
                        If item.SubItems(1).Text <> "" Then
                            'MsgBox("Naay type")
                            For Each totalitem As ListViewItem In frmsolditem.lvitotal.Items
                                If totalitem.SubItems(2).Text = item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")" Then
                                    'MsgBox(totalitem.SubItems(2).Text & " is equal to " & item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                                    totalitemquantity = totalitem.SubItems(0).Text
                                    indexofitemtoberemove += 1
                                    stoper = True
                                    allowremove = True
                                    'MsgBox("Initial index of item to remove is: " & indexofitemtoberemove)
                                Else
                                    'MsgBox(totalitem.SubItems(2).Text & " is not equal to " & item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                                    If stoper <> True Then
                                        stoper = False
                                        indexofitemtoberemove += 1
                                    End If
                                    If allowremove <> True Then
                                        allowremove = False
                                    End If
                                    'MsgBox("Initial index of item to remove is: " & indexofitemtoberemove)
                                End If
                            Next
                        ElseIf item.SubItems(1).Text = "" Then
                            'MsgBox("Walay type")
                            For Each totalitem As ListViewItem In frmsolditem.lvitotal.Items
                                If totalitem.SubItems(2).Text = item.SubItems(0).Text Then
                                    'MsgBox(totalitem.SubItems(2).Text & " is equal to " & item.SubItems(0).Text)
                                    totalitemquantity = totalitem.SubItems(0).Text
                                    indexofitemtoberemove += 1
                                    stoper = True
                                    allowremove = True
                                    'MsgBox("Initial index of item to remove is: " & indexofitemtoberemove)
                                Else
                                    'MsgBox(totalitem.SubItems(2).Text & " is not equal to " & item.SubItems(0).Text)
                                    If stoper <> True Then
                                        stoper = False
                                        indexofitemtoberemove += 1
                                    End If
                                    If allowremove <> True Then
                                        allowremove = False
                                    End If
                                    'MsgBox("Initial index of item to remove is: " & indexofitemtoberemove)
                                End If
                            Next
                        End If

                        If allowremove = True Then
                            'MsgBox("FINAL INDEX OF ITEM TO REMOVE: " & indexofitemtoberemove)
                            frmsolditem.lvitotal.Items.Item(indexofitemtoberemove).Remove()
                        End If
                        Dim totalitem1 As New ListViewItem(totalitemquantity + 1)
                        totalitem1.SubItems.Add("" & (totalitemquantity + 1) & " " & item.SubItems(8).Text)
                        If item.SubItems(1).Text <> "" Then
                            totalitem1.SubItems.Add(item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                        Else
                            totalitem1.SubItems.Add(item.SubItems(0).Text)
                        End If
                        frmsolditem.lvitotal.Items.Add(totalitem1)
                    End If
                End If


                If item.SubItems(7).Text = 1 Then
                    item.Remove()
                ElseIf item.SubItems(7).Text > 1 Then
                    Dim lvi2 As New ListViewItem(item.SubItems(0).Text)
                    lvi2.SubItems.Add(item.SubItems(1).Text)
                    lvi2.SubItems.Add(item.SubItems(2).Text)
                    lvi2.SubItems.Add(item.SubItems(3).Text)
                    lvi2.SubItems.Add(item.SubItems(4).Text)
                    lvi2.SubItems.Add(item.SubItems(5).Text)
                    lvi2.SubItems.Add(item.SubItems(6).Text)
                    lvi2.SubItems.Add(item.SubItems(7).Text - 1)
                    lvi2.SubItems.Add(item.SubItems(8).Text)
                    lvi2.SubItems.Add(item.SubItems(9).Text)
                    lvi2.SubItems.Add(item.SubItems(7).Text - 1 & " " & item.SubItems(8).Text)
                    Dim unitprice As Decimal = item.SubItems(9).Text.Replace("Php ", "")
                    Dim totalprice As Decimal = item.SubItems(11).Text.Replace("Php ", "") - unitprice
                    If totalprice > 999 Then
                        lvi2.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
                    ElseIf totalprice < 1000 Then
                        lvi2.SubItems.Add("Php " & Format((totalprice), "0.00"))
                    End If
                    lvi2.SubItems.Add(item.SubItems(12).Text)
                    lvi2.SubItems.Add(item.SubItems(13).Text)
                    lvistocks.Items.Add(lvi2)
                    item.Remove()
                End If
            End If
        Next
        lvispecs.Items.Clear()

        frmmain.lvitotal.Items.Clear()
        For Each totalitem As ListViewItem In frmsolditem.lvitotal.Items
            Dim assignedpersonel As New ListViewItem(totalitem.SubItems(1).Text & " - " & totalitem.SubItems(2).Text)
            frmmain.lvitotal.Items.Add(assignedpersonel)
        Next

        Dim newgrandtotalinstocks As Decimal
        For Each remainingitems As ListViewItem In lvistocks.Items
            newgrandtotalinstocks += remainingitems.SubItems(11).Text.Replace("Php ", "")
        Next
        If newgrandtotalinstocks > 999 Then
            txttotalprice.Text = "Php " & Format((newgrandtotalinstocks), "0,00.00")
        ElseIf newgrandtotalinstocks > 0 And newgrandtotalinstocks < 1000 Then
            txttotalprice.Text = "Php " & Format((newgrandtotalinstocks), "0.00")
        ElseIf newgrandtotalinstocks = 0 Then
            txttotalprice.Text = ""
        End If

        Dim grandtotal As Decimal
        For Each selecteditem As ListViewItem In frmsolditem.lviitems.Items
            grandtotal += selecteditem.SubItems(12).Text.Replace("Php ", "")
        Next
        If grandtotal > 999 Then
            frmsolditem.txttotalprice.Text = "Php " & Format((grandtotal), "0,00.00")
        ElseIf grandtotal > 0 And grandtotal < 1000 Then
            frmsolditem.txttotalprice.Text = "Php " & Format((grandtotal), "0.00")
        ElseIf grandtotal = 0 Then
            frmsolditem.txttotalprice.Text = ""
        End If
        lvistocks.Sort()

    End Sub

    Private Sub lvistocks_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvistocks.SelectedIndexChanged

        For Each item As ListViewItem In lvistocks.Items
            If lvistocks.SelectedItems.Count = 1 Then
                nupitemqty.Enabled = True
                item = lvistocks.SelectedItems.Item(0)
                nupitemqty.Minimum = 1
                nupitemqty.Maximum = item.SubItems(7).Text
                nupitemqty.Value = 1
                'MsgBox("selected item is 1")
            ElseIf lvistocks.SelectedItems.Count > 1 Then
                nupitemqty.Maximum = lvistocks.SelectedItems.Count
                nupitemqty.Value = lvistocks.SelectedItems.Count
                nupitemqty.Enabled = False
                'MsgBox("selected item is greater than 1")
            ElseIf lvistocks.SelectedItems.Count = 0 Then
                nupitemqty.Enabled = False
                nupitemqty.Minimum = 0
                nupitemqty.Value = 0
                'MsgBox("selected item is 0")
            End If
        Next

    End Sub

    'Private Sub nupitemqty_ValueChanged(sender As Object, e As EventArgs) Handles nupitemqty.ValueChanged

    '    If txtsellingprice.Text <> "" Then
    '        Dim sellingprice As Long
    '        Try
    '            sellingprice = txtsellingprice.Text
    '        Catch ex As Exception
    '            MessageBox.Show("Price must only contain a number from 0 to 9 !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            txtsellingprice.Text = ""
    '            Exit Sub
    '        End Try
    '        txttotalsellingprice.Text = "Php " & Format((sellingprice * nupitemqty.Value), "0,00")
    '    Else
    '        txttotalsellingprice.Text = ""
    '    End If

    'End Sub

    'Private Sub txtsellingprice_TextChanged(sender As Object, e As EventArgs)

    '    If txtsellingprice.Text <> "" Then
    '        Dim sellingprice As Long
    '        Try
    '            sellingprice = txtsellingprice.Text
    '        Catch ex As Exception
    '            MessageBox.Show("Price must only contain a number from 0 to 9 !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            txtsellingprice.Text = ""
    '            Exit Sub
    '        End Try
    '        txttotalsellingprice.Text = "Php " & Format((sellingprice * nupitemqty.Value), "0,00")
    '    Else
    '        txttotalsellingprice.Text = ""
    '    End If

    'End Sub

    Private Sub btnselect_Click(sender As Object, e As EventArgs) Handles btnselect.Click

        If processtooperationortransaction = "operation" Then
            buttonselectprocessoperation()
        ElseIf processtooperationortransaction = "transaction" Then
            buttonselectprocesstransaction()
        End If

    End Sub

    Private Sub buttonselectprocessoperation()

        If lvistocks.SelectedItems.Count > 0 Then
            Dim counter As Integer = 0
            Dim quantity As Integer = 0
            Dim pricetominus As Integer = 0
            Dim itemtoremove As Integer = 0
            Dim allowexecution As Boolean
            Dim startcounter As Boolean
            Dim stopcounter As Boolean
            For Each item As ListViewItem In lvistocks.Items
                If lvistocks.SelectedItems.Count > 0 Then
                    item = lvistocks.SelectedItems.Item(0)

                    If frmchooseitemsandpersonel.lviitems.Items.Count = 0 Then
                        'MsgBox("Walay item sa chooseitemandpersonel")
                        Dim lvi As New ListViewItem(item.SubItems(0).Text)
                        lvi.SubItems.Add(item.SubItems(1).Text)
                        lvi.SubItems.Add(item.SubItems(2).Text)
                        lvi.SubItems.Add(item.SubItems(3).Text)
                        lvi.SubItems.Add(item.SubItems(4).Text)
                        lvi.SubItems.Add(item.SubItems(5).Text)
                        lvi.SubItems.Add(item.SubItems(6).Text)
                        lvi.SubItems.Add(nupitemqty.Value)
                        lvi.SubItems.Add(item.SubItems(8).Text)
                        lvi.SubItems.Add(item.SubItems(9).Text)
                        lvi.SubItems.Add(item.SubItems(9).Text)
                        lvi.SubItems.Add(nupitemqty.Value & " " & item.SubItems(8).Text)
                        Dim unitprice As Decimal = item.SubItems(9).Text.Replace("Php ", "")
                        Dim totalprice As Decimal = unitprice * nupitemqty.Value
                        If totalprice > 999 Then
                            lvi.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
                        ElseIf totalprice < 1000 Then
                            lvi.SubItems.Add("Php " & Format((totalprice), "0.00"))
                        End If
                        lvi.SubItems.Add(item.SubItems(12).Text)
                        lvi.SubItems.Add(item.SubItems(13).Text)
                        frmchooseitemsandpersonel.lviitems.Items.Add(lvi)
                        Dim totallvi As New ListViewItem(nupitemqty.Value)
                        totallvi.SubItems.Add(nupitemqty.Value & " " & item.SubItems(8).Text)
                        If item.SubItems(1).Text <> "" Then
                            totallvi.SubItems.Add(item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                        Else
                            totallvi.SubItems.Add(item.SubItems(0).Text)
                        End If
                        frmchooseitemsandpersonel.lvitotal.Items.Add(totallvi)
                        allowexecution = False
                    ElseIf frmchooseitemsandpersonel.lviitems.Items.Count > 0 Then
                        allowexecution = True
                        'MsgBox("Naay item sa chooseitemandpersonel")
                        For Each item1 As ListViewItem In frmchooseitemsandpersonel.lviitems.Items
                            item1.Selected = True
                        Next
                        For Each item1 As ListViewItem In frmchooseitemsandpersonel.lviitems.Items
                            item1 = frmchooseitemsandpersonel.lviitems.SelectedItems.Item(0)
                            If item1.SubItems(13).Text <> item.SubItems(12).Text Then
                                If counter = 1 Then
                                    counter = 1
                                Else
                                    counter = 0
                                End If

                                If stopcounter = False Then
                                    If startcounter = False Then
                                        itemtoremove = 0
                                        startcounter = True
                                        quantity = item1.SubItems(7).Text
                                    Else
                                        itemtoremove += 1
                                        startcounter = True
                                        quantity = item1.SubItems(7).Text
                                    End If
                                End If

                                'MsgBox("counter : " & counter)
                                'MsgBox(item1.SubItems(12).Text & " are not equal to " & item.SubItems(12).Text & " so counter is equals to " & counter)
                            ElseIf item1.SubItems(13).Text = item.SubItems(12).Text Then
                                counter = 1

                                If stopcounter = False Then
                                    If startcounter = False Then
                                        itemtoremove = 0
                                        startcounter = True
                                        stopcounter = True
                                        quantity = item1.SubItems(7).Text
                                    Else
                                        itemtoremove += 1
                                        startcounter = True
                                        stopcounter = True
                                        quantity = item1.SubItems(7).Text
                                    End If
                                End If

                                'MsgBox("counter : " & counter)
                                'MsgBox(item1.SubItems(12).Text & " are equal to " & item.SubItems(12).Text & " so counter is equals to " & counter)
                            End If
                            item1.Selected = False
                        Next
                    End If

                    If allowexecution = True Then
                        If counter = 0 Then
                            'MsgBox("Counter 0 function will be executed.")
                            Dim lvi1 As New ListViewItem(item.SubItems(0).Text)
                            lvi1.SubItems.Add(item.SubItems(1).Text)
                            lvi1.SubItems.Add(item.SubItems(2).Text)
                            lvi1.SubItems.Add(item.SubItems(3).Text)
                            lvi1.SubItems.Add(item.SubItems(4).Text)
                            lvi1.SubItems.Add(item.SubItems(5).Text)
                            lvi1.SubItems.Add(item.SubItems(6).Text)
                            lvi1.SubItems.Add(nupitemqty.Value)
                            lvi1.SubItems.Add(item.SubItems(8).Text)
                            lvi1.SubItems.Add(item.SubItems(9).Text)
                            lvi1.SubItems.Add(item.SubItems(9).Text)
                            lvi1.SubItems.Add(nupitemqty.Value & " " & item.SubItems(8).Text)
                            Dim unitprice As Decimal = item.SubItems(9).Text.Replace("Php ", "")
                            Dim totalprice As Decimal = unitprice * nupitemqty.Value
                            If totalprice > 999 Then
                                lvi1.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
                            ElseIf totalprice < 1000 Then
                                lvi1.SubItems.Add("Php " & Format((totalprice), "0.00"))
                            End If
                            lvi1.SubItems.Add(item.SubItems(12).Text)
                            lvi1.SubItems.Add(item.SubItems(13).Text)
                            frmchooseitemsandpersonel.lviitems.Items.Add(lvi1)
                            Dim totalitemquantity As Integer = 0
                            Dim indexofitemtoberemove As Integer = -1
                            Dim allowremove As Boolean
                            Dim stoper As Boolean
                            If item.SubItems(1).Text <> "" Then
                                'MsgBox("Naay type")
                                For Each totalitem As ListViewItem In frmchooseitemsandpersonel.lvitotal.Items
                                    If totalitem.SubItems(2).Text = item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")" Then
                                        'MsgBox(totalitem.SubItems(2).Text & " is equal to " & item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                                        totalitemquantity = totalitem.SubItems(0).Text
                                        indexofitemtoberemove += 1
                                        stoper = True
                                        allowremove = True
                                        'MsgBox("Initial index of item to remove is: " & indexofitemtoberemove)
                                    Else
                                        'MsgBox(totalitem.SubItems(2).Text & " is not equal to " & item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                                        If stoper <> True Then
                                            stoper = False
                                            indexofitemtoberemove += 1
                                        End If
                                        If allowremove <> True Then
                                            allowremove = False
                                        End If
                                        'MsgBox("Initial index of item to remove is: " & indexofitemtoberemove)
                                    End If
                                Next
                            ElseIf item.SubItems(1).Text = "" Then
                                'MsgBox("Walay type")
                                For Each totalitem As ListViewItem In frmchooseitemsandpersonel.lvitotal.Items
                                    If totalitem.SubItems(2).Text = item.SubItems(0).Text Then
                                        'MsgBox(totalitem.SubItems(2).Text & " is equal to " & item.SubItems(0).Text)
                                        totalitemquantity = totalitem.SubItems(0).Text
                                        indexofitemtoberemove += 1
                                        stoper = True
                                        allowremove = True
                                        'MsgBox("Initial index of item to remove is: " & indexofitemtoberemove)
                                    Else
                                        'MsgBox(totalitem.SubItems(2).Text & " is not equal to " & item.SubItems(0).Text)
                                        If stoper <> True Then
                                            stoper = False
                                            indexofitemtoberemove += 1
                                        End If
                                        If allowremove <> True Then
                                            allowremove = False
                                        End If
                                        'MsgBox("Initial index of item to remove is: " & indexofitemtoberemove)
                                    End If
                                Next
                            End If

                            If allowremove = True Then
                                'MsgBox("FINAL INDEX OF ITEM TO REMOVE: " & indexofitemtoberemove)
                                frmchooseitemsandpersonel.lvitotal.Items.Item(indexofitemtoberemove).Remove()
                            End If
                            Dim totalitem1 As New ListViewItem(totalitemquantity + nupitemqty.Value)
                            totalitem1.SubItems.Add("" & (totalitemquantity + nupitemqty.Value) & " " & item.SubItems(8).Text)
                            If item.SubItems(1).Text <> "" Then
                                totalitem1.SubItems.Add(item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                            Else
                                totalitem1.SubItems.Add(item.SubItems(0).Text)
                            End If
                            frmchooseitemsandpersonel.lvitotal.Items.Add(totalitem1)
                        ElseIf counter = 1 Then
                            'MsgBox("Counter 1 function will be executed.")
                            'MsgBox("Overwrite the index of " & itemtoremove & " with the quantity of " & quantity)
                            frmchooseitemsandpersonel.lviitems.Items.Item(itemtoremove).Remove()
                            Dim lvi2 As New ListViewItem(item.SubItems(0).Text)
                            lvi2.SubItems.Add(item.SubItems(1).Text)
                            lvi2.SubItems.Add(item.SubItems(2).Text)
                            lvi2.SubItems.Add(item.SubItems(3).Text)
                            lvi2.SubItems.Add(item.SubItems(4).Text)
                            lvi2.SubItems.Add(item.SubItems(5).Text)
                            lvi2.SubItems.Add(item.SubItems(6).Text)
                            lvi2.SubItems.Add(quantity + nupitemqty.Value)
                            lvi2.SubItems.Add(item.SubItems(8).Text)
                            lvi2.SubItems.Add(item.SubItems(9).Text)
                            lvi2.SubItems.Add(item.SubItems(9).Text)
                            lvi2.SubItems.Add(quantity + nupitemqty.Value & " " & item.SubItems(8).Text)
                            Dim unitprice As Decimal = item.SubItems(9).Text.Replace("Php ", "")
                            Dim newtotalprice As Decimal = unitprice * (quantity + nupitemqty.Value)
                            If newtotalprice > 999 Then
                                lvi2.SubItems.Add("Php " & Format((newtotalprice), "0,00.00")) ' total price
                            ElseIf newtotalprice < 1000 Then
                                lvi2.SubItems.Add("Php " & Format((newtotalprice), "0.00")) ' total price
                            End If
                            lvi2.SubItems.Add(item.SubItems(12).Text)
                            lvi2.SubItems.Add(item.SubItems(13).Text)
                            frmchooseitemsandpersonel.lviitems.Items.Add(lvi2)
                            Dim totalitemquantity As Integer = 0
                            Dim indexofitemtoberemove As Integer = -1
                            Dim allowremove As Boolean
                            Dim stoper As Boolean
                            If item.SubItems(1).Text <> "" Then
                                'MsgBox("Naay type")
                                For Each totalitem As ListViewItem In frmchooseitemsandpersonel.lvitotal.Items
                                    If totalitem.SubItems(2).Text = item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")" Then
                                        'MsgBox(totalitem.SubItems(2).Text & " is equal to " & item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                                        totalitemquantity = totalitem.SubItems(0).Text
                                        indexofitemtoberemove += 1
                                        stoper = True
                                        allowremove = True
                                        'MsgBox("Initial index of item to remove is: " & indexofitemtoberemove)
                                    Else
                                        'MsgBox(totalitem.SubItems(2).Text & " is not equal to " & item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                                        If stoper <> True Then
                                            stoper = False
                                            indexofitemtoberemove += 1
                                        End If
                                        If allowremove <> True Then
                                            allowremove = False
                                        End If
                                        'MsgBox("Initial index of item to remove is: " & indexofitemtoberemove)
                                    End If
                                Next
                            ElseIf item.SubItems(1).Text = "" Then
                                'MsgBox("Walay type")
                                For Each totalitem As ListViewItem In frmchooseitemsandpersonel.lvitotal.Items
                                    If totalitem.SubItems(2).Text = item.SubItems(0).Text Then
                                        'MsgBox(totalitem.SubItems(2).Text & " is equal to " & item.SubItems(0).Text)
                                        totalitemquantity = totalitem.SubItems(0).Text
                                        indexofitemtoberemove += 1
                                        stoper = True
                                        allowremove = True
                                        'MsgBox("Initial index of item to remove is: " & indexofitemtoberemove)
                                    Else
                                        'MsgBox(totalitem.SubItems(2).Text & " is not equal to " & item.SubItems(0).Text)
                                        If stoper <> True Then
                                            stoper = False
                                            indexofitemtoberemove += 1
                                        End If
                                        If allowremove <> True Then
                                            allowremove = False
                                        End If
                                        'MsgBox("Initial index of item to remove is: " & indexofitemtoberemove)
                                    End If
                                Next
                            End If

                            If allowremove = True Then
                                'MsgBox("FINAL INDEX OF ITEM TO REMOVE: " & indexofitemtoberemove)
                                frmchooseitemsandpersonel.lvitotal.Items.Item(indexofitemtoberemove).Remove()
                            End If
                            Dim totalitem1 As New ListViewItem(totalitemquantity + nupitemqty.Value)
                            totalitem1.SubItems.Add("" & (totalitemquantity + nupitemqty.Value) & " " & item.SubItems(8).Text)
                            If item.SubItems(1).Text <> "" Then
                                totalitem1.SubItems.Add(item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                            Else
                                totalitem1.SubItems.Add(item.SubItems(0).Text)
                            End If
                            frmchooseitemsandpersonel.lvitotal.Items.Add(totalitem1)
                        End If
                    End If

                    If item.SubItems(7).Text = 1 Then
                        item.Remove()
                    ElseIf item.SubItems(7).Text > 1 Then
                        Dim newquantity As Integer
                        Dim lvi2 As New ListViewItem(item.SubItems(0).Text)
                        lvi2.SubItems.Add(item.SubItems(1).Text)
                        lvi2.SubItems.Add(item.SubItems(2).Text)
                        lvi2.SubItems.Add(item.SubItems(3).Text)
                        lvi2.SubItems.Add(item.SubItems(4).Text)
                        lvi2.SubItems.Add(item.SubItems(5).Text)
                        lvi2.SubItems.Add(item.SubItems(6).Text)
                        newquantity = item.SubItems(7).Text - nupitemqty.Value
                        lvi2.SubItems.Add(newquantity)
                        lvi2.SubItems.Add(item.SubItems(8).Text)
                        lvi2.SubItems.Add(item.SubItems(9).Text)
                        lvi2.SubItems.Add(item.SubItems(7).Text - nupitemqty.Value & " " & item.SubItems(8).Text)
                        Dim unitprice As Decimal = item.SubItems(9).Text.Replace("Php ", "")
                        Dim currenttotalprice As Decimal = item.SubItems(11).Text.Replace("Php ", "")
                        Dim totalprice As Decimal = currenttotalprice - (unitprice * nupitemqty.Value)
                        If totalprice > 999 Then
                            lvi2.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
                        ElseIf totalprice < 1000 Then
                            lvi2.SubItems.Add("Php " & Format((totalprice), "0.00"))
                        End If
                        lvi2.SubItems.Add(item.SubItems(12).Text)
                        lvi2.SubItems.Add(item.SubItems(13).Text)
                        If newquantity > 0 Then
                            lvistocks.Items.Add(lvi2)
                        End If
                        item.Remove()
                    End If
                End If
            Next
            lvispecs.Items.Clear()

            frmmain.lviitems.Items.Clear()
            For Each totalitem As ListViewItem In frmchooseitemsandpersonel.lvitotal.Items
                Dim assignedpersonel As New ListViewItem(totalitem.SubItems(1).Text & " - " & totalitem.SubItems(2).Text)
                frmmain.lviitems.Items.Add(assignedpersonel)
            Next

            Dim newgrandtotalinstocks As Decimal
            For Each remainingitems As ListViewItem In lvistocks.Items
                newgrandtotalinstocks += remainingitems.SubItems(11).Text.Replace("Php ", "")
            Next
            If newgrandtotalinstocks > 999 Then
                txttotalprice.Text = "Php " & Format((newgrandtotalinstocks), "0,00.00")
            ElseIf newgrandtotalinstocks > 0 And newgrandtotalinstocks < 1000 Then
                txttotalprice.Text = "Php " & Format((newgrandtotalinstocks), "0.00")
            ElseIf newgrandtotalinstocks = 0 Then
                txttotalprice.Text = ""
            End If

            Dim grandtotal As Decimal
            For Each selecteditem As ListViewItem In frmchooseitemsandpersonel.lviitems.Items
                grandtotal += selecteditem.SubItems(12).Text.Replace("Php ", "")
            Next
            If grandtotal > 999 Then
                frmchooseitemsandpersonel.txttotalprice.Text = "Php " & Format((grandtotal), "0,00.00")
            ElseIf grandtotal > 0 And grandtotal < 1000 Then
                frmchooseitemsandpersonel.txttotalprice.Text = "Php " & Format((grandtotal), "0.00")
            ElseIf grandtotal = 0 Then
                frmchooseitemsandpersonel.txttotalprice.Text = ""
            End If
            lvistocks.Sort()
        Else
            MessageBox.Show("Please select an item.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub buttonselectprocesstransaction()

        If lvistocks.SelectedItems.Count > 0 Then
            Dim counter As Integer = 0
            Dim quantity As Integer = 0
            Dim pricetominus As Integer = 0
            Dim itemtoremove As Integer = 0
            Dim allowexecution As Boolean
            Dim startcounter As Boolean
            Dim stopcounter As Boolean
            For Each item As ListViewItem In lvistocks.Items
                MsgBox("test")
                If lvistocks.SelectedItems.Count > 0 Then
                    item = lvistocks.SelectedItems.Item(0)
                    MsgBox("selected item is greater than 0")
                    If frmsolditem.lviitems.Items.Count = 0 Then
                        'MsgBox("Walay item sa chooseitemandpersonel")
                        Dim lvi As New ListViewItem(item.SubItems(0).Text)
                        lvi.SubItems.Add(item.SubItems(1).Text)
                        lvi.SubItems.Add(item.SubItems(2).Text)
                        lvi.SubItems.Add(item.SubItems(3).Text)
                        lvi.SubItems.Add(item.SubItems(4).Text)
                        lvi.SubItems.Add(item.SubItems(5).Text)
                        lvi.SubItems.Add(item.SubItems(6).Text)
                        lvi.SubItems.Add(nupitemqty.Value)
                        lvi.SubItems.Add(item.SubItems(8).Text)
                        lvi.SubItems.Add(item.SubItems(9).Text)
                        lvi.SubItems.Add(item.SubItems(9).Text)
                        lvi.SubItems.Add(nupitemqty.Value & " " & item.SubItems(8).Text)
                        Dim unitprice As Decimal = item.SubItems(9).Text.Replace("Php ", "")
                        Dim totalprice As Decimal = unitprice * nupitemqty.Value
                        If totalprice > 999 Then
                            lvi.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
                        ElseIf totalprice < 1000 Then
                            lvi.SubItems.Add("Php " & Format((totalprice), "0.00"))
                        End If
                        lvi.SubItems.Add(item.SubItems(12).Text)
                        lvi.SubItems.Add(item.SubItems(13).Text)
                        frmsolditem.lviitems.Items.Add(lvi)
                        Dim totallvi As New ListViewItem(nupitemqty.Value)
                        totallvi.SubItems.Add(nupitemqty.Value & " " & item.SubItems(8).Text)
                        If item.SubItems(1).Text <> "" Then
                            totallvi.SubItems.Add(item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                        Else
                            totallvi.SubItems.Add(item.SubItems(0).Text)
                        End If
                        frmsolditem.lvitotal.Items.Add(totallvi)
                        allowexecution = False
                    ElseIf frmsolditem.lviitems.Items.Count > 0 Then
                        allowexecution = True
                        'MsgBox("Naay item sa chooseitemandpersonel")
                        For Each item1 As ListViewItem In frmsolditem.lviitems.Items
                            item1.Selected = True
                        Next
                        For Each item1 As ListViewItem In frmsolditem.lviitems.Items
                            item1 = frmsolditem.lviitems.SelectedItems.Item(0)
                            If item1.SubItems(13).Text <> item.SubItems(12).Text Then
                                If counter = 1 Then
                                    counter = 1
                                Else
                                    counter = 0
                                End If

                                If stopcounter = False Then
                                    If startcounter = False Then
                                        itemtoremove = 0
                                        startcounter = True
                                        quantity = item1.SubItems(7).Text
                                    Else
                                        itemtoremove += 1
                                        startcounter = True
                                        quantity = item1.SubItems(7).Text
                                    End If
                                End If

                                'MsgBox("counter : " & counter)
                                'MsgBox(item1.SubItems(12).Text & " are not equal to " & item.SubItems(12).Text & " so counter is equals to " & counter)
                            ElseIf item1.SubItems(13).Text = item.SubItems(12).Text Then
                                counter = 1

                                If stopcounter = False Then
                                    If startcounter = False Then
                                        itemtoremove = 0
                                        startcounter = True
                                        stopcounter = True
                                        quantity = item1.SubItems(7).Text
                                    Else
                                        itemtoremove += 1
                                        startcounter = True
                                        stopcounter = True
                                        quantity = item1.SubItems(7).Text
                                    End If
                                End If

                                'MsgBox("counter : " & counter)
                                'MsgBox(item1.SubItems(12).Text & " are equal to " & item.SubItems(12).Text & " so counter is equals to " & counter)
                            End If
                            item1.Selected = False
                        Next
                    End If

                    If allowexecution = True Then
                        If counter = 0 Then
                            'MsgBox("Counter 0 function will be executed.")
                            Dim lvi1 As New ListViewItem(item.SubItems(0).Text)
                            lvi1.SubItems.Add(item.SubItems(1).Text)
                            lvi1.SubItems.Add(item.SubItems(2).Text)
                            lvi1.SubItems.Add(item.SubItems(3).Text)
                            lvi1.SubItems.Add(item.SubItems(4).Text)
                            lvi1.SubItems.Add(item.SubItems(5).Text)
                            lvi1.SubItems.Add(item.SubItems(6).Text)
                            lvi1.SubItems.Add(nupitemqty.Value)
                            lvi1.SubItems.Add(item.SubItems(8).Text)
                            lvi1.SubItems.Add(item.SubItems(9).Text)
                            lvi1.SubItems.Add(item.SubItems(9).Text)
                            lvi1.SubItems.Add(nupitemqty.Value & " " & item.SubItems(8).Text)
                            Dim unitprice As Decimal = item.SubItems(9).Text.Replace("Php ", "")
                            Dim totalprice As Decimal = unitprice * nupitemqty.Value
                            If totalprice > 999 Then
                                lvi1.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
                            ElseIf totalprice < 1000 Then
                                lvi1.SubItems.Add("Php " & Format((totalprice), "0.00"))
                            End If
                            lvi1.SubItems.Add(item.SubItems(12).Text)
                            lvi1.SubItems.Add(item.SubItems(13).Text)
                            frmsolditem.lviitems.Items.Add(lvi1)
                            Dim totalitemquantity As Integer = 0
                            Dim indexofitemtoberemove As Integer = -1
                            Dim allowremove As Boolean
                            Dim stoper As Boolean
                            If item.SubItems(1).Text <> "" Then
                                'MsgBox("Naay type")
                                For Each totalitem As ListViewItem In frmsolditem.lvitotal.Items
                                    If totalitem.SubItems(2).Text = item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")" Then
                                        'MsgBox(totalitem.SubItems(2).Text & " is equal to " & item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                                        totalitemquantity = totalitem.SubItems(0).Text
                                        indexofitemtoberemove += 1
                                        stoper = True
                                        allowremove = True
                                        'MsgBox("Initial index of item to remove is: " & indexofitemtoberemove)
                                    Else
                                        'MsgBox(totalitem.SubItems(2).Text & " is not equal to " & item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                                        If stoper <> True Then
                                            stoper = False
                                            indexofitemtoberemove += 1
                                        End If
                                        If allowremove <> True Then
                                            allowremove = False
                                        End If
                                        'MsgBox("Initial index of item to remove is: " & indexofitemtoberemove)
                                    End If
                                Next
                            ElseIf item.SubItems(1).Text = "" Then
                                'MsgBox("Walay type")
                                For Each totalitem As ListViewItem In frmsolditem.lvitotal.Items
                                    If totalitem.SubItems(2).Text = item.SubItems(0).Text Then
                                        'MsgBox(totalitem.SubItems(2).Text & " is equal to " & item.SubItems(0).Text)
                                        totalitemquantity = totalitem.SubItems(0).Text
                                        indexofitemtoberemove += 1
                                        stoper = True
                                        allowremove = True
                                        'MsgBox("Initial index of item to remove is: " & indexofitemtoberemove)
                                    Else
                                        'MsgBox(totalitem.SubItems(2).Text & " is not equal to " & item.SubItems(0).Text)
                                        If stoper <> True Then
                                            stoper = False
                                            indexofitemtoberemove += 1
                                        End If
                                        If allowremove <> True Then
                                            allowremove = False
                                        End If
                                        'MsgBox("Initial index of item to remove is: " & indexofitemtoberemove)
                                    End If
                                Next
                            End If

                            If allowremove = True Then
                                'MsgBox("FINAL INDEX OF ITEM TO REMOVE: " & indexofitemtoberemove)
                                frmsolditem.lvitotal.Items.Item(indexofitemtoberemove).Remove()
                            End If
                            Dim totalitem1 As New ListViewItem(totalitemquantity + nupitemqty.Value)
                            totalitem1.SubItems.Add("" & (totalitemquantity + nupitemqty.Value) & " " & item.SubItems(8).Text)
                            If item.SubItems(1).Text <> "" Then
                                totalitem1.SubItems.Add(item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                            Else
                                totalitem1.SubItems.Add(item.SubItems(0).Text)
                            End If
                            frmsolditem.lvitotal.Items.Add(totalitem1)
                        ElseIf counter = 1 Then
                            'MsgBox("Counter 1 function will be executed.")
                            'MsgBox("Overwrite the index of " & itemtoremove & " with the quantity of " & quantity)
                            frmsolditem.lviitems.Items.Item(itemtoremove).Remove()
                            Dim lvi2 As New ListViewItem(item.SubItems(0).Text)
                            lvi2.SubItems.Add(item.SubItems(1).Text)
                            lvi2.SubItems.Add(item.SubItems(2).Text)
                            lvi2.SubItems.Add(item.SubItems(3).Text)
                            lvi2.SubItems.Add(item.SubItems(4).Text)
                            lvi2.SubItems.Add(item.SubItems(5).Text)
                            lvi2.SubItems.Add(item.SubItems(6).Text)
                            lvi2.SubItems.Add(quantity + nupitemqty.Value)
                            lvi2.SubItems.Add(item.SubItems(8).Text)
                            lvi2.SubItems.Add(item.SubItems(9).Text)
                            lvi2.SubItems.Add(item.SubItems(9).Text)
                            lvi2.SubItems.Add(quantity + nupitemqty.Value & " " & item.SubItems(8).Text)
                            Dim unitprice As Decimal = item.SubItems(9).Text.Replace("Php ", "")
                            Dim newtotalprice As Decimal = unitprice * (quantity + nupitemqty.Value)
                            If newtotalprice > 999 Then
                                lvi2.SubItems.Add("Php " & Format((newtotalprice), "0,00.00")) ' total price
                            ElseIf newtotalprice < 1000 Then
                                lvi2.SubItems.Add("Php " & Format((newtotalprice), "0.00")) ' total price
                            End If
                            lvi2.SubItems.Add(item.SubItems(12).Text)
                            lvi2.SubItems.Add(item.SubItems(13).Text)
                            frmsolditem.lviitems.Items.Add(lvi2)
                            Dim totalitemquantity As Integer = 0
                            Dim indexofitemtoberemove As Integer = -1
                            Dim allowremove As Boolean
                            Dim stoper As Boolean
                            If item.SubItems(1).Text <> "" Then
                                'MsgBox("Naay type")
                                For Each totalitem As ListViewItem In frmsolditem.lvitotal.Items
                                    If totalitem.SubItems(2).Text = item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")" Then
                                        'MsgBox(totalitem.SubItems(2).Text & " is equal to " & item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                                        totalitemquantity = totalitem.SubItems(0).Text
                                        indexofitemtoberemove += 1
                                        stoper = True
                                        allowremove = True
                                        'MsgBox("Initial index of item to remove is: " & indexofitemtoberemove)
                                    Else
                                        'MsgBox(totalitem.SubItems(2).Text & " is not equal to " & item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                                        If stoper <> True Then
                                            stoper = False
                                            indexofitemtoberemove += 1
                                        End If
                                        If allowremove <> True Then
                                            allowremove = False
                                        End If
                                        'MsgBox("Initial index of item to remove is: " & indexofitemtoberemove)
                                    End If
                                Next
                            ElseIf item.SubItems(1).Text = "" Then
                                'MsgBox("Walay type")
                                For Each totalitem As ListViewItem In frmsolditem.lvitotal.Items
                                    If totalitem.SubItems(2).Text = item.SubItems(0).Text Then
                                        'MsgBox(totalitem.SubItems(2).Text & " is equal to " & item.SubItems(0).Text)
                                        totalitemquantity = totalitem.SubItems(0).Text
                                        indexofitemtoberemove += 1
                                        stoper = True
                                        allowremove = True
                                        'MsgBox("Initial index of item to remove is: " & indexofitemtoberemove)
                                    Else
                                        'MsgBox(totalitem.SubItems(2).Text & " is not equal to " & item.SubItems(0).Text)
                                        If stoper <> True Then
                                            stoper = False
                                            indexofitemtoberemove += 1
                                        End If
                                        If allowremove <> True Then
                                            allowremove = False
                                        End If
                                        'MsgBox("Initial index of item to remove is: " & indexofitemtoberemove)
                                    End If
                                Next
                            End If

                            If allowremove = True Then
                                'MsgBox("FINAL INDEX OF ITEM TO REMOVE: " & indexofitemtoberemove)
                                frmsolditem.lvitotal.Items.Item(indexofitemtoberemove).Remove()
                            End If
                            Dim totalitem1 As New ListViewItem(totalitemquantity + nupitemqty.Value)
                            totalitem1.SubItems.Add("" & (totalitemquantity + nupitemqty.Value) & " " & item.SubItems(8).Text)
                            If item.SubItems(1).Text <> "" Then
                                totalitem1.SubItems.Add(item.SubItems(0).Text & " (" & item.SubItems(1).Text & ")")
                            Else
                                totalitem1.SubItems.Add(item.SubItems(0).Text)
                            End If
                            frmsolditem.lvitotal.Items.Add(totalitem1)
                        End If
                    End If
                    'MsgBox("naa naku diri removing")
                    If item.SubItems(7).Text = 1 Then
                        item.Remove()
                    ElseIf item.SubItems(7).Text > 1 Then
                        Dim newquantity As Integer
                        Dim lvi2 As New ListViewItem(item.SubItems(0).Text)
                        lvi2.SubItems.Add(item.SubItems(1).Text)
                        lvi2.SubItems.Add(item.SubItems(2).Text)
                        lvi2.SubItems.Add(item.SubItems(3).Text)
                        lvi2.SubItems.Add(item.SubItems(4).Text)
                        lvi2.SubItems.Add(item.SubItems(5).Text)
                        lvi2.SubItems.Add(item.SubItems(6).Text)
                        newquantity = item.SubItems(7).Text - nupitemqty.Value
                        lvi2.SubItems.Add(newquantity)
                        lvi2.SubItems.Add(item.SubItems(8).Text)
                        lvi2.SubItems.Add(item.SubItems(9).Text)
                        lvi2.SubItems.Add(item.SubItems(7).Text - nupitemqty.Value & " " & item.SubItems(8).Text)
                        Dim unitprice As Decimal = item.SubItems(9).Text.Replace("Php ", "")
                        Dim currenttotalprice As Decimal = item.SubItems(11).Text.Replace("Php ", "")
                        Dim totalprice As Decimal = currenttotalprice - (unitprice * nupitemqty.Value)
                        If totalprice > 999 Then
                            lvi2.SubItems.Add("Php " & Format((totalprice), "0,00.00"))
                        ElseIf totalprice < 1000 Then
                            lvi2.SubItems.Add("Php " & Format((totalprice), "0.00"))
                        End If
                        lvi2.SubItems.Add(item.SubItems(12).Text)
                        lvi2.SubItems.Add(item.SubItems(13).Text)
                        If newquantity > 0 Then
                            lvistocks.Items.Add(lvi2)
                        End If
                        item.Remove()
                    End If
                End If
            Next
            lvispecs.Items.Clear()

            frmmain.lvitotal.Items.Clear()
            For Each totalitem As ListViewItem In frmsolditem.lvitotal.Items
                Dim assignedpersonel As New ListViewItem(totalitem.SubItems(1).Text & " - " & totalitem.SubItems(2).Text)
                frmmain.lvitotal.Items.Add(assignedpersonel)
            Next

            Dim newgrandtotalinstocks As Decimal
            For Each remainingitems As ListViewItem In lvistocks.Items
                newgrandtotalinstocks += remainingitems.SubItems(11).Text.Replace("Php ", "")
            Next
            If newgrandtotalinstocks > 999 Then
                txttotalprice.Text = "Php " & Format((newgrandtotalinstocks), "0,00.00")
            ElseIf newgrandtotalinstocks > 0 And newgrandtotalinstocks < 1000 Then
                txttotalprice.Text = "Php " & Format((newgrandtotalinstocks), "0.00")
            ElseIf newgrandtotalinstocks = 0 Then
                txttotalprice.Text = ""
            End If

            Dim grandtotal As Decimal
            For Each selecteditem As ListViewItem In frmsolditem.lviitems.Items
                grandtotal += selecteditem.SubItems(12).Text.Replace("Php ", "")
            Next
            If grandtotal > 999 Then
                frmsolditem.txttotalprice.Text = "Php " & Format((grandtotal), "0,00.00")
            ElseIf grandtotal > 0 And grandtotal < 1000 Then
                frmsolditem.txttotalprice.Text = "Php " & Format((grandtotal), "0.00")
            ElseIf grandtotal = 0 Then
                frmsolditem.txttotalprice.Text = ""
            End If
            lvistocks.Sort()
        Else
            MessageBox.Show("Please select an item.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub processtransaction()



    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click

        Me.Close()

    End Sub

    Private Sub cbosearchstocks_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbosearchstocks.SelectedIndexChanged

        txtsearchstocks.Text = ""

    End Sub
End Class