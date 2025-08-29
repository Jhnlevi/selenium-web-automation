using System.Text.Json;

namespace SauceDemoTests.Utils
{
    public static class JsonDataReader
    {
        public static T ReadJson<T>(string filePath)
        {
            var data = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<T>(data)!;
        }
    }
}
