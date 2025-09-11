using OpenQA.Selenium;
using OrangeHRMTests.Constants;
using OrangeHRMTests.Pages.Menu;

namespace OrangeHRMTests.Pages.Profile
{
    internal class Profile_Page : BasePage
    {
        public Menu_Page _menu { get; }

        // Dictionary for all elements.
        private readonly Dictionary<string, By> _elements;

        public Profile_Page(IWebDriver driver) : base(driver)
        {
            _menu = new Menu_Page(driver);

            _elements = new Dictionary<string, By>
            {
                { Fields_Profile.PersonalDetails, PersonalDetailsTab },
                { Fields_Profile.ContactDetails, ContactDetailsTab },
                { Fields_Profile.EmergencyContacts, EmergencyContactsTab }
            };
        }

        private By PersonalDetailsTab = By.LinkText("Personal Details");
        private By ContactDetailsTab = By.LinkText("Contact Details");
        private By EmergencyContactsTab = By.LinkText("Emergency Contacts");

        // Checking if element is displayed.
        public bool IsDisplayed(string fieldName)
        {
            if (!_elements.ContainsKey(fieldName))
                throw new ArgumentException($"Field '{fieldName}' not found in dictionary.");

            return IsElementDisplayed(_elements[fieldName]);
        }

        // Clicking an element.
        public void ClickElement(string fieldName) => Click(_elements[fieldName]);
    }
}
