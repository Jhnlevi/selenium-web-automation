using SauceDemoTests.Models.Checkout;
using SauceDemoTests.Models.Login;

namespace SauceDemoTests.Utils
{
    public static class TestDataProvider
    {
        // Method for calling positive login test cases.
        public static IEnumerable<TestCaseData> LoginPositiveCases => GetLoginTestData("positive");

        // Method for calling negative login test cases.
        public static IEnumerable<TestCaseData> LoginNegativeCases => GetLoginTestData("negative");

        // Method for calling positive checkout test cases.
        public static IEnumerable<TestCaseData> CheckoutPositiveCases => GetCheckoutTestData("positive");

        // Method for calling positive checkout test cases.
        public static IEnumerable<TestCaseData> CheckoutNegativeCases => GetCheckoutTestData("negative");

        public static IEnumerable<TestCaseData> GetLoginTestData(string testType)
        {
            // Path for the login test data.
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "Login", "loginTestData.json");

            // Call JsonDataReader util.
            var data = TestUtilities.TestDataReader.ReadJson<LoginTestRoot>(path);

            // Filter test case.
            var filteredTestCase = data.testCases!
                .Where(tc => tc.testType.Equals(testType, StringComparison.OrdinalIgnoreCase))
                .ToList();

            foreach (var testCase in filteredTestCase)
            {
                // return a single test case.
                yield return new TestCaseData(testCase).SetName($"{testCase.testCaseId} - {testCase.testCaseDescription}"); ;
            }
        }

        public static IEnumerable<TestCaseData> GetCheckoutTestData(string testType)
        {
            // Path for the checkout test data.
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "Checkout", "checkoutTestData.json");

            // Call JsonDataReader util.
            var data = TestUtilities.TestDataReader.ReadJson<CheckoutTestRoot>(path);

            // Filter test case.
            var filteredTestCase = data.testCases!
                .Where(tc => tc.testType.Equals(testType, StringComparison.OrdinalIgnoreCase))
                .ToList();

            foreach (var testCase in filteredTestCase)
            {
                // return a single test case.
                yield return new TestCaseData(testCase).SetName($"{testCase.testCaseId} - {testCase.testCaseDescription}"); ;
            }
        }
    }
}
