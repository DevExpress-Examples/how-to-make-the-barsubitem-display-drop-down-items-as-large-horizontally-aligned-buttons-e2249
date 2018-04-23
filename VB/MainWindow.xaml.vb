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
Imports DevExpress.Xpf.Bars

Namespace WpfApplication1
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub
	End Class

	Public Class MySubItem
		Inherits BarSubItem
		Public Overrides Function CreateLink() As BarItemLink
			Return New MySubItemLink()
        End Function
        Protected Overrides Function GetLinkType() As System.Type
            Return GetType(MySubItemLink)
        End Function
	End Class


	Public Class MySubItemLink
		Inherits BarSubItemLink
		Protected Overrides Function CreateBarItemLinkControl() As BarItemLinkControlBase
			Return New MySubItemLinkControl(Me)
		End Function
	End Class

	Public Class MySubItemLinkControl
		Inherits BarSubItemLinkControl
		Public Sub New()
			DefaultStyleKey = GetType(MySubItemLinkControl)
		End Sub
		Public Sub New(ByVal link As BarSubItemLink)
			MyBase.New(link)
			DefaultStyleKey = GetType(MySubItemLinkControl)
		End Sub
	End Class
End Namespace
