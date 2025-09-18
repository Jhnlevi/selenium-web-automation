using OpenQA.Selenium;
using OrangeHRMTests.Models;
using SeleniumToolkit.Data;
using SeleniumToolkit.Driver;
using SeleniumToolkit.Helpers;

namespace OrangeHRMTests.Tests
{
    internal abstract class BaseTest
    {
        protected AppConfig _config;
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Structure",
            "NUnit1032:An IDisposable field/property should be Disposed in a TearDown method",
            Justification = "Dispose and Quit are handled by DriverFactory.QuitDriver() method.")]
        protected IWebDriver? _driver;

        [OneTimeSetUp]
        public void ReportSetup() => ReportManager.CreateExtentReport("OrangeHRM");

        [SetUp]
        public virtual void Setup()
        {
            _config = ConfigLoader.Get<AppConfig>("appsettings.json", "AppSettings");
            _driver = DriverFactory.GetDriver("chrome");
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

            //TestResultHelper.LogTestResults(
            //    testStatus,
            //    _driver!,
            //    testMessage,
            //    stackTrace!,
            //    testMethodName!);

            DriverFactory.QuitDriver();
        }

        [OneTimeTearDown]
        public void ReportClose() => ReportManager.QuitExtentReport();
    }
}
