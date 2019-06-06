using Dropbox.TestAutomation;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Selector = Dropbox.TestAutomation.PageObjectModels.Loctors.MyFiles;
#pragma warning disable 649

namespace UiAutomation.Dropbox.PageObjects
{
    public class Files
    {
        public Files() => PageFactory.InitElements(PropertiesCollection.driver, this);

        [FindsBy(How = How.XPath, Using = Selector.newfolder)]
        private IWebElement newfolder;
        public void ClckonNewFolder()
        {
            System.Threading.Thread.Sleep(2000);
            PropertiesCollection.wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Selector.newfolder)));
            newfolder.Click();
        }

        [FindsBy(How = How.Id, Using = Selector.createfolder)]
        private IWebElement createfolder;
        public void Enterfoldername(string Foldername)
        {
            PropertiesCollection.wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(Selector.createfolder)));
            createfolder.SendKeys(Foldername);
        }

        [FindsBy(How = How.Id, Using = Selector.onlyyou)]
        private IWebElement onlyyou;
        [FindsBy(How = How.Id, Using = Selector.specificpeople)]
        private IWebElement specificpeople;
        public void Whocanaccess(string Accesstype)
        {
            if (Accesstype.ToLower() == "only you") onlyyou.Click();
            if (Accesstype.ToLower() == "specific people") specificpeople.Click();
            PropertiesCollection.wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(Selector.onlyyou)));
        }

        [FindsBy(How = How.XPath, Using = Selector.create)]
        private IWebElement create;
        public void ClickonCreate() => create.Click();

        [FindsBy(How = How.XPath, Using = Selector.foldername)]
        private IWebElement foldername;
        public void VerifyFolder(string Foldername)
        {
            PropertiesCollection.wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Selector.foldername)));
            Assert.AreEqual(Foldername.ToLower(), foldername.Text.Replace("dropbox/r/n","").ToString().ToLower());
        }

        [FindsBy(How = How.XPath, Using = Selector.uploadfiles)]
        private IWebElement uploadfiles;
        public void ClickonUploadfiles(string filename)
        {
            PropertiesCollection.wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Selector.uploadfiles)));
            uploadfiles.Click();
            System.Threading.Thread.Sleep(5000);
            SendKeys.SendWait(Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))), @"Data" + "\\" + filename));
            SendKeys.SendWait("{ENTER}");
        }

        [FindsBy(How = How.XPath, Using = Selector.tblverifyuoloadedfiles)]
        private IWebElement tblverifyuoloadedfiles;
        public void Verifyfileuploaded(string filename)
        {
            PropertiesCollection.wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Selector.tblverifyuoloadedfiles)));
            var rows = tblverifyuoloadedfiles
                .FindElements(By.TagName("a"));
            foreach (IWebElement row in rows)
            {
                Assert.AreEqual(row.Text.ToLower(), filename.ToLower());
            }
        }

        [FindsBy(How = How.XPath, Using = Selector.imgsignout)]
        private IWebElement imgsignout;
        public void ClickonSignoutImg() => imgsignout.Click();

        [FindsBy(How = How.XPath, Using = Selector.btnsignout)]
        private IWebElement btnsignout;
        public void ClickonSignout() => btnsignout.Click();

        public void signout()
        {
            ClickonSignoutImg();
            ClickonSignout();
        }
    }
}
