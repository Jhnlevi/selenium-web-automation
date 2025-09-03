using System.Text.Json;

namespace TestUtilities
{
    public static class TestDataReader
    {
        public static T ReadJson<T>(string filePath)
        {
            var data = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<T>(data)!;
        }
    }
}
