Imports System.Windows.Forms
Imports System.Drawing

Module Module1

    Sub Main()

        Console.CursorVisible = False

        Console.WriteLine(
"Please turn off quick edit
Please put in full screen (f11)
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
        Dim lastPoint As ConsolePoint = New ConsolePoint(0, 0)
        Do
            Console.BackgroundColor = backColor
            Dim mousePoint = Mouse.MousePos
            Dim xCord As Integer = Math.Ceiling(mousePoint.X / Mouse._xFont)
            Dim yCord As Integer = Math.Ceiling(mousePoint.Y / Mouse._yFont)

            yCord -= If(yCord = 0, 0, 1)
            Dim currentPoint As ConsolePoint = New ConsolePoint(xCord, yCord)

            If Control.MouseButtons = MouseButtons.Left And xCord < Console.WindowWidth Then
                If mouseHeld Then
                    For t As Decimal = 0 To 1 Step 0.01
                        Console.SetCursorPosition(lastPoint.X * t + currentPoint.X * (1 - t), lastPoint.Y * t + currentPoint.Y * (1 - t))
                        Console.Write("  ")
                    Next
                End If

                If Not mouseHeld Then
                    mouseHeld = True
                End If

                lastPoint = currentPoint

                Console.SetCursorPosition(xCord, yCord)
                Console.Write("  ")
            End If

            If Control.MouseButtons <> MouseButtons.Left Then
                mouseHeld = False
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
