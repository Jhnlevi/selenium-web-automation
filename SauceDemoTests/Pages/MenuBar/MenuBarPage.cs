using OpenQA.Selenium;
using TestUtilities;

namespace SauceDemoTests.Pages.MenuBar
{
    public class MenuBarPage
    {
        // Fields
        private readonly IWebDriver _driver;

        // Locators
        private By BtnMenuHmbgr = By.CssSelector(".bm-burger-button");
        private By BtnMenuCart = By.CssSelector(".shopping_cart_link");
        private By MenuAppLogo = By.CssSelector(".app_logo");
        private By SideMenu = By.CssSelector(".bm-menu");
        private By SMAllItems = By.Id("inventory_sidebar_link");
        private By SMAbout = By.Id("about_sidebar_link");
        private By SMLogout = By.Id("logout_sidebar_link");
        private By SMResetAppState = By.Id("reset_sidebar_link");
        private By SMBtnClose = By.CssSelector(".bm-cross-button");
        private By SMCartBadge = By.CssSelector(".fa-layers-counter.shopping_cart_badge");

        // Constructor
        public MenuBarPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Actions
        public void ShouldDisplayMenuHmbgr() => _driver.WaitForElementVisible(BtnMenuHmbgr);
        public void ShouldDisplayMenuShpngCart() => _driver.WaitForElementVisible(BtnMenuCart);
        public void ShouldDisplayMenuLogo() => _driver.WaitForElementVisible(MenuAppLogo);
        public void ShouldDisplaySideMenu() => _driver.WaitForElementVisible(SideMenu);
        public void ShouldDisplayAllItemsLink() => _driver.WaitForElementVisible(SMAllItems);
        public void ShouldDisplayAboutLink() => _driver.WaitForElementVisible(SMAbout);
        public void ShouldDisplayLogoutLink() => _driver.WaitForElementVisible(SMLogout);
        public void ShouldDisplayAppStateLink() => _driver.WaitForElementVisible(SMResetAppState);
        public void ShouldDisplaySMCloseButton() => _driver.WaitForElementVisible(SMBtnClose);
        public void ShouldDisplayShoppingCartbadge() => _driver.WaitForElementVisible(SMCartBadge);
        public void ClickHmbgrMenu()
        {
            var element = _driver.WaitForElementVisible(BtnMenuHmbgr);
            element.Click();
        }
        public void ClickCart()
        {
            var element = _driver.WaitForElementVisible(BtnMenuCart);
            element.Click();
        }
        public void ClickSMItemsLink()
        {
            var element = _driver.WaitForElementVisible(SMAllItems);
            element.Click();
        }
        public void ClickSMAboutLink()
        {
            var element = _driver.WaitForElementVisible(SMAbout);
            element.Click();
        }
        public void ClickSMLogoutLink()
        {
            var element = _driver.WaitForElementVisible(SMLogout);
            element.Click();
        }
        public void ClickSMRASLink()
        {
            var element = _driver.WaitForElementVisible(SMResetAppState);
            element.Click();
        }
        public void ClickSMCloseBtn()
        {
            var element = _driver.WaitForElementVisible(SMBtnClose);
            element.Click();
        }
        public string GetItemBadgeNumber()
        {
            var element = _driver.WaitForElementVisible(SMCartBadge);
            var itemCount = element.Text;

            return itemCount;
        }
        public bool IsCartBadgePresent() => _driver.FindElements(SMCartBadge).Count > 0;
    }
}
