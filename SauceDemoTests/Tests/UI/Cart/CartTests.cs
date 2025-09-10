using SauceDemoTests.Pages.Cart;
using SauceDemoTests.Pages.Product;
using SauceDemoTests.Utils;
using TestUtilities;

namespace SauceDemoTests.Tests.UI.Cart
{
    public class CartTests : BaseTest
    {
        private ProductPage _product;
        private CartPage _cart;

        [SetUp]
        public override void SetUp()
        {
            // Setup basetest methods first
            base.SetUp();

            // Initialize CartPage, and ProductPage.
            _product = new ProductPage(_driver!);
            _cart = new CartPage(_driver!);

            // Navigate to SauceDemo Website.
            ReportManager.LogInfo("Navigating to SauceDemo website.");
            _driver!.Navigate().GoToUrl(_config.BaseUrl);

            // Log in to the website
            ReportManager.LogInfo("Log in as standard user.");
            PreconditionFlow.LoginAsStandardUser(_driver, "standard_user", "secret_sauce");
        }

        // TC_Cart_0001
        [Test]
        public void Cart_AddProductToCart()
        {
            ReportManager.LogInfo("Clicking 'Add to Cart' button to add product.");
            _product.ClickAddToCart();

            ReportManager.LogInfo("Verifying that an item is added to cart.");
            Assert.That(_product.GetRemoveFromCartBtnText, Is.EqualTo("REMOVE"));
        }

        // TC_Cart_0002
        [Test]
        public void Cart_RemoveProductFromCart()
        {
            ReportManager.LogInfo("Clicking 'Add to Cart' button to add product.");
            _product.ClickAddToCart();

            ReportManager.LogInfo("Clicking 'Remove' button to remove product.");
            _product.ClickRemoveToCart();

            ReportManager.LogInfo("Verifying that an item is removed from cart.");
            Assert.That(_product.GetAddToCartBtnText, Is.EqualTo("ADD TO CART"));
        }

        // TC_Cart_0003

        [Test]
        public void Cart_VerifyCartIconUpdate()
        {
            ReportManager.LogInfo("Clicking 'Add to Cart' button to add product.");
            _product.ClickAddToCart();

            ReportManager.LogInfo("Verifying that cart icon counter is updated with the correct item count.");
            Assert.That(_cart.GetMenuCurrentItemCount, Is.GreaterThan(0));
        }

        // TC_Cart_0004
        [Test]
        public void Cart_VerifyItemCountPersists()
        {
            ReportManager.LogInfo("Clicking 'Add to Cart' button to add product.");
            _product.ClickAddToCart();

            ReportManager.LogInfo("Clicking product to open product details page.");
            _product.ClickProduct();

            ReportManager.LogInfo("Verifying that cart icon counter remains when changing a page.");
            Assert.That(_cart.GetMenuCurrentItemCount, Is.GreaterThan(0));

        }

        // TC_Cart_0005
        [Test]
        public void Cart_VerifyProductQuantityInCartPage()
        {
            ReportManager.LogInfo("Clicking 'Add to Cart' button to add product.");
            _product.ClickAddToCart();

            ReportManager.LogInfo("Clicking shopping cart button to open cart page.");
            _cart._menu.ClickCart();

            ReportManager.LogInfo("Verifying that user can see the quantity of product added to cart.");
            Assert.That(_cart.GetCartCurrentItemCount, Is.GreaterThan(0));
        }

        // TC_Cart_0006
        [Test]
        public void Cart_VerifyProductNameInCartPage()
        {
            ReportManager.LogInfo("Clicking 'Add to Cart' button to add product.");
            _product.ClickAddToCart();

            ReportManager.LogInfo("Clicking shopping cart button to open cart page.");
            _cart._menu.ClickCart();

            ReportManager.LogInfo("Verifying that user can see the name of product added to cart.");
            _product.ShouldDisplayProductName();
        }

        // TC_Cart_0007
        [Test]
        public void Cart_VerifyProductPriceInCartPage()
        {
            ReportManager.LogInfo("Clicking 'Add to Cart' button to add product.");
            _product.ClickAddToCart();

            ReportManager.LogInfo("Clicking shopping cart button to open cart page.");
            _cart._menu.ClickCart();

            ReportManager.LogInfo("Verifying that user can see the price of product added to cart.");
            _product.ShouldDisplayProductPrice();
        }

        // TC_Cart_0008
        [Test]
        public void Cart_VerifyProductDescriptionInCartPage()
        {
            ReportManager.LogInfo("Clicking 'Add to Cart' button to add product.");
            _product.ClickAddToCart();

            ReportManager.LogInfo("Clicking shopping cart button to open cart page.");
            _cart._menu.ClickCart();

            ReportManager.LogInfo("Verifying that user can see the description of product added to cart.");
            _product.ShouldDisplayProductDescription();
        }

        // TC_Cart_0009
        [Test]
        public void Cart_VerifyContinueShoppingIsDisplayed()
        {
            ReportManager.LogInfo("Clicking 'Add to Cart' button to add product.");
            _product.ClickAddToCart();

            ReportManager.LogInfo("Clicking shopping cart button to open cart page.");
            _cart._menu.ClickCart();

            ReportManager.LogInfo("Verifying that user can see the 'Continue Shopping' button.");
            _cart.ShouldDisplayContinueShoppingButton();
        }

        // TC_Cart_0010
        [Test]
        public void Cart_VerifyCheckoutIsDisplayed()
        {
            ReportManager.LogInfo("Clicking 'Add to Cart' button to add product.");
            _product.ClickAddToCart();

            ReportManager.LogInfo("Clicking shopping cart button to open cart page.");
            _cart._menu.ClickCart();

            ReportManager.LogInfo("Verifying that user can see the 'Checkout' button.");
            _cart.ShouldDisplayCheckoutButton();
        }

        // No test case available.
        [Test]
        public void Cart_VerifyRemoveItemButtonIsDisplayed()
        {
            ReportManager.LogInfo("Clicking 'Add to Cart' button to add product.");
            _product.ClickAddToCart();

            ReportManager.LogInfo("Clicking shopping cart button to open cart page.");
            _cart._menu.ClickCart();

            ReportManager.LogInfo("Verifying that user can see the 'Remove' button.");
            _cart.ShouldDisplayRemoveButton();
        }

        // No test case available.
        [Test]
        public void Cart_VerifyContinueShoppingFunctionality()
        {
            ReportManager.LogInfo("Clicking 'Add to Cart' button to add product.");
            _product.ClickAddToCart();

            ReportManager.LogInfo("Clicking shopping cart button to open cart page.");
            _cart._menu.ClickCart();

            ReportManager.LogInfo("Clicking 'Continue shopping' button.");
            _cart.ClickContinueShoppingItem();

            ReportManager.LogInfo("Verifying that the user is redirected to product list page.");
            Assert.That(_driver!.Url.Contains("inventory"), Is.True);
        }

        // No test case available.
        [Test]
        public void Cart_CheckoutFunctionality()
        {
            ReportManager.LogInfo("Clicking 'Add to Cart' button to add product.");
            _product.ClickAddToCart();

            ReportManager.LogInfo("Clicking shopping cart button to open cart page.");
            _cart._menu.ClickCart();

            ReportManager.LogInfo("Clicking 'Continu shopping' button.");
            _cart.ClickCheckoutCartItem();

            ReportManager.LogInfo("Verifying that the user is redirected to checkout step one page.");
            Assert.That(_driver!.Url.Contains("checkout-step-one"), Is.True);
        }
    }
}
