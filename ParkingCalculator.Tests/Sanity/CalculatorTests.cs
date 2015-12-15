using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            string currentWindowName = parkingCalculatorPage.Driver.CurrentWindowHandle;

            parkingCalculatorPage.BtnEntryDateTimeCalendar.Click();



            IList<string> windowNames = parkingCalculatorPage.Driver.WindowHandles;

            foreach (var windowName in windowNames)
            {
                if (!windowName.Equals(currentWindowName))
                {
                    IWebDriver webDriver = parkingCalculatorPage.Driver.SwitchTo().Window(windowName);

                    ReadOnlyCollection<IWebElement> tds = webDriver.FindElements(By.TagName("td"));

                    IList<IWebElement> calenderLinks = new List<IWebElement>();
                    foreach (var td in tds)
                    {
                        if (td.GetAttribute("width") == "20")
                        {
                            IWebElement link = td.FindElement(By.TagName("a"));
                            calenderLinks.Add(link);
                        }
                    }

                    //////////
                    int currentDay = DateTime.Now.Day;

                    foreach (var calenderLink in calenderLinks)
                    {
                        if (calenderLink.Text == currentDay.ToString())
                        {
                            calenderLink.Click();
                            break;
                        }
                    }

                    
                }
            }


            




            parkingCalculatorPage.BtnCalculate.Click();

            //ASSERT
        }
    }
}
