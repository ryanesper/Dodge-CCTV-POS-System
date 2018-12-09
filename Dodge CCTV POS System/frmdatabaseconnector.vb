Public Class frmdatabaseconnector

    Private Sub cmdConnect_Click(sender As Object, e As EventArgs) Handles cmdConnect.Click
        If txtserver.Text = "" And txtuser.Text = "" And txtpassword.Text = "" And txtdatabase.Text = "" Then
            MessageBox.Show("Cannot connect to the database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Try
                If con.State = ConnectionState.Closed Then
                    con.ConnectionString = "Server = " & txtserver.Text & "; User ID = " & txtuser.Text & "; Password = " & txtpassword.Text & "; Database = " & txtdatabase.Text & ";"
                    con.Open()
                    cmd.Connection = con
                    MessageBox.Show("Connection Successfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    con.Close()

                    My.Settings.serversettings = txtserver.Text
                    My.Settings.usersettings = txtuser.Text
                    My.Settings.passwordsettings = txtpassword.Text
                    My.Settings.databasesettings = txtdatabase.Text
                    'My.Settings.server = txtserver.Text
                    'My.Settings.user = txtuser.Text
                    'My.Settings.password = txtpassword.Text
                    'My.Settings.database = txtdatabase.Text
                    MessageBox.Show("The program must be close in order for the settings to take effect.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                End If
            Catch ex As Exception
                MessageBox.Show("Cannot connect to the database.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Me.Close()
    End Sub
End Class
