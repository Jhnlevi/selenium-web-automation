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

            ReportManager.LogInfo("Logging in to OrangeHRM demo website as Admin.");
            TestFlow.Login_Admin(_driver!, _config.BaseUrl);
            ReportManager.LogInfo("Navigating to 'My Info' page.");
            TestFlow.Navigate_MyInfoPage(_driver!);
            ReportManager.LogInfo("Navigating to 'Personal Details' tab.");
            TestFlow.Navigate_MyInfo_PersonalDetailsTab(_driver!);
        }

        [Test]
        public void Profile_PersonalDetailsFields_ShouldBeInteractable()
        {
            var fields = new[] { "FirstName", "MiddleName", "LastName", "EmployeeId", "OtherId", "DriverLicenseNumber" };

            ReportManager.LogInfo("Navigating to MyInfo > 'Personal Details' tab.");
            TestFlow.Navigate_MyInfo_PersonalDetailsTab(_driver!);
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
            TestFlow.Navigate_MyInfo_PersonalDetailsTab(_driver!);
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
            TestFlow.Navigate_MyInfo_PersonalDetailsTab(_driver!);
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
            TestFlow.Navigate_MyInfo_PersonalDetailsTab(_driver!);
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
            TestFlow.Navigate_MyInfo_PersonalDetailsTab(_driver!);
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
