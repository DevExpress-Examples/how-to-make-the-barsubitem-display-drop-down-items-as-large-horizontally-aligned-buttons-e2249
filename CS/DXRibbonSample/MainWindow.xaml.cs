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

namespace Q421413 {
	public partial class MainWindow: DXWindow {
		static MainWindow() {
			BarItemLinkControlCreator.Default.RegisterObject(typeof(MyBarCheckItemLink),
			typeof(MyBarCheckItemLinkControl),
			link => new MyBarCheckItemLinkControl((MyBarCheckItemLink)link));
			BarItemLinkControlCreator.Default.RegisterObject(typeof(MyBarButtonItemLink),
			typeof(MyBarButtonItemLinkControl),
			link => new MyBarButtonItemLinkControl((MyBarButtonItemLink)link));
		}
		public MainWindow() {
			InitializeComponent();
		}
	}
	public class MyBarCheckItem: BarCheckItem {
		protected override Type GetLinkType() {
			return typeof(MyBarCheckItemLink);
		}
	}
	public class MyBarCheckItemLink: BarCheckItemLink {
		protected override BarItemLinkControlBase CreateBarItemLinkControl() {
			return new MyBarCheckItemLinkControl(this);
		}
	}
	public class MyBarCheckItemLinkControl: BarCheckItemLinkControl {
		public MyBarCheckItemLinkControl() { }
		public MyBarCheckItemLinkControl(BarCheckItemLink link) : base(link) { }
		protected override void UpdateActualGlyphAlignmentInRibbon() {
			//switch (CurrentRibbonStyle) {
			//    case RibbonItemStyles.Default:
			//        break;
			//    case RibbonItemStyles.Large:
			//        ActualGlyphAlignment = Dock.Top;
			//        break;
			//    default:
			//        ActualGlyphAlignment = Dock.Left;
			//        break;
			//}
			ActualGlyphAlignment = Dock.Top;
		}
		protected override void UpdateActualGlyphAlignmentInBars() {
			//ActualGlyphAlignment = GetGlyphAlignment();
			ActualGlyphAlignment = Dock.Top;
		}
		//Dock GetGlyphAlignment() {
		//    if (IsLinkControlInMenu) return Dock.Left;
		//    if (Link != null && Link.UserGlyphAlignment.HasValue)
		//        return Link.UserGlyphAlignment.Value;
		//    if (Item != null)
		//        return Item.GlyphAlignment;
		//    return Dock.Left;
		//}
	}

	public class MyBarButtonItem: BarButtonItem {
		protected override Type GetLinkType() {
			return typeof(MyBarButtonItemLink);
		}
	}
	public class MyBarButtonItemLink: BarButtonItemLink {
		protected override BarItemLinkControlBase CreateBarItemLinkControl() {
			return new MyBarButtonItemLinkControl(this);
		}
	}
	public class MyBarButtonItemLinkControl: BarButtonItemLinkControl {
		public MyBarButtonItemLinkControl() { }
		public MyBarButtonItemLinkControl(MyBarButtonItemLink link) : base(link) { }
		protected override void UpdateActualGlyphAlignmentInRibbon() {
			ActualGlyphAlignment = Dock.Top;
		}
		protected override void UpdateActualGlyphAlignmentInBars() {
			ActualGlyphAlignment = Dock.Top;
		}
	}
}