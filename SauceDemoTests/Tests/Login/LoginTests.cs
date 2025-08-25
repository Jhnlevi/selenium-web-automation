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

            // Arrange
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/v1/");
            _login = new LoginPage(_driver);
        }

        [TestCase("standard_user", "secret_sauce")]
        public void Login_WithValidCredentials(string username, string password)
        {
            // Act
            _login.LoginAs(username, password);
            ScreenshotHelper.CaptureScreenshot(_driver, "Login");

            // Assert
            Assert.That(_driver.Url, Is.EqualTo("https://www.saucedemo.com/v1/inventory.html"));
        }

        [TestCase("123", "secret_sauce")]
        [TestCase("standard_user", "123")]
        [TestCase("", "")]
        public void InvalidLogin_ShowsErrorMessage(string username, string password)
        {
            // Act
            _login.LoginAs(username, password);
            ScreenshotHelper.CaptureScreenshot(_driver, "Login");

            // Assert
            Assert.That(_login.IsErrorMessageDisplayed, Is.True);
        }

        [TestCase("locked_out_user", "secret_sauce")]
        public void InvalidLogin_LockedOutUser(string username, string password)
        {
            // Act
            _login.LoginAs(username, password);
            ScreenshotHelper.CaptureScreenshot(_driver, "Login");

            // Assert
            Assert.That(_login.GetErrorMessage().Contains("locked out"), Is.True);
        }

        [TestCase("standard_user", "secret_sauce")]
        public void PasswordField_IsMasked(string username, string password)
        {
            var passwordField = _driver.FindElement(By.Id("password"));
            var passwordType = passwordField.GetAttribute("type");

            // Act
            _login.EnterUserName(username);
            _login.EnterPassword(password);
            ScreenshotHelper.CaptureScreenshot(_driver, "Login");

            // Assert
            Assert.That(passwordType, Is.EqualTo("password"));
        }
    }
}
