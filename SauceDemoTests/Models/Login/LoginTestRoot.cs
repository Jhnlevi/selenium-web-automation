namespace SauceDemoTests.Models.Login
{
    public class LoginTestRoot
    {
        public string name { get; set; } = null!;
        public string description { get; set; } = null!;
        public List<LoginTestCase>? testCases { get; set; }
    }
}
