using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ParkingCalculator.TestModel.PageDeclarations;

namespace ParkingCalculator.Tests.Sanity
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void CheckAllLotsTest()
        {
            //ARRANGE
            ParkingCalculatorPage parkingCalculatorPage = new ParkingCalculatorPage();
            parkingCalculatorPage.Invoke();

            List<string> lotOption = new List<string>();
            lotOption.Add("Short-Term Parking");
            lotOption.Add("Economy Parking");
            lotOption.Add("Long-Term Surface Parking");
            lotOption.Add("Long-Term Garage Parking");
            lotOption.Add("Valet Parking");

            //ASSERT
            Assert.AreEqual(5, parkingCalculatorPage.DdlChooseALot.Options.Count);

            foreach (IWebElement selectOption in parkingCalculatorPage.DdlChooseALot.Options)
            {
                string textOption = selectOption.Text;

                Assert.IsTrue(lotOption.Contains(textOption), "Oops, text " + textOption + " does not exist");
            }
        }

        [TestMethod]
        public void StpLotTest()
        {
            //ARRANGE
            ParkingCalculatorPage parkingCalculatorPage = new ParkingCalculatorPage();
            parkingCalculatorPage.Invoke();

            //ACT
            
            parkingCalculatorPage.DdlChooseALot.SelectByText("Short-Term Parking");

           // parkingCalculatorPage.BtnEntryDateTimeCalendar.Click();
            
           // IList<string>  entryDateWindow = parkingCalculatorPage.Driver.WindowHandles;
            
           // string sadsa = parkingCalculatorPage.Driver.CurrentWindowHandle;

            //IWebElement fdsf = parkingCalculatorPage.Table.SelectByValue("bgcolor").Equals("#FFFF33");

            parkingCalculatorPage.EntryDateInput.Clear();

            
          

            parkingCalculatorPage.BtnCalculate.Click();

            //ASSERT
        }
    }
}
