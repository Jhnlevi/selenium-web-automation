using OpenQA.Selenium;
using OrangeHRMTests.Pages.Login;

namespace OrangeHRMTests.Utils
{
    internal class TestFlow
    {
        public static void LoginAsAdmin(IWebDriver driver, string username, string password, string url)
        {
            var login = new LoginPage(driver);

            login.NavigateToUrl(url);
            login.EnterUsername(username);
            login.EnterPassword(password);
            login.ClickLoginButton();
        }
    }
}
