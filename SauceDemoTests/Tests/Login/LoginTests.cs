using OpenQA.Selenium;
using SauceDemoTests.Pages.Login;
using SauceDemoTests.Utils;

namespace SauceDemoTests.Tests.Login
{
    public class LoginTests : BaseTest
    {
        private LoginPage _login;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/v1/");
            _login = new LoginPage(_driver);
        }

        // TC_Login_0001
        [TestCase("standard_user", "secret_sauce")]
        public void Login_WithValidCredentials(string username, string password)
        {
            _login.LoginAs(username, password);
            ScreenshotHelper.CaptureScreenshot(_driver, "Login_WithValidCredentials");
            Assert.That(_driver.Url, Is.EqualTo("https://www.saucedemo.com/v1/inventory.html"));
        }

        // TC_Login_0002; TC_Login_0003, TC_Login_0004
        [TestCase("123", "secret_sauce", "InvalidUserName")]
        [TestCase("standard_user", "123", "InvalidPassword")]
        [TestCase("", "", "NoData")]
        public void InvalidLogin_ShowsErrorMessage(string username, string password, string message)
        {
            _login.LoginAs(username, password);
            ScreenshotHelper.CaptureScreenshot(_driver, "InvalidLogin_ShowsErrorMessage", message);
            Assert.That(_login.IsErrorMessageDisplayed, Is.True);
        }

        // TC_Login_0006
        [TestCase("locked_out_user", "secret_sauce")]
        public void InvalidLogin_LockedOutUser(string username, string password)
        {
            _login.LoginAs(username, password);
            ScreenshotHelper.CaptureScreenshot(_driver, "InvalidLogin_LockedOutUser", "locked_out_user");
            Assert.That(_login.GetErrorMessage().Contains("locked out"), Is.True);
        }

        // TC_Login_0005
        [TestCase("standard_user", "secret_sauce")]
        public void Login_PasswordFieldIsMasked(string username, string password)
        {
            var passwordField = _driver.FindElement(By.Id("password"));
            var passwordType = passwordField.GetAttribute("type");
            _login.EnterUserName(username);
            _login.EnterPassword(password);
            ScreenshotHelper.CaptureScreenshot(_driver, "Login_PasswordFieldIsMasked");
            Assert.That(passwordType, Is.EqualTo("password"));
        }
    }
}
