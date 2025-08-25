using OpenQA.Selenium;
using SauceDemoTests.Utils;

namespace SauceDemoTests.Tests
{
    public class BaseTest
    {
        protected IWebDriver _driver;

        [SetUp]
        public virtual void SetUp()
        {
            // Driver setup
            _driver = WebDriverFactory.CreateDriver("chrome");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
