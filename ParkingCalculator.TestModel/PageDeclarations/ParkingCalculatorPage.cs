using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ParkingCalculator.TestModel.PageDeclarations
{
    public class ParkingCalculatorPage : PageBase
    {
        #region

        [FindsBy(How = How.Id, Using = @"id(""Lot"")")]
        public IWebElement DdLot { get; set; }

        

        #endregion
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
            VerifyElementVisible("txtUserName", DdLot);
        }
    }
}
