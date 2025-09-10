using OrangeHRMTests.Constants;
using OrangeHRMTests.Pages.Profile;
using OrangeHRMTests.Utils;
using TestUtilities;

namespace OrangeHRMTests.Tests.UI.Profile
{
    internal class ProfilePersonalDetailsTests : BaseTest
    {
        private ProfilePDPage _profilePD;

        [SetUp]
        public override void Setup()
        {
            base.Setup();
            _profilePD = new ProfilePDPage(_driver!);

            ReportManager.LogInfo("Navigating and logging in to OrangeHRM demo website.");
            TestFlow.LoginAsAdmin(_driver!, _config.BaseUrl);
        }

        [Test]
        public void Profile_VerifyPersonalDetailsIsAccessible()
        {
            ReportManager.LogInfo("Navigating to MyInfo page.");
            _profilePD._menu.ClickElement(Fields_Menu.MyInfo);
            ReportManager.LogInfo("Navigating to 'Personal Details' tab.");
            _profilePD._profileTab.ClickElement(Fields_Profile.PersonalDetails);
            ReportManager.LogInfo("Verify that 'Personal Details' tab loads successfully.");
            Assert.That(_profilePD._profileTab.IsDisplayed(Fields_Profile.PersonalDetails), Is.True);
        }
    }
}
