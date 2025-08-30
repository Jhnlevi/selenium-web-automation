namespace SauceDemoTests.Models.Checkout
{
    public class CheckoutTestCase
    {
        public string testCaseId { get; set; } = null!;
        public string testCaseDescription { get; set; } = null!;
        public string testType { get; set; } = null!;
        public CheckoutTestData? testData { get; set; }
        public CheckoutExpectedResult? expectedResult { get; set; }
    }
}
