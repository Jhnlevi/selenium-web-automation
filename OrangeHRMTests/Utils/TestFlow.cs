using OpenQA.Selenium;
using OrangeHRMTests.Constants;
using OrangeHRMTests.Pages.Login;
using OrangeHRMTests.Pages.Menu;
using OrangeHRMTests.Pages.Profile;

namespace OrangeHRMTests.Utils
{
    internal class TestFlow
    {
        public static void LoginAsAdmin(IWebDriver driver, string url)
        {
            var login = new LoginPage(driver);

            login.NavigateToUrl(url);
            login.EnterUsername(Account_Admin.Username);
            login.EnterPassword(Account_Admin.Password);
            login.ClickLoginButton();
        }

        public static void NavigateToMyInfo(IWebDriver driver, string url)
        {
            var menu = new NavigationMenuPage(driver);

            menu.ClickElement(Fields_Menu.MyInfo);
        }

        public static void NavigateToPDTab(IWebDriver driver)
        {
            var menu = new NavigationMenuPage(driver);
            var profile = new ProfilePage(driver);

            menu.ClickElement(Fields_Menu.MyInfo);
            profile.ClickElement(Fields_Profile.PersonalDetails);
        }
    }
}
