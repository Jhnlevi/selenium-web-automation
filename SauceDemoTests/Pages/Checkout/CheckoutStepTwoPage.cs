using OpenQA.Selenium;
using SauceDemoTests.Pages.Cart;
using SauceDemoTests.Pages.MenuBar;
using SauceDemoTests.Pages.Product;
using SauceDemoTests.Utils;

namespace SauceDemoTests.Pages.Checkout
{
    public class CheckoutStepTwoPage
    {
        // Fields
        private readonly IWebDriver _driver;

        // Properties
        private MenuBarPage _menu { get; set; }
        private ProductPage _product { get; set; }
        private CartPage _cart { get; set; }

        // Constructor
        public CheckoutStepTwoPage(IWebDriver driver)
        {
            _driver = driver;
            _menu = new MenuBarPage(_driver);
            _product = new ProductPage(_driver);
            _cart = new CartPage(_driver);
        }

        // Locators
        private By ChkoutCartItem = By.CssSelector(".cart_item");
        private By ChkoutPaymentInfo = By.XPath("(//div[@class='summary_info_label' and text()='Payment Information:'])[1]");
        private By ChkoutShippingInfo = By.XPath("(//div[@class='summary_info_label' and text()='Shipping Information:'])[1]");
        private By ChckoutItemSubTotal = By.CssSelector(".summary_subtotal_label");
        private By ChkoutItemTax = By.CssSelector(".summary_tax_label");
        private By ChkoutItemTotal = By.CssSelector(".summary_total_label");
        private By ChkoutBtnFinish = By.LinkText("FINISH");
        private By ChkoutBtnCancel = By.LinkText("CANCEL");

        // Actions
        public void ShouldDisplayFinishButton() => _driver.WaitElementVisible(ChkoutBtnFinish);
        public void ShouldDisplayCancelButton() => _driver.WaitElementVisible(ChkoutBtnCancel);
        public void ShouldDisplayCartItem() => _driver.WaitElementVisible(ChkoutCartItem);
        public void ShouldDisplayPaymentInfo() => _driver.WaitElementVisible(ChkoutPaymentInfo);
        public void ShouldDisplayShippingInfo() => _driver.WaitElementVisible(ChkoutShippingInfo);
        public void ShouldDisplayItemSubTotal() => _driver.WaitElementVisible(ChckoutItemSubTotal);
        public void ShouldDisplayItemTax() => _driver.WaitElementVisible(ChkoutItemTax);
        public void ShouldDisplayItemTotal() => _driver.WaitElementVisible(ChkoutItemTotal);
        public void ClickFinishButton()
        {
            var element = _driver.WaitElementVisible(ChkoutBtnFinish);
            element.Click();
        }
        public void ClickCancelButton()
        {
            var element = _driver.WaitElementVisible(ChkoutBtnCancel);
            element.Click();
        }
    }
}
