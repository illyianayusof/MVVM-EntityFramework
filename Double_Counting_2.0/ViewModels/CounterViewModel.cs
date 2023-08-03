using Double_Counting_2._0.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Double_Counting_2._0.HelperClasses;

namespace Double_Counting_2._0.ViewModels
{
    public class CounterViewModel : INotifyPropertyChanged
    {
        DoDoubleCountingContext ctx = new DoDoubleCountingContext();      
  
        private List<SubStopReason?> _SubStopReason;
        public List<SubStopReason?> SubStopReason
        {
            get { return _SubStopReason; }
            set
            {
                _SubStopReason = value;
                OnPropertyChanged("SubStopReason");
            }
        }

        private string? _SubString;
        public string? SubString
        {
            get
            {
                return _SubString;
            }
            set
            {
                _SubString = value;
                OnPropertyChanged("SubString");
            }
        }

        private int _SheetCounter;
        public int SheetCounter
        {
            get
            {
                return _SheetCounter;
            }
            set
            {
                _SheetCounter = value;
                OnPropertyChanged("SheetCounter");
            }
        }

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

        public CounterViewModel()
        {
            DataGridSSR();
            LabelSSR();
            _Timer = new Timer();           
        }

        public void DataGridSSR()
        {
            var q = (from a in ctx.SubStopReasons
                     select a).ToList();
            SubStopReason = q;
        }

        public void LabelSSR()
        {
            SubString = (from a in ctx.SubStopReasons
                         where a.SubStopReasonId == 1
                         select a.SubStopReason1).FirstOrDefault();     

            //var q = ctx.SubStopReasons.ToList().FirstOrDefault(x => x.SubStopReasonId == 1).SubStopReason1;
            // SubString = q;
        }

      
       

    }
}
