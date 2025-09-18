using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace OrangeHRMTests.Utils
{
    internal static class WaitHelpers
    {
        /// <summary>
        /// Waits until the specified element is displayed on the page.
        /// </summary>
        /// <returns>The <see cref="IWebElement"/> once it is displayed.</returns>
        public static IWebElement WaitElementVisible(
            this IWebDriver driver,
            By locator,
            int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

            return wait.Until(d =>
            {
                try
                {
                    var element = d.FindElement(locator);
                    return element.Displayed ? element : null;
                }
                catch (StaleElementReferenceException) { return null; }
                catch (NoSuchElementException) { return null; }
            });
        }

        /// <summary>
        /// Waits until the specified elements are displayed on the page.
        /// </summary>
        /// <returns>The <see cref="IWebElement"/> of the specified elements once it is displayed.</returns>
        public static IReadOnlyCollection<IWebElement> WaitElementsVisible(
            this IWebDriver driver,
            By locator,
            int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

            return wait.Until(d =>
            {
                try
                {
                    var elements = d.FindElements(locator);
                    var isDisplayed = elements.Where(e => e.Displayed).ToList();
                    return isDisplayed.Count > 0 ? isDisplayed : null;
                }
                catch (StaleElementReferenceException) { return null; }
            });
        }

        /// <summary>
        /// Waits until an element is displayed and enabled
        /// </summary>
        /// <returns>The <see cref="IWebElement"/> once it is displayed and enabled.</returns>
        public static IWebElement WaitElementClickable(
            this IWebDriver driver,
            By locator,
            int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

            return wait.Until(d =>
            {
                var element = d.FindElement(locator);
                return (element.Displayed && element.Enabled) ? element : null;
            });
        }

        /// <summary>
        /// Waits for element to exists
        /// </summary>
        /// <returns>The <see cref="IWebElement"/> is the element is present on DOM.</returns>
        public static IWebElement WaitElementExists(
            this IWebDriver driver,
            By locator,
            int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

            return wait.Until(d =>
            {
                try
                {
                    return d.FindElement(locator);
                }
                catch (NoSuchElementException) { return null; }
            });
        }

        /// <summary>
        /// Waits for an element to disappear.
        /// </summary>
        /// <returns>A boolean once an element disappears.</returns>
        public static bool WaitElementDisappear(
            this IWebDriver driver,
            By locator,
            int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

            return wait.Until(d =>
            {
                try
                {
                    var element = d.FindElement(locator);
                    return !element.Displayed;
                }
                catch (NoSuchElementException) { return true; }
            });
        }

        /// <summary>
        /// Waits for the text of an element to appear.
        /// </summary>
        /// <returns>True if an element contains the specified text. Otherwise, false.</returns>
        public static bool WaitElementTextAppear(this IWebDriver driver,
            By locator,
            string text,
            int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

            return wait.Until(d =>
            {
                try
                {
                    var elementText = d.FindElement(locator).Text;
                    return elementText.Contains(text);
                }
                catch (NoSuchElementException) { return false; }
            });
        }
    }
}
