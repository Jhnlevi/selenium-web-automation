using AventStack.ExtentReports;
using OpenQA.Selenium;
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
        protected ExtentReports _extent;
        protected ExtentTest _test;
        private TestContext _context = TestContext.CurrentContext;

        [OneTimeSetUp]
        public void SetupReport()
        {
            // Report set up.
            var reportName = _context.Test.Name;
            _extent = ReportManager.CreateReport(reportName);
        }

        [SetUp]
        public virtual void SetUp()
        {
            // Driver set up.
            _driver = WebDriverFactory.GetDriver("chrome");

            // Report test set up.
            var reportName = _context.Test.Name;
            _test = _extent.CreateTest(reportName);
        }

        [TearDown]
        public void TearDown()
        {
            // Get test results, message, method name, and stack trace.
            var testStatus = _context.Result.Outcome.Status;
            var testMessage = _context.Result.Message;
            var stackTrace = _context.Result.StackTrace;
            var testMethodName = _context.Test.MethodName;

            TestResultHelper.LogTestResults(testStatus, _driver, _test, testMessage, stackTrace, testMethodName);

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
            _extent.Flush();
        }
    }
}
