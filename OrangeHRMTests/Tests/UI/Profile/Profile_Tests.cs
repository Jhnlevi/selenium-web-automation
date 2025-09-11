using OrangeHRMTests.Constants;
using OrangeHRMTests.Pages.Profile;
using OrangeHRMTests.Utils;
using TestUtilities;

namespace OrangeHRMTests.Tests.UI.Profile
{
    internal class Profile_Tests : BaseTest
    {
        private ProfilePDPage _profilePD;
        private ProfilePage _profile;

        [SetUp]
        public override void Setup()
        {
            base.Setup();
            _profilePD = new ProfilePDPage(_driver!);
            _profile = new ProfilePage(_driver!);

            ReportManager.LogInfo("Logging in to OrangeHRM website, and navigating to 'My Info' Page.");
            TestFlow.Login_MyInfo_Flow(_driver!, _config.BaseUrl);
        }

        [Test]
        public void Profile_PersonalDetails_IsAccessible()
        {
            ReportManager.LogInfo("Navigating to 'Personal Details' tab.");
            _profile.ClickElement(Fields_Profile.PersonalDetails);
            ReportManager.LogInfo("Verify that 'Personal Details' tab loads successfully.");
            Assert.That(_profile.IsDisplayed(Fields_Profile.PersonalDetails), Is.True, "'Personal Details' tab does not load.");
        }

        [Test]
        public void Profile_ContactDetails_IsAccessible()
        {
            ReportManager.LogInfo("Navigating to 'Contact Details' tab.");
            _profile.ClickElement(Fields_Profile.ContactDetails);
            ReportManager.LogInfo("Verify that 'Contact Details' tab loads successfully.");
            Assert.That(_profile.IsDisplayed(Fields_Profile.PersonalDetails), Is.True, "'Contact Details' tab does not load.");
        }

        [Test]
        public void Profile_EmergencyContacts_IsAccessible()
        {
            ReportManager.LogInfo("Navigating to 'Contact Details' tab.");
            _profile.ClickElement(Fields_Profile.EmergencyContacts);
            ReportManager.LogInfo("Verify that 'Contact Details' tab loads successfully.");
            Assert.That(_profile.IsDisplayed(Fields_Profile.EmergencyContacts), Is.True, "'Emergency Contacts' tab does not load.");
        }
    }
}
