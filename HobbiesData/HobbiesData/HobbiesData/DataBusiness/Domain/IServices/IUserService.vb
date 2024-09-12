Public Interface IUserService
    ''' <summary>
    ''' Saves the user.
    ''' </summary>
    ''' <param name="user">The user.</param>
    ''' <returns>Result transaction</returns>
    Function SaveUser(user As User) As Result

    ''' <summary>
    ''' Gets the usersby age.
    ''' </summary>
    ''' <param name="age">The age.</param>
    ''' <returns>Result transaction</returns>
    Function GetUsersbyAge(age As Integer) As Result(Of List(Of User))

    ''' <summary>
    ''' Gets the usersby hour.
    ''' </summary>
    ''' <returns>Result transaction</returns>
    Function GetUsersbyHour() As Result(Of List(Of User))
End Interface
