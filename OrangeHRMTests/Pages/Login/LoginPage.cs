using OpenQA.Selenium;
using OrangeHRMTests.Pages.TopBar;

namespace OrangeHRMTests.Pages.Login
{
    internal class LoginPage : BasePage
    {
        public TopBarPage _topbar { get; }

        public LoginPage(IWebDriver driver) : base(driver)
        {
            _topbar = new TopBarPage(driver);
        }

        private By InptUsername = By.Name("username");
        private By InptPassword = By.Name("password");
        private By BtnLogin = By.CssSelector(".orangehrm-login-button");
        private By ErrAlertMessage = By.CssSelector(".oxd-alert-content-text");
        private By FieldUsernameError = By.CssSelector("div.oxd-input-group:has(input[name='username']) span.oxd-input-field-error-message");
        private By FieldPasswordError = By.CssSelector("div.oxd-input-group:has(input[name='password']) span.oxd-input-field-error-message");
        private By ErrAlert = By.CssSelector(".oxd-alert--error");

        public bool UsernameDisplayed => IsElementDisplayed(InptUsername);
        public bool PasswordDisplayed => IsElementDisplayed(InptPassword);
        public bool LoginButtonDisplayed => IsElementDisplayed(BtnLogin);
        public bool ErrorMessageDisplayed => IsElementDisplayed(ErrAlert);

        public void EnterUsername(string username) => EnterText(InptUsername, username);
        public void EnterPassword(string password) => EnterText(InptPassword, password);
        public void ClickLoginButton() => Click(BtnLogin);
        public string GetErrorMessage() => GetText(ErrAlertMessage);

        public string GetFieldError(string fieldName)
        {
            return fieldName.ToLower() switch
            {
                "username" => GetText(FieldUsernameError),
                "password" => GetText(FieldPasswordError),
                _ => throw new ArgumentException($"Unknown field: {fieldName}")
            };
        }
    }
}
