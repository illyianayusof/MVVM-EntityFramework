using Double_Counting_2._0.ViewModels;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Double_Counting_2._0.Views
{
    /// <summary>
    /// Interaction logic for BarcodeScanningView.xaml
    /// </summary>
    public partial class BarcodeScanningView : UserControl
    {
        public BarcodeScanningView()
        {
            InitializeComponent();
            BarcodeScanningViewModel mvm = new BarcodeScanningViewModel();
            this.DataContext = mvm; 
        }
    }
}
