using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;

namespace TestUtilities
{
    public static class ReportManager
    {
        private static ExtentReports _extent;
        [ThreadStatic]
        private static ExtentTest _test;

        // Create the report
        public static ExtentReports CreateReport(string rName = "")
        {
            if (_extent == null)
            {
                // Get the current test folder.
                var projectFolder = TestContext.CurrentContext.TestDirectory;
                var projectRoot = Path.Combine(projectFolder, "..", "..", "..");
                projectRoot = Path.GetFullPath(projectRoot);

                // Checks if the folder exists. If not, create the screenshots folder inside reports folder.
                var reportFolder = Path.Combine(projectRoot, "Reports");
                if (!Directory.Exists(reportFolder))
                {
                    Directory.CreateDirectory(reportFolder);
                }

                // Create the report file name.
                var timeStamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                var fileName = $"Report_{rName}_{timeStamp}.html";
                var reportFile = Path.Combine(reportFolder, fileName);

                // Generate the report
                var htmlReporter = new ExtentSparkReporter(reportFile);
                _extent = new ExtentReports();
                _extent.AttachReporter(htmlReporter);
            }
            return _extent;
        }
    }
}
