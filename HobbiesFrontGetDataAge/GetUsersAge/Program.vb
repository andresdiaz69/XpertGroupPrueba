Imports System
Imports HobbiesData

Module Program

    Private userServie As New UserService()

    Sub Main(args As String())
        Console.WriteLine("Programa que consulta usuarios por edad")

        Dim age As Integer = GetAgeSearch()
        search(age)

        Console.ReadKey()
    End Sub

    ''' <summary>
    ''' Searches users by the specified age.
    ''' </summary>
    ''' <param name="age">The age.</param>
    Private Sub search(age As Integer)
        Dim result As Result(Of List(Of User)) = userServie.GetUsersbyAge(age)

        If result.IsSuccess Then
            Console.WriteLine("Usuarios: ")
            For Each user As User In result.Value
                Console.WriteLine($"Nombre: {user.Nombre}, Apellido: {user.Apellido}, Edad: {user.Edad}, Hobbies: {user.Hobbies}"
                                  )
            Next
        Else
            Console.WriteLine($"Error al crear usuario, detalle tecnico: {result.ErrorMessage}")
        End If
    End Sub

    ''' <summary>
    ''' Gets the age for search.
    ''' </summary>
    ''' <returns>Age</returns>
    Private Function GetAgeSearch() As Integer
        Dim ageStr As String = String.Empty
        Dim age As Integer = 0
        Dim result As Result

        Do
            Console.Write("Ingrese edad usuario para la busqueda: ")
            ageStr = Console.ReadLine()

            result = Utilities.ValidateNumber(ageStr)

            If Not result.IsSuccess Then
                Console.WriteLine(result.ErrorMessage)
            End If

        Loop While Not result.IsSuccess

        age = Integer.Parse(ageStr)

        Return ageStr
    End Function
End Module
