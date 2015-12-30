using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ParkingCalculator.TestModel.Enums;
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

            parkingCalculatorPage.BtnEntryDateTimeCalendar.Click();
            parkingCalculatorPage.EntryCalendarWindow.ClickByDay(DateTime.Now.Day);

            int daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);

            for (int i = 0; i < 10; i++)
            {
                if (daysInMonth != DateTime.Now.Day)
                {
                    parkingCalculatorPage.BtnLeavingDateTimeCalendar.Click();
                    parkingCalculatorPage.LeavingCalendarWindow.ClickByDay(DateTime.Now.AddDays(i + 1).Day);
                    
                    parkingCalculatorPage.BtnCalculate.Click();

                    // find $
                    ReadOnlyCollection<IWebElement> tds = parkingCalculatorPage.Driver.FindElements(By.TagName("td"));

                    foreach (var td in tds)
                    {
                        if (td.GetAttribute("width") == "325")
                        {
                            IWebElement b = td.FindElement(By.TagName("b"));
                            // _calendarDaysLinks.Add(link);
                            string bText = b.Text.Remove(0, 2).Replace('.', ',');

                            decimal priceActual = 0;
                            decimal.TryParse(bText, out priceActual);
                            if (priceActual == 0)
                            {
                                Assert.Fail("Hey BRO, price cannot be ZERO!");
                            }

                            decimal expectedPrice = CalculatePrice(i + 1, LotEnumType.Stp);

                            Assert.AreEqual(expectedPrice, priceActual);

                        }
                    }
                }
            }


            //ASSERT
        }

        private decimal CalculatePrice(int daysCount, LotEnumType lotType)
        {
            decimal result = 0;
            int priceOfFirstDate = 0;
            int priceOfNonFirstDay = 0;

            switch (lotType)
            {
                case LotEnumType.Stp:
                    priceOfFirstDate = 28;
                    priceOfNonFirstDay = 26;

                    if (daysCount == 1)
                    {
                        result = priceOfFirstDate;
                    }
                    else
                    {
                        result = (priceOfNonFirstDay * (daysCount - 1)) + priceOfFirstDate;
                    }

                    break;
                case LotEnumType.Ep:
                    break;
                case LotEnumType.Lts:
                    break;
                case LotEnumType.Ltg:
                    break;
                case LotEnumType.Vp:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("lotType");
            }

            return result;
        }
    }
}
