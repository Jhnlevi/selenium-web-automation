namespace SauceDemoTests.Models
{
    public class AppConfig
    {
        public string BaseUrl { get; set; } = null!;
        public string Browser { get; set; } = null!;
        public int ImplicitWait { get; set; }
        public int PageLoadTimeout { get; set; }
        public string ScreenshotFolderPath { get; set; } = null!;
        public string ReportFolderPath { get; set; } = null!;
    }
}
