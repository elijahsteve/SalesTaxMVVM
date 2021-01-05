using Prism.Mvvm;
using Prism.Commands;
using System;
using System.Data;
using static SalesTaxMVVM.Services.Calculate;

namespace SalesTaxMVVM.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {       
        private string _salesAmount = "0";
        private bool _checked;
        private string _salesAmountItem;
        private string _stateTaxItem;
        private string _countyTaxItem;
        private string _salesTotalTaxItem;
        private string _totalAmountItem;
        private double _salesAmountdbl;
                
        public string SalesAmount
        {
            get => _salesAmount;
            set => SetProperty(ref _salesAmount, value);
        }
        public bool Checked
        {
            get => _checked;
            set => SetProperty(ref _checked, value);
        }
        public string SalesAmountItem
        {
            get => _salesAmountItem;
            set => SetProperty(ref _salesAmountItem, value);
        }
        public string StateTaxItem
        {
            get => _stateTaxItem;
            set => SetProperty(ref _stateTaxItem, value);
        }
        public string CountyTaxItem
        {
            get => _countyTaxItem;
            set => SetProperty(ref _countyTaxItem, value);
        }
        public string SalesTotalTaxItem
        {
            get => _salesTotalTaxItem;
            set => SetProperty(ref _salesTotalTaxItem, value);
        }
        public string TotalAmountItem
        {
            get => _totalAmountItem;
            set => SetProperty(ref _totalAmountItem, value);
        }

        public DelegateCommand CalculateTaxCommand { get; }

        public MainWindowViewModel()
        {
            ResetAmounts();
            Checked = false;           
            CalculateTaxCommand = new DelegateCommand(CalculateTax, CanCalculateTax);
        }

        public void ResetAmounts()
        {
            //SalesAmount = "0";
            //SalesAmountItem = "Sales Amount: $0.00";
            //StateTaxItem = "State Tax: $0.00";
            //CountyTaxItem = "County Tax: $0.00";
            //SalesTotalTaxItem = "Total of Sales Tax: $0.00";
            //TotalAmountItem = "Total Amount: $0.00";
        }

        void CalculateTax()
        {
            SalesAmountItem = string.Format("Sales Amount: {0:C}", _salesAmountdbl);
            StateTaxItem = string.Format("State Tax: {0:C}", GetStateTax(_salesAmountdbl));
            CountyTaxItem = string.Format("County Tax: {0:C}", GetCountyTax(_salesAmountdbl, Checked));
            SalesTotalTaxItem = string.Format("Total of Sales Tax: {0:C}", GetTotalSalesTax(_salesAmountdbl, Checked));
            TotalAmountItem = string.Format("Total Amount: {0:C}", GetTotal(_salesAmountdbl, Checked));
        }

        bool CanCalculateTax()
        {
            if (ValidIsNumber(_salesAmount, out _salesAmountdbl))
            {
                return true;
            }
            else
            {
                ResetAmounts();
                SalesAmount = "Error";
                return false;
            }
        }
    }
}
