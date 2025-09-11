using System.Text.Json.Serialization;

namespace OrangeHRMTests.Models.Login
{
    internal class Login_Model
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("description")]
        public string Description { get; set; } = null!;

        [JsonPropertyName("testCases")]
        public List<LoginCase>? TestCases { get; set; }
    }
    internal class LoginCase
    {
        [JsonPropertyName("testCaseId")]
        public string TestCaseId { get; set; } = null!;

        [JsonPropertyName("testCaseDescription")]
        public string TestCaseDescription { get; set; } = null!;

        [JsonPropertyName("testType")]
        public string TestType { get; set; } = null!;

        [JsonPropertyName("testData")]
        public LoginData? TestData { get; set; }

        [JsonPropertyName("expectedResult")]
        public ExpectedResult? ExpectedResult { get; set; }

        // Custom name for each test case.
        public override string ToString()
        {
            return $"{TestCaseId} : {TestCaseDescription}";
        }
    }
    internal class LoginData
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

        [JsonPropertyName("fieldErrors")]
        public List<FieldError>? FieldErrors { get; set; }
    }

    internal class FieldError
    {
        [JsonPropertyName("field")]
        public string Field { get; set; } = null!;

        [JsonPropertyName("message")]
        public string Message { get; set; } = null!;
    }
}
