Public Class PurchaseBill
  Inherits MegaBase.Bill

#Region " C�digo generado por el Dise�ador de Windows Forms "

  Public Sub New()
    MyBase.New()

    'El Dise�ador de Windows Forms requiere esta llamada.
    InitializeComponent()

    'Agregar cualquier inicializaci�n despu�s de la llamada a InitializeComponent()

  End Sub

  'Form reemplaza a Dispose para limpiar la lista de componentes.
  Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
    If disposing Then
      If Not (components Is Nothing) Then
        components.Dispose()
      End If
    End If
    MyBase.Dispose(disposing)
  End Sub

  'Requerido por el Dise�ador de Windows Forms
  Private components As System.ComponentModel.IContainer

  'NOTA: el Dise�ador de Windows Forms requiere el siguiente procedimiento
  'Puede modificarse utilizando el Dise�ador de Windows Forms. 
  'No lo modifique con el editor de c�digo.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    '
    'PurchaseBill
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(6, 13)
    Me.ClientSize = New System.Drawing.Size(544, 348)
    Me.Name = "PurchaseBill"
    Me.Text = "Factura de compra"

  End Sub

#End Region

  Private Sub _onLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    lID.Text = "C�digo:"
  End Sub

End Class
