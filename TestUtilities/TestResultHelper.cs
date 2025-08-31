using OpenQA.Selenium;

namespace TestUtilities
{
    public static class TestResultHelper
    {
        public static void LogTestResults(
            NUnit.Framework.Interfaces.TestStatus status,
            IWebDriver driver,
            string message,
            string stackTrace,
            string methodName)
        {
            switch (status)
            {
                case NUnit.Framework.Interfaces.TestStatus.Failed:
                    string screenshotFile = ScreenshotHelper.CaptureScreenshot(driver, methodName);
                    ReportManager.LogFail($"Test Failed : {message} \n {stackTrace}");
                    ReportManager.ReportAttachScreenshot(screenshotFile);
                    break;
                case NUnit.Framework.Interfaces.TestStatus.Passed:
                    ReportManager.LogPass("Test Passed!");
                    break;
                default:
                    ReportManager.LogWarn("Test ended with unusual status");
                    break;
            }
        }
    }
}
