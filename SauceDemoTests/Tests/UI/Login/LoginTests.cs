using OpenQA.Selenium;
using SauceDemoTests.Models.Login;
using SauceDemoTests.Pages.Login;
using SauceDemoTests.Utils;
using SeleniumToolkit.Helpers;

namespace SauceDemoTests.Tests.UI.Login
{
    public class LoginTests : BaseTest
    {
        private LoginPage _login;

        [SetUp]
        public override void SetUp()
        {
            // Setup basetest methods first.
            base.SetUp();

            // Navigating to SauceDemo website.
            ReportManager.LogInfo("Navigating to SauceDemo website.");
            _driver!.Navigate().GoToUrl(_config.BaseUrl);

            // Initialize LoginPage.
            _login = new LoginPage(_driver);
        }

        // TC_Login_0001
        [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.LoginPositiveCases))]
        public void Login_WithValidCredentials(LoginTestCase testCase)
        {
            ReportManager.LogInfo("Entering username and password.");
            _login.EnterUserName(testCase.testData!.userName);
            _login.EnterPassword(testCase.testData.password);

            ReportManager.LogInfo("Clicking 'Login' button.");
            _login.ClickLoginBtn();

            ReportManager.LogInfo("Verifying dashboard is displayed.");
            Assert.That(_driver!.Url, Is.EqualTo("https://www.saucedemo.com/v1/inventory.html"));
        }

        // TC_Login_0002; TC_Login_0003, TC_Login_0004
        [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.LoginNegativeCases))]
        public void InvalidLogin_ShowsErrorMessage(LoginTestCase testCase)
        {
            ReportManager.LogInfo("Entering username and password.");
            _login.EnterUserName(testCase.testData!.userName);
            _login.EnterPassword(testCase.testData!.password);

            ReportManager.LogInfo("Clicking 'Login' button.");
            _login.ClickLoginBtn();

            ReportManager.LogInfo("Verifying that the user shouldn't be able to login; An error message is displayed.");
            Assert.That(_login.IsErrorMessageDisplayed, Is.True);
        }

        // TC_Login_0006
        [TestCase("locked_out_user", "secret_sauce", "Negative")]
        public void InvalidLogin_LockedOutUser(string username, string password, string testType)
        {
            ReportManager.LogInfo("Entering username and password.");
            _login.EnterUserName(username);
            _login.EnterPassword(password);

            ReportManager.LogInfo("Clicking 'Login' button.");
            _login.ClickLoginBtn();

            ReportManager.LogInfo("Verifying that the locked-out user shouldn't be able to login; An error message is displayed.");
            Assert.That(_login.GetErrorMessage().Contains("locked out"), Is.True);
        }

        // TC_Login_0005
        [TestCase("standard_user", "secret_sauce")]
        public void Login_PasswordFieldIsMasked(string username, string password)
        {
            // Get password field attribute.
            var passwordField = _driver!.FindElement(By.Id("password"));
            var passwordType = passwordField.GetAttribute("type");

            ReportManager.LogInfo("Entering username and password.");
            _login.EnterUserName(username);
            _login.EnterPassword(password);

            ReportManager.LogInfo("Verifying password field is masked.");
            Assert.That(passwordType, Is.EqualTo("password"));
        }
    }
}
