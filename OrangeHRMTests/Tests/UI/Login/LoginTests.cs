using OrangeHRMTests.Pages.Login;
using TestUtilities;

namespace OrangeHRMTests.Tests.UI.Login
{
    internal class LoginTests : BaseTest
    {
        private LoginPage _login;

        [SetUp]
        public override void Setup()
        {
            base.Setup();

            _login = new LoginPage(_driver);

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
    }
}
