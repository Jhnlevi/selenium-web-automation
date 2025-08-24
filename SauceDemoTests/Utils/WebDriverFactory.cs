using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace SauceDemoTests.Utils
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateDriver(string driver)
        {
            switch (driver.ToLower())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("start-maximized");
                    return new ChromeDriver(chromeOptions);

                case "edge":
                    var edgeOptions = new EdgeOptions();
                    edgeOptions.AddArgument("start-maximized");
                    edgeOptions.AddArgument("--headless");
                    return new EdgeDriver(edgeOptions);

                default:
                    throw new ArgumentException("Invalid browser name. Please enter 'chrome' or 'edge'.");
            }
        }
    }
}
