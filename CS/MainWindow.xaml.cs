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
using DevExpress.Xpf.Bars;

namespace WpfApplication1 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
    }

    public class MySubItem : BarSubItem {
        public override BarItemLink CreateLink() {
            return new MySubItemLink();
        }
        protected override Type GetLinkType() {
            return typeof(MySubItemLink);
        }
    }
    
    
    public class MySubItemLink : BarSubItemLink {
        protected override BarItemLinkControlBase CreateBarItemLinkControl() {
            return new MySubItemLinkControl(this);
        }        
    }

    public class MySubItemLinkControl : BarSubItemLinkControl {
        public MySubItemLinkControl() {
            DefaultStyleKey = typeof(MySubItemLinkControl);
        }
        public MySubItemLinkControl(BarSubItemLink link) : base(link) {
            DefaultStyleKey = typeof(MySubItemLinkControl);
        }
    }
}
