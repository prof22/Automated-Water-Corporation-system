Imports System.Data.OleDb

Public Class login
    Dim dr As OleDbDataReader
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            cnn.Open()
            Dim cmd As New OleDbCommand("SELECT * FROM [admin] WHERE user= '" & txtusername.Text & "' and password= '" & txtpassword.Text & "'", cnn)
            dr = cmd.ExecuteReader
            If dr.Read Then
                Me.Visible = False
                Main.ShowDialog()
            Else
                MessageBox.Show("Invalid login details")
            End If
            cnn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            If cnn.State = ConnectionState.Open Then
                cnn.Close()
            End If

        End Try
    End Sub
End Class