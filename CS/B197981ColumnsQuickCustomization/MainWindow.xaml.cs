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
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Core.Native;
using System.Windows.Controls.Primitives;

namespace B197981ColumnsQuickCustomization {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            List<TestData> list = new List<TestData>();
            for(int i = 0; i < 10; i++)
                list.Add(new TestData() { Column1 = "1Row" + i, Column2 = "2Row" + i, Column3 = "3Row" + i});
            gridControl.ItemsSource = list;
        }

        Popup popup = new Popup();
        void gridControl_PreviewMouseDown(object sender, MouseButtonEventArgs e) {
            popup.IsOpen = false;
            FrameworkElement header = LayoutHelper.FindParentObject<IndicatorColumnHeader>(e.OriginalSource as DependencyObject);
            if(Mouse.LeftButton == MouseButtonState.Pressed && header != null) {
                popup.PlacementTarget = header;
                popup.Child = new ListBox() { ItemsSource = gridControl.Columns, ItemTemplate = FindResource("itemTemplate") as DataTemplate };
                popup.IsOpen = true;
                e.Handled = true;
            }
        }
    }

    public class TestData {
        public string Column1 { get; set; }
        public string Column2 { get; set; }
        public string Column3 { get; set; }
    }
}
