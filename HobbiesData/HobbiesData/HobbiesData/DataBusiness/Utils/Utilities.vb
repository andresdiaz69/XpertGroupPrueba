Imports System.Data

Public Class Utilities

    ''' <summary>
    ''' Converts the data table to list T.
    ''' </summary>
    ''' <typeparam name="T">T object</typeparam>
    ''' <param name="dataTable">The data table.</param>
    ''' <returns>List of T</returns>
    Public Shared Function ConvertDataTableToList(Of T As New)(dataTable As DataTable) As List(Of T)
        Dim result As New List(Of T)()

        For Each row As DataRow In dataTable.Rows
            Dim obj As New T()

            For Each prop In GetType(T).GetProperties()
                If dataTable.Columns.Contains(prop.Name) AndAlso Not IsDBNull(row(prop.Name)) Then
                    prop.SetValue(obj, row(prop.Name), Nothing)
                End If
            Next

            result.Add(obj)
        Next

        Return result
    End Function

    ''' <summary>
    ''' Converts the data table to text.
    ''' </summary>
    ''' <param name="dataTable">The data table.</param>
    ''' <returns>Dt info in txt</returns>
    Public Shared Function ConvertDataTableToTxt(dataTable As DataTable)

        Dim stringBuilder As New System.Text.StringBuilder()

        For Each column As DataColumn In dataTable.Columns
            stringBuilder.Append(column.ColumnName & vbTab)
        Next

        stringBuilder.AppendLine()

        For Each row As DataRow In dataTable.Rows
            For Each column As DataColumn In dataTable.Columns
                stringBuilder.Append(row(column).ToString() & vbTab)
            Next
            stringBuilder.AppendLine()
        Next

        Return stringBuilder.ToString()

    End Function

    ''' <summary>
    ''' Validates the string.
    ''' </summary>
    ''' <param name="str">The string.</param>
    ''' <returns>Result validation</returns>
    Public Shared Function ValidateString(str As String, len As Integer) As Result

        If String.IsNullOrEmpty(str) Then
            Return Result.Failure("El dato ingresado no puede estar vacío. Inténtelo de nuevo.")
        End If

        If str.Length > len Then
            Return Result.Failure($"El dato ingresado no ser superior a {len} caracteres. Inténtelo de nuevo.")
        End If

        Return Result.Success
    End Function

    ''' <summary>
    ''' Validates the number.
    ''' </summary>
    ''' <param name="str">The string.</param>
    ''' <returns>Result validation</returns>
    Public Shared Function ValidateNumber(str As String)
        Dim age As Integer = 0

        If Not Integer.TryParse(str, age) Then
            Return Result.Failure("El dato ingresado no es numérico. Inténtelo de nuevo.")
        End If

        If str.Length <= 0 Then
            Return Result.Failure("El dato ingresado no ser menor o igual a cero")
        End If

        Return Result.Success
    End Function

End Class
