using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using ParkingCalculator.TestModel.PageDeclarations;

namespace ParkingCalculator.Tests.Sanity
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void gefdjh()
        {
            //A
            ParkingCalculatorPage parkingCalculatorPage = new ParkingCalculatorPage();
            parkingCalculatorPage.Invoke();
            
            //A
            parkingCalculatorPage.DdlChooseALot.Click();

            IWebElement selectSTP = parkingCalculatorPage.DdlChooseALot.FindElement(By.Name("STP"));
            selectSTP.Click();

           


            //A
        }
    }
}
