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
                // Failed test result.
                case NUnit.Framework.Interfaces.TestStatus.Failed:

                    // Get screenshot path.
                    string screenshotFilePath = ScreenshotHelper.CaptureScreenshot(driver, methodName);

                    // Log to Report.
                    ReportManager.LogFail($"Test Failed : {message} \n {stackTrace}");

                    // Attach screenshot to report.
                    ReportManager.ReportAttachScreenshot(screenshotFilePath);
                    break;

                // Pass test result.
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
