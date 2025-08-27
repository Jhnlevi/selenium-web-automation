using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace TestUtilities
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateDriver(string driver)
        {
            switch (driver.ToLower())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    // Prevent "Chrome is being controlled by automated test software" infobar
                    chromeOptions.AddArgument("--disable-infobars");

                    // Disable password manager popups
                    chromeOptions.AddArgument("--disable-save-password-bubble");
                    chromeOptions.AddArgument("--disable-password-manager-reauthentication");

                    // Incognito
                    chromeOptions.AddArgument("--incognito");

                    // Maximized window
                    chromeOptions.AddArgument("start-maximized");

                    return new ChromeDriver(chromeOptions);

                case "edge":
                    var edgeOptions = new EdgeOptions();
                    // Maximized window
                    edgeOptions.AddArgument("start-maximized");

                    // Headless 
                    edgeOptions.AddArgument("--headless");

                    return new EdgeDriver(edgeOptions);

                default:
                    throw new ArgumentException("Invalid browser name. Please enter 'chrome' or 'edge'.");
            }
        }
    }
}
