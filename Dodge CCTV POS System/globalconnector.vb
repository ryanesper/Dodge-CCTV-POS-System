Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text

Module globalconnector

    Public con As New MySqlConnection
    Public cmd As New MySqlCommand
    Public reader As MySqlDataReader
    Public sqlda As New MySqlDataAdapter
    Public ds As New DataSet

    Public productfinalizeid As String

    Public adminid, firstname, middlename, lastname, username, password As String
    Public rtl0 As String = ""
    Public rtl1 = "", rtl2 = "", rtl3 = "", rtl4 = "", rtl5 = "", rtl6 = "", rtl7 = "", rtl8 = "", rtl9 = "", rtl10 = "", rtl11 = "", rtl12 = "", rtl13 = "", rtl14 As String = ""
    Public operationnumber, productmode As String
    Public cmddelete, confirm As String
    Public fvproduct As String

    Public generateidforproduct As Boolean
    Public loadcomboboxiteminproduct As Boolean
    Public loaduseditemsinoperation As Boolean
    'Public loadoperationassignedpersonel As Boolean
    Public loadsolditemsinoperationtosales As Boolean
    Public loaduseditemsinoperationtosales As Boolean
    Public selectedidinsales As String
    Public newtransactioninsales As Boolean
    Public processtooperationortransaction As String
    Public retialin As String

    Public Sub openconnection()

        If con.State = ConnectionState.Closed Then
            'con.ConnectionString = "Server=localhost; User ID=root; Password=ryan; Database=cctvdodge"
            'con.ConnectionString = "Server = " & My.Settings.server & "; User ID = " & My.Settings.user & "; Password = " & My.Settings.password & "; Database = " & My.Settings.database & ";"
            con.ConnectionString = "Server = " & My.Settings.serversettings & "; User ID = " & My.Settings.usersettings & "; Password = " & My.Settings.passwordsettings & "; Database = " & My.Settings.databasesettings & ";"
            con.Open()
            cmd.Connection = con
        End If

    End Sub

    Public Sub productidgeneratorver3()

        openconnection()
        Dim idinitial As String = "v3PROD"
        Dim counter As Integer = 1
        Dim idnumber As String = "00"
        productfinalizeid = idinitial & idnumber & counter.ToString
        Dim isidexists As Boolean = True

        reader.Close()
        cmd.CommandText = "select product_id from tbl_transaction_item_sold where product_id = '" & productfinalizeid & "'"
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
                cmd.CommandText = "select product_id from tbl_transaction_item_sold where product_id = '" & productfinalizeid & "'"
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

    Public Sub productidgeneratorver2()

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

    Public Sub productidgenerator()

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

    Public Sub displayoperation()

        frmmain.lviopr.Items.Clear()
        openconnection()
        cmd = New MySqlCommand("select * from tbl_operations", con)
        reader = cmd.ExecuteReader
        While (reader.Read())
            Dim operation As New ListViewItem(reader("operation_id").ToString())
            operation.SubItems.Add(reader("contract_name").ToString())
            operation.SubItems.Add(reader("client").ToString())
            operation.SubItems.Add(reader("location").ToString())
            operation.SubItems.Add(reader("status").ToString())
            frmmain.lviopr.Items.Add(operation)
        End While
        reader.Close()

    End Sub

    Public Sub displaystocks()

        frmmain.lvistocks.Items.Clear()
        openconnection()
        Dim grandtotal As Decimal
        Dim qty As Integer = 0
        cmd = New MySqlCommand("select * from tbl_stocks", con)
        reader = cmd.ExecuteReader
        While (reader.Read())
            Dim lvi As New ListViewItem(reader("product").ToString())
            lvi.SubItems.Add(reader("type").ToString())
            lvi.SubItems.Add(reader("brand").ToString())
            lvi.SubItems.Add(reader("supplier").ToString())
            lvi.SubItems.Add(reader("serial").ToString())
            lvi.SubItems.Add(reader("model").ToString())
            lvi.SubItems.Add(reader("arrival_date").ToString())
            lvi.SubItems.Add(reader("quantity").ToString())
            qty += reader("quantity").ToString()
            lvi.SubItems.Add(reader("unit").ToString())
            Dim unit_price As Decimal = reader("unit_price").ToString()
            If unit_price > 999 Then
                lvi.SubItems.Add("Php " & Format((unit_price), "0,00.00"))
            ElseIf unit_price < 1000 Then
                lvi.SubItems.Add("Php " & Format((unit_price), "0.00"))
            End If
            lvi.SubItems.Add(reader("quantity_unit").ToString())
            Dim total_price As Decimal = reader("totalprice").ToString
            If total_price > 999 Then
                lvi.SubItems.Add("Php " & Format((total_price), "0,00.00"))
            ElseIf total_price < 1000 Then
                lvi.SubItems.Add("Php " & Format((total_price), "0.00"))
            End If
            grandtotal += total_price
            lvi.SubItems.Add(reader("product_id").ToString())
            frmmain.lvistocks.Items.Add(lvi)
        End While
        reader.Close()
        If qty = 0 Then
            frmmain.txtquantity.Text = ""
        ElseIf qty > 0 Then
            frmmain.txtquantity.Text = qty
        End If
        If grandtotal <> 0 Then
            If grandtotal > 999 Then
                frmmain.txttotalprice.Text = "Php " & Format((grandtotal), "0,00.00")
            ElseIf grandtotal < 1000 Then
                frmmain.txttotalprice.Text = "Php " & Format((grandtotal), "0.00")
            End If
        Else
            frmmain.txttotalprice.Text = ""
        End If

    End Sub

    Public Sub filterstocks()

        frmmain.lvistocks.Items.Clear()
        openconnection()
        Dim grandtotal As Decimal
        Dim qty As Integer = 0
        cmd = New MySqlCommand("select * from tbl_stocks where product = '" & frmmain.cboproduct.Text & "'", con)
        reader = cmd.ExecuteReader
        While (reader.Read())
            Dim lvi As New ListViewItem(reader("product").ToString())
            lvi.SubItems.Add(reader("type").ToString())
            lvi.SubItems.Add(reader("brand").ToString())
            lvi.SubItems.Add(reader("supplier").ToString())
            lvi.SubItems.Add(reader("serial").ToString())
            lvi.SubItems.Add(reader("model").ToString())
            lvi.SubItems.Add(reader("arrival_date").ToString())
            lvi.SubItems.Add(reader("quantity").ToString())
            qty += reader("quantity").ToString()
            lvi.SubItems.Add(reader("unit").ToString())
            Dim unit_price As Decimal = reader("unit_price").ToString()
            If unit_price > 999 Then
                lvi.SubItems.Add("Php " & Format((unit_price), "0,00.00"))
            ElseIf unit_price < 1000 Then
                lvi.SubItems.Add("Php " & Format((unit_price), "0.00"))
            End If
            lvi.SubItems.Add(reader("quantity_unit").ToString())
            Dim total_price As Decimal = reader("totalprice").ToString
            If total_price > 999 Then
                lvi.SubItems.Add("Php " & Format((total_price), "0,00.00"))
            ElseIf total_price < 1000 Then
                lvi.SubItems.Add("Php " & Format((total_price), "0.00"))
            End If
            grandtotal += total_price
            lvi.SubItems.Add(reader("product_id").ToString())
            frmmain.lvistocks.Items.Add(lvi)
        End While
        reader.Close()
        If qty = 0 Then
            frmmain.txtquantity.Text = ""
        ElseIf qty > 0 Then
            frmmain.txtquantity.Text = qty
        End If
        If grandtotal <> 0 Then
            If grandtotal > 999 Then
                frmmain.txttotalprice.Text = "Php " & Format((grandtotal), "0,00.00")
            ElseIf grandtotal < 1000 Then
                frmmain.txttotalprice.Text = "Php " & Format((grandtotal), "0.00")
            End If
        Else
            frmmain.txttotalprice.Text = ""
        End If

    End Sub

    Public Sub displayitemtouse()

        frmselectfromstocks.lvistocks.Items.Clear()
        openconnection()
        Dim grandtotal As Decimal
        cmd = New MySqlCommand("select * from tbl_stocks", con)
        reader = cmd.ExecuteReader
        While (reader.Read())
            Dim lvi As New ListViewItem(reader("product").ToString())
            lvi.SubItems.Add(reader("type").ToString())
            lvi.SubItems.Add(reader("brand").ToString())
            lvi.SubItems.Add(reader("supplier").ToString())
            lvi.SubItems.Add(reader("serial").ToString())
            lvi.SubItems.Add(reader("model").ToString())
            lvi.SubItems.Add(reader("arrival_date").ToString())
            lvi.SubItems.Add(reader("quantity").ToString())
            lvi.SubItems.Add(reader("unit").ToString())
            Dim unit_price As Decimal = reader("unit_price").ToString()
            If unit_price > 999 Then
                lvi.SubItems.Add("Php " & Format((unit_price), "0,00.00"))
            ElseIf unit_price < 1000 Then
                lvi.SubItems.Add("Php " & Format((unit_price), "0.00"))
            End If
            lvi.SubItems.Add(reader("quantity_unit").ToString())
            Dim total_price As Decimal = reader("totalprice").ToString
            If total_price > 999 Then
                lvi.SubItems.Add("Php " & Format((total_price), "0,00.00"))
            ElseIf unit_price < 1000 Then
                lvi.SubItems.Add("Php " & Format((total_price), "0.00"))
            End If
            grandtotal += total_price
            lvi.SubItems.Add(reader("product_id").ToString())
            lvi.SubItems.Add(reader("status").ToString())
            frmselectfromstocks.lvistocks.Items.Add(lvi)
        End While
        reader.Close()
        If grandtotal <> 0 Then
            If grandtotal > 999 Then
                frmselectfromstocks.txttotalprice.Text = "Php " & Format((grandtotal), "0,00.00")
            ElseIf grandtotal < 1000 Then
                frmselectfromstocks.txttotalprice.Text = "Php " & Format((grandtotal), "0.00")
            End If
        Else
            frmselectfromstocks.txttotalprice.Text = ""
        End If

    End Sub

    Public Sub filteritemtouse()

        frmselectfromstocks.lvistocks.Items.Clear()
        openconnection()
        Dim grandtotal As Decimal
        cmd = New MySqlCommand("select * from tbl_stocks where product = '" & frmselectfromstocks.cboproduct.Text & "'", con)
        reader = cmd.ExecuteReader
        While (reader.Read())
            Dim lvi As New ListViewItem(reader("product").ToString())
            lvi.SubItems.Add(reader("type").ToString())
            lvi.SubItems.Add(reader("brand").ToString())
            lvi.SubItems.Add(reader("supplier").ToString())
            lvi.SubItems.Add(reader("serial").ToString())
            lvi.SubItems.Add(reader("model").ToString())
            lvi.SubItems.Add(reader("arrival_date").ToString())
            lvi.SubItems.Add(reader("quantity").ToString())
            lvi.SubItems.Add(reader("unit").ToString())
            Dim unit_price As Decimal = reader("unit_price").ToString()
            If unit_price > 999 Then
                lvi.SubItems.Add("Php " & Format((unit_price), "0,00.00"))
            ElseIf unit_price < 1000 Then
                lvi.SubItems.Add("Php " & Format((unit_price), "0.00"))
            End If
            lvi.SubItems.Add(reader("quantity_unit").ToString())
            Dim total_price As Decimal = reader("totalprice").ToString
            If total_price > 999 Then
                lvi.SubItems.Add("Php " & Format((total_price), "0,00.00"))
            ElseIf total_price < 1000 Then
                lvi.SubItems.Add("Php " & Format((total_price), "0.00"))
            End If
            grandtotal += total_price
            lvi.SubItems.Add(reader("product_id").ToString())
            lvi.SubItems.Add(reader("status").ToString())
            frmselectfromstocks.lvistocks.Items.Add(lvi)
        End While
        reader.Close()
        If grandtotal <> 0 Then
            If grandtotal > 999 Then
                frmselectfromstocks.txttotalprice.Text = "Php " & Format((grandtotal), "0,00.00")
            ElseIf grandtotal < 1000 Then
                frmselectfromstocks.txttotalprice.Text = "Php " & Format((grandtotal), "0.00")
            End If
        Else
            frmselectfromstocks.txttotalprice.Text = ""
        End If

    End Sub

    Public Sub operationitemsalesexpanddipslay()

        Dim initalgrandtotal1 As Decimal
        openconnection()
        frmmain.lvisales.Items.Clear()



        If frmmain.cbofilter.Text = "" Then
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
                frmmain.lvisales.Items.Add(item)
            End While
            reader.Close()

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
                frmmain.lvisales.Items.Add(item)
            End While
            reader.Close()
        Else
            If frmmain.cbofilter.Text = "Operations" Then
                'cmd = New MySqlCommand("select tbl_operations.date_started, tbl_operation_item_used.operation_id, tbl_operations.client, tbl_operations.location, tbl_operations.contact, tbl_operation_item_used.product, tbl_operation_item_used.type, tbl_operation_item_used.selling_price, tbl_operation_item_used.quantity, tbl_operation_item_used.unit, tbl_operation_item_used.total_price from tbl_operation_item_used inner join tbl_operations on tbl_operation_item_used.operation_id = tbl_operations.operation_id", con)
                cmd = New MySqlCommand("select * from tbl_operation_item_used inner join tbl_operations on tbl_operation_item_used.operation_id = tbl_operations.operation_id", con)
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
                    frmmain.lvisales.Items.Add(item)
                End While
                reader.Close()
            ElseIf frmmain.cbofilter.Text = "Transactions" Then
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
                    frmmain.lvisales.Items.Add(item)
                End While
                reader.Close()
            End If
        End If




        con.Close()
        If initalgrandtotal1 > 999 Then
            frmmain.txtgts.Text = "Php " & Format((initalgrandtotal1), "0,00.00")
        ElseIf initalgrandtotal1 > 0 And initalgrandtotal1 < 1000 Then
            frmmain.txtgts.Text = "Php " & Format((initalgrandtotal1), "0.00")
        ElseIf initalgrandtotal1 < 1000 Then
            frmmain.txtgts.Text = ""
        End If

    End Sub

    Public Sub operationitemsalescollapsedipslay()

        Dim initalgrandtotal1 As Decimal
        openconnection()



        con.Close()
        If initalgrandtotal1 > 999 Then
            frmmain.txtgts.Text = "Php " & Format((initalgrandtotal1), "0,00.00")
        ElseIf initalgrandtotal1 > 0 And initalgrandtotal1 < 1000 Then
            frmmain.txtgts.Text = "Php " & Format((initalgrandtotal1), "0.00")
        ElseIf initalgrandtotal1 < 1000 Then
            frmmain.txtgts.Text = ""
        End If

    End Sub



    'Public Sub operationitemsalescollapsedipslay()

    '    Dim initalgrandtotal1 As Long
    '    openconnection()
    '    frmmain.lvisales.Items.Clear()
    '    cmd = New MySqlCommand("select distinct tbl_operation_item_used.date_started, tbl_operation_item_used.operation_id, tbl_operations.client, tbl_operations.location, tbl_operations.contact, tbl_operation_item_used.product, tbl_operation_item_used.type, tbl_operation_item_used.unit_price, tbl_operation_item_used.quantity, tbl_operation_item_used.total_price from tbl_operation_item_used inner join tbl_operations on tbl_operation_item_used.operation_id = tbl_operations.operation_id", con)
    '    reader = cmd.ExecuteReader
    '    While (reader.Read())
    '        Dim item As New ListViewItem(reader("operation_id").ToString())
    '        item.SubItems.Add(reader("date_started").ToString())
    '        item.SubItems.Add(reader("client").ToString())
    '        item.SubItems.Add(reader("location").ToString())
    '        item.SubItems.Add(reader("contact").ToString())
    '        item.SubItems.Add("")
    '        item.SubItems.Add("")
    '        item.SubItems.Add("")
    '        item.SubItems.Add(reader("quantity").ToString())
    '        item.SubItems.Add(reader("total_price").ToString())
    '        initalgrandtotal1 += reader("total_price").ToString().Replace("Php ", "")
    '        frmmain.lvisales.Items.Add(item)
    '    End While
    '    reader.Close()
    '    frmmain.txtgts.Text = "Php " & Format((initalgrandtotal1), "0,00")

    'End Sub

    Public Sub selectitemstouse()

        openconnection()
        frmmain.lviitems.Items.Clear()
        cmd = New MySqlCommand("select * from tbl_operation_item_total where operation_id = '" & frmmain.txtoprno.Text & "'", con)
        reader = cmd.ExecuteReader
        While (reader.Read())
            Dim lvi As New ListViewItem(reader("quantity").ToString() & " - " & reader("item").ToString())
            frmmain.lviitems.Items.Add(lvi)
        End While
        reader.Close()
        con.Close()
    End Sub

    Public Class encryptanddecrypt

        Dim DES As New TripleDESCryptoServiceProvider
        Dim MDS As New MD5CryptoServiceProvider

        Function MDShash(value As String) As Byte()

            Return MDS.ComputeHash(ASCIIEncoding.ASCII.GetBytes(value))

        End Function

        Function encrypt(stringinput As String, key As String) As String

            DES.Key = MDShash(key)
            DES.Mode = CipherMode.ECB

            Dim buffer As Byte() = ASCIIEncoding.ASCII.GetBytes(stringinput)

            Return Convert.ToBase64String(DES.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length))

        End Function

        Function decrypt(encryptedstring As String, key As String) As String

            DES.Key = MDShash(key)
            DES.Mode = CipherMode.ECB
            Dim buffer As Byte() = Convert.FromBase64String(encryptedstring)

            Return ASCIIEncoding.ASCII.GetString(DES.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length))

        End Function

    End Class

End Module
