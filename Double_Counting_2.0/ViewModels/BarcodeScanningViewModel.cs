using Double_Counting_2._0.Commands;
using Double_Counting_2._0.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Double_Counting_2._0.ViewModels
{
    public class BarcodeScanningViewModel : INotifyPropertyChanged
    {
        DoDoubleCountingContext ctx = new DoDoubleCountingContext();
        private string _BatchNumber;
        public string BatchNumber
        {
            get
            {
                return _BatchNumber;
            }
            set
            {
                _BatchNumber = value;
                OnPropertyChanged("BatchNumber");
            }
        }

        private int _WasteBeforeAmount;
        public int WasteBeforeAmount
        {
            get
            {
                return _WasteBeforeAmount;
            }
            set
            {
                _WasteBeforeAmount = value;
                OnPropertyChanged("WasteBeforeAmount");
            }
        }

        private ICommand _AddBarcode;
        public ICommand AddBarcode
        {
            get
            {
                _AddBarcode = new RelayCommand(p => AddBarcodeIntoSQL());
                return _AddBarcode;
            }
        }

        private string _IsShowHideVisible;
        public string IsShowHideVisible
        {
            get
            {
                return _IsShowHideVisible;
            }
            set
            {
                _IsShowHideVisible = value;
                OnPropertyChanged("IsShowHideVisible");
            }
        }

        public void AddBarcodeIntoSQL()
        {
            //Barcode barcodeobj = new Barcode();
            //barcodeobj.BatchNumber = _BatchNumber;
            //barcodeobj.ScannedTime = DateTime.Now;

            //ctx.Add(barcodeobj);
            //ctx.SaveChanges();

            //int BatchNumberID = (from a in ctx.Barcodes
            //             orderby a.ScannedTime descending
            //             select a).FirstOrDefault().BarcodeId;

            //WasteBefore wastebeforeobj = new WasteBefore();
            //wastebeforeobj.WasteBeforeAmount = _WasteBeforeAmount;
            //wastebeforeobj.BatchNumberId = BatchNumberID;

            //ctx.Add(wastebeforeobj);
            //ctx.SaveChanges();

            //ctx.Database.SqlQueryRaw<Barcode>("exec TEST_PROC ").ToList();

            ctx.Database.ExecuteSqlRaw($"exec InsertAfterBarcodeScan @p0, @p1", _BatchNumber, _WasteBeforeAmount);

            IsShowHideVisible = "Collapsed";

        }
        public BarcodeScanningViewModel() 
        {
            IsShowHideVisible = "Visible";
        }   
    }
}
