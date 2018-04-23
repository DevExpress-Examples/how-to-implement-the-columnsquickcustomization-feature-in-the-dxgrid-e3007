Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports DevExpress.Xpf.Grid
Imports DevExpress.Xpf.Core.Native
Imports System.Windows.Controls.Primitives

Namespace B197981ColumnsQuickCustomization
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()

			Dim list As New List(Of TestData)()
			For i As Integer = 0 To 9
				list.Add(New TestData() With {.Column1 = "1Row" & i, .Column2 = "2Row" & i, .Column3 = "3Row" & i})
			Next i
			gridControl.ItemsSource = list
		End Sub

		Private popup As New Popup()
		Private Sub gridControl_PreviewMouseDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
			popup.IsOpen = False
			Dim header As FrameworkElement = LayoutHelper.FindParentObject(Of IndicatorColumnHeader)(TryCast(e.OriginalSource, DependencyObject))
			If Mouse.LeftButton = MouseButtonState.Pressed AndAlso header IsNot Nothing Then
				popup.PlacementTarget = header
				popup.Child = New ListBox() With {.ItemsSource = gridControl.Columns, .ItemTemplate = TryCast(FindResource("itemTemplate"), DataTemplate)}
				popup.IsOpen = True
				e.Handled = True
			End If
		End Sub
	End Class

	Public Class TestData
		Private privateColumn1 As String
		Public Property Column1() As String
			Get
				Return privateColumn1
			End Get
			Set(ByVal value As String)
				privateColumn1 = value
			End Set
		End Property
		Private privateColumn2 As String
		Public Property Column2() As String
			Get
				Return privateColumn2
			End Get
			Set(ByVal value As String)
				privateColumn2 = value
			End Set
		End Property
		Private privateColumn3 As String
		Public Property Column3() As String
			Get
				Return privateColumn3
			End Get
			Set(ByVal value As String)
				privateColumn3 = value
			End Set
		End Property
	End Class
End Namespace
