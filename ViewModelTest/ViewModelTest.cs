using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prism;
using Prism.Commands;
using Prism.Mvvm;
using FluentAssertions;
using SalesTaxMVVM.ViewModels;

namespace ViewModelTest
{
    [TestClass]
    public class ViewModelTest
    {
        [TestMethod]
        public void HappyPathUnchecked()
        {
            var window = new MainWindowViewModel();
            window.SalesAmount = "100";
            window.Checked = false;

            window.CalculateTaxCommand.Execute();           
            
            var expectedSalesAmount = "Sales Amount: $100.00";
            var expectedStateTax = "State Tax: $4.00";
            var expectedCountyTax = "County Tax: $0.00";
            var expectedTotalSalesTax = "Total of Sales Tax: $4.00";
            var expectedTotalAmount = "Total Amount: $104.00";


            Assert.IsTrue(window.CalculateTaxCommand.CanExecute());

            Assert.AreEqual(expectedSalesAmount, window.SalesAmountItem);
            Assert.AreEqual(expectedStateTax, window.StateTaxItem);
            Assert.AreEqual(expectedCountyTax, window.CountyTaxItem);
            Assert.AreEqual(expectedTotalSalesTax, window.SalesTotalTaxItem);
            Assert.AreEqual(expectedTotalAmount, window.TotalAmountItem);
        }

        //    SalesAmount = "0";
        //    SalesAmountItem = "Sales Amount: $0.00";
        //    StateTaxItem = "State Tax: $0.00";
        //    CountyTaxItem = "County Tax: $0.00";
        //    SalesTotalTaxItem = "Total of Sales Tax: $0.00";
        //    TotalAmountItem = "Total Amount: $0.00";

    }
}
