using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestUtilities
{
    public static class WebDriverWaitHelper
    {
        // Custom wait method; Returns element if it is displayed and enabled.
        public static IWebElement WaitForElementToBeVisible(this IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

            return wait.Until(driv =>
            {
                try
                {
                    var element = driv.FindElement(locator);
                    return (element.Displayed && element.Enabled) ? element : null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
            });
        }
        public static IReadOnlyCollection<IWebElement> WaitForElementsToBeVisible(
            this IWebDriver driver,
            By locator,
            int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

            return wait.Until(driv =>
            {
                try
                {
                    var elements = driv.FindElements(locator);
                    var displayedElements = elements.Where(e => e.Displayed).ToList();
                    return displayedElements.Count > 0 ? elements : null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            });
        }
    }
}
