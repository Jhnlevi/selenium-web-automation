using System.Text.Json.Serialization;

namespace OrangeHRMTests.Models.Login
{
    internal class LoginTestModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;
        [JsonPropertyName("description")]
        public string Description { get; set; } = null!;
        [JsonPropertyName("testCases")]
        public List<TestCase>? TestCases { get; set; }
    }
    internal class TestCase
    {
        [JsonPropertyName("testCaseId")]
        public string TestCaseId { get; set; } = null!;
        [JsonPropertyName("testCaseDescription")]
        public string TestCaseDescription { get; set; } = null!;
        [JsonPropertyName("testType")]
        public string TestType { get; set; } = null!;
        [JsonPropertyName("TestData")]
        public TestData? testData { get; set; }
        [JsonPropertyName("expectedResult")]
        public ExpectedResult? ExpectedResult { get; set; }
    }
    internal class TestData
    {
        [JsonPropertyName("userName")]
        public string UserName { get; set; } = null!;
        [JsonPropertyName("password")]
        public string Password { get; set; } = null!;
    }
    internal class ExpectedResult
    {
        [JsonPropertyName("result")]
        public string Result { get; set; } = null!;
        [JsonPropertyName("message")]
        public string Message { get; set; } = null!;
    }
}
