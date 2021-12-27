Imports System, System.IO, System.Collections.Generic
Imports System.Drawing, System.Drawing.Drawing2D
Imports System.ComponentModel, System.Windows.Forms
Imports System.IO.Compression
Imports Microsoft.VisualBasic.CompilerServices
Imports System.Runtime.CompilerServices
Imports System.Security.Cryptography
Imports System.Text
Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim m As New OpenFileDialog
        m.Filter = "Application *.exe|*.exe"
        m.Title = "Select"
        If m.ShowDialog = DialogResult.OK Then TextBox1.Text = m.FileName
    End Sub

    Private Sub XD_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XD.Tick
        L1.Text = RN() : L2.Text = "2" & RNN(2, "123456")
    End Sub
    Function RN() As String
        Randomize()
        t = New Random
        s = ""
        Dim k As String
        k = "!/*-;,?µ£=)@\[{~"
        s += k(t.Next(0, k.Length))
        Return s
    End Function
    Dim t As Random : Dim s As String
    Function RNN(ByVal l As Integer, ByVal k As String) As String
        Randomize()
        t = New Random
        s = ""
        For i = 1 To l
            s += k(t.Next(0, k.Length))
        Next
        Return s
    End Function
    Function Crypt(ByVal w As String)
        Dim bui As New System.Text.StringBuilder
        For i = 0 To w.Length - 1
            bui.Append(Convert.ToString(CLng(Asc(w.Substring(i, 1))), 2) & L1.Text)
        Next
        Return bui.ToString.Remove(bui.ToString.Length - 1, 1)
    End Function
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If TextBox1.Text = "" Then Exit Sub
        If Dir(TextBox1.Text) = "" Then MsgBox("( " & TextBox1.Text & " ) Invalid File !", MsgBoxStyle.Critical) : Exit Sub
        Dim q As String = RNN(15, "劳是英说肉自说会想伏乓是问年英的语仰方那动想是非动是表道动语")
        RichTextBox1.Text = E1.Text.Replace("$S$", q)
        Dim xw As String = Crypt(Convert.ToBase64String((IO.File.ReadAllBytes(TextBox1.Text))))
        Dim x As Integer = 0
        For i As Integer = 1 To Int(L2.Text) - (xw.Length Mod Int(L2.Text))
            x += 1
        Next
        Dim w2 As String = xw.Substring(xw.Length - x, x)
        Dim w1 As String = xw.Substring(0, xw.Length - x)
        Dim bui As New System.Text.StringBuilder
        Dim co As String
        For j As Integer = 1 To w1.Length Step Int(L2.Text)
            co = Mid(w1, j, Int(L2.Text))
            bui.Append(q & " += " & Chr(34) & co & Chr(34) & vbNewLine & "'" & RNN(120, co) & vbNewLine)
        Next
        bui.Append(q & " += " & Chr(34) & w2 & Chr(34) & vbNewLine)
        RichTextBox1.Text += bui.ToString
        Dim z1 As String = RNN(9, "劳是英说肉自说会想伏乓是问年英的语仰方那动想是非动是表道动语")
        Dim z2 As String = RNN(10, "劳是英说肉自说会想伏乓是问年英的语仰方那动想是非动是表道动语")
        RichTextBox1.Text += E2.Text.Replace("$f$", z1).Replace("$ff$", z2).Replace("$S$", q).Replace("$s$", L1.Text)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If RichTextBox1.Text = "" Then Exit Sub
        Clipboard.SetText(RichTextBox1.Text)
        MsgBox("Copy", MsgBoxStyle.Information)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim sfd As New SaveFileDialog
        sfd.Filter = "Visual Basic File|*.vb"
        If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
            File.WriteAllText(sfd.FileName, RichTextBox1.Text)
            MsgBox("Save" & sfd.FileName, MsgBoxStyle.Information, "Information")
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        RichTextBox1.Text = ""
        MsgBox("Copy", MsgBoxStyle.Information)
    End Sub
End Class
