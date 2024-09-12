Imports System
Imports HobbiesData

Module Program

    Private userServie As New UserService()
    Sub Main(args As String())
        Console.WriteLine("Programa que consulta usuarios por hora")

        search()

        Console.ReadKey()
    End Sub

    ''' <summary>
    ''' Searches users by last 2 hours
    ''' </summary>
    Private Sub search()
        Dim result As Result(Of List(Of User)) = userServie.GetUsersbyHour()

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
End Module
