using System.Text.Json.Serialization;

namespace OrangeHRMTests.Models.Profile
{
    internal class ProfilePDModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("description")]
        public string Description { get; set; } = null!;

        [JsonPropertyName("testCases")]
        public List<PDCase>? PDCases { get; set; }
    }
    internal class PDCase
    {
        [JsonPropertyName("testCaseId")]
        public string TestCaseId { get; set; } = null!;

        [JsonPropertyName("testCaseDescription")]
        public string TestCaseDescription { get; set; } = null!;

        [JsonPropertyName("testType")]
        public string TestType { get; set; } = null!;

        [JsonPropertyName("testData")]
        public PDData? PDData { get; set; }

        [JsonPropertyName("expectedResult")]
        public ExpectedResult? ExpectedResult { get; set; }

        // Custom name for each test case.
        public override string ToString()
        {
            return $"{TestCaseId} : {TestCaseDescription}";
        }
    }
    internal class PDData
    {
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; } = null!;

        [JsonPropertyName("middleName")]
        public string MiddleName { get; set; } = null!;

        [JsonPropertyName("lastName")]
        public string LastName { get; set; } = null!;

        [JsonPropertyName("employeeId")]
        public string EmployeeId { get; set; } = null!;

        [JsonPropertyName("otherId")]
        public string OtherId { get; set; } = null!;

        [JsonPropertyName("driverLicense")]
        public string DriverLicense { get; set; } = null!;

        [JsonPropertyName("nationality")]
        public string Nationality { get; set; } = null!;

        [JsonPropertyName("maritalStatus")]
        public string MaritalStatus { get; set; } = null!;

        [JsonPropertyName("licenseExpiry")]
        public string LicenseExpiry { get; set; } = null!;

        [JsonPropertyName("dateOfBirth")]
        public string DateOfBirth { get; set; } = null!;

        [JsonPropertyName("gender")]
        public string Gender { get; set; } = null!;
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
