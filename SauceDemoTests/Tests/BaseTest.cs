using AventStack.ExtentReports;
using OpenQA.Selenium;
using SauceDemoTests.Utils;

namespace SauceDemoTests.Tests
{
    public class BaseTest
    {
        protected ExtentReports _extent;
        protected ExtentTest _test;
        protected IWebDriver _driver;

        [OneTimeSetUp]
        public void SetupReport()
        {
            // Report set up
            _extent = ReportManager.GetInstance();
        }

        [SetUp]
        public virtual void SetUp()
        {
            // Driver set up
            _driver = WebDriverFactory.CreateDriver("chrome");

            // Report test set up
            string reportTestName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(reportTestName);
        }

        [TearDown]
        public void TearDown()
        {
            // Get test results
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var testMessage = TestContext.CurrentContext.Result.Message;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;

            // Log the results to report
            switch (testStatus)
            {
                case NUnit.Framework.Interfaces.TestStatus.Failed:
                    _test.Fail("Test Failed : " + testMessage).Fail(stackTrace);
                    break;
                case NUnit.Framework.Interfaces.TestStatus.Passed:
                    _test.Pass("Test Passed");
                    break;
                default:
                    _test.Warning("Test ended with unusual status");
                    break;
            }

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
