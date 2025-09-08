using NUnit.Framework;

namespace TestUtilities
{
    public static class TestDataLoader
    {
        public static T Load<T>(string folderName, string moduleName, string fileName)
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, folderName, moduleName, fileName);
            var data = TestDataReader.ReadJson<T>(path);

            return data;
        }
    }
}
