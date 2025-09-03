using SauceDemoTests.Models.Checkout;
using SauceDemoTests.Pages.Cart;
using SauceDemoTests.Pages.Checkout;
using SauceDemoTests.Utils;
using TestUtilities;

namespace SauceDemoTests.Tests.UI.Checkout
{
    public class CheckoutStepOneTests : BaseTest
    {
        // Fields.
        private CartPage _cart;
        private CheckoutStepOnePage _stepOne;

        [SetUp]
        public override void SetUp()
        {
            // Setup basetest methods first.
            base.SetUp();

            // Initialize CartPage and CheckoutStepOnePage.
            _cart = new CartPage(_driver);
            _stepOne = new CheckoutStepOnePage(_driver);

            // Navigate to SauceDemo Website.
            ReportManager.LogInfo("Navigating to SauceDemo website.");
            _driver.Navigate().GoToUrl(_config.BaseUrl);

            // Log in to the website.
            ReportManager.LogInfo("Log in as standard user.");
            PreconditionFlow.LoginAsStandardUser(_driver, "standard_user", "secret_sauce");

            // Adding item to cart.
            ReportManager.LogInfo("Clicking 'Add to Cart' button to add product.");
            PreconditionFlow.AddProductToCart(_driver);

            // Navigating to cart page.
            ReportManager.LogInfo("Clicking shopping cart icon in the menu bar.");
            PreconditionFlow.NavigateToCart(_driver);
        }

        // TC_Checkout_0001
        [Test]
        public void Checkout_StepOne_NavigateToCheckout()
        {
            ReportManager.LogInfo("Clicking 'Checkout' button.");
            _cart.ClickCheckoutCartItem();
            Assert.That(_driver.Url.Contains("checkout-step-one"), Is.True);
        }

        // TC_Checkout_0002
        [Test]
        public void Checkout_StepOne_VerifyCancelIsDisplayed()
        {
            Checkout_StepOne_NavigateToCheckout();
            ReportManager.LogInfo("Verifying that the user can see the cancel button.");
            _stepOne.ShouldDisplayCancelButton();
        }

        // TC_Checkout_0003
        [Test]
        public void Checkout_StepOne_VerifyContinueIsDisplayed()
        {
            Checkout_StepOne_NavigateToCheckout();
            ReportManager.LogInfo("Verifying that the user can see the 'continue' button.");
            _stepOne.ShouldDisplayContinueButton();
        }

        // TC_Checkout_0004
        [Test]
        public void Checkout_StepOne_VerifyFieldsAreDisplayed()
        {
            Checkout_StepOne_NavigateToCheckout();
            ReportManager.LogInfo("Verify that user can see 'First Name' field.");
            _stepOne.ShouldDisplayFirstName();
            ReportManager.LogInfo("Verify that user can see 'Last Name' field.");
            _stepOne.ShouldDisplayLastName();
            ReportManager.LogInfo("Verify that user can see 'Postal Code' field.");
            _stepOne.ShouldDisplayPostalCode();
        }

        // TC_Checkout_0005
        [Test]
        [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.CheckoutPositiveCases))]
        public void Checkout_StepOne_ValidUserInputs(CheckoutTestCase testCase)
        {
            Checkout_StepOne_NavigateToCheckout();
            ReportManager.LogInfo("Entering user first name.");
            _stepOne.ChkoutEnterFirstName(testCase.testData.firstName);
            ReportManager.LogInfo("Entering user last name.");
            _stepOne.ChkoutEnterLastName(testCase.testData.lastName);
            ReportManager.LogInfo("Entering user postal code.");
            _stepOne.ChkoutPostalCode(testCase.testData.postalCode);
            ReportManager.LogInfo("Clicking 'continue' button.");
            _stepOne.ClickContinueButton();
            Assert.That(_driver.Url.Contains("checkout-step-two"), Is.True);
        }

        // TC_Checkout_0006; TC_Checkout_0007; TC_Checkout_0008; TC_Checkout_0009; TC_Checkout_0010; TC_Checkout_0011
        [Test]
        [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.CheckoutNegativeCases))]
        public void Checkout_StepOne_InvalidUserInputs(CheckoutTestCase testCase)
        {
            Checkout_StepOne_NavigateToCheckout();
            ReportManager.LogInfo("Entering user first name.");
            _stepOne.ChkoutEnterFirstName(testCase.testData.firstName);
            ReportManager.LogInfo("Entering user last name.");
            _stepOne.ChkoutEnterLastName(testCase.testData.lastName);
            ReportManager.LogInfo("Entering user postal code.");
            _stepOne.ChkoutPostalCode(testCase.testData.postalCode);
            ReportManager.LogInfo("Clicking 'continue' button.");
            _stepOne.ClickContinueButton();
            Assert.That(_stepOne.IsErrorMessageDisplayed(), Is.True);
        }
    }
}
