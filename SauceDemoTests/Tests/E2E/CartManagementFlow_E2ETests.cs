using SauceDemoTests.Pages.Cart;
using SauceDemoTests.Pages.Checkout;
using SauceDemoTests.Pages.Login;
using SauceDemoTests.Pages.MenuBar;
using SauceDemoTests.Pages.Product;
using TestUtilities;

namespace SauceDemoTests.Tests.E2E
{
    public class CartManagementFlow_E2ETests : BaseTest
    {
        private CartPage _cart;
        private CheckoutStepOnePage _checkoutStepOne;
        private CheckoutStepTwoPage _checkoutStepTwo;
        private LoginPage _login;
        private MenuBarPage _menu;
        private ProductPage _product;

        [SetUp]
        public override void SetUp()
        {
            // Setup basetest methods first.
            base.SetUp();

            // Navigate to SauceDemo website.
            ReportManager.LogInfo("Navigating to SauceDemo website.");
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/v1/");

            // Initialize all POMs.
            _cart = new CartPage(_driver);
            _checkoutStepOne = new CheckoutStepOnePage(_driver);
            _checkoutStepTwo = new CheckoutStepTwoPage(_driver);
            _login = new LoginPage(_driver);
            _menu = new MenuBarPage(_driver);
            _product = new ProductPage(_driver);
        }

        // For assertions that verify the url.
        private void AssertUrlContains(string url) => Assert.That(_driver.Url.Contains(url), Is.True);

        [Test]
        [TestCase(
            "standard_user",
            "secret_sauce",
            "Sample First",
            "Sample Last",
            "111"
        )]
        public void E2E_CartManagementFlow(string username, string password, string fname, string lname, string pcode)
        {
            int addItems = 3;
            int removeItems = 1;

            // Login
            ReportManager.LogInfo("Entering username.");
            _login.EnterUserName(username);
            ReportManager.LogInfo("Entering password.");
            _login.EnterPassword(password);
            ReportManager.LogInfo("Clicking 'login' button.");
            _login.ClickLoginBtn();
            ReportManager.LogInfo("Verifying that the user reaches the homepage (inventory).");
            AssertUrlContains("inventory");

            // Product
            // Add items to cart
            _product.AddItemsToCart(addItems);
            ReportManager.LogInfo($"Verifying that {addItems} item/s are added to cart.");
            Assert.That(_cart.GetMenuCurrentItemCount(), Is.GreaterThan(0));

            var currentItemCount = _cart.GetMenuCurrentItemCount();

            // Remove Items to cart
            _product.RemoveItemsToCart(currentItemCount, removeItems);
            ReportManager.LogInfo($"Verifying that {removeItems} item/s are remove from cart.");
            Assert.That(_cart.GetMenuCurrentItemCount(), Is.LessThan(currentItemCount));

            // Cart
            ReportManager.LogInfo("Clicking 'cart' icon.");
            _menu.ClickCart();
            ReportManager.LogInfo("Verifying that the user reaches the cart page.");
            AssertUrlContains("cart");
            ReportManager.LogInfo("Clicking 'checkout' button.");
            _cart.ClickCheckoutCartItem();
            ReportManager.LogInfo("Verifying that the user reaches checkout information page (checkout-step-one).");
            AssertUrlContains("checkout-step-one");

            // Checkout
            ReportManager.LogInfo("Entering first name.");
            _checkoutStepOne.ChkoutEnterFirstName(fname);
            ReportManager.LogInfo("Entering last name.");
            _checkoutStepOne.ChkoutEnterLastName(lname);
            ReportManager.LogInfo("Entering postal code.");
            _checkoutStepOne.ChkoutPostalCode(pcode);
            ReportManager.LogInfo("Clicking 'continue' icon.");
            _checkoutStepOne.ClickContinueButton();
            ReportManager.LogInfo("Verifying that the user reaches checkout overview page (checkout-step-two).");
            AssertUrlContains("checkout-step-two");
            ReportManager.LogInfo("Clicking 'finish' icon.");
            _checkoutStepTwo.ClickFinishButton();
            ReportManager.LogInfo("Verifying that the user reaches checkout complete page.");
            AssertUrlContains("checkout-complete");

            // Logout
            ReportManager.LogInfo("Clicking hamburger icon in the menu bar.");
            _menu.ClickHmbgrMenu();
            ReportManager.LogInfo("Clicking 'Logout' link.");
            _menu.ClickSMLogoutLink();
            ReportManager.LogInfo("Verifying that the user reaches login page (index).");
            AssertUrlContains("index");
        }
    }
}
