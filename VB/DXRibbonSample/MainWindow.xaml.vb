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
Imports DevExpress.Xpf.Ribbon
Imports DevExpress.Xpf.Bars
Imports DevExpress.Xpf.Core

Namespace Q421413
	Partial Public Class MainWindow
		Inherits DXWindow
		Shared Sub New()
			BarItemLinkControlCreator.Default.RegisterObject(GetType(MyBarCheckItemLink), GetType(MyBarCheckItemLinkControl), Function(link) New MyBarCheckItemLinkControl(CType(link, MyBarCheckItemLink)))
			BarItemLinkControlCreator.Default.RegisterObject(GetType(MyBarButtonItemLink), GetType(MyBarButtonItemLinkControl), Function(link) New MyBarButtonItemLinkControl(CType(link, MyBarButtonItemLink)))
		End Sub
		Public Sub New()
			InitializeComponent()
		End Sub
	End Class
	Public Class MyBarCheckItem
		Inherits BarCheckItem
		Protected Overrides Function GetLinkType() As Type
			Return GetType(MyBarCheckItemLink)
		End Function
	End Class
	Public Class MyBarCheckItemLink
		Inherits BarCheckItemLink
		Protected Overrides Function CreateBarItemLinkControl() As BarItemLinkControlBase
			Return New MyBarCheckItemLinkControl(Me)
		End Function
	End Class
	Public Class MyBarCheckItemLinkControl
		Inherits BarCheckItemLinkControl
		Public Sub New()
		End Sub
		Public Sub New(ByVal link As BarCheckItemLink)
			MyBase.New(link)
		End Sub
		Protected Overrides Sub UpdateActualGlyphAlignmentInRibbon()
			'switch (CurrentRibbonStyle) {
			'    case RibbonItemStyles.Default:
			'        break;
			'    case RibbonItemStyles.Large:
			'        ActualGlyphAlignment = Dock.Top;
			'        break;
			'    default:
			'        ActualGlyphAlignment = Dock.Left;
			'        break;
			'}
			ActualGlyphAlignment = Dock.Top
		End Sub
		Protected Overrides Sub UpdateActualGlyphAlignmentInBars()
			'ActualGlyphAlignment = GetGlyphAlignment();
			ActualGlyphAlignment = Dock.Top
		End Sub
		'Dock GetGlyphAlignment() {
		'    if (IsLinkControlInMenu) return Dock.Left;
		'    if (Link != null && Link.UserGlyphAlignment.HasValue)
		'        return Link.UserGlyphAlignment.Value;
		'    if (Item != null)
		'        return Item.GlyphAlignment;
		'    return Dock.Left;
		'}
	End Class

	Public Class MyBarButtonItem
		Inherits BarButtonItem
		Protected Overrides Function GetLinkType() As Type
			Return GetType(MyBarButtonItemLink)
		End Function
	End Class
	Public Class MyBarButtonItemLink
		Inherits BarButtonItemLink
		Protected Overrides Function CreateBarItemLinkControl() As BarItemLinkControlBase
			Return New MyBarButtonItemLinkControl(Me)
		End Function
	End Class
	Public Class MyBarButtonItemLinkControl
		Inherits BarButtonItemLinkControl
		Public Sub New()
		End Sub
		Public Sub New(ByVal link As MyBarButtonItemLink)
			MyBase.New(link)
		End Sub
		Protected Overrides Sub UpdateActualGlyphAlignmentInRibbon()
			ActualGlyphAlignment = Dock.Top
		End Sub
		Protected Overrides Sub UpdateActualGlyphAlignmentInBars()
			ActualGlyphAlignment = Dock.Top
		End Sub
	End Class
End Namespace