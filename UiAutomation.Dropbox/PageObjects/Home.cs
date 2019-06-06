using Dropbox.TestAutomation;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selector = Dropbox.TestAutomation.PageObjectModels.Loctors.HomePage;
#pragma warning disable 649

namespace UiAutomation.Dropbox.PageObjects
{
    public class Home
    {
        public Home() => PageFactory.InitElements(PropertiesCollection.driver, this);

        [FindsBy(How = How.XPath, Using = Selector.hometitle)]
        private IWebElement hometitle;
        public void VerifyHometitle(string title)
        {
            PropertiesCollection.wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Selector.hometitle)));
            Assert.AreEqual(title.ToLower(), hometitle.Text.ToString().ToLower());
        }

        [FindsBy(How = How.Id, Using = Selector.filesmenu)]
        private IWebElement filesmenu;
        public void ClckonFiles() => filesmenu.Click();
    }
}
