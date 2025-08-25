using SauceDemoTests.Pages.Login;
using SauceDemoTests.Utils;

namespace SauceDemoTests.Tests.Login
{
    public class LoginTests : BaseTest
    {
        // Fields
        private LoginPage _login;

        [SetUp]
        public override void SetUp()
        {
            // Call parent first
            base.SetUp();

            // Navigate
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/v1/");

            // Initialized POM
            _login = new LoginPage(_driver);
        }

        [TestCase("standard_user", "secret_sauce")]
        public void Login_WithValidCredentials(string username, string password)
        {
            // Act
            _login.LoginAs(username, password);

            // Take screenshot
            ScreenshotHelper.CaptureScreenshot(_driver);

            // Assert
            Assert.That(_driver.Url, Is.EqualTo("https://www.saucedemo.com/v1/inventory.html"));
        }
    }
}
