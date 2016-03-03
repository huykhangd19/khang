Public Class frmLoad

    Private Sub frmLoad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProgressBar1.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ProgressBar1.Show()

        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(5)
        If ProgressBar1.Value = ProgressBar1.Maximum Then
            Timer1.Stop()
            MessageBox.Show("Welcome", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            frmMain.Show()
            Me.Hide()
        End If
        Label1.Text = ProgressBar1.Value & (" %")
    End Sub

    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click

    End Sub
End Class