Public Class Result
    Public Property IsSuccess As Boolean
    Public Property ErrorMessage As String

    ''' <summary>
    ''' Initializes a new instance of the <see cref="Result"/> class.
    ''' </summary>
    ''' <param name="isSuccess">if set to <c>true</c> [is success].</param>
    ''' <param name="errorMessage">The error message.</param>
    Public Sub New(ByVal isSuccess As Boolean, ByVal errorMessage As String)
        Me.IsSuccess = isSuccess
        Me.ErrorMessage = errorMessage
    End Sub

    ''' <summary>
    ''' Successes this instance.
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function Success() As Result
        Return New Result(True, String.Empty)
    End Function

    ''' <summary>
    ''' Failures the specified error message.
    ''' </summary>
    ''' <param name="errorMessage">The error message.</param>
    ''' <returns></returns>
    Public Shared Function Failure(ByVal errorMessage As String) As Result
        Return New Result(False, errorMessage)
    End Function
End Class

Public Class Result(Of T)
    Inherits Result

    Public Property Value As T

    ''' <summary>
    ''' Initializes a new instance of the <see cref="Result{T}"/> class.
    ''' </summary>
    ''' <param name="isSuccess">if set to <c>true</c> [is success].</param>
    ''' <param name="errorMessage">The error message.</param>
    ''' <param name="value">The value.</param>
    Private Sub New(ByVal isSuccess As Boolean, ByVal errorMessage As String, ByVal value As T)
        MyBase.New(isSuccess, errorMessage)
        Me.Value = value
    End Sub

    ''' <summary>
    ''' Successes the specified value.
    ''' </summary>
    ''' <param name="value">The value.</param>
    ''' <returns></returns>
    Public Shared Function Success(ByVal value As T) As Result(Of T)
        Return New Result(Of T)(True, String.Empty, value)
    End Function

    ''' <summary>
    ''' Failures the specified error message.
    ''' </summary>
    ''' <param name="errorMessage">The error message.</param>
    ''' <returns></returns>
    Public Overloads Shared Function Failure(ByVal errorMessage As String) As Result(Of T)
        Return New Result(Of T)(False, errorMessage, Nothing)
    End Function
End Class
