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
        public void ShouldDisplayFirstName() => _driver.WaitForElementToBeVisible(ChkoutInfoFirstName);
        public void ShouldDisplayLastName() => _driver.WaitForElementToBeVisible(ChkoutInfoLastName);
        public void ShouldDisplayPostalCode() => _driver.WaitForElementToBeVisible(ChkoutInfoPostalCode);
        public void ShouldDisplayCancelButton() => _driver.WaitForElementToBeVisible(ChkoutBtnCancel);
        public void ShouldDisplayContinueButton() => _driver.WaitForElementToBeVisible(ChkoutBtnContinue);
        public void ShouldDisplayErrorMessage() => _driver.WaitForElementToBeVisible(ChkErrMessage);
        public void ChkoutEnterFirstName(string firstName)
        {
            var element = _driver.WaitForElementToBeVisible(ChkoutInfoFirstName);
            element.Clear();
            element.SendKeys(firstName);
        }
        public void ChkoutEnterLastName(string lastName)
        {
            var element = _driver.WaitForElementToBeVisible(ChkoutInfoLastName);
            element.Clear();
            element.SendKeys(lastName);
        }
        public void ChkoutPostalCode(string postalCode)
        {
            var element = _driver.WaitForElementToBeVisible(ChkoutInfoPostalCode);
            element.Clear();
            element.SendKeys(postalCode);
        }
        public void ClickCancelButton()
        {
            var element = _driver.WaitForElementToBeVisible(ChkoutBtnCancel);
            element.Click();
        }
        public void ClickContinueButton()
        {
            var element = _driver.WaitForElementToBeVisible(ChkoutBtnContinue);
            element.Click();
        }
        public string GetErrorMessage()
        {
            var element = _driver.WaitForElementToBeVisible(ChkErrMessage);
            return element.Text;
        }
        public bool IsErrorMessageDisplayed()
        {
            return !String.IsNullOrEmpty(GetErrorMessage());
        }
    }
}
