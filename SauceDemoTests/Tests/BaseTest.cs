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

        // Report
        [OneTimeSetUp]
        public void SetupReport()
        {
            _extent = ReportManager.GetInstance();
        }

        [SetUp]
        public virtual void SetUp()
        {
            // Driver setup
            _driver = WebDriverFactory.CreateDriver("chrome");

            // Report test setup
            string reportTestName = TestContext.CurrentContext.Test.Name;
            _test = _extent.CreateTest(reportTestName);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        // Report
        [OneTimeTearDown]
        public void CloseReport()
        {
            _extent.Flush();
        }
    }
}
