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
Imports DevExpress.Mvvm.Native

Namespace Q421413
    Partial Public Class MainWindow
        Inherits ThemedWindow

        Shared Sub New()
            BarItemLinkControlStrategyCreator.Default.RegisterObject(Of BarButtonItemLink, BarButtonItemLinkControl, MyBarButtonItemLinkControlStrategy)(Function(x) New MyBarButtonItemLinkControlStrategy(x))
        End Sub
        Public Sub New()
            InitializeComponent()
        End Sub
    End Class
    Public Class MyBarButtonItemLinkControlStrategy
        Inherits BarButtonItemLinkControlStrategy

        Public Sub New(ByVal instance As IBarItemLinkControl)
            MyBase.New(instance)
        End Sub
        Public Overrides Sub UpdateActualGlyphAlignment()
            If Not GlyphAlignmentInMenuHelper.CheckUpdateActualGlyphAlignment(Me, Instance) Then
                MyBase.UpdateActualGlyphAlignment()
            End If
        End Sub
    End Class

    Public NotInheritable Class GlyphAlignmentInMenuHelper

        Private Sub New()
        End Sub
        Public Shared ReadOnly ValueProperty As DependencyProperty = DependencyProperty.RegisterAttached("Value", GetType(Dock?), GetType(GlyphAlignmentInMenuHelper), New FrameworkPropertyMetadata(Nothing, FrameworkPropertyMetadataOptions.Inherits))

        Public Shared Function GetValue(ByVal obj As DependencyObject) As Dock?
            Return DirectCast(obj.GetValue(ValueProperty), Dock?)
        End Function
        Public Shared Sub SetValue(ByVal obj As DependencyObject, ByVal value? As Dock)
            obj.SetValue(ValueProperty, value)
        End Sub

        Public Shared Function CheckUpdateActualGlyphAlignment(ByVal strategy As BarItemLinkControlStrategy, ByVal instance As IBarItemLinkControl) As Boolean
            If Not strategy.IsLinkInMenu Then
                Return False
            End If
            Dim item = instance.With(Function(x) x.Link).With(Function(x) x.Item)
            If item IsNot Nothing Then
                Dim dock = GetValue(item)
                If dock.HasValue Then
                    instance.ActualGlyphAlignment = dock.Value
                    Return True
                End If
            End If
            Return False
        End Function
    End Class
End Namespace