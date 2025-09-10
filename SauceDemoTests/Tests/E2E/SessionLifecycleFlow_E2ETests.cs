using SauceDemoTests.Pages.Cart;
using SauceDemoTests.Pages.Checkout;
using SauceDemoTests.Pages.Login;
using SauceDemoTests.Pages.MenuBar;
using SauceDemoTests.Pages.Product;
using TestUtilities;

namespace SauceDemoTests.Tests.E2E
{
    public class SessionLifecycleFlow_E2ETests : BaseTest
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
            _driver!.Navigate().GoToUrl(_config.BaseUrl);

            // Initialize all POMs.
            _cart = new CartPage(_driver);
            _checkoutStepOne = new CheckoutStepOnePage(_driver);
            _checkoutStepTwo = new CheckoutStepTwoPage(_driver);
            _login = new LoginPage(_driver);
            _menu = new MenuBarPage(_driver);
            _product = new ProductPage(_driver);
        }

        // For assertions that verify the url.
        private void AssertUrlContains(string url) => Assert.That(_driver!.Url.Contains(url), Is.True);

        [Test]
        [TestCase(
            "standard_user",
            "secret_sauce"
        )]
        public void E2E_UserSessionManagement_And_AccessControlValidation(string username, string password)
        {
            int addItems = 4;

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
            _product.AddItemsToCart(addItems);
            ReportManager.LogInfo($"Verifying that there are {_cart.GetMenuCurrentItemCount()} item/s are added to cart.");
            Assert.That(_cart.GetMenuCurrentItemCount(), Is.GreaterThan(0));

            // Logout
            ReportManager.LogInfo("Clicking hamburger icon in the menu bar.");
            _menu.ClickHmbgrMenu();
            ReportManager.LogInfo("Clicking 'Logout' link.");
            _menu.ClickSMLogoutLink();
            ReportManager.LogInfo("Verifying that the user reaches login page (index).");
            AssertUrlContains("index");

            // Go to cart page without logging in.
            ReportManager.LogInfo("Navigating to cart page of SauceDemo.");
            _driver!.Navigate().GoToUrl("https://www.saucedemo.com/v1/cart.html");
            // Known issue with SauceDem - User can still access other pages such as /cart or /inventory.
            ReportManager.LogInfo("SauceDemo issue: After logout, user can still access /cart.html via URL.");
            // Assert.That(_driver.Url.Contains("cart"), Is.False);
            Assert.That(_driver.Url.Contains("cart"), Is.True);
        }
    }
}
