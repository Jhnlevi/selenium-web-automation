using System.Text.Json;

namespace TestUtilities
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
