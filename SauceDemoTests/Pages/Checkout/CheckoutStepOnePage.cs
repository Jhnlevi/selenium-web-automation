using OpenQA.Selenium;
using SauceDemoTests.Pages.MenuBar;
using TestUtilities;

namespace SauceDemoTests.Pages.Checkout
{
    public class CheckoutStepOnePage
    {
        // Fields
        private readonly IWebDriver _driver;

        // Properties
        private MenuBarPage _menu { get; set; }

        public CheckoutStepOnePage(IWebDriver driver)
        {
            _driver = driver;
            _menu = new MenuBarPage(_driver);
        }
        // Locators
        private By ChkoutInfoFirstName = By.Id("first-name");
        private By ChkoutInfoLastName = By.Id("last-name");
        private By ChkoutInfoPostalCode = By.Id("postal-code");
        private By ChkoutBtnCancel = By.CssSelector("div.checkout_buttons .cart_cancel_link.btn_secondary");
        private By ChkoutBtnContinue = By.CssSelector("div.checkout_buttons .btn_primary.cart_button");
        private By ChkErrMessage = By.CssSelector("h3[data-test='error']");

        // Actions
        public void ShouldDisplayFirstName() => _driver.WaitForElementVisible(ChkoutInfoFirstName);
        public void ShouldDisplayLastName() => _driver.WaitForElementVisible(ChkoutInfoLastName);
        public void ShouldDisplayPostalCode() => _driver.WaitForElementVisible(ChkoutInfoPostalCode);
        public void ShouldDisplayCancelButton() => _driver.WaitForElementVisible(ChkoutBtnCancel);
        public void ShouldDisplayContinueButton() => _driver.WaitForElementVisible(ChkoutBtnContinue);
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
