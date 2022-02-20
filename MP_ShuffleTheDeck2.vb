
Option Strict On
Option Explicit On
Option Compare Binary

Module MP_ShuffleTheDeck2

    Sub Main()
        Dim cardChosen(3, 12) As Boolean
        Dim trys As Integer
        Dim i As Integer = 0
        Dim letter As Integer
        Dim number As Integer
        For i = 1 To 10

            Do
                letter = RandomNumberInRange(3)
                number = RandomNumberInRange(8)
                trys += 1
            Loop While cardChosen(letter, number) = True
            Console.WriteLine($"draw {i} took {trys}")
            trys = 0
            cardChosen(letter, number) = True
        Next

        DisplayCard(cardChosen)
        Console.ReadLine()
    End Sub
    Sub DisplayCard(ByRef cardChosen(,) As Boolean)

        Dim header() As String = {"❤️", "spade", "Diamond", "Club"}
        Dim jay As String = "J"
        Dim width As Integer = 4
        Dim data As String
        For row = 0 To cardChosen.GetLength(1)
            For column = 0 To cardChosen.GetLength(0) - 1
                Select Case row
                    Case 0
                        data = header(column).PadLeft(width)
                    Case 1
                        data = "J"
                    Case Else
                        If cardChosen(column, row - 1) Then
                            data = ""
                        Else
                            data = CStr(row + 1)
                        End If
                End Select
                Console.Write(data.PadLeft(width) & "|")
            Next
            Console.WriteLine()
            Console.WriteLine(StrDup(20, "-"))
        Next

    End Sub

    Function RandomNumberInRange(Optional max% = 10%, Optional min% = 0%) As Integer
        Dim _max% = max - min
        If _max < 0 Then
            Throw New System.ArgumentException("Maximum number must be greater than minimum number")
        End If
        Randomize(DateTime.Now.Millisecond)
        Return CInt(System.Math.Floor(Rnd() * (_max + 1))) + min
    End Function





    'gets 2 through 10 
    Function GetRandomNumber() As Integer
        Dim value As Integer

        Dim temp As Single


        Do Until value > 1
            Randomize()
            temp = Rnd() * (9)
            value = CInt(System.Math.Floor(CDbl(temp)))
        Loop
        'generates value between 2-10
        Return value
    End Function


    'Get J,Q,K,A
    Function GetRandomLetter() As Integer
        Dim value As Integer

        Dim temp As Single
        Randomize()

        temp = Rnd() * 4
        value = CInt(System.Math.Floor(CDbl(temp)))
        'generates value between 1-chosen array length

        Return value
    End Function

End Module
