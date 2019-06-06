using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UiAutomation.Dropbox.PageObjects;

namespace UiAutomation.Dropbox
{
    [Binding]
    class StepDefinition
    { 

        Signin signin = new Signin();
        Home home = new Home();
        Files files = new Files();

        [Given(@"I have logged in into drop box")]
        public void GivenIHaveLoggedInIntoDropBox() => signin.login();

        [Given(@"I can see Home screen displayed with title '(.*)'")]
        public void GivenICanSeeHomeScreenDisplayedWithTitle(string title) => home.VerifyHometitle(title);

        [When(@"I click on Files from the left hand panel")]
        public void WhenIClickOnFilesFromTheLeftHandPanel() => home.ClckonFiles();

        [When(@"I click on New folder")]
        public void WhenIClickOnNewFolder() => files.ClckonNewFolder();

        [When(@"I enter Folder name '(.*)' and  select access as '(.*)'")]
        public void WhenIEnterFolderNameAndSelectAccessAs(string foldername, string accesstype)
        {
            files.Enterfoldername(foldername);
            ScenarioContext.Current.Add("foldername", foldername);
            files.Whocanaccess(accesstype);
        }

        [When(@"I click on create")]
        public void WhenIClickOnCreate() => files.ClickonCreate();

        [Then(@"I can see the folder is created")]
        public void ThenICanSeeTheFolderIsCreated() => files.VerifyFolder(ScenarioContext.Current["foldername"].ToString());

        [When(@"I click on upload files and  select the files '(.*)' to upload")]
        public void WhenIClickOnUploadFilesAndSelectTheFilesToUpload(string filename) => files.ClickonUploadfiles(filename);

        [Then(@"I can see the file '(.*)' is uploaded successfully")]
        public void ThenICanSeeTheFileIsUploadedSuccessfully(string filename) => files.Verifyfileuploaded(filename);

        [Then(@"I logged out from dropbox")]
        public void ThenILoggedOutFromDropbox() => files.signout();
    }
}
