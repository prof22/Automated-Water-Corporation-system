Imports System.Data.OleDb

Public Class billing
    Dim mode As String
    Dim dr As OleDbDataReader
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If rdflat.Checked Then
            mode = "flat"
        ElseIf rdroom.Checked Then

            mode = "room"
        Else
            MsgBox("select Mode of payment")
        End If



        Try
            If cnn.State = ConnectionState.Closed Then
                cnn.Open()
            End If

            Dim cmd As New OleDb.OleDbCommand
            cmd.Connection = cnn
            cmd.CommandText = "INSERT INTO `bill` (`accountname`, `accountnumber`, `zonecode`, `smonth`, `numberofmonths`, `date`, `purpose`, `modeofpayment`, `amountpaid`, `amountdue`, `balance`) VALUES (@accountname, @accountnumber, @zonecode, @smonth, @numberofmonths, @date, @purpose, @modeofpayment, @amountpaid, @amountdue, @balance)"


            With cmd.Parameters

                .AddWithValue("@accountname", txtacctname.Text)
                .AddWithValue("@accountnumber", txtaccountnumber.Text)
                .AddWithValue("@zonecode", txtzone.Text)
                .AddWithValue("@smonth", txtmonth.Text)
                .AddWithValue("@numberofmonths", txtnumberofmonth.Text)
                .AddWithValue("@date", txtdate.Text)
                .AddWithValue("@purpose", txtpurpose.Text)
                .AddWithValue("@modeofpayment", mode)
                .AddWithValue("@amountpaid", txtamt.Text)
                .AddWithValue("@amountdue", txtamtdue.Text)
                .AddWithValue("@balance", txtbal.Text)



            End With
            cmd.ExecuteNonQuery()
            MsgBox("New Record Added")
            txtaccountnumber.Clear()
            txtacctname.Clear()
            txtzone.Clear()
            txtmonth.Clear()
            txtnumberofmonth.Clear()
            txtdate.Clear()
            txtpurpose.Clear()
            cnn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtnumberofmonth_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnumberofmonth.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtnumberofmonth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnumberofmonth.TextChanged

    End Sub

    Private Sub txtzone_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtzone.TextChanged

    End Sub

    Private Sub txtaccountnumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtaccountnumber.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtaccountnumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtaccountnumber.TextChanged
        If Button3.Visible = True Then
            'txtacctname.ReadOnly = True
            txtzone.ReadOnly = True
            txtmonth.ReadOnly = True
            txtnumberofmonth.ReadOnly = True
            txtdate.ReadOnly = True
            txtamtdue.ReadOnly = True
            txtpurpose.ReadOnly = True
            txtbal.ReadOnly = True
            Try
                If cnn.State = ConnectionState.Closed Then
                    cnn.Open()
                End If

                Dim cmd As New OleDb.OleDbCommand
                cmd.Connection = cnn
                cmd.CommandText = "select * from bill Where `accountnumber` = '" & txtaccountnumber.Text & "'"
                dr = cmd.ExecuteReader
                If dr.HasRows Then
                    dr.Read()
                    txtacctname.Text = dr.Item("accountname").ToString
                    txtzone.Text = dr.Item("zonecode").ToString
                    txtmonth.Text = dr.Item("smonth").ToString
                    txtnumberofmonth.Text = dr.Item("numberofmonths").ToString
                    txtdate.Text = dr.Item("date").ToString

                    txtamtdue.Text = dr.Item("amountdue").ToString
                    txtamt.Text = dr.Item("amountpaid").ToString
                    txtbal.Text = dr.Item("balance").ToString
                    mode = dr.Item("modeofpayment").ToString
                    txtpurpose.Text = dr.Item("purpose").ToString
                    dr.Close()
                End If
                cnn.Close()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If rdflat.Checked Then
            mode = "flat"
        ElseIf rdroom.Checked Then

            mode = "room"
        Else
            MsgBox("select Mode of payment")
        End If



        Try
            If cnn.State = ConnectionState.Closed Then
                cnn.Open()
            End If

            Dim cmd As New OleDb.OleDbCommand
            cmd.Connection = cnn
            cmd.CommandText = "UPDATE `bill` SET `accountname` = @accountname, `amountpaid` = @amountpaid,  `balance`= @balance Where `accountnumber` = '" & txtaccountnumber.Text & "'"

            With cmd.Parameters


                .AddWithValue("@accountname", txtacctname.Text)
                .AddWithValue("@amountpaid", txtamt.Text)
                .AddWithValue("@balance", txtbal.Text)



            End With
            cmd.ExecuteNonQuery()
            MsgBox("New Record Updated")
            txtaccountnumber.Clear()
            txtacctname.Clear()
            txtzone.Clear()
            txtmonth.Clear()
            txtnumberofmonth.Clear()
            txtdate.Clear()
            txtpurpose.Clear()
            cnn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtamt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtamt.TextChanged
        If Button2.Visible = True Then
            Try
                Dim amtdue As String = txtamtdue.Text
                Dim amtpaid As String = txtamt.Text
                Dim total, amtdue2, amtpaid2 As Integer
                amtdue2 = CType(amtdue, Integer)
                amtpaid2 = CType(amtpaid, Integer)
                total = amtdue2 - amtpaid2
                txtbal.Text = total.ToString()
            Catch ex As Exception

            End Try
        End If
       
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class