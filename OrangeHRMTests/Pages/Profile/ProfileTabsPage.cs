using OpenQA.Selenium;
using OrangeHRMTests.Constants;

namespace OrangeHRMTests.Pages.Profile
{
    internal class ProfileTabsPage : BasePage
    {
        // Dictionary for all elements.
        private readonly Dictionary<string, By> _elements;

        public ProfileTabsPage(IWebDriver driver) : base(driver)
        {
            _elements = new Dictionary<string, By>
            {
                { ProfileTabs.PersonalDetails, PersonalDetailsTab },
                { ProfileTabs.ContactDetails, ContactDetailsTab },
                { ProfileTabs.EmergencyContacts, EmergencyContactsTab }
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
