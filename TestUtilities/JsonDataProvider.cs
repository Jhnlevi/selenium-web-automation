using NUnit.Framework;

namespace TestUtilities
{
    public static class JsonDataProvider
    {
        public static IEnumerable<TestCaseData> GetLoginTestData(string fileName)
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", fileName);
            var data = JsonDataReader.ReadJson<List<>>(path);

            foreach (var item in data)
            {
                yield return item;
            }
        }
    }
}
