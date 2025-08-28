using OpenQA.Selenium;
using SauceDemoTests.Pages.MenuBar;
using SauceDemoTests.Pages.Product;
using TestUtilities;

namespace SauceDemoTests.Pages.Cart
{
    public class CartPage
    {
        // Fields
        private readonly IWebDriver _driver;

        // Properties
        public MenuBarPage _menu { get; set; }
        public ProductPage _product { get; set; }



        // Constructor
        public CartPage(IWebDriver driver)
        {
            _driver = driver;
            _menu = new MenuBarPage(_driver);
            _product = new ProductPage(_driver);
        }

        // Locators
        private By CartQuantity = By.CssSelector(".cart_quantity");
        private By CartRmvItemBtn = By.CssSelector(".btn_secondary.cart_button");
        private By CartCheckoutBtn = By.CssSelector(".btn_action.checkout_button");
        private By CartContinueShoppingBtn = By.LinkText("Continue Shopping");

        // Actions

        public void ShouldDisplayCartProductName() => _product.ShouldDisplayProductName();
        public void ShouldDisplayCartProductDescription() => _product.ShouldDisplayProductDescription();
        public void ShouldDisplayCartProductPrice() => _product.ShouldDisplayProductPrice();
        public void GetMenuCurrentItemCount()
        {
            _menu.GetItemBadgeNumber();
        }
        public string GetCartCurrentItemCount()
        {
            var element = _driver.WaitForElementVisible(CartQuantity);

            return element.Text.ToString();
        }
        public void ClickRemoveCartItem()
        {
            var element = _driver.WaitForElementVisible(CartRmvItemBtn);
            element.Click();
        }
        public void ClickCheckoutCartItem()
        {
            var element = _driver.WaitForElementVisible(CartCheckoutBtn);
            element.Click();
        }
        public void ClickContinueShoppingItem()
        {
            var element = _driver.WaitForElementVisible(CartContinueShoppingBtn);
            element.Click();
        }
    }
}
