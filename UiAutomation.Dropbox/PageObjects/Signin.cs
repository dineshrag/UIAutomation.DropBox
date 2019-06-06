using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selector = Dropbox.TestAutomation.PageObjectModels.Loctors.LoginPage;
using System.Configuration;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using Dropbox.TestAutomation;
#pragma warning disable 649

namespace UiAutomation.Dropbox.PageObjects
{
    public class Signin
    {
        public Signin() => PageFactory.InitElements(PropertiesCollection.driver, this);

        public void NavigatetoURL() => PropertiesCollection.driver
            .Navigate()
            .GoToUrl(ConfigurationManager.AppSettings["baseurl"].ToString());

        public void Maximizewindow() => PropertiesCollection.driver
            .Manage()
            .Window
            .Maximize();

        [FindsBy(How = How.Name, Using = Selector.Username)]
        private IWebElement username;
        public void EnterUserName() => username.SendKeys(ConfigurationManager.AppSettings["username"]);

        [FindsBy(How = How.Name, Using = Selector.Password)]
        private IWebElement password;
        public void EnterPassword() => password.SendKeys(ConfigurationManager.AppSettings["password"]);

        [FindsBy(How = How.XPath, Using = Selector.Signin)]
        private IWebElement signin;
        public void ClickSignin() => signin.Click();

        public void login()
        {
            NavigatetoURL();
            Maximizewindow();
            EnterUserName();
            EnterPassword();
            ClickSignin();
        }
    }
}
