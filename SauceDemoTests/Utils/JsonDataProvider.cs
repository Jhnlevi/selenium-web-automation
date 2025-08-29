using SauceDemoTests.Models.Login;

namespace SauceDemoTests.Utils
{
    public static class JsonDataProvider
    {
        public static IEnumerable<TestCaseData> GetLoginTestData(string testType)
        {
            // Path for the login test data.
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "Login", "loginTestData.json");

            // Call JsonDataReader util.
            var data = JsonDataReader.ReadJson<LoginTestRoot>(path);

            // Filter test case.
            var filteredTestCase = data.testCases
                .Where(tc => tc.testType.Equals(testType, StringComparison.OrdinalIgnoreCase))
                .ToList();

            foreach (var testCase in filteredTestCase)
            {
                // return a single test case.
                yield return new TestCaseData(testCase).SetName($"{testCase.testCaseId} - {testCase.testCaseDescription}"); ;
            }

        }

        // Method for calling positive login test cases.
        public static IEnumerable<TestCaseData> LoginPositiveCases => GetLoginTestData("positive");

        // Method for calling positive negative test cases.
        public static IEnumerable<TestCaseData> LoginNegativeCases => GetLoginTestData("negative");
    }
}
