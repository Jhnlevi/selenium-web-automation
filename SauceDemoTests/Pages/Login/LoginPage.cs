using OpenQA.Selenium;
using SauceDemoTests.Utils;

namespace SauceDemoTests.Pages.Login
{
    public class LoginPage
    {
        // Fields
        private readonly IWebDriver _driver;

        // Locator
        private By InputUserName = By.Id("user-name");
        private By InputPassword = By.Id("password");
        private By BtnLogin = By.Id("login-button");
        private By ErrMessage = By.CssSelector("[data-test='error']");

        // Constructor
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Actions
        public void EnterUserName(string username)
        {
            var element = _driver.WaitElementVisible(InputUserName);
            element.Clear();
            element.SendKeys(username);
        }
        public void EnterPassword(string password)
        {
            var element = _driver.WaitElementVisible(InputPassword);
            element.Clear();
            element.SendKeys(password);
        }
        public void ClickLoginBtn()
        {
            var element = _driver.WaitElementVisible(BtnLogin);
            element.Click();
        }
        public string GetErrorMessage()
        {
            var element = _driver.WaitElementVisible(ErrMessage);
            return element.Text;
        }
        public bool IsErrorMessageDisplayed()
        {
            return !string.IsNullOrEmpty(GetErrorMessage());
        }
        // Precondition method
        public void LoginAs(string username, string password)
        {
            EnterUserName(username);
            EnterPassword(password);
            ClickLoginBtn();
        }
    }
}
