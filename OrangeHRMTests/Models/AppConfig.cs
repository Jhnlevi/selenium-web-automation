namespace OrangeHRMTests.Models
{
    internal class AppConfig
    {
        public string AppName { get; set; } = null!;
        public string BaseUrl { get; set; } = null!;
        public string Browser { get; set; } = null!;
        public int ImplicitWait { get; set; }
        public int PageLoadTimeout { get; set; }
    }
}
