using OpenQA.Selenium;
using SauceDemoTests.Pages.Login;

namespace SauceDemoTests.Tests.Login
{
    public class LoginTests : BaseTest
    {
        private LoginPage _login;

        [SetUp]
        public override void SetUp()
        {
            // Setup basetest methods first
            base.SetUp();

            _test.Info("Navigating to SauceDemo website.");
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/v1/");

            // Initialize LoginPage
            _login = new LoginPage(_driver);
        }

        // TC_Login_0001
        [TestCase("standard_user", "secret_sauce")]
        public void Login_WithValidCredentials(string username, string password)
        {
            _test.Info("Entering username and password.");
            _login.EnterUserName(username);
            _login.EnterPassword(password);

            _test.Info("Clicking 'Login' button.");
            _login.ClickLoginBtn();

            _test.Info("Verifying dashboard is displayed.");
            Assert.That(_driver.Url, Is.EqualTo("https://www.saucedemo.com/v1/inventory.html"));
        }

        // TC_Login_0002; TC_Login_0003, TC_Login_0004
        [TestCase("123", "secret_sauce", "InvalidUserName", "Negative")]
        [TestCase("standard_user", "123", "InvalidPassword", "Negative")]
        [TestCase("", "", "NoData", "Negative")]
        public void InvalidLogin_ShowsErrorMessage(string username, string password, string message, string testType)
        {
            _test.Info("Entering username and password.");
            _login.EnterUserName(username);
            _login.EnterPassword(password);

            _test.Info("Clicking 'Login' button.");
            _login.ClickLoginBtn();

            _test.Info("Verifying that the user shouldn't be able to login; An error message is displayed.");
            Assert.That(_login.IsErrorMessageDisplayed, Is.True);
        }

        // TC_Login_0006
        [TestCase("locked_out_user", "secret_sauce", "Negative")]
        public void InvalidLogin_LockedOutUser(string username, string password, string testType)
        {
            _test.Info("Entering username and password.");
            _login.EnterUserName(username);
            _login.EnterPassword(password);

            _test.Info("Clicking 'Login' button.");
            _login.ClickLoginBtn();

            _test.Info("Verifying that the locked-out user shouldn't be able to login; An error message is displayed.");
            Assert.That(_login.GetErrorMessage().Contains("locked out"), Is.True);
        }

        // TC_Login_0005
        [TestCase("standard_user", "secret_sauce")]
        public void Login_PasswordFieldIsMasked(string username, string password)
        {
            // Get password field attribute
            var passwordField = _driver.FindElement(By.Id("password"));
            var passwordType = passwordField.GetAttribute("type");

            _test.Info("Entering username and password.");
            _login.EnterUserName(username);
            _login.EnterPassword(password);

            _test.Info("Verifying password field is masked.");
            Assert.That(passwordType, Is.EqualTo("password"));
        }
    }
}
