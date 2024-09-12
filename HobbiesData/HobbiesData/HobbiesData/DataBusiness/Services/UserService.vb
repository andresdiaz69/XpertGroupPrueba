Public Class UserService
    Implements IUserService

    Private _userRepository As IUserRepository

    ''' <summary>
    ''' Initializes a new instance of the <see cref="UserService"/> class.
    ''' </summary>
    Public Sub New()
        _userRepository = New UserRepository()
    End Sub

    ''' <summary>
    ''' Saves the user.
    ''' </summary>
    ''' <param name="user">The user.</param>
    ''' <returns>
    ''' Result transaction
    ''' </returns>
    Public Function SaveUser(user As User) As Result Implements IUserService.SaveUser
        Return _userRepository.SaveUser(user)
    End Function

    ''' <summary>
    ''' Gets the usersby age.
    ''' </summary>
    ''' <param name="age">The age.</param>
    ''' <returns>
    ''' Result transaction
    ''' </returns>
    Public Function GetUsersbyAge(age As Integer) As Result(Of List(Of User)) Implements IUserService.GetUsersbyAge
        Return _userRepository.GetUsersbyAge(age)
    End Function

    ''' <summary>
    ''' Gets the usersby hour.
    ''' </summary>
    ''' <returns>
    ''' Result transaction
    ''' </returns>
    Public Function GetUsersbyHour() As Result(Of List(Of User)) Implements IUserService.GetUsersbyHour
        Return _userRepository.GetUsersbyHour()
    End Function

End Class
