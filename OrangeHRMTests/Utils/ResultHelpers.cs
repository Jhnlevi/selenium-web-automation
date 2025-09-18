using OpenQA.Selenium;
using SeleniumToolkit.Helpers;

namespace OrangeHRMTests.Utils
{
    internal static class ResultHelpers
    {
        /// <summary>
        /// Log test results to report.
        /// </summary>
        public static void LogResults(
            IWebDriver driver,
            string status,
            string message,
            string trace,
            string name)
        {
            switch (status)
            {
                case "Passed":
                    ReportManager.LogPass("Test passed!");
                    break;
                case "Failed":
                    string screenshotPath = ScreenshotManager.Capture(driver, name);
                    ReportManager.LogFail($"Test Failed: {message}");
                    ReportManager.LogInfo($"Stack trace: {trace}");
                    ReportManager.ReportAttachScreenshot(screenshotPath);
                    break;
                default:
                    ReportManager.LogWarn("Test ended with unusual status...");
                    break;
            }
        }
    }
}
