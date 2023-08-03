using Double_Counting_2._0.Models;
using Double_Counting_2._0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Windows.Threading;
using System.Drawing;
using System.Diagnostics.Metrics;
using static System.Net.Mime.MediaTypeNames;


namespace Double_Counting_2._0.HelperClasses
{
    public class Timer : INotifyPropertyChanged
    {
        DoDoubleCountingContext ctx = new DoDoubleCountingContext(); 
        
        private string _currentTime;
        public string CurrTime
        {
            get
            {
                return _currentTime;
            }
            set
            {
                _currentTime = value;
                OnPropertyChanged("CurrTime");
            }
        }
        private string _MachineStatus;
        public string MachineStatus
        {
            get
            {
                return _MachineStatus;
            }
            set
            {
                _MachineStatus = value;
                OnPropertyChanged("MachineStatus");
            }
        }

        private string _SheetType;
        public string SheetType
        {
            get
            {
                return _SheetType;
            }
            set
            {
                _SheetType = value;
                OnPropertyChanged("SheetType");
            }
        }

        private string _SensorResults;
        public string SensorResults
        {
            get
            {
                return _SensorResults;
            }
            set
            {
                _SensorResults = value;
                OnPropertyChanged("SensorResults");
            }
        }

        private string _SheetRating;
        public string SheetRating
        {
            get
            {
                return _SheetRating;
            }
            set
            {
                _SheetRating = value;
                OnPropertyChanged("SheetRating");
            }
        }

        private int _SheetCount;
        public int SheetCount
        {
            get
            {
                return _SheetCount;
            }
            set
            {
                _SheetCount = value;
                OnPropertyChanged("SheetCount");
            }
        }

        private int _CounterID;
        public int CounterID
        {
            get
            {
                return _CounterID;
            }
            set
            {
                _CounterID = value;
                OnPropertyChanged("CounterID");
            }
        }


        private Brush _YellowBG;
        public Brush YellowBG
        {
            get
            {
                return _YellowBG;
            }
            set
            {
                _YellowBG = value;
                OnPropertyChanged("YellowBG");
            }
        }

        private Brush _BankNoteBG;
        public Brush BankNoteBG
        {
            get
            {
                return _BankNoteBG;
            }
            set
            {
                _BankNoteBG = value;
                OnPropertyChanged("BankNoteBG");
            }
        }

        private Brush _BlackBG;
        public Brush BlackBG
        {
            get
            {
                return _BlackBG;
            }
            set
            {
                _BlackBG = value;
                OnPropertyChanged("BlackBG");
            }
        }

        private Brush _MSBackground;
        public Brush MSBackground
        {
            get
            {
                return _MSBackground;
            }
            set
            {
                _MSBackground = value;
                OnPropertyChanged("MSBackground");
            }
        }

        private string _TimestampPrinting;
        public string TimestampPrinting
        {
            get
            {
                return _TimestampPrinting;
            }
            set
            {
                _TimestampPrinting = value;
                OnPropertyChanged("TimestampPrinting");
            }
        }     

        DispatcherTimer timer;
        public Timer()
        {
            _MSBackground = Brushes.LightBlue;
            _YellowBG = Brushes.LightGray;
            _BankNoteBG = Brushes.LightGray;
            _BlackBG = Brushes.LightGray;
            _currentTime = DateTime.Now.ToLongTimeString();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += Timer_Click;
            timer.Start();
        }


        int tempCounterID = 0;
        int countSheetCounter = 0;
        public void Timer_Click(object sender, EventArgs e)
        {
            
            IList<TblCounter> test = SheetCounterInsert();
            
            if (test.Count > 0)
            {
                CheckSheetType(test.First().CounterId);
                if (tempCounterID != test.First().CounterId)
                {
                    tempCounterID = test.First().CounterId;
                    MachineStatus = "Machine Running";
                    MSBackground = Brushes.Green;
                    
                    DateTime getdate = new DateTime();
                    getdate = test.First().TimestampPrinting;
                    TimestampPrinting = getdate.ToLongTimeString();

                    CounterID = test.First().CounterId;
                    //SheetCount = test.First().SheetCounter;

                   
                    SensorResults = test.First().SensorResults;
                    SheetRating = test.First().SheetRating;
                    //SheetCount = test.First().SheetCounter; 

                    //if (test.First().SheetType == "Y" || (test.First().SheetType == "Y "))
                    //{
                    //    SheetType = test.First().SheetType;
                    //    YellowBG = Brushes.Yellow;
                    //    BankNoteBG = Brushes.LightGray;
                    //    BlackBG = Brushes.LightGray;
                    //}
                    //else if (test.First().SheetType == "BN" || (test.First().SheetType == "BN "))
                    //{
                    //    SheetType = test.First().SheetType;
                    //    BankNoteBG = Brushes.DarkGreen;
                    //    YellowBG = Brushes.LightGray;
                    //    BlackBG = Brushes.LightGray;

                    //    countSheetCounter += 1;
                    //    SheetCount = countSheetCounter;


                    //}
                    //else if (test.First().SheetType == "BL" || (test.First().SheetType == "BL "))
                    //{
                    //    SheetType = test.First().SheetType;
                    //    BlackBG = Brushes.SlateGray;
                    //    BankNoteBG = Brushes.LightGray;
                    //    YellowBG = Brushes.LightGray;
                    //}
                }                
                else
                {
                    MachineStatus = "Machine Stopped";
                    MSBackground = Brushes.Red;
                }     
            }    

            DateTime d;
            d = DateTime.Now;
            CurrTime = DateTime.Now.ToLongTimeString();
        }

        public IList<TblCounter> SheetCounterInsert()
        {
            IList<TblCounter> q1 = (from a in ctx.TblCounters
                         orderby a.TimestampPrinting descending
                         select a).Take(1).ToArray();          
            return q1;
        }    
        
        public void CheckSheetType(int CID)
        {
            int tempCID = CID;
            var rows = from a in ctx.TblCounters
                       where a.CounterId >= tempCID && a.CounterId <= CID
                       select a;

            foreach(var row in rows)
            {
                if (row.SheetType == "Y" || (row.SheetType == "Y "))
                {                   
                    YellowBG = Brushes.Yellow;
                    BankNoteBG = Brushes.LightGray;
                    BlackBG = Brushes.LightGray;
                }
                else if (row.SheetType == "BN" || (row.SheetType == "BN "))
                {                
                    BankNoteBG = Brushes.DarkGreen;
                    YellowBG = Brushes.LightGray;
                    BlackBG = Brushes.LightGray;

                    countSheetCounter += 1;
                    SheetCount = countSheetCounter;

                }
                else if (row.SheetType == "BL" || (row.SheetType == "BL "))
                {                   
                    BlackBG = Brushes.SlateGray;
                    BankNoteBG = Brushes.LightGray;
                    YellowBG = Brushes.LightGray;
                }
            }

        }
    }
}
