using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Graphing;

namespace FourSoulsGUI
{
    /// <summary>
    /// Interaction logic for LegendControl.xaml
    /// </summary>
    public partial class LegendControl : UserControl
    {

        public static readonly DependencyProperty RowsProperty =
            DependencyProperty.Register("Rows", typeof(int), typeof(LegendControl), new PropertyMetadata(1));

        public static readonly DependencyProperty ColumnsProperty =
            DependencyProperty.Register("Columns", typeof(int), typeof(LegendControl), new PropertyMetadata(1));

        public static readonly DependencyProperty LegendItemsProperty =
            DependencyProperty.Register("LegendItems", typeof(ObservableCollection<LegendItem>), typeof(LegendControl), new PropertyMetadata(null));

        public int Rows
        {
            get { return (int)GetValue(RowsProperty); }
            set { SetValue(RowsProperty, value); }
        }

        public int Columns
        {
            get { return (int)GetValue(ColumnsProperty); }
            set { SetValue(ColumnsProperty, value); }
        }

        public ObservableCollection<LegendItem> LegendItems
        {
            get { return (ObservableCollection<LegendItem>)GetValue(LegendItemsProperty); }
            set { SetValue(LegendItemsProperty, value); }
        }

        public LegendControl()
        {
            InitializeComponent();
        }
    }
}
