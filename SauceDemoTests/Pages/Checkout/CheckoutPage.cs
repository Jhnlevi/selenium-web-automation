using OpenQA.Selenium;
using SauceDemoTests.Pages.Cart;
using SauceDemoTests.Pages.MenuBar;
using SauceDemoTests.Pages.Product;
using TestUtilities;

namespace SauceDemoTests.Pages.Checkout
{
    public class CheckoutPage
    {
        // Fields
        private readonly IWebDriver _driver;

        // Properties
        private MenuBarPage _menu { get; set; }
        private ProductPage _product { get; set; }
        private CartPage _cart { get; set; }

        // Constructor
        public CheckoutPage(IWebDriver driver)
        {
            _driver = driver;
            _menu = new MenuBarPage(_driver);
            _product = new ProductPage(_driver);
            _cart = new CartPage(_driver);
        }

        // Locators
        private By ChkoutInfoFirstName = By.Id("first-name");
        private By ChkoutInfoLastName = By.Id("last-name");
        private By ChkoutInfoPostalCode = By.Id("postal-code");
        private By ChkoutBtnCancel = By.CssSelector("div.checkout_buttons .cart_cancel_link.btn_secondary");
        private By ChkoutBtnContinue = By.CssSelector("div.checkout_buttons .btn_primary.cart_button");
        private By ChkoutCartItem = By.CssSelector(".cart_item");
        private By ChkoutPaymentInfo = By.XPath("(//div[@class='summary_info_label' and text()='Payment Information:'])[1]");
        private By ChkoutShippingInfo = By.XPath("(//div[@class='summary_info_label' and text()='Shipping Information:'])[1]");
        private By ChckoutItemSubTotal = By.CssSelector(".summary_subtotal_label");
        private By ChkoutItemTax = By.CssSelector(".summary_tax_label");
        private By ChkoutItemTotal = By.CssSelector(".summary_total_label");
        private By ChkoutBtnFinish = By.LinkText("FINISH");
        private By ChkErrMessage = By.CssSelector("h3[data-test='error']");

        // Actions
        public void ShouldDisplayFirstName() => _driver.WaitForElementVisible(ChkoutInfoFirstName);
        public void ShouldDisplayLastName() => _driver.WaitForElementVisible(ChkoutInfoLastName);
        public void ShouldDisplayPostalCode() => _driver.WaitForElementVisible(ChkoutInfoPostalCode);
        public void ShouldDisplayCancelButton() => _driver.WaitForElementVisible(ChkoutBtnCancel);
        public void ShouldDisplayContinueButton() => _driver.WaitForElementVisible(ChkoutBtnContinue);
        public void ShouldDisplayFinishButton() => _driver.WaitForElementVisible(ChkoutBtnFinish);
        public void ShouldDisplayCartItem() => _driver.WaitForElementVisible(ChkoutCartItem);
        public void ShouldDisplayPaymentInfo() => _driver.WaitForElementVisible(ChkoutPaymentInfo);
        public void ShouldDisplayShippingInfo() => _driver.WaitForElementVisible(ChkoutShippingInfo);
        public void ShouldDisplayItemSubTotal() => _driver.WaitForElementVisible(ChckoutItemSubTotal);
        public void ShouldDisplayItemTax() => _driver.WaitForElementVisible(ChkoutItemTax);
        public void ShouldDisplayItemTotal() => _driver.WaitForElementVisible(ChkoutItemTotal);
        public void ShouldDisplayErrorMessage() => _driver.WaitForElementVisible(ChkErrMessage);
        public void ChkoutEnterFirstName(string firstName)
        {
            var element = _driver.WaitForElementVisible(ChkoutInfoFirstName);
            element.Clear();
            element.SendKeys(firstName);
        }
        public void ChkoutEnterLastName(string lastName)
        {
            var element = _driver.WaitForElementVisible(ChkoutInfoLastName);
            element.Clear();
            element.SendKeys(lastName);
        }
        public void ClickCancelButton()
        {
            var element = _driver.WaitForElementVisible(ChkoutBtnCancel);
            element.Click();
        }
        public void ClickContinueButton()
        {
            var element = _driver.WaitForElementVisible(ChkoutBtnContinue);
            element.Click();
        }
        public void ClickFinishButton()
        {
            var element = _driver.WaitForElementVisible(ChkoutBtnFinish);
            element.Click();
        }
        public string GetErrorMessage()
        {
            var element = _driver.WaitForElementVisible(ChkErrMessage);
            return element.Text;
        }
        public bool IsErrorMessageDisplayed()
        {
            return !String.IsNullOrEmpty(GetErrorMessage());
        }
    }
}
