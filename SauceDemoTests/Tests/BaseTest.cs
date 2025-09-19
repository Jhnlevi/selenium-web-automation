using OpenQA.Selenium;
using SauceDemoTests.Models;
using SauceDemoTests.Utils;
using SeleniumToolkit.Data;
using SeleniumToolkit.Driver;
using SeleniumToolkit.Helpers;

namespace SauceDemoTests.Tests
{
    public abstract class BaseTest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Structure",
            "NUnit1032:An IDisposable field/property should be Disposed in a TearDown method",
            Justification = "Dispose and Quit are handled by CloseDriver method.")]
        protected IWebDriver? _driver;
        protected AppConfig _config;

        [OneTimeSetUp]
        public void SetupReport()
        {
            // Report set up.
            ReportManager.CreateExtentReport("SauceDemo");
        }

        [SetUp]
        public virtual void SetUp()
        {
            // Config set up.
            _config = ConfigLoader.Get<AppConfig>("appsettings.json", "AppSettings");

            // Driver set up.
            _driver = DriverFactory.GetDriver(_config.Browser);

            // Report test set up.
            ReportManager.CreateExtentTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void TearDown()
        {
            var _context = TestContext.CurrentContext;
            var status = _context.Result.Outcome.Status.ToString();
            var message = _context.Result.Message;
            var trace = _context.Result.StackTrace;
            var methodName = _context.Test.MethodName;

            // Helper class to log results in report.
            ResultHelpers.LogResults(_driver!, status, message, trace!, methodName!);

            // Close driver.
            DriverFactory.QuitDriver();
        }

        [OneTimeTearDown]
        public void CloseReport()
        {
            // Close report.
            ReportManager.QuitExtentReport();
        }
    }
}
