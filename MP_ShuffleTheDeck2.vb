'Morgan Puckett
'RCET 0265
'Spring 2022
'Shuffle the Deck

Option Strict On
Option Explicit On
Option Compare Binary

Module MP_ShuffleTheDeck2

    Sub Main()
        'Dim varibles to create array & random numbers to blank out 
        Dim cardChosen(3, 13) As Boolean
        Dim trys As Integer
        Dim i As Integer = 0
        Dim letter As Integer
        Dim number As Integer
        For i = 1 To 25

            Do
                'this marks specific values in array true (Blank)
                letter = RandomNumberInRange(3)
                number = RandomNumberInRange(13)
                trys += 1
            Loop While cardChosen(letter, number) = True
            'Enablt this to see if/when a number gets redrawn
            'Console.WriteLine($"draw {i} took {trys}")
            trys = 0
            cardChosen(letter, number) = True
        Next

        DisplayCard(cardChosen)
        Console.ReadLine()
    End Sub
    Sub DisplayCard(ByRef cardChosen(,) As Boolean)
        'these string arrays will create a header for the table 
        Dim header() As String = {"Heart", "Spade", "Diamond", "Club"}
        'allows for designated number values 
        Dim ajqk() As String = {"A", "J", "Q", "K"}
        Dim width As Integer = 7
        Dim data As String
        'creates table look of the array on user interface
        For row = 0 To cardChosen.GetLength(1)
            For column = 0 To cardChosen.GetLength(0) - 1
                Select Case row
                    Case 0
                        data = header(column).PadLeft(width)
                    Case Else
                        'if a value = true then it will not show up on the array 
                        If cardChosen(column, row - 1) = True Then
                            data = ""
                        Else
                            'this select case will allow the array to mark true other values
                            'but when a value isnt true it will place a letter in the A,J,K,Q values
                            Select Case row
                                Case 1
                                    data = ajqk(0).PadLeft(width)
                                Case 12
                                    data = ajqk(1).PadLeft(width)
                                Case 13
                                    data = ajqk(2).PadLeft(width)
                                Case 14
                                    data = ajqk(3).PadLeft(width)
                                Case Else
                                    data = CStr(row)
                            End Select
                        End If
                End Select
                Console.Write(data.PadLeft(width) & "|")
            Next
            Console.WriteLine()
            Console.WriteLine(StrDup(32, "-"))
        Next

    End Sub
    'a function that allows user to generate random numbers, max and min values are optional
    Function RandomNumberInRange(Optional max% = 10%, Optional min% = 0%) As Integer
        Dim _max% = max - min
        If _max < 0 Then
            Throw New System.ArgumentException("Maximum number must be greater than minimum number")
        End If
        Randomize(DateTime.Now.Millisecond)
        Return CInt(System.Math.Floor(Rnd() * (_max + 1))) + min
    End Function
End Module
