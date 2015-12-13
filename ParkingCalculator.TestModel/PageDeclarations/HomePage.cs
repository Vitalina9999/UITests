using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace ParkingCalculator.TestModel.PageDeclarations
{
    public class HomePage : PageBase
    {
        #region Properties
        [FindsBy(How = How.XPath, Using = @"id(""wpName2"")")]
        protected IWebElement txtUserName { get; set; }


        [FindsBy(How = How.XPath, Using = @"id(""wpPassword2"")")]
        protected IWebElement txtPassword { get; set; }


        [FindsBy(How = How.XPath, Using = @"id(""wpRetype"")")]
        protected IWebElement txtConfirmPassword { get; set; }


        [FindsBy(How = How.XPath, Using = @"id(""wpEmail"")")]
        protected IWebElement txtEmailAddress { get; set; }


        [FindsBy(How = How.XPath, Using = @"id(""wpCaptchaWord"")")]
        protected IWebElement txtCaptcha { get; set; }


        [FindsBy(How = How.XPath, Using = @"id(""wpCreateaccount"")")]
        protected IWebElement btnCreateYourAccount { get; set; }
        #endregion

        public override void Invoke()
        {
            Driver.Url = @"https://en.wikipedia.org/w/index.php?title=Special:UserLogin&returnto=Main+Page&type=signup";
        }
        public override bool IsDisplayed()
        {
            return txtCaptcha.Displayed;
        }
        public override void VerifyExpectedElementsAreDisplayed()
        {
            VerifyElementVisible("txtUserName", txtUserName);
            VerifyElementVisible("txtPassword", txtPassword);
            VerifyElementVisible("txtConfirmPassword", txtConfirmPassword);
            VerifyElementVisible("txtEmailAddress", txtEmailAddress);
            VerifyElementVisible("txtCaptcha", txtCaptcha);
            VerifyElementVisible("btnCreateYourAccount", btnCreateYourAccount);
        }
    }
}
