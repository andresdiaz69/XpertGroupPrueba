Public Class User
    Private _nombre As String
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _Apellido As String
    Public Property Apellido() As String
        Get
            Return _Apellido
        End Get
        Set(ByVal value As String)
            _Apellido = value
        End Set
    End Property

    Private _edad As Integer
    Public Property Edad() As Integer
        Get
            Return _edad
        End Get
        Set(ByVal value As Integer)
            _edad = value
        End Set
    End Property

    Private _hobbies As String
    Public Property Hobbies() As String
        Get
            Return _hobbies
        End Get
        Set(ByVal value As String)
            _hobbies = value
        End Set
    End Property

    Private _usuarioCreacion As Integer
    Public Property UsuarioCreacion() As Integer
        Get
            Return _usuarioCreacion
        End Get
        Set(ByVal value As Integer)
            _usuarioCreacion = value
        End Set
    End Property
End Class
