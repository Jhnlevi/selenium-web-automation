using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace SauceDemoTests.Utils
{
    public static class ReportManager
    {
        private static ExtentReports _extent;
        public static ExtentReports GetInstance()
        {
            if (_extent == null)
            {
                // Save to the Reports folder
                var projectRoot = AppDomain.CurrentDomain.BaseDirectory;

                // Navigate up from bin to project folder
                projectRoot = Path.Combine(projectRoot, "..", "..", "..");

                string reportsFolder = Path.Combine(projectRoot, "Reports");

                // Checks if the folder exists
                if (!Directory.Exists(reportsFolder))
                {
                    Directory.CreateDirectory(reportsFolder);
                }

                // Get current date and time
                string timeStamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string reportFileName = $"TestReport_{timeStamp}.html";

                // Generate the report
                var htmlReporter = new ExtentSparkReporter(reportFileName);
                _extent = new ExtentReports();
                _extent.AttachReporter(htmlReporter);
            }
            return _extent;
        }
    }
}
