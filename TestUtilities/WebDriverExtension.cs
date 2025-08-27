using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestUtilities
{
    public static class WebDriverExtension
    {
        // Waits for element to be visible
        public static IWebElement WaitForElementVisible(this IWebDriver driver, By locator, int timeoutInSeconds = 10)
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
    }
}
