namespace OrangeHRMTests.Models.Profile
{
    internal class Field_PD_Model
    {
        public string Locator { get; set; } = null!;
        public string Value { get; set; } = null!;
        public FieldType Type { get; set; }
    }

    internal enum FieldType
    {
        Text,
        Dropdown,
        Date,
        Radio,
        Button
    }
}
