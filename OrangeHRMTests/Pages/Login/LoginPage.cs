using OpenQA.Selenium;

namespace OrangeHRMTests.Pages.Login
{
    internal class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        private By InptUsername = By.Name("username");
        private By InptPassword = By.Name("password");
        private By BtnLogin = By.CssSelector(".orangehrm-login-button");
        private By ErrAlertMessage = By.CssSelector(".oxd-alert-content-text");
        private By ErrAlert = By.CssSelector(".oxd-alert--error");

        public bool UsernameDisplayed => IsElementDisplayed(InptUsername);
        public bool PasswordDisplayed => IsElementDisplayed(InptPassword);
        public bool LoginButtonDisplayed => IsElementDisplayed(BtnLogin);
        public bool ErrorMessageDisplayed => IsElementDisplayed(ErrAlert);

        public void EnterUsername(string username) => EnterText(InptUsername, username);
        public void EnterPassword(string password) => EnterText(InptPassword, password);
        public void ClickLoginButton() => Click(BtnLogin);
        public string GetErrorMessage() => GetText(ErrAlertMessage);
    }
}
