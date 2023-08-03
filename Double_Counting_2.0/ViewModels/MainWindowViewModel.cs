using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Double_Counting_2._0.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {

        private object _currentView;
        private object _view1;  

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged("CurrentView");
            }
        }


        public MainWindowViewModel()
        {
            //_view1 = new BarcodeScanningViewModel();    
            //CurrentView = _view1;
        }
    }
}
