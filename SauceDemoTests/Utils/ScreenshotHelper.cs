using OpenQA.Selenium;

namespace SauceDemoTests.Utils
{
    public static class ScreenshotHelper
    {
        public static string CaptureScreenshot(IWebDriver driver, string testName, string data = "")
        {

            var projectRoot = AppDomain.CurrentDomain.BaseDirectory;

            // Navigate up from bin to project folder
            projectRoot = Path.Combine(projectRoot, "..", "..", "..");

            string screenshotDirectory = Path.Combine(projectRoot, "Reports", "Screenshots");

            // Checks if the folder exists
            if (!Directory.Exists(screenshotDirectory))
            {
                Directory.CreateDirectory(screenshotDirectory);
            }

            // Captures screenshot
            ITakesScreenshot screenshotDriver = (ITakesScreenshot)driver;
            var screenshot = screenshotDriver.GetScreenshot();

            // Get timestamps and filepath
            string timeStamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            var fileName = string.IsNullOrEmpty(data)
                ? $"{testName}_{timeStamp}.png"
                : $"{testName}_{data}_{timeStamp}.png";

            var filePath = Path.Combine(screenshotDirectory, fileName);

            screenshot.SaveAsFile(filePath);
            //Console.WriteLine($"Screenshot saved at: {filePath}");

            return filePath;
        }
    }
}
