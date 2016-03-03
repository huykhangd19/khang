Imports System.Data.SqlClient
Imports System.Data.DataTable
Public Class frmCapnhatsanpham
    Dim db As New DataTable
    Dim chuoiketnoi As String = "workstation id=khangldhps03070.mssql.somee.com;packet size=4096;user id=khangldhps03070_SQLLogin_1;pwd=mic6vwmd9p;data source=khangldhps03070.mssql.somee.com;persist security info=False;initial catalog=khangldhps03070"
    Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Dim connect As SqlConnection = New SqlConnection(chuoiketnoi)
        connect.Open()
        Dim xem As SqlDataAdapter = New SqlDataAdapter("select SANPHAM.MASP as 'Mã sản phẩm',SANPHAM.TENSP as 'Tên sản phẩm', LOAISANPHAM.MALOAI as 'Mã Loại', LOAISANPHAM.TENLOAI as 'Tên Loại',SANPHAM.SOLUONG as 'Số lượng' from SANPHAM inner join LOAISANPHAM on SANPHAM.MASP = LOAISANPHAM.MASP where SANPHAM.MASP='" & txtMASP.Text & "'", connect)
        Try
            If txtMASP.Text = "" Then
                MessageBox.Show("Bạn cần nhập mã sản phẩm", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)

            Else
                db.Clear()
                dgvSanpham.DataSource = Nothing
                xem.Fill(db)
                If db.Rows.Count > 0 Then
                    dgvSanpham.DataSource = db.DefaultView
                    txtMASP.Text = Nothing

                Else
                    MessageBox.Show("Không tìm thấy")
                    txtMASP.Text = Nothing
                End If
            End If
            connect.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmCapnhatsanpham_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub dgvSanpham_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSanpham.CellContentClick
        Dim click As Integer = dgvSanpham.CurrentCell.RowIndex
        txtMASP.Text = dgvSanpham.Item(0, click).Value
        txtTENSP.Text = dgvSanpham.Item(1, click).Value
        txtMALOAI.Text = dgvSanpham.Item(2, click).Value
        txtTENLOAI.Text = dgvSanpham.Item(3, click).Value
        txtSOLUONG.Text = dgvSanpham.Item(4, click).Value
    End Sub

    Private Sub LoadData()
        Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim load As SqlDataAdapter = New SqlDataAdapter("select SANPHAM.MASP as 'Mã sản phẩm',SANPHAM.TENSP as 'Tên sản phẩm', LOAISANPHAM.MALOAI as 'Mã Loại', LOAISANPHAM.TENLOAI as 'Tên Loại',SANPHAM.SOLUONG as 'Số lượng' from SANPHAM inner join LOAISANPHAM on SANPHAM.MASP = LOAISANPHAM.MASP", conn)

        conn.Open()
        load.Fill(db)
        dgvSanpham.DataSource = db.DefaultView
    End Sub
    Private Sub btnCapnhat_Click(sender As Object, e As EventArgs) Handles btnCapnhat.Click
        Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim updatequery As String = "update SANPHAM set MASP=@MASP, TENSP=@TENSP, SOLUONG=@SOLUONG where MASP=@MASP update LOAISANPHAM set MALOAI=@MALOAI, MASP=@MASP, TENLOAI=@TENLOAI where MASP=@MASP"
        Dim addupdate As SqlCommand = New SqlCommand(updatequery, conn)
        conn.Open()
        Try
            txtMASP.Focus()
            If txtMASP.Text = "" Then
                MessageBox.Show("Bạn chưa nhập mã sản phẩm", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
            Else
                txtMASP.Focus()
                If txtTENSP.Text = "" Then
                    MessageBox.Show("Bạn chưa nhập tên sản phẩm", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                Else
                    txtTENSP.Focus()
                    If txtMALOAI.Text = "" Then
                        MessageBox.Show("Bạn chưa nhập mã loại", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                    Else
                        txtMALOAI.Focus()
                        If txtSOLUONG.Text = "" Then
                            MessageBox.Show("Bạn chưa nhập số lượng", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                        Else
                            addupdate.Parameters.AddWithValue("@MASP", txtMASP.Text)
                            addupdate.Parameters.AddWithValue("@TENSP", txtTENSP.Text)
                            addupdate.Parameters.AddWithValue("@MALOAI", txtMALOAI.Text)
                            addupdate.Parameters.AddWithValue("@TENLOAI", txtTENLOAI.Text)
                            addupdate.Parameters.AddWithValue("@SOLUONG", txtSOLUONG.Text)
                            addupdate.ExecuteNonQuery()
                            conn.Close()
                            MessageBox.Show("Cập nhật thành công")
                            txtMASP.Text = Nothing
                            txtTENSP.Text = Nothing
                            txtMALOAI.Text = Nothing
                            txtTENLOAI.Text = Nothing
                            txtSOLUONG.Text = Nothing
                            End If
                        End If
                    End If
                End If
        Catch ex As Exception
            MessageBox.Show("Không thành công", "Lỗi", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
        End Try


        db.Clear()
        dgvSanpham.DataSource = db
        dgvSanpham.DataSource = Nothing
        LoadData()
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        Dim delquery As String = "delete from LOAISANPHAM where MASP=@MASP delete from SANPHAM where MASP=@MASP"
        Dim delete As SqlCommand = New SqlCommand(delquery, conn)
        Dim resulft As DialogResult = MessageBox.Show("Bạn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        conn.Open()
        Try
            If txtMASP.Text = "" Then
                MessageBox.Show("Bạn cần nhập mã khách hàng", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                txtMASP.Focus()
            Else
                If resulft = Windows.Forms.DialogResult.Yes Then
                    delete.Parameters.AddWithValue("@MASP", txtMASP.Text)
                    delete.ExecuteNonQuery()
                    conn.Close()
                    MessageBox.Show("Xóa thành công")

                    txtMASP.Text = Nothing
                    txtTENSP.Text = Nothing
                    txtMALOAI.Text = Nothing
                    txtTENLOAI.Text = Nothing
                    txtSOLUONG.Text = Nothing
                    txtMASP.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Nhập đúng mã sản phẩm cần xóa", "Lỗi", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
        End Try


        db.Clear()
        dgvSanpham.DataSource = db
        dgvSanpham.DataSource = Nothing
        LoadData()
    End Sub

    Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
        Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim query As String = "insert into SANPHAM values(@MASP,@TENSP,@SOLUONG) insert into LOAISANPHAM values(@MALOAI,@MASP,@TENLOAI)"
        Dim save As SqlCommand = New SqlCommand(query, conn)
        conn.Open()
        Try
            txtMASP.Focus()
            If txtMASP.Text = "" Then
                MessageBox.Show("Bạn chưa nhập mã sản phẩm", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
            Else
                txtMASP.Focus()
                If txtTENSP.Text = "" Then
                    MessageBox.Show("Bạn chưa nhập tên sản phẩm", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                Else
                    txtTENSP.Focus()
                    If txtMALOAI.Text = "" Then
                        MessageBox.Show("Bạn chưa nhập mã loại", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                    Else
                        txtMALOAI.Focus()
                        If txtSOLUONG.Text = "" Then
                            MessageBox.Show("Bạn chưa nhập số lượng", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                        Else
                            save.Parameters.AddWithValue("@MASP", txtMASP.Text)
                            save.Parameters.AddWithValue("@TENSP", txtTENSP.Text)
                            save.Parameters.AddWithValue("@MALOAI", txtMALOAI.Text)
                            save.Parameters.AddWithValue("@TENLOAI", txtTENLOAI.Text)
                            save.Parameters.AddWithValue("@SOLUONG", txtSOLUONG.Text)
                            save.ExecuteNonQuery()
                            MessageBox.Show("Lưu thành công")

                            txtMASP.Text = Nothing
                            txtMALOAI.Text = Nothing
                            txtSOLUONG.Text = Nothing
                            txtTENSP.Text = Nothing
                            txtTENLOAI.Text = Nothing

                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Không được trùng mã sản phẩm", "Lỗi", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
        End Try


        Dim refesh As SqlDataAdapter = New SqlDataAdapter("select SANPHAM.MASP as 'Mã sản phẩm',SANPHAM.TENSP as 'Tên sản phẩm', LOAISANPHAM.MALOAI as 'Mã Loại', LOAISANPHAM.TENLOAI as 'Tên Loại',SANPHAM.SOLUONG as 'Số lượng' from SANPHAM inner join LOAISANPHAM on SANPHAM.MASP = LOAISANPHAM.MASP", conn)
        db.Clear()
        refesh.Fill(db)
        dgvSanpham.DataSource = db.DefaultView
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class