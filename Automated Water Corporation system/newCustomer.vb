Public Class newCustomer

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If cnn.State = ConnectionState.Closed Then
                cnn.Open()
            End If

            Dim cmd As New OleDb.OleDbCommand
            cmd.Connection = cnn
            cmd.CommandText = "INSERT INTO `customers` (`cname`, `accountnumber`, `purpose`, `zone`, `area`, `address`, `modeofpayment`) VALUES (@cname, @accountnumber, @purpose, @zone, @area, @address, @modeofpayment)"


            With cmd.Parameters

                .AddWithValue("@cname", txtname.Text)
                .AddWithValue("@accountnumber", txtacctnumber.Text)
                .AddWithValue("@purpose", txtpurpose.Text)
                .AddWithValue("@zone", txtzone.Text)
                .AddWithValue("@area", txtarea.Text)
                .AddWithValue("@address", txtaddress.Text)

                .AddWithValue("@modeofpayment", txtmode.Text)



            End With
            cmd.ExecuteNonQuery()
            MsgBox("New Record Added")
            txtname.Clear()
            txtacctnumber.Clear()
            txtpurpose.Clear()
            txtzone.Clear()
            txtarea.Clear()
            txtaddress.Clear()
            txtmode.Clear()
            cnn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtacctnumber_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtacctnumber.KeyDown

    End Sub

    Private Sub txtacctnumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtacctnumber.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtacctnumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtacctnumber.TextChanged

    End Sub
End Class