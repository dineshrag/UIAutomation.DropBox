
namespace Dropbox.TestAutomation.PageObjectModels
{
    public class Loctors
    {
        public class LoginPage
        {
            public const string Username = "login_email";
            public const string Password = "login_password";
            public const string Signin = "//div[@class='signin-text']";
            public void EnterUserName() { }
        }

        public class HomePage
        {
            public const string hometitle = "//h1[@class='page-header__heading']";
            public const string filesmenu = "files";
        }

        public class MyFiles
        {
            public const string newfolder = "//div[contains(text(), 'New folder')]";
            public const string createfolder = "new_folder_name_input";
            public const string onlyyou = "not_confidential_option";
            public const string specificpeople = "confidential_option";
            public const string create = "//button[contains(text(), 'Create')]";
            public const string foldername = "//*[@id='path-breadcrumbs']/span[2]";
            public const string uploadfiles = "//div[contains(text(), 'Upload files')]";
            public const string tblverifyuoloadedfiles = "//table[@role ='table']/tbody";
            public const string imgsignout = "//img[@alt='Account photo']";
            public const string btnsignout = "//a[@role='menuitem' and contains(text(), 'Sign out')]";
        }
    }
}
