using OpenQA.Selenium;

namespace SauceDemoTests.Utils
{
    public static class ScreenshotHelper
    {
        public static void CaptureScreenshot(IWebDriver driver, string fileNamePrefix)
        {

            var projectRoot = AppDomain.CurrentDomain.BaseDirectory;

            // Navigate up from bin to project folder
            projectRoot = Path.Combine(projectRoot, "..", "..", "..");

            string screenshotDirectory = Path.Combine(projectRoot, "Screenshots");

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
            string filePath = Path.Combine(screenshotDirectory, $"{fileNamePrefix}_{timeStamp}.png");

            screenshot.SaveAsFile(filePath);
            Console.WriteLine($"Screenshot saved: {filePath}");
        }
    }
}
