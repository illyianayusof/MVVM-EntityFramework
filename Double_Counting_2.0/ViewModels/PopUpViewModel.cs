﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Double_Counting_2._0.HelperClasses;

namespace Double_Counting_2._0.ViewModels
{
    public class PopUpViewModel : INotifyPropertyChanged
    {

        private Timer _Timer;
        public Timer Timer
        {
            get
            {
                return _Timer;
            }
            set
            {
                _Timer = value;
                OnPropertyChanged("Timer");
            }
        }
        public PopUpViewModel()
        {
            _Timer = new Timer();
        }
    }
}
