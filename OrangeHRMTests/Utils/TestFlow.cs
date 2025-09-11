using OpenQA.Selenium;
using OrangeHRMTests.Constants;
using OrangeHRMTests.Pages.Login;
using OrangeHRMTests.Pages.Menu;
using OrangeHRMTests.Pages.Profile;

namespace OrangeHRMTests.Utils
{
    internal class TestFlow
    {
        public static void Login_Admin(IWebDriver driver, string url)
        {
            var login = new Login_Page(driver);

            login.NavigateToUrl(url);
            login.EnterUsername(Account_Admin.Username);
            login.EnterPassword(Account_Admin.Password);
            login.ClickLoginButton();
        }

        public static void Navigate_MyInfoPage(IWebDriver driver)
        {
            var menu = new Menu_Page(driver);
            menu.ClickElement(Fields_Menu.MyInfo);
        }

        public static void Navigate_MyInfo_PersonalDetailsTab(IWebDriver driver)
        {
            var profile = new Profile_Page(driver);

            profile.ClickElement(Fields_Profile.PersonalDetails);
        }

        public static void Navigate_MyInfo_ContactDetailsTab(IWebDriver driver)
        {
            var profile = new Profile_Page(driver);

            profile.ClickElement(Fields_Profile.ContactDetails);
        }
    }
}
