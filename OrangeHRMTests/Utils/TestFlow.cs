using OpenQA.Selenium;
using OrangeHRMTests.Constants;
using OrangeHRMTests.Pages.Login;
using OrangeHRMTests.Pages.Menu;

namespace OrangeHRMTests.Utils
{
    internal class TestFlow
    {
        public static void LoginAsAdmin(IWebDriver driver, string url)
        {
            var login = new LoginPage(driver);

            login.NavigateToUrl(url);
            login.EnterUsername(TestAccount.Username);
            login.EnterPassword(TestAccount.Password);
            login.ClickLoginButton();
        }

        public void NavigateToMyInfo(IWebDriver driver, string url)
        {
            var login = new LoginPage(driver);
            var menu = new NavigationMenuPage(driver);

            login.NavigateToUrl(url);
            login.EnterUsername(TestAccount.Username);
            login.EnterPassword(TestAccount.Password);
            login.ClickLoginButton();
            menu.ClickElement(MenuFields.MyInfo);
        }
    }
}
