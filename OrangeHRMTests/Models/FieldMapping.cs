using OrangeHRMTests.Enums;

namespace OrangeHRMTests.Models
{
    internal class FieldMapping
    {
        public string Locator { get; set; } = null!;
        public string Value { get; set; } = null!;
        public FieldType? Type { get; set; }
    }
}
