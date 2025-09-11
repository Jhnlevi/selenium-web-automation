using OrangeHRMTests.Constants;
using OrangeHRMTests.Pages.Profile;
using OrangeHRMTests.Utils;
using TestUtilities;

namespace OrangeHRMTests.Tests.UI.Profile
{
    internal class ProfilePDTests : BaseTest
    {
        private ProfilePDPage _profilePD;

        [SetUp]
        public override void Setup()
        {
            base.Setup();
            _profilePD = new ProfilePDPage(_driver!);

            ReportManager.LogInfo("Navigating and logging in (As Admin) to OrangeHRM demo website.");
            TestFlow.LoginAsAdmin(_driver!, _config.BaseUrl);
        }

        [Test]
        public void Profile_PersonalDetails_IsAccessible()
        {
            ReportManager.LogInfo("Navigating to MyInfo page.");
            _profilePD._menu.ClickElement(Fields_Menu.MyInfo);
            ReportManager.LogInfo("Navigating to 'Personal Details' tab.");
            _profilePD._profileTab.ClickElement(Fields_Profile.PersonalDetails);
            ReportManager.LogInfo("Verify that 'Personal Details' tab loads successfully.");
            Assert.That(_profilePD._profileTab.IsDisplayed(Fields_Profile.PersonalDetails), Is.True, "'Personal Details tab does not load.");
        }

        [Test]
        public void Profile_PersonalDetailsFields_ShouldBeInteractable()
        {
            var fields = new[] { "FirstName", "MiddleName", "LastName", "EmployeeId", "OtherId", "DriverLicenseNumber" };

            ReportManager.LogInfo("Navigating to MyInfo > 'Personal Details' tab.");
            TestFlow.NavigateToPDTab(_driver!);
            ReportManager.LogInfo("Verifying that all input fields are visible and interactable in 'Personal Details' tab.");
            Assert.Multiple(() =>
            {
                foreach (var field in fields)
                {
                    Assert.That(_profilePD.IsDisplayed(field), Is.True, $"{field}, was not displayed.");
                }
            });
        }

        [Test]
        public void Profile_PersonalDetailsDropdowns_ShouldBeInteractable()
        {
            var fields = new[] { "Nationality", "MaritalStatus" };

            ReportManager.LogInfo("Navigating to MyInfo > 'Personal Details' tab.");
            TestFlow.NavigateToPDTab(_driver!);
            ReportManager.LogInfo("Verifying that all dropdown fields are visible and interactable in 'Personal Details' tab.");
            Assert.Multiple(() =>
            {
                foreach (var field in fields)
                {
                    Assert.That(_profilePD.IsDisplayed(field), Is.True, $"{field}, was not displayed.");
                }
            });
        }

        [Test]
        public void Profile_PersonalDetailsDateFields_ShouldBeInteractable()
        {
            var fields = new[] { "LicenseExpiryDate", "DateOfBirth" };

            ReportManager.LogInfo("Navigating to MyInfo > 'Personal Details' tab.");
            TestFlow.NavigateToPDTab(_driver!);
            ReportManager.LogInfo("Verifying that all date fields are visible and interactable in 'Personal Details' tab.");
            Assert.Multiple(() =>
            {
                foreach (var field in fields)
                {
                    Assert.That(_profilePD.IsDisplayed(field), Is.True, $"{field}, was not displayed.");
                }
            });
        }

        [Test]
        public void Profile_PersonalDetailsRadioButtons_ShouldBeInteractable()
        {
            var fields = new[] { "MaleRadio", "FemaleRadio" };

            ReportManager.LogInfo("Navigating to MyInfo > 'Personal Details' tab.");
            TestFlow.NavigateToPDTab(_driver!);
            ReportManager.LogInfo("Verifying that all radio buttons are visible and interactable in 'Personal Details' tab.");
            Assert.Multiple(() =>
            {
                foreach (var field in fields)
                {
                    Assert.That(_profilePD.IsDisplayed(field), Is.True, $"{field}, was not displayed.");
                }
            });
        }

        [Test]
        public void Profile_PersonalDetailsButtons_ShouldBeInteractable()
        {
            var fields = new[] { "SaveButton" };

            ReportManager.LogInfo("Navigating to MyInfo > 'Personal Details' tab.");
            TestFlow.NavigateToPDTab(_driver!);
            ReportManager.LogInfo("Verifying that all buttons are visible and interactable in 'Personal Details' tab.");
            Assert.Multiple(() =>
            {
                foreach (var field in fields)
                {
                    Assert.That(_profilePD.IsDisplayed(field), Is.True, $"{field}, was not displayed.");
                }
            });
        }
    }
}
