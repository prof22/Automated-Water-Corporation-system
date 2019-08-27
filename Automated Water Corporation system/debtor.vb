Public Class debtor

    Private Sub debtor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim da As New OleDb.OleDbDataAdapter("select * from bill where balance > '0'", cnn)
        Dim dt As New DataTable
        da.Fill(dt)

        Me.dgv.DataSource = dt
        cnn.Close()
        dgv.RowsDefaultCellStyle.BackColor = Color.LightGray
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.White

        cnn.Close()
    End Sub

    Private Sub dgv_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub
End Class