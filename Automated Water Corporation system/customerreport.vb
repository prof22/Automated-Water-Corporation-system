Public Class customerreport

    Private Sub customerreport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim da As New OleDb.OleDbDataAdapter("select * from customers", cnn)
        Dim dt As New DataTable
        da.Fill(dt)

        Me.dgv.DataSource = dt
        cnn.Close()
        dgv.RowsDefaultCellStyle.BackColor = Color.LightGray
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.White

        cnn.Close()
    End Sub
End Class