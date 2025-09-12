using OrangeHRMTests.Constants;
using OrangeHRMTests.Enums;
using OrangeHRMTests.Models;
using OrangeHRMTests.Models.Profile;
using OrangeHRMTests.Pages.Profile;
using OrangeHRMTests.Utils;
using OrangeHRMTests.Utils.Providers;
using TestUtilities;

namespace OrangeHRMTests.Tests.UI.Profile
{
    internal class Profile_PD_Tests : BaseTest
    {
        private Profile_PD_Page _profilePD;

        [SetUp]
        public override void Setup()
        {
            base.Setup();
            _profilePD = new Profile_PD_Page(_driver!);

            ReportManager.LogInfo("Logging in to OrangeHRM demo website as Admin.");
            TestFlow.Login_Admin(_driver!, _config.BaseUrl);
            ReportManager.LogInfo("Navigating to 'My Info' page.");
            TestFlow.Navigate_MyInfoPage(_driver!);
            ReportManager.LogInfo("Navigating to 'Personal Details' tab.");
            TestFlow.Navigate_MyInfo_PersonalDetailsTab(_driver!);
            // To wait for form loader to disappear.
            _profilePD.PD_WaitForFormLoaderDisappear();
        }

        [Test]
        public void Profile_PersonalDetailsFields_ShouldBeInteractable()
        {
            var fields = new[] { "FirstName", "MiddleName", "LastName", "EmployeeId", "OtherId", "DriverLicenseNumber" };

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

            ReportManager.LogInfo("Verifying that all buttons are visible and interactable in 'Personal Details' tab.");
            Assert.Multiple(() =>
            {
                foreach (var field in fields)
                {
                    Assert.That(_profilePD.IsDisplayed(field), Is.True, $"{field}, was not displayed.");
                }
            });
        }

        [TestCaseSource(typeof(Profile_Provider), nameof(Profile_Provider.GetValidPDCaseRecords))]
        public void Profile_PersonalDetails_WithValidData(PDCase testCase)
        {
            var mappings = new List<FieldMapping>
            {
                new FieldMapping { Locator = Fields_Profile_PD.FirstName, Value = testCase.PDData!.FirstName, Type = FieldType.Text  },
                new FieldMapping { Locator = Fields_Profile_PD.MiddleName, Value = testCase.PDData!.MiddleName, Type = FieldType.Text  },
                new FieldMapping { Locator = Fields_Profile_PD.LastName, Value = testCase.PDData!.LastName, Type = FieldType.Text  },
                new FieldMapping { Locator = Fields_Profile_PD.EmployeeId, Value = testCase.PDData!.EmployeeId, Type = FieldType.Text  },
                new FieldMapping { Locator = Fields_Profile_PD.OtherId, Value = testCase.PDData!.OtherId, Type = FieldType.Text  },
                new FieldMapping { Locator = Fields_Profile_PD.DriverLicenseNumber, Value = testCase.PDData!.DriverLicense, Type = FieldType.Text  },
                new FieldMapping { Locator = Fields_Profile_PD.LicenseExpiryDate, Value = testCase.PDData!.LicenseExpiry, Type = FieldType.Date  },
                new FieldMapping { Locator = Fields_Profile_PD.Nationality, Value = testCase.PDData!.Nationality, Type = FieldType.Text  },
                new FieldMapping { Locator = Fields_Profile_PD.MaritalStatus, Value = testCase.PDData!.MaritalStatus, Type = FieldType.Text  },
                new FieldMapping { Locator = Fields_Profile_PD.DateOfBirth, Value = testCase.PDData!.DateOfBirth, Type = FieldType.Date  },
            };

            foreach (var mapping in mappings)
            {
                ReportManager.LogInfo($"Entering '{mapping.Locator}'.");

                switch (mapping.Type)
                {
                    case FieldType.Text:
                        _profilePD.PD_EnterText(mapping.Locator, mapping.Value!);
                        break;
                    case FieldType.Dropdown:
                        _profilePD.PD_SelectDropdownByText(mapping.Locator, mapping.Value!);
                        break;
                    case FieldType.Date:
                        _profilePD.PD_EnterDate(mapping.Locator, mapping.Value!);
                        break;
                    case FieldType.Radio:
                        break;
                    default:
                        break;
                }
            }

            if (testCase.PDData!.Gender.Equals("Male", StringComparison.OrdinalIgnoreCase) == true)
            {
                ReportManager.LogInfo("Clicking 'Male' button.");
                _profilePD.PD_Click(Fields_Profile_PD.MaleRadio);
            }
            else if (testCase.PDData!.Gender.Equals("Female", StringComparison.OrdinalIgnoreCase) == true)
            {
                ReportManager.LogInfo("Clicking 'Female' button.");
                _profilePD.PD_Click(Fields_Profile_PD.MaleRadio);
            }

            ReportManager.LogInfo("Clicking 'Save' button.");
            _profilePD.PD_Click(Fields_Profile_PD.SaveButton);
            ReportManager.LogInfo("Refreshing the page.");
            _profilePD.RefreshCurrentPage();

            ReportManager.LogInfo("Verify that data entered in 'Personal Details' is saved successfully and persists after refreshing the page.");
            Assert.That(_profilePD.PD_WaitForFieldvalue(Fields_Profile_PD.EmployeeId), Is.EqualTo(testCase.PDData!.EmployeeId));
            Assert.That(_profilePD.PD_WaitForFieldvalue(Fields_Profile_PD.OtherId), Is.EqualTo(testCase.PDData!.OtherId));
            Assert.That(_profilePD.PD_WaitForFieldvalue(Fields_Profile_PD.DriverLicenseNumber), Is.EqualTo(testCase.PDData!.DriverLicense));
        }
    }
}
