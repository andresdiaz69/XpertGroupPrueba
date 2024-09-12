Imports System
Imports HobbiesData

Module Program
    Sub Main(args As String())
        Console.WriteLine("Hello World!")

        Dim userservice As UserService = New UserService()

        'userservice.SaveUser(New User() With {
        '    .Nombre = "andresdts",
        '    .Apellido = "ApeTest",
        '    .Edad = 25,
        '    .Hobbies = "1-2-5-4-1-8",
        '    .UsuarioCreacion = 1
        '})

        Dim result As Result(Of List(Of User)) =
            userservice.GetUsersbyAge(26)

        Console.ReadKey()
    End Sub
End Module
