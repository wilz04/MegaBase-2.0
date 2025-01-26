Imports System.Data.Odbc
Imports System.Data.OracleClient

Module Cx

  Private OdbcCmd As OdbcCommand
  Private cx As OdbcConnection
  Private dataSet As OdbcDataReader
  Private Ocmd As OracleCommand
  Private order As String

  Public Sub Cx_init()
    Ocmd = New OracleCommand
    cx = New OdbcConnection("DSN=General; UID=USV08; PWD=USV08;")
    Ocmd.Connection = New OracleConnection("Server=General; UID=USV08; PWD=USV08;")
  End Sub

  Public Function getN() As String
    Try
      cx.Open()
      order = "Select max(Numero_factura) From Factura_venta;"
      OdbcCmd = New OdbcCommand(order, cx)
      dataSet = OdbcCmd.ExecuteReader()
      dataSet.Read()
      Dim n As String
      n = Trim(Str(Val(dataSet.Item(0)) + 1))
      dataSet.Close()
      cx.Close()
      Return n
    Catch e As Exception
      dataSet.Close()
      cx.Close()
      Return "1"
    End Try
  End Function

  Public Sub getRows(ByRef cb As System.Windows.Forms.ComboBox, ByVal col As String)
    Try
      cx.Open()
      order = "Select Codigo from " & col & ";"
      OdbcCmd = New OdbcCommand(order, cx)
      dataSet = OdbcCmd.ExecuteReader()
      Dim i As Integer
      i = 0
      While dataSet.Read()
        cb.Items.Add(dataSet.Item(i))
      End While
      dataSet.Close()
      cx.Close()
    Catch e As Exception
      dataSet.Close()
      cx.Close()
    End Try
    cb.Text = "<< Selecciona una opción >>"
  End Sub

  Public Function addPurchaseBill(ByVal number As String, ByVal today As Date, ByVal supplier As String, ByVal payType As String, ByVal count_cred As String, ByVal days As String, ByVal u As String, ByVal article As String, ByVal quantity As Integer, ByVal discount As Integer, ByVal total As Integer) As Boolean
    Try
      Ocmd.Connection.Open()
      Ocmd.CommandType = CommandType.StoredProcedure
      Ocmd.CommandText = "Add_PurchaseBill"
      Ocmd.Parameters.Add(New OracleParameter("idNumber", number))
      Ocmd.Parameters.Add(New OracleParameter("today", today))
      Ocmd.Parameters.Add(New OracleParameter("supplier", supplier))
      Ocmd.Parameters.Add(New OracleParameter("payType", payType))
      Ocmd.Parameters.Add(New OracleParameter("count_cred", count_cred))
      Ocmd.Parameters.Add(New OracleParameter("days", days))
      Ocmd.Parameters.Add(New OracleParameter("u", u))
      Ocmd.Parameters.Add(New OracleParameter("article", article))
      Ocmd.Parameters.Add(New OracleParameter("quantity", quantity))
      Ocmd.Parameters.Add(New OracleParameter("discount", discount))
      Ocmd.Parameters.Add(New OracleParameter("total", total))
      Ocmd.ExecuteReader()
      Ocmd.Connection.Close()
      Return True
    Catch e As Exception
      Ocmd.Connection.Close()
      Return False
    End Try
  End Function

  Public Function addSupplier(ByVal code As String, ByVal name As String, ByVal id As String, ByVal setCredit As String, ByVal phone As String, ByVal country As String, ByVal county As String) As Boolean
    Try
      Ocmd.Connection.Open()
      Ocmd.CommandType = CommandType.StoredProcedure
      Ocmd.CommandText = "Add_supplier"
      Ocmd.Parameters.Add(New OracleParameter("code", code))
      Ocmd.Parameters.Add(New OracleParameter("name", name))
      Ocmd.Parameters.Add(New OracleParameter("idNumber", id))
      Ocmd.Parameters.Add(New OracleParameter("setCredit", setCredit))
      Ocmd.Parameters.Add(New OracleParameter("phone", phone))
      Ocmd.Parameters.Add(New OracleParameter("country", country))
      Ocmd.Parameters.Add(New OracleParameter("county", county))
      Ocmd.ExecuteReader()
      Ocmd.Connection.Close()
      Return True
    Catch e As Exception
      Ocmd.Connection.Close()
      Return False
    End Try
  End Function

  Public Function addArticle(ByVal code As String, ByVal name As String, ByVal u As String, ByVal count As String, ByVal price As Integer, ByVal discount As Integer) As Boolean
    Try
      Ocmd.Connection.Open()
      Ocmd.CommandType = CommandType.StoredProcedure
      Ocmd.CommandText = "Add_article"
      Ocmd.Parameters.Add(New OracleParameter("code", code))
      Ocmd.Parameters.Add(New OracleParameter("name", name))
      Ocmd.Parameters.Add(New OracleParameter("u", u))
      Ocmd.Parameters.Add(New OracleParameter("count", count))
      Ocmd.Parameters.Add(New OracleParameter("price", price))
      Ocmd.Parameters.Add(New OracleParameter("discount", discount))
      Ocmd.ExecuteReader()
      Ocmd.Connection.Close()
      Return True
    Catch e As Exception
      Ocmd.Connection.Close()
      Return False
    End Try
  End Function

  Public Function addPayType(ByVal code As String, ByVal description As String) As Boolean
    Try
      Ocmd.Connection.Open()
      Ocmd.CommandType = CommandType.StoredProcedure
      Ocmd.CommandText = "Add_payType"
      Ocmd.Parameters.Add(New OracleParameter("code", code))
      Ocmd.Parameters.Add(New OracleParameter("description", description))
      Ocmd.ExecuteReader()
      Ocmd.Connection.Close()
      Return True
    Catch e As Exception
      Ocmd.Connection.Close()
      Return False
    End Try
  End Function

  Public Function addCount(ByVal code As String, ByVal level As String) As Boolean
    Try
      Ocmd.Connection.Open()
      Ocmd.CommandType = CommandType.StoredProcedure
      Ocmd.CommandText = "Add_count"
      Ocmd.Parameters.Add(New OracleParameter("code", code))
      Ocmd.Parameters.Add(New OracleParameter("nLevel", level))
      Ocmd.ExecuteReader()
      Ocmd.Connection.Close()
      Return True
    Catch e As Exception
      Ocmd.Connection.Close()
      Return False
    End Try
  End Function

  Public Function addSaleBill(ByVal number As String, ByVal today As Date, ByVal client As String, ByVal payType As String, ByVal count_cred As String, ByVal days As String, ByVal article As String, ByVal quantity As Integer, ByVal discount As Integer) As Boolean
    Try
      Ocmd.Connection.Open()
      Ocmd.CommandType = CommandType.StoredProcedure
      Ocmd.CommandText = "Add_saleBill"
      Ocmd.Parameters.Add(New OracleParameter("idNumber", number))
      Ocmd.Parameters.Add(New OracleParameter("today", today))
      Ocmd.Parameters.Add(New OracleParameter("client", client))
      Ocmd.Parameters.Add(New OracleParameter("payType", payType))
      Ocmd.Parameters.Add(New OracleParameter("count_cred", count_cred))
      Ocmd.Parameters.Add(New OracleParameter("days", days))
      Ocmd.Parameters.Add(New OracleParameter("article", article))
      Ocmd.Parameters.Add(New OracleParameter("quantity", quantity))
      Ocmd.Parameters.Add(New OracleParameter("discount", discount))
      Ocmd.ExecuteReader()
      Ocmd.Connection.Close()
      Return True
    Catch e As Exception
      Ocmd.Connection.Close()
      Return False
    End Try
  End Function

  Public Function addPrice(ByVal code As String, ByVal name As String, ByVal price As Integer, ByVal discount As Integer) As Boolean
    Try
      Ocmd.Connection.Open()
      Ocmd.CommandType = CommandType.StoredProcedure
      Ocmd.CommandText = "Add_price"
      Ocmd.Parameters.Add(New OracleParameter("code", code))
      Ocmd.Parameters.Add(New OracleParameter("name", name))
      Ocmd.Parameters.Add(New OracleParameter("price", price))
      Ocmd.Parameters.Add(New OracleParameter("discount", discount))
      Ocmd.ExecuteReader()
      Ocmd.Connection.Close()
      Return True
    Catch e As Exception
      Ocmd.Connection.Close()
      Return False
    End Try
  End Function

End Module
