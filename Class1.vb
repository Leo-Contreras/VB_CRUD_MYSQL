Imports System.Data.SqlClient

Public Class Class1
    Dim conn As New SqlConnection("server=DESKTOP-G48S0RP\SQLEXPRESS;Initial Catalog=CRUD;Integrated Security=True")

    Public Function ListarEmpleados() As DataTable
        Dim da As New SqlDataAdapter("pb_listar", conn)
        Dim tbl As New DataTable
        da.Fill(tbl)
        Return tbl
    End Function

    Public Function Insertar(nom As String, direc As String, fechaing As Date, fechater As Date, area As String)
        Dim da As New SqlCommand("pb_nuevo", conn)
        da.CommandType = CommandType.StoredProcedure
        da.Parameters.AddWithValue("@nombre", nom)
        da.Parameters.AddWithValue("@direccion", direc)
        da.Parameters.AddWithValue("@fechaing", fechaing)
        da.Parameters.AddWithValue("@fechater", fechater)
        da.Parameters.AddWithValue("@area", area)
        conn.Open()
        Dim resp As Integer
        Try
            resp = da.ExecuteNonQuery
            conn.Close()

        Catch ex As Exception
            MsgBox("Error Al registrar usuario")
        End Try
        Return resp
    End Function

    Public Function Eliminar(codigo As String)
        Dim elim As New SqlCommand("pb_eliminar", conn)
        elim.CommandType = CommandType.StoredProcedure
        elim.Parameters.AddWithValue("@codigo", codigo)
        conn.Open()
        Dim elim1 As String = elim.ExecuteNonQuery
        conn.Close()
        Return elim1
    End Function

    Public Function Modificar(codigo As String, nom As String, direc As String, fechaing As Date, fechater As Date, area As String)
        Dim modf As New SqlCommand("pb_modificar", conn)
        modf.CommandType = CommandType.StoredProcedure
        modf.Parameters.AddWithValue("@codigo", codigo)
        modf.Parameters.AddWithValue("@nombre", nom)
        modf.Parameters.AddWithValue("@direccion", direc)
        modf.Parameters.AddWithValue("@fechaing", fechaing)
        modf.Parameters.AddWithValue("@fechater", fechater)
        modf.Parameters.AddWithValue("@area", area)
        conn.Open()
        Dim modf1 As String = modf.ExecuteNonQuery
        conn.Close()
        Return modf1
    End Function


End Class
