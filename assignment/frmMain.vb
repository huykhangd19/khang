Public Class frmMain

    Private Sub ThêmSảnPhẩmToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThêmSảnPhẩmToolStripMenuItem.Click
        frmCapnhatsanpham.Show()
    End Sub

    Private Sub XemKhácHàngToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XemKhácHàngToolStripMenuItem.Click
        frmKH.Show()
    End Sub

    Private Sub ChỉnhSữaKHToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChỉnhSữaKHToolStripMenuItem.Click
        frmDieuchinhKH.Show()
    End Sub

    Private Sub XemSảnPhẩmToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XemSảnPhẩmToolStripMenuItem.Click
        frmXemsanpham.Show()
    End Sub

    Private Sub LoạiSànPhẩmToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim dialog As DialogResult = MessageBox.Show("Bạn muốn kết thúc ?",
                                                      "Fpoly: Thông báo !", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (dialog = DialogResult.Yes) Then
            Me.Close()
            Application.Exit()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmDieuchinhKH.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmKH.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        frmCapnhatsanpham.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        frmXemsanpham.Show()
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub
End Class
