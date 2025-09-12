using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OrangeHRMTests.Models.Login;
using OrangeHRMTests.Pages.Login;
using OrangeHRMTests.Utils.Providers;
using TestUtilities;

namespace OrangeHRMTests.Tests.UI.Login
{
    internal class Login_Tests : BaseTest
    {
        private Login_Page _login;
        private WebDriverWait? _wait;

        [SetUp]
        public override void Setup()
        {
            base.Setup();
            _login = new Login_Page(_driver!);

            _wait = new WebDriverWait(_driver!, TimeSpan.FromSeconds(15));

            ReportManager.LogInfo("Navigating to OrangeHRM demo website.");
            _login.NavigateToUrl(_config.BaseUrl);
        }

        [Test]
        public void Login_VerifyPageIsLoaded()
        {
            ReportManager.LogInfo("Verifying that login page elements are visible");

            Assert.That(_login.UsernameDisplayed, Is.True);
            Assert.That(_login.PasswordDisplayed, Is.True);
            Assert.That(_login.LoginButtonDisplayed, Is.True);
        }

        [TestCaseSource(typeof(Login_Provider), nameof(Login_Provider.GetValidCaseRecords))]
        public void Login_WithValidCredentials(LoginCase testCase)
        {
            ReportManager.LogInfo("Entering username.");
            _login.EnterUsername(testCase.TestData!.UserName);
            ReportManager.LogInfo("Entering password.");
            _login.EnterPassword(testCase.TestData!.Password);
            ReportManager.LogInfo("Clicking login button.");
            _login.ClickLoginButton();
            ReportManager.LogInfo("Verifying that user is redirected to dashboard.");

            _wait!.Until(d => d.WaitForElementToBeVisible(By.CssSelector("div.oxd-layout-context")));

            Assert.That(_login.GetCurrentUrl().EndsWith("/dashboard/index"), Is.True);

        }

        [TestCaseSource(typeof(Login_Provider), nameof(Login_Provider.GetInvalidCaseRecords))]
        public void Login_WithInvalidCredentials(LoginCase testCase)
        {
            ReportManager.LogInfo("Entering username.");
            _login.EnterUsername(testCase.TestData!.UserName);
            ReportManager.LogInfo("Entering password.");
            _login.EnterPassword(testCase.TestData!.Password);
            ReportManager.LogInfo("Clicking login button.");
            _login.ClickLoginButton();
            ReportManager.LogInfo("Verifying that user cannot login with invalid credentials.");
            Assert.That(_login.ErrorMessageDisplayed, Is.True);
        }

        [TestCaseSource(typeof(Login_Provider), nameof(Login_Provider.GetMissingCaseRecords))]
        public void Login_WithMissingInput(LoginCase testCase)
        {
            ReportManager.LogInfo("Entering username.");
            _login.EnterUsername(testCase.TestData!.UserName);
            ReportManager.LogInfo("Entering password.");
            _login.EnterPassword(testCase.TestData!.Password);
            ReportManager.LogInfo("Clicking login button.");
            _login.ClickLoginButton();
            if (testCase.ExpectedResult!.FieldErrors != null && testCase.ExpectedResult.FieldErrors.Any())
            {
                // To loop on all fields.
                foreach (var expected in testCase.ExpectedResult.FieldErrors)
                {
                    var actualMessage = _login.GetFieldError(expected.Field);
                    ReportManager.LogInfo($"Verifying that user cannot login with missing {expected.Field}.");
                    Assert.That(actualMessage, Is.EqualTo(expected.Message));
                }
            }
        }

        [Test]
        public void Login_RedirectToLoginPageOnLogout()
        {
            ReportManager.LogInfo("Entering username.");
            _login.EnterUsername("Admin");
            ReportManager.LogInfo("Entering password.");
            _login.EnterPassword("admin123");
            ReportManager.LogInfo("Clicking login button.");
            _login.ClickLoginButton();
            ReportManager.LogInfo("Clicking user dropdown menu in topbar.");
            _login._topbar.ClickUserDropdown();
            ReportManager.LogInfo("Clicking logout button.");
            _login._topbar.ClickLogoutButton();
            ReportManager.LogInfo("Verifying that user is redirected to login page");
            Assert.That(_driver!.Url.Contains("login"), Is.True);
        }
    }
}
