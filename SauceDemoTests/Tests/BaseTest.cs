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
            // Get test results, message, and stack trace
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var testMessage = TestContext.CurrentContext.Result.Message;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;

            // Log the results to report
            switch (testStatus)
            {
                case NUnit.Framework.Interfaces.TestStatus.Failed:
                    // Adding Screenshot to report for every failed test
                    string screenshotFile = ScreenshotHelper.CaptureScreenshot(_driver, TestContext.CurrentContext.Test.Name);
                    _test.Fail($"Test Failed : {testMessage}\n{stackTrace}").AddScreenCaptureFromPath(screenshotFile);
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
