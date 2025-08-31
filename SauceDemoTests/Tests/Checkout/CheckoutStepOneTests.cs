using SauceDemoTests.Models.Checkout;
using SauceDemoTests.Pages.Cart;
using SauceDemoTests.Pages.Checkout;
using SauceDemoTests.Pages.Login;
using SauceDemoTests.Pages.MenuBar;
using SauceDemoTests.Pages.Product;
using SauceDemoTests.Utils;

namespace SauceDemoTests.Tests.Checkout
{
    public class CheckoutStepOneTests : BaseTest
    {
        // Fields.
        private LoginPage _login;
        private ProductPage _product;
        private CartPage _cart;
        private MenuBarPage _menu;
        private CheckoutStepOnePage _stepOne;

        [SetUp]
        public override void SetUp()
        {
            // Setup basetest methods first.
            base.SetUp();

            // Initialize LoginPage, ProductPage, CartPage, MenuBarPage, and CheckoutStepOnePage.
            _login = new LoginPage(_driver);
            _product = new ProductPage(_driver);
            _cart = new CartPage(_driver);
            _menu = new MenuBarPage(_driver);
            _stepOne = new CheckoutStepOnePage(_driver);

            // Navigate to SauceDemo Website.
            _test.Info("Navigating to SauceDemo website.");
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/v1/");

            // Log in to the website.
            _test.Info("Log in as standard user.");
            PreconditionFlow.LoginAsStandardUser(_driver, "standard_user", "secret_sauce");

            // Adding item to cart.
            _test.Info("Clicking 'Add to Cart' button to add product.");
            PreconditionFlow.AddProductToCart(_driver);

            // Navigating to cart page.
            _test.Info("Clicking shopping cart icon in the menu bar.");
            PreconditionFlow.NavigateToCart(_driver);
        }

        // TC_Checkout_0001
        [Test]
        public void Checkout_StepOne_NavigateToCheckout()
        {
            _test.Info("Clicking 'Checkout' button.");
            _cart.ClickCheckoutCartItem();
            Assert.That(_driver.Url.Contains("checkout-step-one"), Is.True);
        }

        // TC_Checkout_0002
        [Test]
        public void Checkout_StepOne_VerifyCancelIsDisplayed()
        {
            Checkout_StepOne_NavigateToCheckout();
            _test.Info("Verifying that the user can see the cancel button.");
            _stepOne.ShouldDisplayCancelButton();
        }

        // TC_Checkout_0003
        [Test]
        public void Checkout_StepOne_VerifyContinueIsDisplayed()
        {
            Checkout_StepOne_NavigateToCheckout();
            _test.Info("Verifying that the user can see the 'continue' button.");
            _stepOne.ShouldDisplayContinueButton();
        }

        // TC_Checkout_0004
        [Test]
        public void Checkout_StepOne_VerifyFieldsAreDisplayed()
        {
            Checkout_StepOne_NavigateToCheckout();
            _test.Info("Verify that user can see 'First Name' field.");
            _stepOne.ShouldDisplayFirstName();
            _test.Info("Verify that user can see 'Last Name' field.");
            _stepOne.ShouldDisplayLastName();
            _test.Info("Verify that user can see 'Postal Code' field.");
            _stepOne.ShouldDisplayPostalCode();
        }

        // TC_Checkout_0005
        [Test]
        [TestCaseSource(typeof(JsonDataProvider), nameof(JsonDataProvider.CheckoutPositiveCases))]
        public void Checkout_StepOne_ValidUserInputs(CheckoutTestCase testCase)
        {
            Checkout_StepOne_NavigateToCheckout();
            _test.Info("Entering user first name.");
            _stepOne.ChkoutEnterFirstName(testCase.testData.firstName);
            _test.Info("Entering user last name.");
            _stepOne.ChkoutEnterLastName(testCase.testData.lastName);
            _test.Info("Entering user postal code.");
            _stepOne.ChkoutPostalCode(testCase.testData.postalCode);
            _test.Info("Clicking 'continue' button.");
            _stepOne.ClickContinueButton();
            Assert.That(_driver.Url.Contains("checkout-step-two"), Is.True);
        }

        // TC_Checkout_0006; TC_Checkout_0007; TC_Checkout_0008; TC_Checkout_0009; TC_Checkout_0010; TC_Checkout_0011
        [Test]
        [TestCaseSource(typeof(JsonDataProvider), nameof(JsonDataProvider.CheckoutNegativeCases))]
        public void Checkout_StepOne_InvalidUserInputs(CheckoutTestCase testCase)
        {
            Checkout_StepOne_NavigateToCheckout();
            _test.Info("Entering user first name.");
            _stepOne.ChkoutEnterFirstName(testCase.testData.firstName);
            _test.Info("Entering user last name.");
            _stepOne.ChkoutEnterLastName(testCase.testData.lastName);
            _test.Info("Entering user postal code.");
            _stepOne.ChkoutPostalCode(testCase.testData.postalCode);
            _test.Info("Clicking 'continue' button.");
            _stepOne.ClickContinueButton();
            Assert.That(_stepOne.IsErrorMessageDisplayed(), Is.True);
        }
    }
}
