using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace TestUtilities
{
    public static class WebDriverFactory
    {
        [ThreadStatic]
        private static IWebDriver _driver;

        // Creating the driver base on the browser; To be used base test file.
        public static IWebDriver CreateDriver(string browser)
        {
            switch (browser.ToLower())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--disable-infobars");
                    chromeOptions.AddArgument("--disable-save-password-bubble");
                    chromeOptions.AddArgument("--disable-password-manager-reauthentication");
                    chromeOptions.AddArgument("start-maximized");
                    // Start tests in incognito mode.
                    chromeOptions.AddArgument("--incognito");

                    // For CI.
                    if (Environment.GetEnvironmentVariable("CI") == "true")
                    {
                        chromeOptions.AddArgument("--headless");
                        chromeOptions.AddArgument("--disable-gpu");
                        chromeOptions.AddArgument("--window-size=1920,1080");
                    }

                    return new ChromeDriver(chromeOptions);

                case "edge":
                    var edgeOptions = new EdgeOptions();
                    edgeOptions.AddArgument("start-maximized");
                    return new EdgeDriver(edgeOptions);

                default:
                    throw new ArgumentException("Invalid browser name. Please enter 'chrome' or 'edge'.");
            }
        }

        // Getting the driver; Default browser is chrome; To be used in BaseTest file.
        public static IWebDriver GetDriver(string browser = "chrome")
        {
            if (_driver == null)
            {
                _driver = CreateDriver(browser);
            }
            return _driver;
        }

        // Closing the driver; To be used in BaseTest file.
        public static void CloseDriver()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
                _driver = null;
            }
        }
    }
}
