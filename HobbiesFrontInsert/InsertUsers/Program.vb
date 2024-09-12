Imports System
Imports HobbiesData

Module Program
    Private user As User
    Private userServie As New UserService()
    Sub Main(args As String())
        Console.WriteLine("Programa que inserta un usuario en la BD")

        GetInfoUser()
        InsertUser()

        Console.ReadKey()
    End Sub

    ''' <summary>
    ''' Gets the information user.
    ''' </summary>
    Private Sub GetInfoUser()
        user = New User()

        With user
            .Nombre = GetName()
            .Apellido = GetLastName()
            .Edad = GetAge()
            .Hobbies = GetHobbies()
            .UsuarioCreacion = 1 'Id Admin (usuario "logueado")
        End With
    End Sub

    Public Sub InsertUser()
        Dim result As Result = userServie.SaveUser(user)

        If result.IsSuccess Then
            Console.WriteLine("Usuario creado con éxito")
        Else
            Console.WriteLine($"Error al crear usuario, detalle tecnico: {result.ErrorMessage}")
        End If
    End Sub

    ''' <summary>
    ''' Gets the name.
    ''' </summary>
    ''' <returns>name</returns>
    Private Function GetName() As String
        Dim name As String = String.Empty
        Dim result As Result

        Do
            Console.Write("Ingrese nombre usuario: ")
            name = Console.ReadLine()

            result = Utilities.ValidateString(name, 50)

            If Not result.IsSuccess Then
                Console.WriteLine(result.ErrorMessage)
            End If

        Loop While Not result.IsSuccess

        Return name
    End Function

    ''' <summary>
    ''' Gets the last name.
    ''' </summary>
    ''' <returns>last name</returns>
    Private Function GetLastName() As String
        Dim lastname As String = String.Empty
        Dim result As Result

        Do
            Console.Write("Ingrese apellido usuario: ")
            lastname = Console.ReadLine()

            result = Utilities.ValidateString(lastname, 50)

            If Not result.IsSuccess Then
                Console.WriteLine(result.ErrorMessage)
            End If

        Loop While Not result.IsSuccess

        Return lastname
    End Function

    ''' <summary>
    ''' Gets the age.
    ''' </summary>
    ''' <returns>age</returns>
    Private Function GetAge() As Integer
        Dim ageStr As String = String.Empty
        Dim age As Integer = 0
        Dim result As Result

        Do
            Console.Write("Ingrese edad usuario: ")
            ageStr = Console.ReadLine()

            result = Utilities.ValidateNumber(ageStr)

            If Not result.IsSuccess Then
                Console.WriteLine(result.ErrorMessage)
            End If

        Loop While Not result.IsSuccess

        age = Integer.Parse(ageStr)

        Return ageStr
    End Function

    ''' <summary>
    ''' Gets the Hobbies.
    ''' </summary>
    ''' <returns>hobbies</returns>
    Private Function GetHobbies() As String
        Dim hobbies As String = String.Empty
        Dim result As Result

        Do
            Console.Write("Ingrese hobbies (separados por guion  - ): ")
            hobbies = Console.ReadLine()

            result = Utilities.ValidateString(hobbies, 300)

            If Not result.IsSuccess Then
                Console.WriteLine(result.ErrorMessage)
            End If

        Loop While Not result.IsSuccess

        Return hobbies
    End Function
End Module
