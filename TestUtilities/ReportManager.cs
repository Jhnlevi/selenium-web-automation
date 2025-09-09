using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;

namespace TestUtilities
{
    public static class ReportManager
    {
        private static ExtentReports _extent = null!;
        [ThreadStatic]
        private static ExtentTest _test = null!;

        // Create the report
        public static void CreateExtentReport(string projectName)
        {
            if (_extent == null)
            {
                // Get the current test folder.
                var projectRoot = Path.GetFullPath(Path.Combine(TestContext.CurrentContext.TestDirectory, "..", "..", ".."));

                // Checks if the folder exists. If not, create the screenshots folder inside reports folder.
                var reportFolder = Path.Combine(projectRoot, "Reports");
                if (!Directory.Exists(reportFolder))
                    Directory.CreateDirectory(reportFolder);

                // Create the report file name.
                var timeStamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                var fileName = $"{projectName}_Report_{timeStamp}.html";
                var reportFile = Path.Combine(reportFolder, fileName);

                // Generate the report
                var htmlReporter = new ExtentSparkReporter(reportFile);
                _extent = new ExtentReports();
                _extent.AttachReporter(htmlReporter);
            }
        }

        // Create test to use in report.
        public static void CreateExtentTest(string testName) => _test = _extent.CreateTest(testName);

        // Log test info.
        public static void LogInfo(string testMessage) => _test.Info(testMessage);

        // Log if pass.
        public static void LogPass(string testMessage) => _test.Pass(testMessage);

        // Log if fail.
        public static void LogFail(string testMessage) => _test.Fail(testMessage);

        // Log warnings.
        public static void LogWarn(string testMessage) => _test.Warning(testMessage);

        // Attach screenshot to report.
        public static void ReportAttachScreenshot(string filePath) => _test.AddScreenCaptureFromPath(filePath);

        // Close the report.
        public static void CloseExtentReport() => _extent.Flush();
    }
}
