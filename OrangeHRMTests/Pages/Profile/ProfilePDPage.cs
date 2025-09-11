using OpenQA.Selenium;
using OrangeHRMTests.Constants;
using OrangeHRMTests.Pages.Menu;

namespace OrangeHRMTests.Pages.Profile
{
    internal class ProfilePDPage : BasePage
    {
        public NavigationMenuPage _menu { get; }
        public ProfilePage _profileTab { get; }

        // Dictionary for all elements.
        private readonly Dictionary<string, By> _elements;

        public ProfilePDPage(IWebDriver driver) : base(driver)
        {
            _menu = new NavigationMenuPage(driver);
            _profileTab = new ProfilePage(driver);

            _elements = new Dictionary<string, By>
            {
                {Fields_Profile_PD.FirstName, FldFirstName},
                {Fields_Profile_PD.MiddleName, FldMiddleName},
                {Fields_Profile_PD.LastName, FldLastName},
                {Fields_Profile_PD.EmployeeId, FldEmployeeId},
                {Fields_Profile_PD.OtherId, FldOtherId},
                {Fields_Profile_PD.DriverLicenseNumber, FldDriversNumber},
                {Fields_Profile_PD.LicenseExpiryDate, DateLED},
                {Fields_Profile_PD.Nationality, DrpdwnNationality},
                {Fields_Profile_PD.MaritalStatus, DrpdwnMarital},
                {Fields_Profile_PD.DateOfBirth, DateDOB},
                {Fields_Profile_PD.MaleRadio, RadioMale},
                {Fields_Profile_PD.FemaleRadio, RadioFemale},
                {Fields_Profile_PD.SaveButton, BtnSave},
            };
        }

        private By FldFirstName = By.Name("firstName");
        private By FldMiddleName = By.Name("middleName");
        private By FldLastName = By.Name("lastName");
        private By FldEmployeeId = By.XPath("//label[text()='Employee Id']/following::input[1]");
        private By FldOtherId = By.XPath("//label[text()='Other Id']/following::input[1]");
        private By FldDriversNumber = By.XPath("//label[text()=\"Driver's License Number\"]/following::input[1]");
        private By DateLED = By.XPath("//label[text()='License Expiry Date']/following::input[1]");
        private By DrpdwnNationality = By.XPath("//label[text()='Nationality']/following::input[1]");
        private By DrpdwnMarital = By.XPath("//label[text()='Marital Status']/following::input[1]");
        private By DateDOB = By.XPath("//label[text()='Date of Birth']/following::input[1]");
        private By RadioMale = By.XPath("//label[normalize-space()='Male']");
        private By RadioFemale = By.XPath("//label[normalize-space()='Female']");
        private By BtnSave = By.XPath("//button[normalize-space()='Save']");

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
