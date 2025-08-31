using SauceDemoTests.Pages.Cart;
using SauceDemoTests.Pages.Checkout;
using SauceDemoTests.Pages.Login;
using SauceDemoTests.Pages.MenuBar;
using SauceDemoTests.Pages.Product;
using SauceDemoTests.Utils;
using TestUtilities;

namespace SauceDemoTests.Tests.Checkout
{
    public class CheckoutStepTwoTests : BaseTest
    {
        // Fields.
        private LoginPage _login;
        private ProductPage _product;
        private CartPage _cart;
        private MenuBarPage _menu;
        private CheckoutStepOnePage _stepOne;
        private CheckoutStepTwoPage _stepTwo;

        [SetUp]
        public override void SetUp()
        {
            // Setup basetest methods first.
            base.SetUp();

            // Initialize LoginPage, ProductPage, CartPage, MenuBarPage, CheckoutStepOnePage, and CheckoutStepTwoPage.
            _login = new LoginPage(_driver);
            _product = new ProductPage(_driver);
            _cart = new CartPage(_driver);
            _menu = new MenuBarPage(_driver);
            _stepOne = new CheckoutStepOnePage(_driver);
            _stepTwo = new CheckoutStepTwoPage(_driver);

            // Navigate to SauceDemo Website.
            ReportManager.LogInfo("Navigating to SauceDemo website.");
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/v1/");

            // Log in to the website.
            ReportManager.LogInfo("Log in as standard user.");
            PreconditionFlow.LoginAsStandardUser(_driver, "standard_user", "secret_sauce");

            // Adding item to cart.
            ReportManager.LogInfo("Clicking 'Add to Cart' button to add product.");
            PreconditionFlow.AddProductToCart(_driver);

            // Navigating to cart page.
            ReportManager.LogInfo("Clicking shopping cart icon in the menu bar.");
            PreconditionFlow.NavigateToCart(_driver);

            // Navigating to checkout page.
            ReportManager.LogInfo("Clicking 'Checkout' button.");
            PreconditionFlow.NavigateToCheckout(_driver);

        }
        // TC_Checkout_0012
        [Test]
        public void Checkout_StepTwo_VerifyCheckoutOverview()
        {
            ReportManager.LogInfo("Entering user first name.");
            _stepOne.ChkoutEnterFirstName("Sample First");
            ReportManager.LogInfo("Entering user last name.");
            _stepOne.ChkoutEnterLastName("Sample Last");
            ReportManager.LogInfo("Entering user postal code.");
            _stepOne.ChkoutPostalCode("1111");
            ReportManager.LogInfo("Clicking 'continue' button.");
            _stepOne.ClickContinueButton();
            Assert.That(_driver.Url.Contains("checkout-step-two"), Is.True);
        }

        // TC_Checkout_0013
        [Test]
        public void Checkout_StepTwo_VerifyItemSummaryVisibility()
        {
            Checkout_StepTwo_VerifyCheckoutOverview();
            ReportManager.LogInfo("Verifying that the user can see the item summary.");
            _stepTwo.ShouldDisplayCartItem();
        }

        // TC_Checkout_0014
        [Test]
        public void Checkout_StepTwo_VerifyPaymentInfoVisibility()
        {
            Checkout_StepTwo_VerifyCheckoutOverview();
            ReportManager.LogInfo("Verifying that the user can see the payment information.");
            _stepTwo.ShouldDisplayPaymentInfo();
        }

        // TC_Checkout_0015
        [Test]
        public void Checkout_StepTwo_VerifyShippingInfoVisibility()
        {
            Checkout_StepTwo_VerifyCheckoutOverview();
            ReportManager.LogInfo("Verifying that the user can see the shipping information.");
            _stepTwo.ShouldDisplayShippingInfo();
        }

        // TC_Checkout_0016
        [Test]
        public void Checkout_StepTwo_VerifyItemSubTotalVisibility()
        {
            Checkout_StepTwo_VerifyCheckoutOverview();
            ReportManager.LogInfo("Verifying that the user can see the subtotal for the item.");
            _stepTwo.ShouldDisplayItemSubTotal();
        }

        // TC_Checkout_0017
        [Test]
        public void Checkout_StepTwo_VerifyItemTaxVisibility()
        {
            Checkout_StepTwo_VerifyCheckoutOverview();
            ReportManager.LogInfo("Verifying that the user can see the tax for the item.");
            _stepTwo.ShouldDisplayItemTax();
        }

        // TC_Checkout_0018
        [Test]
        public void Checkout_StepTwo_VerifyTotalPriceVisibility()
        {
            Checkout_StepTwo_VerifyCheckoutOverview();
            ReportManager.LogInfo("Verifying that the user can see the total price for the item.");
            _stepTwo.ShouldDisplayItemTotal();
        }

        // TC_Checkout_0019
        [Test]
        public void Checkout_StepTwo_VerifyFinishVisibility()
        {
            Checkout_StepTwo_VerifyCheckoutOverview();
            ReportManager.LogInfo("Verifying that the user can see the finish button.");
            _stepTwo.ShouldDisplayFinishButton();
        }

        // TC_Checkout_0020
        [Test]
        public void Checkout_StepTwo_OrderCompletion()
        {
            Checkout_StepTwo_VerifyCheckoutOverview();
            ReportManager.LogInfo("Clicking 'Finish' button.");
            _stepTwo.ClickFinishButton();
            ReportManager.LogInfo("Verifying that the user completes the order.");
            Assert.That(_driver.Url.Contains("checkout-complete"), Is.True);
        }

        // TC_Checkout_0021
        [Test]
        public void Checkout_StepTwo_VerifyingCartIsCleared()
        {
            Checkout_StepTwo_OrderCompletion();
            ReportManager.LogInfo("Clicking hamburger menu.");
            _menu.ClickHmbgrMenu();
            ReportManager.LogInfo("Clicking 'All items'.");
            _menu.ClickSMItemsLink();
            ReportManager.LogInfo("Verifying that the shopping cart is cleared of items.");
            Assert.That(_menu.IsCartBadgePresent, Is.False);
        }
    }
}
