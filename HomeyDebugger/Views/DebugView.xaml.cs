using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HomeyDebugger.ViewModels;

namespace HomeyDebugger.Views
{
    /// <summary>
    /// Interaction logic for Debug.xaml
    /// </summary>
    public partial class DebugView : Window
    {
        public DebugView()
        {
            InitializeComponent();
        }

        private void DataGrid_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

            if (LogList.Items.Count > 0)
            {
                var border = VisualTreeHelper.GetChild(LogList, 0) as Decorator;
                if (border != null)
                {
                    var scroll = border.Child as ScrollViewer;
                    if (scroll != null) scroll.ScrollToEnd();
                }
            }
        }

        private void LogList_Loaded(object sender, RoutedEventArgs e)
        {
            var dg = (DataGrid)sender;

            if (dg == null || dg.ItemsSource == null) return;

            var sourceCollection = dg.ItemsSource as ObservableCollection<LogRow>;
            if (sourceCollection == null) return;

            sourceCollection.CollectionChanged +=
                new NotifyCollectionChangedEventHandler(DataGrid_CollectionChanged);
        }
    }
}
