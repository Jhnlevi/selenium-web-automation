using OpenQA.Selenium;

namespace TestUtilities
{
    public static class ScreenshotHelper
    {
        public static string CaptureScreenshot(IWebDriver driver, string testName, string folderName = "")
        {
            // Navigate from bin to the project folder.
            var projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", ".."));
            var screenshotFolder = Path.Combine(projectRoot, "Reports", "Screenshots");

            // Checks if the folder exists. If not, create the screenshots folder inside reports folder.
            if (!Directory.Exists(screenshotFolder))
            {
                Directory.CreateDirectory(screenshotFolder);
            }

            // Create the file name.
            var timeStamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var fileName = $"{testName}_{timeStamp}.png";
            var filePath = Path.Combine(screenshotFolder, fileName);

            // Take screenshot
            ITakesScreenshot screenshotDriver = (ITakesScreenshot)driver;
            var screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile(filePath);

            return filePath;
        }
    }
}
