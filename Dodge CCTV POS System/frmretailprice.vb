Public Class frmretailprice

    Private Sub btnok_Click(sender As Object, e As EventArgs) Handles btnok.Click

        If retialin = "itemtoinstall" Then
            retailinitemtoinstall()
        ElseIf retialin = "itemtoinsell" Then
            retailinitemtoinsell()
        End If

    End Sub

    Private Sub retailinitemtoinstall()

        If txtretailprice.Text <> "" Then
            For Each item As ListViewItem In frmchooseitemsandpersonel.lviitems.Items
                If item.SubItems(13).Text = rtl13 Then
                    item.Remove()
                End If
            Next

            Dim item1 As New ListViewItem(rtl0)
            item1.SubItems.Add(rtl1)
            item1.SubItems.Add(rtl2)
            item1.SubItems.Add(rtl3)
            item1.SubItems.Add(rtl4)
            item1.SubItems.Add(rtl5)
            item1.SubItems.Add(rtl6)
            item1.SubItems.Add(rtl7)
            item1.SubItems.Add(rtl8)
            item1.SubItems.Add(rtl9)
            Dim retailedprice As Decimal = txtretailprice.Text
            If retailedprice > 999 Then
                item1.SubItems.Add("Php " & Format((retailedprice), "0,00.00"))
            ElseIf retailedprice < 1000 Then
                item1.SubItems.Add("Php " & Format((retailedprice), "0.00"))
            End If
            item1.SubItems.Add(rtl11)
            Dim newtotalprice As Decimal = retailedprice * rtl7
            If newtotalprice > 999 Then
                item1.SubItems.Add("Php " & Format((newtotalprice), "0,00.00"))
            ElseIf newtotalprice < 1000 Then
                item1.SubItems.Add("Php " & Format((newtotalprice), "0.00"))
            End If
            item1.SubItems.Add(rtl13)
            item1.SubItems.Add(rtl14)
            frmchooseitemsandpersonel.lviitems.Items.Add(item1)
            txtretailprice.Text = ""

            Dim grandtotal As Decimal
            For Each item As ListViewItem In frmchooseitemsandpersonel.lviitems.Items
                grandtotal += item.SubItems(12).Text.Replace("Php ", "")
            Next
            If grandtotal > 999 Then
                frmchooseitemsandpersonel.txttotalprice.Text = "Php " & Format((grandtotal), "0,00.00")
            ElseIf grandtotal > 0 And grandtotal < 1000 Then
                frmchooseitemsandpersonel.txttotalprice.Text = "Php " & Format((grandtotal), "0.00")
            ElseIf grandtotal = 0 Then
                frmchooseitemsandpersonel.txttotalprice.Text = ""
            End If
            txtretailprice.Focus()
            Me.Close()
        Else
            MessageBox.Show("Retail price cannot be empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub retailinitemtoinsell()

        If txtretailprice.Text <> "" Then
            For Each item As ListViewItem In frmsolditem.lviitems.Items
                If item.SubItems(13).Text = rtl13 Then
                    item.Remove()
                End If
            Next

            Dim item1 As New ListViewItem(rtl0)
            item1.SubItems.Add(rtl1)
            item1.SubItems.Add(rtl2)
            item1.SubItems.Add(rtl3)
            item1.SubItems.Add(rtl4)
            item1.SubItems.Add(rtl5)
            item1.SubItems.Add(rtl6)
            item1.SubItems.Add(rtl7)
            item1.SubItems.Add(rtl8)
            item1.SubItems.Add(rtl9)
            Dim retailedprice As Decimal = txtretailprice.Text
            If retailedprice > 999 Then
                item1.SubItems.Add("Php " & Format((retailedprice), "0,00.00"))
            ElseIf retailedprice < 1000 Then
                item1.SubItems.Add("Php " & Format((retailedprice), "0.00"))
            End If
            item1.SubItems.Add(rtl11)
            Dim newtotalprice As Decimal = retailedprice * rtl7
            If newtotalprice > 999 Then
                item1.SubItems.Add("Php " & Format((newtotalprice), "0,00.00"))
            ElseIf newtotalprice < 1000 Then
                item1.SubItems.Add("Php " & Format((newtotalprice), "0.00"))
            End If
            item1.SubItems.Add(rtl13)
            item1.SubItems.Add(rtl14)
            frmsolditem.lviitems.Items.Add(item1)
            txtretailprice.Text = ""

            Dim grandtotal As Decimal
            For Each item As ListViewItem In frmsolditem.lviitems.Items
                grandtotal += item.SubItems(12).Text.Replace("Php ", "")
            Next
            If grandtotal > 999 Then
                frmsolditem.txttotalprice.Text = "Php " & Format((grandtotal), "0,00.00")
            ElseIf grandtotal > 0 And grandtotal < 1000 Then
                frmsolditem.txttotalprice.Text = "Php " & Format((grandtotal), "0.00")
            ElseIf grandtotal = 0 Then
                frmsolditem.txttotalprice.Text = ""
            End If
            txtretailprice.Focus()
            Me.Close()
        Else
            MessageBox.Show("Retail price cannot be empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click

        txtretailprice.Focus()
        txtretailprice.Text = ""
        Me.Close()

    End Sub

    Private Sub txtretailprice_KeyDown(sender As Object, e As KeyEventArgs) Handles txtretailprice.KeyDown

        If e.KeyCode = Keys.Enter Then
            btnok.PerformClick()
        End If

    End Sub

    Private Sub txtretailprice_TextChanged(sender As Object, e As EventArgs) Handles txtretailprice.TextChanged

        If txtretailprice.Text <> "" Then
            Try
                Dim number As Long = txtretailprice.Text
            Catch ex As Exception
                MessageBox.Show("Price must only contain a number from 0 to 9 !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtretailprice.Text = ""
                Exit Sub
            End Try
        End If

    End Sub
End Class