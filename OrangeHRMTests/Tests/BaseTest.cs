using OpenQA.Selenium;
using OrangeHRMTests.Models;
using TestUtilities;

namespace OrangeHRMTests.Tests
{
    internal class BaseTest
    {
        protected AppConfig _config;
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Structure",
            "NUnit1032:An IDisposable field/property should be Disposed in a TearDown method",
            Justification = "Dispose and Quit are handled by CloseDriver method.")]
        protected IWebDriver _driver;

        [OneTimeSetUp]
        public void ReportSetup() => ReportManager.CreateExtentReport();

        [SetUp]
        public virtual void Setup()
        {
            _config = TestConfigReader.GetAppSettings<AppConfig>();
            _driver = WebDriverFactory.GetDriver("chrome");
            ReportManager.CreateExtentTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void Teardown()
        {
            var _context = TestContext.CurrentContext;
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

            if (_driver != null)
            {
                WebDriverFactory.CloseDriver();
                _driver = null;
            }
        }

        [OneTimeTearDown]
        public void ReportClose() => ReportManager.CloseExtentReport();
    }
}
