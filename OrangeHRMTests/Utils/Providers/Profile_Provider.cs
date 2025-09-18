using OrangeHRMTests.Models.Profile;
using SeleniumToolkit.Data;

namespace OrangeHRMTests.Utils.Providers
{
    internal class Profile_Provider
    {
        // Always return the case level.
        private const string moduleName = "Profile";
        private const string PDValid = "profile_pd_valid.json";
        private const string PDInvalid = "profile_pd_invalid.json";
        private const string PDMissing = "profile_pd_missing.json";


        // PD model:
        public static PDCase GetRecordById(string id, string fileName)
        {
            var data = JsonLoader.LoadJson<Profile_PD_Model>(moduleName, fileName);
            var record = data?.PDCases?.FirstOrDefault(tc => tc.TestCaseId == id);
            return record!;
        }

        public static IEnumerable<PDCase> GetRecords(string fileName)
        {
            var data = JsonLoader.LoadJson<Profile_PD_Model>(moduleName, fileName);
            return data?.PDCases ?? Enumerable.Empty<PDCase>();
        }

        // Get single record
        public static PDCase GetValidPDCaseRecord(string id) => GetRecordById(id, PDValid);
        public static PDCase GetInvalidPDCaseRecord(string id) => GetRecordById(id, PDInvalid);
        public static PDCase GetMissingPDCaseRecord(string id) => GetRecordById(id, PDMissing);

        // Get multiple records
        public static IEnumerable<PDCase> GetValidPDCaseRecords() => GetRecords(PDValid);
        public static IEnumerable<PDCase> GetInvalidPDCaseRecords() => GetRecords(PDInvalid);
        public static IEnumerable<PDCase> GetMissingPDCaseRecords() => GetRecords(PDMissing);
    }
}
