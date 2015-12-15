using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace ParkingCalculator.TestModel.PageDeclarations
{
    public class ParkingCalculatorPage : PageBase
    {
        #region Properties

        [FindsBy(How = How.Id, Using = "Lot")]
        private IWebElement _ddlChooseALot { get; set; }

        public SelectElement DdlChooseALot
        {
            get
            {
                SelectElement selectElement = new SelectElement(_ddlChooseALot);
                return selectElement;
            }
        }

        [FindsBy(How = How.TagName, Using = "tr")]
        public IList<IWebElement> TableRows { get; set; }

        [FindsBy(How = How.TagName, Using = "td")]
        public IList<IWebElement> TableCols { get; set; }

        [FindsBy(How = How.ClassName, Using = "BodyCopy")]
        public IList<IWebElement> BodyCopyList { get; set; }

        [FindsBy(How = How.TagName, Using = "table")]
        private IWebElement _tableTag { get; set; }
        public SelectElement Table
        {
            get
            {
                SelectElement selectElement = new SelectElement(_tableTag);
                return selectElement;
            }
        }
        
        [FindsBy(How = How.TagName, Using = "option")]
        public IList<IWebElement> OptionList { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/form/table/tbody/tr[2]/td[2]/font/a")]
        public IWebElement BtnEntryDateTimeCalendar { get; set; }

        [FindsBy(How = How.Name, Using = "Calendar")]
        public IWebElement CalendarPage { get; set; }

        [FindsBy(How = How.Id, Using = "EntryDate")]
        public IWebElement EntryDateInput { get; set; }

        [FindsBy(How = How.Id, Using = "ExitDate")]
        public IWebElement ExitDateInput { get; set; }

        [FindsBy(How = How.Name, Using = "Submit")]
        public IWebElement BtnCalculate { get; set; }

        #endregion

        #region Methods
        public override void Invoke()
        {
            Driver.Url = @"http://adam.goucher.ca/parkcalc";
        }

        public override bool IsDisplayed()
        {
            //return txtCaptcha.Displayed;
            return true;
        }
        public override void VerifyExpectedElementsAreDisplayed()
        {
            VerifyElementVisible("DdlChooseALot", DdlChooseALot.WrappedElement);
        }
        #endregion
    }
}
