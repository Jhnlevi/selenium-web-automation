using OpenQA.Selenium;
using OrangeHRMTests.Constants;
using OrangeHRMTests.Pages.Menu;

namespace OrangeHRMTests.Pages.Profile
{
    internal class ProfilePage : BasePage
    {
        public NavigationMenuPage _menu { get; }

        // Dictionary for all elements.
        private readonly Dictionary<string, By> _elements;

        public ProfilePage(IWebDriver driver) : base(driver)
        {
            _menu = new NavigationMenuPage(driver);

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
