namespace SauceDemoTests.Models.Login
{
    public class LoginTestCase
    {
        public string testCaseId { get; set; } = null!;
        public string testCaseDescription { get; set; } = null!;
        public string testType { get; set; } = null!;
        public LoginTestData? testData { get; set; }
        public LoginExpectedResult? expectedResult { get; set; }
    }
}
