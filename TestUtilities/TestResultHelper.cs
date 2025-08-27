using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace SauceDemoTests.Utils
{
    public static class TestResultHelper
    {
        public static void LogTestResults(
            NUnit.Framework.Interfaces.TestStatus status,
            IWebDriver driver,
            ExtentTest extentTest,
            string message,
            string stackTrace,
            string methodName)
        {
            switch (status)
            {
                case NUnit.Framework.Interfaces.TestStatus.Failed:
                    string screenshotFile = ScreenshotHelper.CaptureScreenshot(driver, TestContext.CurrentContext.Test.MethodName);
                    extentTest.Fail($"Test Failed : {message}\n{stackTrace}").AddScreenCaptureFromPath(screenshotFile);
                    break;
                case NUnit.Framework.Interfaces.TestStatus.Passed:
                    if (TestContext.CurrentContext.Test.Arguments.Contains("Negative"))
                    {
                        string passScreenshot = ScreenshotHelper.CaptureScreenshot(driver, TestContext.CurrentContext.Test.MethodName);
                        extentTest.Pass("Test Passed").AddScreenCaptureFromPath(passScreenshot);
                    }
                    else
                    {
                        extentTest.Pass("Test Passed");
                    }
                    break;
                default:
                    extentTest.Warning("Test ended with unusual status");
                    break;
            }
        }
    }
}
