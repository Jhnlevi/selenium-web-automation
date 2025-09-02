using OpenQA.Selenium;
using SauceDemoTests.Models;
using TestUtilities;

namespace SauceDemoTests.Tests
{
    public class BaseTest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Structure",
            "NUnit1032:An IDisposable field/property should be Disposed in a TearDown method",
            Justification = "Dispose and Quit are handled by CloseDriver method.")]
        protected IWebDriver _driver;
        protected AppConfig _config;
        // protected ExtentTest _test;

        [OneTimeSetUp]
        public void SetupReport()
        {
            // Report set up.
            ReportManager.CreateExtentReport();
        }

        [SetUp]
        public virtual void SetUp()
        {
            // Config set up.
            _config = TestConfigReader.GetAppSettings<AppConfig>();

            // Driver set up.
            _driver = WebDriverFactory.GetDriver(_config.Browser);

            // Report test set up.
            ReportManager.CreateExtentTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void TearDown()
        {
            var _context = TestContext.CurrentContext;
            // Get test results, message, method name, and stack trace.
            var testStatus = _context.Result.Outcome.Status;
            var testMessage = _context.Result.Message;
            var stackTrace = _context.Result.StackTrace;
            var testMethodName = _context.Test.MethodName;

            TestResultHelper.LogTestResults(
                testStatus,
                _driver,
                testMessage,
                stackTrace,
                testMethodName);

            // Close driver.

            if (_driver != null)
            {
                WebDriverFactory.CloseDriver();
                _driver = null;
            }
        }

        [OneTimeTearDown]
        public void CloseReport()
        {
            // Close report.
            ReportManager.CloseExtentReport();
        }
    }
}
