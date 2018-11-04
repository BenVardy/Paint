Imports System.Windows.Forms
Imports System.Drawing

Module Module1

    Sub Main()

        Console.CursorVisible = False

        Console.WriteLine(
"Please turn off quick edit
Please put in full screen (f11)
Click the crosses to Calibrate
Press Enter to exit the program whilst running

Black = Tab
Blue = 'B'
Cyan = 'C'
Green = 'G'
Magenta = 'M'
Red = 'R'
Yellow = 'Y'
Eraser = 'E'
Press Any Key to continue..."
        )
        Console.ReadKey()

        Mouse.Calibrate()

        Console.CursorVisible = False
        Console.BackgroundColor = ConsoleColor.White
        Console.Clear()

        Dim backColor As ConsoleColor = ConsoleColor.Black

        Dim mouseHeld As Boolean = False
        Dim lastPoints As New List(Of ConsolePoint)
        Do
            Console.BackgroundColor = backColor
            Dim mousePoint = Mouse.MousePos
            Dim xCord As Integer = Math.Ceiling(mousePoint.X / Mouse._xFont)
            Dim yCord As Integer = Math.Ceiling(mousePoint.Y / Mouse._yFont)

            yCord -= If(yCord = 0, 0, 1)
            Dim currentPoint As ConsolePoint = New ConsolePoint(xCord, yCord)

            If Control.MouseButtons = MouseButtons.Left And xCord < Console.WindowWidth Then
                If mouseHeld And lastPoints.Count = 4 Then
                    Dim P0 = lastPoints(1)
                    Dim P3 = lastPoints(2)

                    Dim P1 As New ConsolePoint(lastPoints(1).X + (lastPoints(2).X - lastPoints(0).X) / 6, lastPoints(1).Y + (lastPoints(2).Y - lastPoints(0).Y) / 6)
                    Dim P2 As New ConsolePoint(lastPoints(2).X - (lastPoints(3).X - lastPoints(1).X) / 6, lastPoints(2).Y - (lastPoints(3).Y - lastPoints(1).Y) / 6)

                    For t As Decimal = 0 To 1 Step 0.01
                        Dim x As Integer = (1 - t) ^ 3 * P0.X + 3 * t * (1 - t) ^ 2 * P1.X + 3 * t ^ 2 * (1 - t) * P2.X + t ^ 3 * P3.X
                        Dim y As Integer = (1 - t) ^ 3 * P0.Y + 3 * t * (1 - t) ^ 2 * P1.Y + 3 * t ^ 2 * (1 - t) * P2.Y + t ^ 3 * P3.Y
                        Console.SetCursorPosition(x, y)
                        Console.Write("  ")
                    Next
                End If

                If Not mouseHeld Then
                    mouseHeld = True
                End If

                lastPoints.Add(currentPoint)
                If lastPoints.Count > 4 Then lastPoints.RemoveAt(0)

                'Console.SetCursorPosition(xCord, yCord)
                'Console.Write("  ")
            End If

            If Control.MouseButtons <> MouseButtons.Left Then
                mouseHeld = False
                lastPoints = New List(Of ConsolePoint)
            End If


            If Console.KeyAvailable Then
                Console.SetCursorPosition(0, 0)
                Dim key = Console.ReadKey
                Console.CursorLeft = 0
                Console.BackgroundColor = ConsoleColor.White
                Console.Write("  ")
                Console.BackgroundColor = backColor

                Select Case key.Key
                    Case ConsoleKey.Enter
                        Environment.Exit(0)
                    Case ConsoleKey.Spacebar
                        Console.BackgroundColor = ConsoleColor.White
                        Console.Clear()
                    Case ConsoleKey.Tab
                        backColor = ConsoleColor.Black
                    Case ConsoleKey.B
                        backColor = ConsoleColor.Blue
                    Case ConsoleKey.C
                        backColor = ConsoleColor.Cyan
                    Case ConsoleKey.G
                        backColor = ConsoleColor.Green
                    Case ConsoleKey.M
                        backColor = ConsoleColor.Magenta
                    Case ConsoleKey.R
                        backColor = ConsoleColor.Red
                    Case ConsoleKey.Y
                        backColor = ConsoleColor.Yellow
                    Case ConsoleKey.E
                        backColor = ConsoleColor.White
                End Select

            End If
        Loop

    End Sub

End Module
