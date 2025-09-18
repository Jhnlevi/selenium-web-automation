using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OrangeHRMTests.Utils;

namespace OrangeHRMTests.Pages
{
    internal abstract class BasePage
    {
        protected IWebDriver _driver;

        public BasePage(IWebDriver driver) => _driver = driver;

        // Button actions.
        public void Click(By locator) => _driver.WaitElementVisible(locator).Click();

        // Text actions.
        public void ClearText(By locator) => _driver.WaitElementVisible(locator).Clear();

        public void EnterText(By locator, string text)
        {
            // For OrangeHRM only, otherwise .Clear() works.
            _driver.WaitElementVisible(locator).SendKeys(Keys.Control + "a");
            _driver.WaitElementVisible(locator).SendKeys(Keys.Delete);
            _driver.WaitElementVisible(locator).SendKeys(text);
            _driver.WaitElementVisible(locator).SendKeys(Keys.Tab);
        }

        public string GetText(By locator) => _driver.WaitElementVisible(locator).Text;
        public string GetFieldValue(By locator) => _driver.WaitElementVisible(locator).GetAttribute("value")!;

        // Checking actions; Returns boolean.
        public bool IsElementDisplayed(By locator) => _driver.WaitElementVisible(locator).Displayed;

        public bool IsElementEnabled(By locator) => _driver.WaitElementVisible(locator).Enabled;

        public bool IsElementSelected(By locator) => _driver.WaitElementVisible(locator).Selected;

        // Date Actions
        public void EnterDate(By locator, string text)
        {
            var element = _driver.WaitElementVisible(locator);
            element.SendKeys(Keys.Control + "a");
            element.SendKeys(Keys.Delete);
            element.SendKeys(text);
        }

        // Dropdown Actions
        public void SelectByText(By locator, string text)
        {
            var element = _driver.WaitElementVisible(locator);
            var select = new SelectElement(element);
            select.SelectByText(text);
        }

        public void SelectByValue(By locator, string value)
        {
            var element = _driver.WaitElementVisible(locator);
            var select = new SelectElement(element);
            select.SelectByValue(value);
        }

        public void SelectByIndex(By locator, int index)
        {
            var element = _driver.WaitElementVisible(locator);
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
