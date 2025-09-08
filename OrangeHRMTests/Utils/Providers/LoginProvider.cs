using OrangeHRMTests.Models.Login;
using TestUtilities;

namespace OrangeHRMTests.Utils.Providers
{
    internal class LoginProvider
    {
        // Always return the case level.
        private const string folderName = "TestData";
        private const string moduleName = "Login";
        private const string validFile = "login_valid.json";
        private const string invalidFile = "login_invalid.json";
        private const string missingFile = "login_missing.json";

        public static LoginCase GetRecordById(string id, string fileName)
        {
            var data = TestDataLoader.Load<LoginModel>(folderName, moduleName, fileName);
            var record = data?.TestCases?.FirstOrDefault(tc => tc.TestCaseId == id);
            return record!;
        }

        public static IEnumerable<LoginCase> GetRecords(string fileName)
        {
            var data = TestDataLoader.Load<LoginModel>(folderName, moduleName, fileName);
            return data?.TestCases ?? Enumerable.Empty<LoginCase>();
        }

        // Get single record
        public static LoginCase GetValidCaseRecord(string id) => GetRecordById(id, validFile);
        public static LoginCase GetInvalidCaseRecord(string id) => GetRecordById(id, invalidFile);
        public static LoginCase GetMissingCaseRecord(string id) => GetRecordById(id, missingFile);

        // Get multiple records
        public static IEnumerable<LoginCase> GetValidCaseRecords() => GetRecords(validFile);
        public static IEnumerable<LoginCase> GetInvalidCaseRecords() => GetRecords(invalidFile);
        public static IEnumerable<LoginCase> GetMissingCaseRecords() => GetRecords(missingFile);
    }
}
