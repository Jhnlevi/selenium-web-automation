namespace SauceDemoTests.Models.Login
{
    public class TestRoot
    {
        public string name { get; set; } = null!;
        public string description { get; set; } = null!;
        public List<TestCase>? testCases { get; set; }
    }
}
