using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OrangeHRMTests.Constants;
using OrangeHRMTests.Pages.Menu;

namespace OrangeHRMTests.Pages.Profile
{
    internal class Profile_PD_Page : BasePage
    {
        // Dictionary for all elements.
        private readonly Dictionary<string, By> _elements;
        private readonly WebDriverWait _wait;
        public Menu_Page _menu { get; }
        public Profile_Page _profileTab { get; }


        public Profile_PD_Page(IWebDriver driver) : base(driver)
        {
            _menu = new Menu_Page(driver);
            _profileTab = new Profile_Page(driver);
            _wait = new WebDriverWait(_driver!, TimeSpan.FromSeconds(15));

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

        private By PageFormLoader = By.CssSelector(".oxd-form-loader");
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
        public void PD_EnterText(string fieldName, string value) => EnterText(_elements[fieldName], value);

        // Enter text in date fields.
        public void PD_EnterDate(string fieldName, string value) => EnterDate(_elements[fieldName], value);

        // Select from dropdown.
        public void PD_SelectDropdownByText(string fieldName, string option) => SelectByText(_elements[fieldName], option);

        // Click elements.
        public void PD_Click(string fieldName) => Click(_elements[fieldName]);

        // Get current input text
        public string PD_WaitForFieldvalue(string fieldName)
        {
            return _wait.Until(d =>
            {
                var text = GetFieldValue(_elements[fieldName]);
                return !string.IsNullOrEmpty(text) ? text : null;
            });
        }

        // To handle form wait
        public void PD_WaitForFormLoaderDisappear()
        {
            _wait.Until(d =>
            {
                try
                {
                    var loader = _driver!.FindElement(PageFormLoader);
                    return !loader.Displayed;
                }
                catch (NoSuchElementException) { return true; }
                catch (StaleElementReferenceException) { return true; }
            });
        }
    }
}
