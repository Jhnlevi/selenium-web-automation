using OpenQA.Selenium;
using SauceDemoTests.Pages.Cart;
using SauceDemoTests.Pages.Login;
using SauceDemoTests.Pages.MenuBar;
using SauceDemoTests.Pages.Product;
using TestUtilities;

namespace SauceDemoTests.Utils
{
    public static class PreconditionFlow
    {
        public static void LoginAsStandardUser(IWebDriver driver, string username, string password)
        {
            var _login = new LoginPage(driver);
            _login.EnterUserName(username);
            _login.EnterPassword(password);
            _login.ClickLoginBtn();
        }
        public static void AddProductToCart(IWebDriver driver)
        {
            var _product = new ProductPage(driver);
            _product.ClickAddToCart();
        }
        public static void NavigateToCart(IWebDriver driver)
        {
            var _menu = new MenuBarPage(driver);
            _menu.ClickCart();
        }
        public static void NavigateToCheckout(IWebDriver driver)
        {
            var _cart = new CartPage(driver);
            _cart.ClickCheckoutCartItem();
        }

        public static void FromLoginToCartFlow(IWebDriver driver, string username, string password)
        {
            ReportManager.LogInfo("Log in as standard user.");
            LoginAsStandardUser(driver, username, password);
            ReportManager.LogInfo("Clicking 'Add to Cart' button to add product.");
            AddProductToCart(driver);
            ReportManager.LogInfo("Clicking shopping cart icon in the menu bar.");
            NavigateToCart(driver);
        }

        public static void FromLoginToCheckoutFlow(IWebDriver driver, string username, string password)
        {
            ReportManager.LogInfo("Log in as standard user.");
            LoginAsStandardUser(driver, username, password);
            ReportManager.LogInfo("Clicking 'Add to Cart' button to add product.");
            AddProductToCart(driver);
            ReportManager.LogInfo("Clicking shopping cart icon in the menu bar.");
            NavigateToCart(driver);
            ReportManager.LogInfo("Clicking 'Checkout' button.");
            NavigateToCheckout(driver);
        }
    }
}
