using AventStack.ExtentReports;
using OpenQA.Selenium;
using TestUtilities;

namespace SauceDemoTests.Tests
{
    public class BaseTest
    {
        protected ExtentReports _extent;
        protected ExtentTest _test;
        protected IWebDriver _driver;
        private string reportName = null!;

        [OneTimeSetUp]
        public void SetupReport()
        {
            // Report set up
            reportName = TestContext.CurrentContext.Test.Name;
            _extent = ReportManager.CreateReport(reportName);
        }

        [SetUp]
        public virtual void SetUp()
        {
            // Driver set up
            _driver = WebDriverFactory.CreateDriver("chrome");

            // Report test set up
            reportName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(reportName);
        }

        [TearDown]
        public void TearDown()
        {
            // Get test results, message, method name, and stack trace
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var testMessage = TestContext.CurrentContext.Result.Message;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;
            var testMethodName = TestContext.CurrentContext.Test.MethodName;

            TestResultHelper.LogTestResults(testStatus, _driver, _test, testMessage, stackTrace, testMethodName);

            // Close driver
            _driver.Quit();
            _driver.Dispose();
        }

        [OneTimeTearDown]
        public void CloseReport()
        {
            // Close report
            _extent.Flush();
        }
    }
}
