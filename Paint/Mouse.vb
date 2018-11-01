Imports System.Windows.Forms
Imports System.Drawing

Public Class Mouse

    Public Shared _xFont, _yFont As Integer

    Shared Function getMouseClick() As Point
        While Control.MouseButtons <> MouseButtons.Left
        End While

        While Control.MouseButtons = MouseButtons.Left
        End While

        Return Control.MousePosition
    End Function

    Shared Sub Calibrate()
        Console.Clear()
        Console.CursorVisible = False

        Dim XCords As Integer(,) =
        {
            {Math.Floor(Console.WindowWidth * 0.04), Math.Floor(Console.WindowHeight * 0.05)},
            {Math.Floor(Console.WindowWidth * 0.92), Math.Floor(Console.WindowHeight * 0.9)}
        }

        Console.SetCursorPosition(XCords(0, 0), XCords(0, 1))
        Console.Write("X")

        Dim cursorPoint As Point = getMouseClick()
        Dim mouseX = cursorPoint.X
        Dim mouseY = cursorPoint.Y

        Console.Clear()
        Console.SetCursorPosition(XCords(1, 0), XCords(1, 1))
        Console.Write("X")

        cursorPoint = getMouseClick()
        mouseX -= cursorPoint.X
        mouseY -= cursorPoint.Y

        Console.Clear()
        _xFont = Math.Abs(Math.Round(mouseX / (XCords(1, 0) - XCords(0, 0))))
        _yFont = Math.Abs(Math.Round(mouseY / (XCords(1, 1) - XCords(0, 1))))

        'Console.WriteLine($"{_x} x {_y}")
    End Sub

    Shared ReadOnly Property MousePos As Point
        Get
            Return Control.MousePosition
        End Get
    End Property

End Class
