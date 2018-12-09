Imports CrystalDecisions.CrystalReports.Engine
Imports MySql.Data.MySqlClient
Imports CrystalDecisions.Shared

Public Class frmoperationsprintpreview
    Dim da As MySqlDataAdapter
    Dim ds As DataSet
    Dim p(7) As MySqlParameter
    Dim con As New MySqlConnection("Server=localhost; User ID=root; Password=ryan; Database=cctvdodge;")

    Public Sub New(ByVal stitle As String)
        InitializeComponent()
        Try
            Dim ds As New DataSet
            Dim query As String
            p(0) = New MySqlParameter("@operation_id", MySqlDbType.String)
            p(0).Value = stitle
            query = "select * from tbl_operations where operation_id=@operation_id"
            Dim dscmd As New MySqlDataAdapter(query, con)
            dscmd.SelectCommand.Parameters.Add(p(0))
            dscmd.Fill(ds, "tbl_operations")
            con.Close()
            Dim cryds As New operationscrystalreport
            cryds.SetDataSource(ds.Tables(0))
            CrystalReportViewer1.ReportSource = cryds
            CrystalReportViewer1.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
        con.Close()
    End Sub

    Private Sub frmoperationsprintpreview_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class