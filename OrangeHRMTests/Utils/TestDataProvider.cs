using OrangeHRMTests.Models.Login;
using TestUtilities;

namespace OrangeHRMTests.Utils
{
    internal class TestDataProvider
    {
        // Get single login data.
        public static TestCaseData GetSingleLoginRecord(string testId)
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "Login", "loginTestData.json");
            var data = TestDataReader.ReadJson<LoginTestModel>(path);
            var testCase = data?.TestCases?.FirstOrDefault(tc => tc.TestCaseId == testId);

            return new TestCaseData(testCase);
        }

        // Get multiple login data.
        public static IEnumerable<TestCaseData> GetMultipleLoginRecord(string type)
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "Login", "loginTestData.json");
            var data = TestDataReader.ReadJson<LoginTestModel>(path);

            var filteredTestCase = data?.TestCases?
                .Where(tc => tc.TestType.Equals(type, StringComparison.OrdinalIgnoreCase))
                .ToList();

            foreach (var testCase in filteredTestCase)
            {
                yield return new TestCaseData(testCase);
            }
        }

        // For negative tests of login.
        public static IEnumerable<TestCaseData> LoginNegativeCases => GetMultipleLoginRecord("negative");
    }
}
