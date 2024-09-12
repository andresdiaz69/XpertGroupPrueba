Imports System.Data
Imports System.Data.SqlClient

Public Class DataAccess
    Private Const _fileName As String = "Settings.xml"
    Private ReadOnly _connectionString As String
    Private _basePath As String
    Private _filePath As String

    ''' <summary>
    ''' Initializes a new instance of the <see cref=".DataAccess"/> class.
    ''' </summary>
    Public Sub New()
        _basePath = AppDomain.CurrentDomain.BaseDirectory
        _filePath = System.IO.Path.Combine(_basePath, _fileName)
        _connectionString = GetConnectionString()
    End Sub

    ''' <summary>
    ''' Executes the stored procedure to datatable.
    ''' </summary>
    ''' <param name="procedureName">Name of the procedure.</param>
    ''' <param name="parameters">The parameters.</param>
    ''' <returns></returns>
    Public Function ExecuteStoredProcedure(procedureName As String, parameters As SqlParameter()) As Result(Of DataTable)

        'Dim result As Result(Of DataTable)
        Dim resultDatatable As DataTable = New DataTable()

        Try
            Using connection As New SqlConnection(_connectionString)
                Using command As New SqlCommand(procedureName, connection)
                    command.CommandType = CommandType.StoredProcedure
                    If parameters IsNot Nothing Then
                        command.Parameters.AddRange(parameters)
                    End If

                    Using adapter As New SqlDataAdapter(command)
                        adapter.Fill(resultDatatable)
                    End Using

                    WriteLogResults(resultDatatable, $"Call SP {procedureName}")

                    Return Result(Of DataTable).Success((resultDatatable))
                End Using
            End Using


        Catch ex As Exception
            Return Result.Failure(ex.Message)
        End Try

    End Function

    ''' <summary>
    ''' Executes the stored procedure non query.
    ''' </summary>
    ''' <param name="procedureName">Name of the procedure.</param>
    ''' <param name="parameters">The parameters.</param>
    ''' <returns></returns>
    Public Function ExecuteStoredProcedureNonQuery(procedureName As String, parameters As SqlParameter()) As Result
        Try
            Using connection As New SqlConnection(_connectionString)
                Using command As New SqlCommand(procedureName, connection)
                    command.CommandType = CommandType.StoredProcedure

                    If parameters IsNot Nothing Then
                        command.Parameters.AddRange(parameters)
                    End If

                    connection.Open()
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()

                    WriteLogSimple($"Call SP {procedureName} rowsAffected= {rowsAffected}")

                    Return Result.Success
                End Using
            End Using
        Catch ex As Exception
            Return Result.Failure(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Gets the connection string.
    ''' </summary>
    ''' <returns>Connection string</returns>
    Public Function GetConnectionString() As String
        Dim xmlDoc As XDocument = XDocument.Load(_filePath)
        Dim connectionString As String =
            (From cs In xmlDoc.<configuration>.<connectionStrings>.<add>
             Where cs.Attribute("name").Value = "DefaultConnection"
             Select cs.Attribute("connectionString").Value).FirstOrDefault()
        Return connectionString
    End Function

    ''' <summary>
    ''' Gets the file log path.
    ''' </summary>
    ''' <returns>Path log file</returns>
    Public Function GetFileLogPath() As String
        Dim xmlDoc As XDocument = XDocument.Load(_filePath)
        Dim File As String =
            (From cs In xmlDoc.<configuration>.<appSettings>.<add>
             Where cs.Attribute("key").Value = "FileLog"
             Select cs.Attribute("value").Value).FirstOrDefault()
        Return File
    End Function

    ''' <summary>
    ''' Writes the log results.
    ''' </summary>
    ''' <param name="datatable">Datatable.</param>
    Private Sub WriteLogResults(datatable As DataTable, title As String)
        Dim File As String = GetFileLogPath()
        Dim infoText As String = title + DateTime.Now.ToString() + vbCrLf + Utilities.ConvertDataTableToTxt(datatable)

        System.IO.File.WriteAllText(File, infoText)
    End Sub

    Private Sub WriteLogSimple(info As String)
        Dim File As String = GetFileLogPath()
        System.IO.File.WriteAllText(File, info + DateTime.Now.ToString())
    End Sub
End Class
