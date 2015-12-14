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

            //ACT
            parkingCalculatorPage.DdlChooseALot.Click();

            IList<IWebElement> optionList = parkingCalculatorPage.DdlChooseALot.FindElements(By.TagName("option"));

            //ASSERT
            Assert.AreEqual(5, optionList.Count);

            foreach (IWebElement selectOption in optionList)
            {
                string textOption = selectOption.Text;

                Assert.IsTrue(lotOption.Contains(textOption), "Oops, text " + textOption + " does not exist");
            }
        }

        [TestMethod]
        public void StpLotTest()
        {
        }

    }
}
