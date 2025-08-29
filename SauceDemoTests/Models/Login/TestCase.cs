namespace SauceDemoTests.Models.Login
{
    public class TestCase
    {
        public string testCaseId { get; set; } = null!;
        public string testCaseDescription { get; set; } = null!;
        public string testType { get; set; } = null!;
        public TestData? testData { get; set; }
        public ExpectedResult? expectedResult { get; set; }
    }
}
