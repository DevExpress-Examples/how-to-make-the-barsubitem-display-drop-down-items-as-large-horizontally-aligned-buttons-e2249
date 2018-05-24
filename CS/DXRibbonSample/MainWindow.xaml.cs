using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Ribbon;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Core;
using DevExpress.Mvvm.Native;

namespace Q421413 {
	public partial class MainWindow: ThemedWindow {
		static MainWindow() {           
            BarItemLinkControlStrategyCreator.Default.RegisterObject<BarButtonItemLink, BarButtonItemLinkControl, MyBarButtonItemLinkControlStrategy>(x => new MyBarButtonItemLinkControlStrategy(x));
        }
		public MainWindow() {
			InitializeComponent();
		}
	}	
    public class MyBarButtonItemLinkControlStrategy : BarButtonItemLinkControlStrategy {
        public MyBarButtonItemLinkControlStrategy(IBarItemLinkControl instance) : base(instance) { }
        public override void UpdateActualGlyphAlignment() {
            if (!GlyphAlignmentInMenuHelper.CheckUpdateActualGlyphAlignment(this, Instance))
                base.UpdateActualGlyphAlignment();
        }
    }

    public static class GlyphAlignmentInMenuHelper {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached("Value", typeof(Dock?), typeof(GlyphAlignmentInMenuHelper), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));

        public static Dock? GetValue(DependencyObject obj) { return (Dock?)obj.GetValue(ValueProperty); }
        public static void SetValue(DependencyObject obj, Dock? value) { obj.SetValue(ValueProperty, value); }            

        public static bool CheckUpdateActualGlyphAlignment(BarItemLinkControlStrategy strategy, IBarItemLinkControl instance) {
            if (!strategy.IsLinkInMenu)
                return false;
            var item = instance.With(x => x.Link).With(x => x.Item);
            if (item!=null) {
                var dock = GetValue(item);
                if (dock.HasValue) {
                    instance.ActualGlyphAlignment = dock.Value;
                    return true;
                }
            }
            return false;
        }
    }
}