using OrangeHRMTests.Models.Login;
using TestUtilities;

namespace OrangeHRMTests.Utils
{
    internal class TestDataProvider
    {
        // Get single login data.
        public static LoginTestCase GetSingleLoginRecord(string testId, string fileName)
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "Login", fileName);
            var data = TestDataReader.ReadJson<LoginTestModel>(path);
            var testCase = data?.TestCases?.FirstOrDefault(tc => tc.TestCaseId == testId);

            return testCase;
        }

        // Get multiple login data.
        public static IEnumerable<LoginTestCase> GetMultipleLoginRecord(string type, string fileName)
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "Login", fileName);
            var data = TestDataReader.ReadJson<LoginTestModel>(path);

            var filteredTestCase = data?.TestCases?
                .Where(tc => tc.TestType.Equals(type, StringComparison.OrdinalIgnoreCase))
                .ToList();

            foreach (var testCase in filteredTestCase)
            {
                yield return testCase;
            }
        }

        // For negative tests of login.
        public static IEnumerable<LoginTestCase> GetNegativeFunctional => GetMultipleLoginRecord("negative", "loginFunctional.json");
        public static IEnumerable<LoginTestCase> GetNegativeValidation => GetMultipleLoginRecord("negative", "loginValidation.json");
    }
}
