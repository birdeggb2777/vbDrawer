Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Public Class Form1
    Dim x0, y0 As Integer
    Dim X, Y As Integer
    Dim x2, y2 As Integer
    Dim pencheck As Boolean = False
    Dim color1 As Color = Color.Red
    Dim color2 As Color = Color.Green 'Dim color3 As Color = Color.FromArgb(255, 255, 255, 255)
    Dim co1r, co1g, co1b, co2r, co2g, co2b, co1a, co2a As Single
    Dim penbig As Integer = 80
    Dim penstyle As Integer = 1
    Dim penandpen As Single = 1.2
    Private Sub 複製圖片ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 複製圖片ToolStripMenuItem.Click
        On Error Resume Next
        My.Computer.Clipboard.SetImage(PictureBox1.Image)
    End Sub
    Private Sub picturebox1_Mousedown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        Try
            Dim intcheck As Integer = ToolStripTextBox1.Text
        Catch ex As Exception
            ToolStripTextBox1.Text = "1"
        End Try
        Try
            Dim intcheck As Byte = ToolStripTextBox3.Text
        Catch ex As Exception
            ToolStripTextBox3.Text = "255"
        End Try
        Try
            Dim intcheck As Byte = ToolStripTextBox4.Text
        Catch ex As Exception
            ToolStripTextBox4.Text = "255"
        End Try
        Try
            Dim intcheck As Integer = ToolStripTextBox5.Text
        Catch ex As Exception
            ToolStripTextBox5.Text = "0"
        End Try
        Try
            Dim intcheck As Integer = ToolStripTextBox6.Text
        Catch ex As Exception
            ToolStripTextBox6.Text = "1.2"
        End Try
        X = e.X
        Y = e.Y
        x0 = e.X
        y0 = e.Y
        pencheck = True
        If ToolStripComboBox1.Items(ToolStripComboBox1.SelectedIndex) = "軌道" Then penstyle = 1
        If ToolStripComboBox1.Items(ToolStripComboBox1.SelectedIndex) = "圓圈" Then penstyle = 2
        If ToolStripComboBox1.Items(ToolStripComboBox1.SelectedIndex) = "素材" Then penstyle = 3
        If ToolStripComboBox1.Items(ToolStripComboBox1.SelectedIndex) = "旗幟" Then penstyle = 4
        If ToolStripComboBox1.Items(ToolStripComboBox1.SelectedIndex) = "空心圓" Then penstyle = 5
        If ToolStripComboBox1.Items(ToolStripComboBox1.SelectedIndex) = "一般線" Then penstyle = 6
        If ToolStripComboBox1.Items(ToolStripComboBox1.SelectedIndex) = "稻草" Then penstyle = 7
        If ToolStripComboBox1.Items(ToolStripComboBox1.SelectedIndex) = "魔法陣" Then penstyle = 8
        If ToolStripComboBox1.Items(ToolStripComboBox1.SelectedIndex) = "魔法陣(改)" Then penstyle = 9
        co1r = color1.R
        co1g = color1.G
        co1b = color1.B
        co2r = color2.R
        co2g = color2.G
        co2b = color2.B
        co1a = ToolStripTextBox3.Text
        co2a = ToolStripTextBox4.Text
        penandpen = ToolStripTextBox6.Text
    End Sub
    Private Sub picturebox1_Mousemove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        If pencheck = True Then
            If penstyle = 1 Then '軌道
                Dim pic1s As Image = PictureBox1.Image
                x2 = e.X
                y2 = e.Y
                Dim drawImage As New Bitmap(pic1s, pic1s.Width, pic1s.Height)
                Dim g As Graphics = Graphics.FromImage(drawImage)
                Dim myPen As New Pen(Color.FromArgb(co1a, co1r, co1g, co1b), ToolStripTextBox1.Text * penandpen)
                Dim myPen2 As New Pen(Color.FromArgb(co2a, co2r, co2g, co2b), ToolStripTextBox1.Text)
                Dim wi As Integer = (pic1s.Width / PictureBox1.Width)
                Dim he As Integer = (pic1s.Width / PictureBox1.Width)
                g.DrawLine(myPen, X * wi, Y * he, x2 * wi, y2 * he)
                g.DrawLine(myPen2, X * wi, Y * he, x2 * wi, y2 * he)
                g.Dispose()
                PictureBox1.Image = drawImage
                X = e.X
                Y = e.Y
            ElseIf penstyle = 2 Then '圓圈
                Dim pic1s As Image = PictureBox1.Image
                x2 = e.X
                y2 = e.Y
                Dim pen2xy As Integer = ToolStripTextBox1.Text
                Dim drawImage As New Bitmap(pic1s, pic1s.Width, pic1s.Height)
                Dim g As Graphics = Graphics.FromImage(drawImage)
                Dim myPen As New Pen(Color.FromArgb(co1a, co1r, co1g, co1b), ToolStripTextBox1.Text)
                Dim myPen2 As New Pen(Color.FromArgb(co2a, co2r, co2g, co2b), ToolStripTextBox1.Text * penandpen)
                Dim wi As Integer = (pic1s.Width / PictureBox1.Width)
                Dim he As Integer = (pic1s.Width / PictureBox1.Width)
                g.DrawEllipse(myPen, x2 * wi, y2 * he, pen2xy, pen2xy)
                g.DrawEllipse(myPen2, x2 * wi, y2 * he, pen2xy, pen2xy)
                g.Dispose()
                PictureBox1.Image = drawImage
                X = e.X
                Y = e.Y
            ElseIf penstyle = 3 Then '素材
                Dim pic1s As Image = PictureBox1.Image
                x2 = e.X
                y2 = e.Y
                Dim drawImage As New Bitmap(pic1s, pic1s.Width, pic1s.Height)
                Dim g As Graphics = Graphics.FromImage(drawImage)
                Dim wi As Integer = (pic1s.Width / PictureBox1.Width)
                Dim he As Integer = (pic1s.Width / PictureBox1.Width)
                Dim myImage As Image = My.Resources.測試
                Dim myTextureBrush As New TextureBrush(myImage)
                g.FillRectangle(myTextureBrush, X * wi, Y * he, myImage.Width, myImage.Height)
                PictureBox1.Image = drawImage
                X = e.X
                Y = e.Y
            ElseIf penstyle = 4 Then '旗幟
                Dim pic1s As Image = PictureBox1.Image
                x2 = e.X
                y2 = e.Y
                Dim drawImage As New Bitmap(pic1s, pic1s.Width, pic1s.Height)
                Dim g As Graphics = Graphics.FromImage(drawImage)
                Dim myPen As New Pen(Color.FromArgb(co1a, co1r, co1g, co1b), ToolStripTextBox1.Text)
                Dim myPen2 As New Pen(Color.FromArgb(co2a, co2r, co2g, co2b), ToolStripTextBox1.Text * penandpen)
                Dim wi As Integer = (pic1s.Width / PictureBox1.Width)
                Dim he As Integer = (pic1s.Width / PictureBox1.Width)
                For i = X To X + Math.Abs(x2 - X)
                    For ii = Y To Y + Math.Abs(y2 - Y)
                        g.DrawLine(myPen, X * wi, Y * he, x2 * wi, y2 * he)
                        g.DrawLine(myPen2, X * wi, Y * he, x2 * wi, y2 * he)
                        y2 += 1
                    Next
                    y2 = Y
                    x2 += 1
                Next
                g.Dispose()
                PictureBox1.Image = drawImage
                X = e.X
                Y = e.Y
            ElseIf penstyle = 5 Then '空心圈
                Dim pic1s As Image = PictureBox1.Image
                x2 = e.X
                y2 = e.Y
                Dim pen2xy As Integer = ToolStripTextBox1.Text * -1
                Dim drawImage As New Bitmap(pic1s, pic1s.Width, pic1s.Height)
                Dim g As Graphics = Graphics.FromImage(drawImage)
                Dim myPen As New Pen(Color.FromArgb(co1a, co1r, co1g, co1b), pen2xy)
                Dim myPen2 As New Pen(Color.FromArgb(co2a, co2r, co2g, co2b), pen2xy * penandpen)
                Dim wi As Integer = (pic1s.Width / PictureBox1.Width)
                Dim he As Integer = (pic1s.Width / PictureBox1.Width)
                g.DrawEllipse(myPen, x2 * wi, y2 * he, pen2xy, pen2xy)
                g.DrawEllipse(myPen2, x2 * wi, y2 * he, pen2xy, pen2xy)
                g.Dispose()
                PictureBox1.Image = drawImage
                X = e.X
                Y = e.Y
            ElseIf penstyle = 6 Then '一般線
                Dim pic1s As Image = PictureBox1.Image
                x2 = e.X
                y2 = e.Y
                Dim drawImage As New Bitmap(pic1s, pic1s.Width, pic1s.Height)
                Dim g As Graphics = Graphics.FromImage(drawImage)
                Dim myPen As New Pen(Color.FromArgb(co1a, co1r, co1g, co1b), ToolStripTextBox1.Text)
                Dim myPen2 As New Pen(Color.FromArgb(co2a, co2r, co2g, co2b), ToolStripTextBox1.Text * penandpen)
                Dim wi As Integer = (pic1s.Width / PictureBox1.Width)
                Dim he As Integer = (pic1s.Width / PictureBox1.Width)
                myPen.StartCap = Drawing2D.LineCap.Round '此行必要，否則線會斷
                myPen2.StartCap = Drawing2D.LineCap.Round '此行必要，否則線會斷
                g.DrawLine(myPen, X * wi, Y * he, x2 * wi, y2 * he)
                g.DrawLine(myPen2, X * wi, Y * he, x2 * wi, y2 * he)
                g.Dispose()
                PictureBox1.Image = drawImage
                X = e.X
                Y = e.Y
            ElseIf penstyle = 7 Then '稻草
                Dim pic1s As Image = PictureBox1.Image
                x2 = e.X
                y2 = e.Y
                If (x2 - x0) > 0 Then
                    x2 = x0 + Math.Abs(e.X - x0)
                Else
                    x2 = x0 - Math.Abs(e.X - x0)
                End If
                If (y2 - y0) > 0 Then
                    y2 = y0 + Math.Abs(e.Y - y0)
                Else
                    y2 = y0 - Math.Abs(e.Y - y0)
                End If
                Dim drawImage As New Bitmap(pic1s, pic1s.Width, pic1s.Height)
                Dim g As Graphics = Graphics.FromImage(drawImage)
                Dim myPen As New Pen(Color.FromArgb(co1a, co1r, co1g, co1b), ToolStripTextBox1.Text)
                Dim wi As Integer = (pic1s.Width / PictureBox1.Width)
                Dim he As Integer = (pic1s.Width / PictureBox1.Width)
                myPen.StartCap = Drawing2D.LineCap.Round '此行必要，否則線會斷
                g.DrawLine(myPen, X * wi, Y * he, x2 * wi, y2 * he)
                '  x2 = x0 - Math.Abs(e.X - x0)
                ' y2 = y0 - Math.Abs(e.Y - y0)
                x2 = e.X
                y2 = e.Y
                If (x2 - X) > 0 Then
                    X = X - Math.Abs(e.X - X)
                Else
                    X = X + Math.Abs(e.X - X)
                End If
                If (y2 - Y) > 0 Then
                    Y = Y - Math.Abs(e.Y - Y)
                Else
                    Y = Y + Math.Abs(e.Y - Y)
                End If
                If (x2 - X) > 0 Then
                    X = X - Math.Abs(e.X - X)
                Else
                    X = X + Math.Abs(e.X - X)
                End If
                If (y2 - Y) > 0 Then
                    Y = Y - Math.Abs(e.Y - Y)
                Else
                    Y = Y + Math.Abs(e.Y - Y)
                End If
                g.DrawLine(myPen, X * wi, Y * he, x2 * wi, y2 * he)
                g.Dispose()
                PictureBox1.Image = drawImage
                'X = x0 + Math.Abs(e.X - x0)
                'Y = y0 + Math.Abs(e.Y - y0)
                X = e.X
                Y = e.Y
            ElseIf penstyle = 8 Then '魔法陣
                Dim pic1s As Image = PictureBox1.Image
                x2 = e.X
                y2 = e.Y
                Dim drawImage As New Bitmap(pic1s, pic1s.Width, pic1s.Height)
                Dim g As Graphics = Graphics.FromImage(drawImage)
                Dim myPen As New Pen(Color.FromArgb(co1a, co1r, co1g, co1b), ToolStripTextBox1.Text)
                Dim myPen2 As New Pen(Color.FromArgb(co2a, co2r, co2g, co2b), ToolStripTextBox1.Text * penandpen)
                Dim wi As Integer = (pic1s.Width / PictureBox1.Width)
                Dim he As Integer = (pic1s.Width / PictureBox1.Width)
                myPen.StartCap = Drawing2D.LineCap.Round '此行必要，否則線會斷
                myPen2.StartCap = Drawing2D.LineCap.Round '此行必要，否則線會斷
                If (x2 - x0) > 0 And (y2 - y0) > 0 Then
                    g.DrawLine(myPen, X * wi, Y * he, x2 * wi, y2 * he)
                    g.DrawLine(myPen, x0 - Math.Abs(x0 - X) * wi, y0 - Math.Abs(y0 - Y) * he, x0 - Math.Abs(x0 - x2) * wi, y0 - Math.Abs(y0 - y2) * he)
                    g.DrawLine(myPen, X * wi, y0 - Math.Abs(y0 - Y) * he, x2 * wi, y0 - Math.Abs(y0 - y2) * he)
                    g.DrawLine(myPen, x0 - Math.Abs(x0 - X) * wi, y0 + Math.Abs(y0 - Y) * he, x0 - Math.Abs(x0 - x2) * wi, y0 + Math.Abs(y0 - y2) * he)
                    g.DrawLine(myPen2, X * wi, Y * he, x2 * wi, y2 * he)
                    g.DrawLine(myPen2, x0 - Math.Abs(x0 - X) * wi, y0 - Math.Abs(y0 - Y) * he, x0 - Math.Abs(x0 - x2) * wi, y0 - Math.Abs(y0 - y2) * he)
                    g.DrawLine(myPen2, X * wi, y0 - Math.Abs(y0 - Y) * he, x2 * wi, y0 - Math.Abs(y0 - y2) * he)
                    g.DrawLine(myPen2, x0 - Math.Abs(x0 - X) * wi, y0 + Math.Abs(y0 - Y) * he, x0 - Math.Abs(x0 - x2) * wi, y0 + Math.Abs(y0 - y2) * he)
                ElseIf (x2 - x0) < 0 And (y2 - y0) < 0 Then
                    g.DrawLine(myPen, X * wi, Y * he, x2 * wi, y2 * he)
                    g.DrawLine(myPen, x0 + Math.Abs(x0 - X) * wi, y0 + Math.Abs(y0 - Y) * he, x0 + Math.Abs(x0 - x2) * wi, y0 + Math.Abs(y0 - y2) * he)
                    g.DrawLine(myPen, x0 + Math.Abs(x0 - X) * wi, y0 - Math.Abs(y0 - Y) * he, x0 + Math.Abs(x0 - x2) * wi, y0 - Math.Abs(y0 - y2) * he)
                    g.DrawLine(myPen, x0 - Math.Abs(x0 - X) * wi, y0 + Math.Abs(y0 - Y) * he, x0 - Math.Abs(x0 - x2) * wi, y0 + Math.Abs(y0 - y2) * he)
                    g.DrawLine(myPen2, X * wi, Y * he, x2 * wi, y2 * he)
                    g.DrawLine(myPen2, x0 + Math.Abs(x0 - X) * wi, y0 + Math.Abs(y0 - Y) * he, x0 + Math.Abs(x0 - x2) * wi, y0 + Math.Abs(y0 - y2) * he)
                    g.DrawLine(myPen2, x0 + Math.Abs(x0 - X) * wi, y0 - Math.Abs(y0 - Y) * he, x0 + Math.Abs(x0 - x2) * wi, y0 - Math.Abs(y0 - y2) * he)
                    g.DrawLine(myPen2, x0 - Math.Abs(x0 - X) * wi, y0 + Math.Abs(y0 - Y) * he, x0 - Math.Abs(x0 - x2) * wi, y0 + Math.Abs(y0 - y2) * he)
                ElseIf (x2 - x0) > 0 And (y2 - y0) < 0 Then
                    g.DrawLine(myPen, X * wi, Y * he, x2 * wi, y2 * he)
                    g.DrawLine(myPen, x0 - Math.Abs(x0 - X) * wi, y0 + Math.Abs(y0 - Y) * he, x0 - Math.Abs(x0 - x2) * wi, y0 + Math.Abs(y0 - y2) * he)
                    g.DrawLine(myPen, X * wi, y0 + Math.Abs(y0 - Y) * he, x2, y0 + Math.Abs(y0 - y2) * he)
                    g.DrawLine(myPen, x0 - Math.Abs(x0 - X) * wi, Y * he, x0 - Math.Abs(x0 - x2), y2 * he)
                    g.DrawLine(myPen2, X * wi, Y * he, x2 * wi, y2 * he)
                    g.DrawLine(myPen2, x0 - Math.Abs(x0 - X) * wi, y0 + Math.Abs(y0 - Y) * he, x0 - Math.Abs(x0 - x2) * wi, y0 + Math.Abs(y0 - y2) * he)
                    g.DrawLine(myPen2, X * wi, y0 + Math.Abs(y0 - Y) * he, x2, y0 + Math.Abs(y0 - y2) * he)
                    g.DrawLine(myPen2, x0 - Math.Abs(x0 - X) * wi, Y * he, x0 - Math.Abs(x0 - x2), y2 * he)
                ElseIf (x2 - x0) < 0 And (y2 - y0) > 0 Then
                    g.DrawLine(myPen, X * wi, Y * he, x2 * wi, y2 * he)
                    g.DrawLine(myPen, x0 + Math.Abs(x0 - X) * wi, y0 - Math.Abs(y0 - Y) * he, x0 + Math.Abs(x0 - x2) * wi, y0 - Math.Abs(y0 - y2) * he)
                    g.DrawLine(myPen, X * wi, y0 - Math.Abs(y0 - Y) * he, x2 * wi, y0 - Math.Abs(y0 - y2) * he)
                    g.DrawLine(myPen, x0 + Math.Abs(x0 - X) * wi, y0 + Math.Abs(y0 - Y) * he, x0 + Math.Abs(x0 - x2), y0 + Math.Abs(y0 - y2) * he)
                    g.DrawLine(myPen2, X * wi, Y * he, x2 * wi, y2 * he)
                    g.DrawLine(myPen2, x0 + Math.Abs(x0 - X) * wi, y0 - Math.Abs(y0 - Y) * he, x0 + Math.Abs(x0 - x2) * wi, y0 - Math.Abs(y0 - y2) * he)
                    g.DrawLine(myPen2, X * wi, y0 - Math.Abs(y0 - Y) * he, x2 * wi, y0 - Math.Abs(y0 - y2) * he)
                    g.DrawLine(myPen2, x0 + Math.Abs(x0 - X) * wi, y0 + Math.Abs(y0 - Y) * he, x0 + Math.Abs(x0 - x2), y0 + Math.Abs(y0 - y2) * he)
                End If
                g.Dispose()
                PictureBox1.Image = drawImage
                X = e.X
                Y = e.Y
            ElseIf penstyle = 9 Then '魔法陣(改)
                Dim pic1s As Image = PictureBox1.Image
                x2 = e.X
                y2 = e.Y
                Dim drawImage As New Bitmap(pic1s, pic1s.Width, pic1s.Height)
                Dim g As Graphics = Graphics.FromImage(drawImage)
                Dim myPen As New Pen(Color.FromArgb(co1a, co1r, co1g, co1b), ToolStripTextBox1.Text)
                Dim myPen2 As New Pen(Color.FromArgb(co2a, co2r, co2g, co2b), ToolStripTextBox1.Text * penandpen)
                Dim wi As Integer = (pic1s.Width / PictureBox1.Width)
                Dim he As Integer = (pic1s.Width / PictureBox1.Width)
                myPen.StartCap = Drawing2D.LineCap.Round '此行必要，否則線會斷
                myPen2.StartCap = Drawing2D.LineCap.Round '此行必要，否則線會斷
                If (x2 - x0) > 0 And (y2 - y0) > 0 Then
                    g.DrawLine(myPen, X * wi, Y * he, x2 * wi, y2 * he)
                    g.DrawLine(myPen, x0 - Math.Abs(x0 - X) * wi, y0 - Math.Abs(y0 - Y) * he, x0 - Math.Abs(x0 - x2) * wi, y0 - Math.Abs(y0 - y2) * he)
                    g.DrawLine(myPen, x0 + Math.Abs(y0 - Y) * wi, y0 - Math.Abs(x0 - X) * he, x0 + Math.Abs(y0 - y2) * wi, y0 - Math.Abs(x0 - x2) * he)
                    g.DrawLine(myPen, x0 - Math.Abs(y0 - Y) * wi, y0 + Math.Abs(x0 - X) * he, x0 - Math.Abs(y0 - y2) * wi, y0 + Math.Abs(x0 - x2) * he)
                    g.DrawLine(myPen2, X * wi, Y * he, x2 * wi, y2 * he)
                    g.DrawLine(myPen2, x0 - Math.Abs(x0 - X) * wi, y0 - Math.Abs(y0 - Y) * he, x0 - Math.Abs(x0 - x2) * wi, y0 - Math.Abs(y0 - y2) * he)
                    g.DrawLine(myPen2, x0 + Math.Abs(y0 - Y) * wi, y0 - Math.Abs(x0 - X) * he, x0 + Math.Abs(y0 - y2) * wi, y0 - Math.Abs(x0 - x2) * he)
                    g.DrawLine(myPen2, x0 - Math.Abs(y0 - Y) * wi, y0 + Math.Abs(x0 - X) * he, x0 - Math.Abs(y0 - y2) * wi, y0 + Math.Abs(x0 - x2) * he)
                ElseIf (x2 - x0) < 0 And (y2 - y0) < 0 Then
                    g.DrawLine(myPen, X * wi, Y * he, x2 * wi, y2 * he)
                    g.DrawLine(myPen, x0 + Math.Abs(x0 - X) * wi, y0 + Math.Abs(y0 - Y) * he, x0 + Math.Abs(x0 - x2) * wi, y0 + Math.Abs(y0 - y2) * he)
                    g.DrawLine(myPen, x0 + Math.Abs(y0 - Y) * wi, y0 - Math.Abs(x0 - X) * he, x0 + Math.Abs(y0 - y2) * wi, y0 - Math.Abs(x0 - x2) * he)
                    g.DrawLine(myPen, x0 - Math.Abs(y0 - Y) * wi, y0 + Math.Abs(x0 - X) * he, x0 - Math.Abs(y0 - y2) * wi, y0 + Math.Abs(x0 - x2) * he)
                    g.DrawLine(myPen2, X * wi, Y * he, x2 * wi, y2 * he)
                    g.DrawLine(myPen2, x0 + Math.Abs(x0 - X) * wi, y0 + Math.Abs(y0 - Y) * he, x0 + Math.Abs(x0 - x2) * wi, y0 + Math.Abs(y0 - y2) * he)
                    g.DrawLine(myPen2, x0 + Math.Abs(y0 - Y) * wi, y0 - Math.Abs(x0 - X) * he, x0 + Math.Abs(y0 - y2) * wi, y0 - Math.Abs(x0 - x2) * he)
                    g.DrawLine(myPen2, x0 - Math.Abs(y0 - Y) * wi, y0 + Math.Abs(x0 - X) * he, x0 - Math.Abs(y0 - y2) * wi, y0 + Math.Abs(x0 - x2) * he)
                ElseIf (x2 - x0) > 0 And (y2 - y0) < 0 Then
                    g.DrawLine(myPen, X * wi, Y * he, x2 * wi, y2 * he)
                    g.DrawLine(myPen, x0 - Math.Abs(x0 - X) * wi, y0 + Math.Abs(y0 - Y) * he, x0 - Math.Abs(x0 - x2) * wi, y0 + Math.Abs(y0 - y2) * he)
                    g.DrawLine(myPen, x0 + Math.Abs(y0 - Y) * wi, y0 + Math.Abs(x0 - X) * he, x0 + Math.Abs(y0 - y2), y0 + Math.Abs(x0 - x2) * he)
                    g.DrawLine(myPen, x0 - Math.Abs(y0 - Y) * wi, y0 - Math.Abs(x0 - X) * he, x0 - Math.Abs(y0 - y2), y0 - Math.Abs(x0 - x2) * he)
                    g.DrawLine(myPen2, X * wi, Y * he, x2 * wi, y2 * he)
                    g.DrawLine(myPen2, x0 - Math.Abs(x0 - X) * wi, y0 + Math.Abs(y0 - Y) * he, x0 - Math.Abs(x0 - x2) * wi, y0 + Math.Abs(y0 - y2) * he)
                    g.DrawLine(myPen2, x0 + Math.Abs(y0 - Y) * wi, y0 + Math.Abs(x0 - X) * he, x0 + Math.Abs(y0 - y2), y0 + Math.Abs(x0 - x2) * he)
                    g.DrawLine(myPen2, x0 - Math.Abs(y0 - Y) * wi, y0 - Math.Abs(x0 - X) * he, x0 - Math.Abs(y0 - y2), y0 - Math.Abs(x0 - x2) * he)
                ElseIf (x2 - x0) < 0 And (y2 - y0) > 0 Then
                    g.DrawLine(myPen, X * wi, Y * he, x2 * wi, y2 * he)
                    g.DrawLine(myPen, x0 + Math.Abs(x0 - X) * wi, y0 - Math.Abs(y0 - Y) * he, x0 + Math.Abs(x0 - x2) * wi, y0 - Math.Abs(y0 - y2) * he)
                    g.DrawLine(myPen, x0 - Math.Abs(y0 - Y) * wi, y0 - Math.Abs(x0 - X) * he, x0 - Math.Abs(y0 - y2) * wi, y0 - Math.Abs(x0 - x2) * he)
                    g.DrawLine(myPen, x0 + Math.Abs(y0 - Y) * wi, y0 + Math.Abs(x0 - X) * he, x0 + Math.Abs(y0 - y2) * wi, y0 + Math.Abs(x0 - x2) * he)
                    g.DrawLine(myPen2, X * wi, Y * he, x2 * wi, y2 * he)
                    g.DrawLine(myPen2, x0 + Math.Abs(x0 - X) * wi, y0 - Math.Abs(y0 - Y) * he, x0 + Math.Abs(x0 - x2) * wi, y0 - Math.Abs(y0 - y2) * he)
                    g.DrawLine(myPen2, x0 - Math.Abs(y0 - Y) * wi, y0 - Math.Abs(x0 - X) * he, x0 - Math.Abs(y0 - y2) * wi, y0 - Math.Abs(x0 - x2) * he)
                    g.DrawLine(myPen2, x0 + Math.Abs(y0 - Y) * wi, y0 + Math.Abs(x0 - X) * he, x0 + Math.Abs(y0 - y2) * wi, y0 + Math.Abs(x0 - x2) * he)
                End If
                g.Dispose()
                PictureBox1.Image = drawImage
                X = e.X
                Y = e.Y
            End If
                Dim text5 As Single = ToolStripTextBox5.Text
            Dim text1 As Single = ToolStripTextBox1.Text
            ToolStripTextBox1.Text = text1 + text5
            Dim text2 As Single = ToolStripTextBox2.Text
            Dim acheck As Integer = 0
            co1a += text2
            co2a -= text2
            If co1a > 255 Then
                co1a = 255
                acheck += 1
            End If
            If co2a > 255 Then
                co2a = 255
                acheck += 1
            End If
            If co1a < 0 Then
                co1a = 0
                acheck += 1
            End If
            If co2a < 0 Then
                co2a = 0
                acheck += 1
            End If
            If acheck >= 2 Then ToolStripTextBox2.Text = ToolStripTextBox2.Text * -1
        End If
        System.GC.Collect()
    End Sub
    Private Sub 載入圖片ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 載入圖片ToolStripMenuItem.Click
        OpenFileDialog1.Filter = "圖片檔 (*.png;*.jpg;*.bmp;*.gif;*.tif)|*.png;*.jpg;*.bmp;*.gif;*.tif"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim a As New Bitmap(OpenFileDialog1.FileName)
            PictureBox1.Image = a
        End If
    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim dlg As ColorDialog = New ColorDialog
        If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            color1 = dlg.Color
            ToolStripButton1.BackColor = color1
        End If
    End Sub
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim dlg As ColorDialog = New ColorDialog
        If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            color2 = dlg.Color
            ToolStripButton2.BackColor = color2
        End If
    End Sub
    Private Sub picturebox1_Mouseup(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        pencheck = False
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolStripButton1.BackColor = Color.Red
        ToolStripButton2.BackColor = Color.Green
        Me.DoubleBuffered = True
        ToolStripComboBox1.SelectedIndex = 5
    End Sub
End Class
'ElseIf penstyle = 7 Then '魔法陣
'' Dim xy07 As Point = New Point(x0, y0)
'Dim x07 As Integer = x0
'Dim y07 As Integer = y0
'Dim pic1s As Image = PictureBox1.Image
'x2 = x0 + Math.Abs(e.X - x0)
'y2 = y0 + Math.Abs(e.Y - y0)
'Dim drawImage As New Bitmap(pic1s, pic1s.Width, pic1s.Height)
'Dim g As Graphics = Graphics.FromImage(drawImage)
'Dim myPen As New Pen(Color.FromArgb(co1a, co1r, co1g, co1b), ToolStripTextBox1.Text)
'' Dim myPen2 As New Pen(Color.FromArgb(co2a, co2r, co2g, co2b), ToolStripTextBox1.Text * penandpen)
'Dim wi As Integer = (pic1s.Width / PictureBox1.Width)
'Dim he As Integer = (pic1s.Width / PictureBox1.Width)
'myPen.StartCap = Drawing2D.LineCap.Round '此行必要，否則線會斷
'' myPen2.StartCap = Drawing2D.LineCap.Round '此行必要，否則線會斷
'g.DrawLine(myPen, e.X * wi, e.Y * he, x2 * wi, y2 * he)
'g.DrawLine(myPen, e.Y * wi, e.X * he, y2 * wi, x2 * he)
'g.Dispose()
'PictureBox1.Image = drawImage
'X = x0 + Math.Abs(e.X - x0)
'Y = y0 + Math.Abs(e.Y - y0)


'ElseIf penstyle = 7 Then '魔法陣
'' Dim xy07 As Point = New Point(x0, y0)
'' Dim x07 As Integer = x0
''Dim y07 As Integer = y0
'Dim pic1s As Image = PictureBox1.Image
'x2 = x0 + Math.Abs(e.X - x0)
'y2 = y0 + Math.Abs(e.Y - y0)
'Dim drawImage As New Bitmap(pic1s, pic1s.Width, pic1s.Height)
'Dim g As Graphics = Graphics.FromImage(drawImage)
'Dim myPen As New Pen(Color.FromArgb(co1a, co1r, co1g, co1b), ToolStripTextBox1.Text)
'' Dim myPen2 As New Pen(Color.FromArgb(co2a, co2r, co2g, co2b), ToolStripTextBox1.Text * penandpen)
'Dim wi As Integer = (pic1s.Width / PictureBox1.Width)
'Dim he As Integer = (pic1s.Width / PictureBox1.Width)
'myPen.StartCap = Drawing2D.LineCap.Round '此行必要，否則線會斷
'' myPen2.StartCap = Drawing2D.LineCap.Round '此行必要，否則線會斷
'g.DrawLine(myPen, X * wi, Y * he, x2 * wi, y2 * he)
'x2 = x0 - Math.Abs(e.X - x0)
'y2 = y0 - Math.Abs(e.Y - y0)
'g.DrawLine(myPen, X * wi, Y * he, y2 * wi, x2 * he)
'g.Dispose()
'PictureBox1.Image = drawImage
'X = x0 + Math.Abs(e.X - x0)
'Y = y0 + Math.Abs(e.Y - y0)


'ElseIf penstyle = 8 Then '對稱魔法陣
'Dim pic1s As Image = PictureBox1.Image
'x2 = e.X
'y2 = e.Y
'Dim drawImage As New Bitmap(pic1s, pic1s.Width, pic1s.Height)
'Dim g As Graphics = Graphics.FromImage(drawImage)
'Dim myPen As New Pen(Color.FromArgb(co1a, co1r, co1g, co1b), ToolStripTextBox1.Text)
'Dim wi As Integer = (pic1s.Width / PictureBox1.Width)
'Dim he As Integer = (pic1s.Width / PictureBox1.Width)
'myPen.StartCap = Drawing2D.LineCap.Round '此行必要，否則線會斷
'If (x2 - x0) > 0 And (y2 - y0) > 0 Then
'g.DrawLine(myPen, X * wi, Y * he, x2 * wi, y2 * he)
'g.DrawLine(myPen, x0 - Math.Abs(x0 - X) * wi, y0 - Math.Abs(y0 - Y) * he, x0 - Math.Abs(x0 - x2) * wi, y0 - Math.Abs(y0 - y2) * he)
'g.DrawLine(myPen, X * wi, y0 - Math.Abs(y0 - Y) * he, X * wi, y0 - Math.Abs(y0 - y2) * he)
'g.DrawLine(myPen, x0 - Math.Abs(x0 - X) * wi, Y * he, x0 - Math.Abs(x0 - x2) * wi, Y)
'ElseIf (x2 - x0) < 0 And (y2 - y0) < 0 Then
'
'
'
'
'End If