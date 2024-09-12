

Imports System.Data
Imports System.Data.SqlClient

Public Class UserRepository
    Implements IUserRepository

    Private _dataAccess As DataAccess

    ''' <summary>
    ''' Initializes a new instance of the <see cref=".UserRepository"/> class.
    ''' </summary>
    Public Sub New()
        _dataAccess = New DataAccess()
    End Sub

    ''' <summary>
    ''' Saves the user.
    ''' </summary>
    ''' <param name="user">The user.</param>
    ''' <returns>
    ''' Result transaction
    ''' </returns>
    Public Function SaveUser(user As User) As Result Implements IUserRepository.SaveUser

        Dim parameters() As SqlParameter = {
            New SqlParameter("@Nombre", SqlDbType.NVarChar, 50) With {.Value = user.Nombre},
            New SqlParameter("@Apellido", SqlDbType.NVarChar, 50) With {.Value = user.Apellido},
            New SqlParameter("@Edad", SqlDbType.Int) With {.Value = user.Edad},
            New SqlParameter("@Hobbies", SqlDbType.NVarChar, 50) With {.Value = user.Hobbies},
            New SqlParameter("@UsuarioCreacion", SqlDbType.Int) With {.Value = user.UsuarioCreacion}
        }
        Return _dataAccess.ExecuteStoredProcedureNonQuery("SP_Crear_Usuario_V1", parameters)
    End Function

    ''' <summary>
    ''' Gets the usersby age.
    ''' </summary>
    ''' <param name="age">The age.</param>
    ''' <returns>
    ''' Result transaction
    ''' </returns>
    Public Function GetUsersbyAge(age As Integer) As Result(Of List(Of User)) Implements IUserRepository.GetUsersbyAge

        Dim parameters() As SqlParameter = {
            New SqlParameter("@Edad", SqlDbType.Int) With {.Value = age}}

        Dim resultConsult As Result(Of DataTable) =
            _dataAccess.ExecuteStoredProcedure("ObtenerUsuariosxEdad", parameters)

        If resultConsult.IsSuccess Then
            Return Result(Of List(Of User)).Success(
                (Utilities.ConvertDataTableToList(Of User)(resultConsult.Value)))
        Else
            Return Result(Of List(Of User)).Failure(resultConsult.ErrorMessage)
        End If
    End Function

    ''' <summary>
    ''' Gets the usersby hour.
    ''' </summary>
    ''' <returns>
    ''' Result transaction
    ''' </returns>
    Public Function GetUsersbyHour() As Result(Of List(Of User)) Implements IUserRepository.GetUsersbyHour


        Dim resultConsult =
            _dataAccess.ExecuteStoredProcedure("ObtenerUsuariosxHora", Nothing)

        If resultConsult.IsSuccess Then
            Return Result(Of List(Of User)).Success(
                (Utilities.ConvertDataTableToList(Of User)(resultConsult.Value)))
        Else
            Return Result(Of List(Of User)).Failure(resultConsult.ErrorMessage)
        End If

    End Function

End Class
