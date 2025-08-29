using Microsoft.CodeAnalysis;

namespace SauceDemoTests.Utils
{
    public static class JsonDataProvider
    {
        public static IEnumerable<TestCaseData> GetLoginTestData(string testType, string model)
        {
            // Path for the login test data.
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "Login", "loginTestData.json");

            // Call JsonDataReader util.
            var data = JsonDataReader.ReadJson<List<ModelExtensions>>(path);
        }
    }
}
