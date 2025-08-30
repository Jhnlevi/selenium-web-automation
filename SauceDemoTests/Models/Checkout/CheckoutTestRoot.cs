namespace SauceDemoTests.Models.Checkout
{
    public class CheckoutTestRoot
    {
        public string name { get; set; } = null!;
        public string description { get; set; } = null!;
        public List<CheckoutTestCase>? testCases { get; set; }
    }
}
