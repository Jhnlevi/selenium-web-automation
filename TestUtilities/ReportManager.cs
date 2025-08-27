using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace TestUtilities
{
    public static class ReportManager
    {
        private static ExtentReports _extent;
        public static ExtentReports GetInstance()
        {
            if (_extent == null)
            {
                // Save to the Reports folder, and navigate up from bin to project folder
                var projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\.."));

                string reportsFolder = Path.Combine(projectRoot, "Reports");

                // Checks if the folder exists
                if (!Directory.Exists(reportsFolder))
                {
                    Directory.CreateDirectory(reportsFolder);
                }

                // Get current date and time
                string timeStamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string reportFileName = $"TestReport_{timeStamp}.html";

                string reportFile = Path.Combine(reportsFolder, reportFileName);

                // Generate the report
                var htmlReporter = new ExtentSparkReporter(reportFile);
                _extent = new ExtentReports();
                _extent.AttachReporter(htmlReporter);
            }
            return _extent;
        }
    }
}
