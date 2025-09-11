using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestUtilities;

namespace OrangeHRMTests.Pages
{
    internal abstract class BasePage
    {
        protected IWebDriver _driver;

        public BasePage(IWebDriver driver) => _driver = driver;

        // Button actions.
        public void Click(By locator) => _driver.WaitForElementToBeVisible(locator).Click();

        // Text actions.
        public void ClearText(By locator) => _driver.WaitForElementToBeVisible(locator).Clear();

        public void EnterText(By locator, string text)
        {
            // For OrangeHRM only, otherwise .Clear() works.
            _driver.WaitForElementToBeVisible(locator).SendKeys(Keys.Control + "a");
            _driver.WaitForElementToBeVisible(locator).SendKeys(Keys.Backspace);
            _driver.WaitForElementToBeVisible(locator).SendKeys(Keys.Control + "a");
            _driver.WaitForElementToBeVisible(locator).SendKeys(Keys.Delete);
            _driver.WaitForElementToBeVisible(locator).SendKeys(text);
            _driver.WaitForElementToBeVisible(locator).SendKeys(Keys.Tab);
        }

        public string GetText(By locator) => _driver.WaitForElementToBeVisible(locator).Text;
        public string GetTextByValue(By locator) => _driver.WaitForElementToBeVisible(locator).GetAttribute("value")!;

        // Checking actions; Returns boolean.
        public bool IsElementDisplayed(By locator) => _driver.WaitForElementToBeVisible(locator).Displayed;

        public bool IsElementEnabled(By locator) => _driver.WaitForElementToBeVisible(locator).Enabled;

        public bool IsElementSelected(By locator) => _driver.WaitForElementToBeVisible(locator).Selected;

        // Date Actions
        public void EnterDate(By locator, string text)
        {
            var element = _driver.WaitForElementToBeVisible(locator);
            element.SendKeys(Keys.Control + "a");
            element.SendKeys(Keys.Delete);
            element.SendKeys(text);
        }

        // Dropdown Actions
        public void SelectByText(By locator, string text)
        {
            var element = _driver.WaitForElementToBeVisible(locator);
            var select = new SelectElement(element);
            select.SelectByText(text);
        }

        public void SelectByValue(By locator, string value)
        {
            var element = _driver.WaitForElementToBeVisible(locator);
            var select = new SelectElement(element);
            select.SelectByValue(value);
        }

        public void SelectByIndex(By locator, int index)
        {
            var element = _driver.WaitForElementToBeVisible(locator);
            var select = new SelectElement(element);
            select.SelectByIndex(index);
        }

        // Navigation/Page actions.
        public void NavigateToUrl(string url) => _driver.Navigate().GoToUrl(url);

        public void RefreshCurrentPage() => _driver.Navigate().Refresh();

        public string GetPageTitle() => _driver.Title;

        public string GetCurrentUrl() => _driver.Url;
    }
}
