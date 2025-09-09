using OpenQA.Selenium;
using OrangeHRMTests.Pages.Menu;

namespace OrangeHRMTests.Pages.Profile
{
    internal class ProfilePDPage : BasePage
    {
        public NavigationMenuPage _menu { get; }

        // Dictionary
        private readonly Dictionary<string, By> _elements;

        public ProfilePDPage(IWebDriver driver) : base(driver)
        {
            _menu = new NavigationMenuPage(driver);

            _elements = new Dictionary<string, By>
            {
                {"FirstName", FldFirstName},
                {"MiddleName", FldMiddleName},
                {"LastName", FldLastName},
                {"EmployeeId", FldEmployeeId},
                {"OtherId", FldOtherId},
                {"DriverLicenseNumber", FldDriversNumber},
                {"LicenseExpiry", DateLED},
                {"Nationality", DrpdwnNationality},
                {"MaritalStatus", DrpdwnMarital},
                {"DateOfBirth", DateDOB},
                {"MaleRadio", RadioMale},
                {"FemaleRadio", RadioFemale},
                {"SaveButton", BtnSave},
            };
        }

        private By FldFirstName = By.Name("firstName");
        private By FldMiddleName = By.Name("middleName");
        private By FldLastName = By.Name("lastName");
        private By FldEmployeeId = By.XPath("//label[text()='Employee Id']/following::input[1]");
        private By FldOtherId = By.XPath("//label[text()='Other Id']/following::input[1]");
        private By FldDriversNumber = By.XPath("//label[text()='Driver's License Number']/following::input[1]");
        private By DateLED = By.XPath("//label[text()='License Expiry Date']/following::input[1]");
        private By DrpdwnNationality = By.XPath("//label[text()='Nationality']/following::input[1]");
        private By DrpdwnMarital = By.XPath("//label[text()='Marital Status']/following::input[1]");
        private By DateDOB = By.XPath("//label[text()='Date of Birth']/following::input[1]");
        private By RadioMale = By.XPath("//label[normalize-space()='Male']");
        private By RadioFemale = By.XPath("//label[normalize-space()='Female']");
        private By BtnSave = By.XPath("//button[text()='Save']");

        // Checking if element is displayed
        public bool IsDisplayed(string fieldName)
        {
            if (!_elements.ContainsKey(fieldName))
                throw new ArgumentException($"Field '{fieldName}' not found in dictionary.");

            return IsElementDisplayed(_elements[fieldName]);
        }

        // Enter text in input fields.
        public void InputText(string fieldName, string value) => EnterText(_elements[fieldName], value);

        // Select from dropdown.
        public void SelectDropdownByText(string fieldName, string option) => SelectByText(_elements[fieldName], option);

        // Click elements.
        public void ClickElement(string fieldName) => Click(_elements[fieldName]);
    }
}
