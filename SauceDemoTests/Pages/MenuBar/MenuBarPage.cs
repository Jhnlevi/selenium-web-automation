using OpenQA.Selenium;
using SauceDemoTests.Utils;

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
        public void ShouldDisplayMenuHmbgr() => _driver.WaitElementVisible(BtnMenuHmbgr);
        public void ShouldDisplayMenuShpngCart() => _driver.WaitElementVisible(BtnMenuCart);
        public void ShouldDisplayMenuLogo() => _driver.WaitElementVisible(MenuAppLogo);
        public void ShouldDisplaySideMenu() => _driver.WaitElementVisible(SideMenu);
        public void ShouldDisplayAllItemsLink() => _driver.WaitElementVisible(SMAllItems);
        public void ShouldDisplayAboutLink() => _driver.WaitElementVisible(SMAbout);
        public void ShouldDisplayLogoutLink() => _driver.WaitElementVisible(SMLogout);
        public void ShouldDisplayAppStateLink() => _driver.WaitElementVisible(SMResetAppState);
        public void ShouldDisplaySMCloseButton() => _driver.WaitElementVisible(SMBtnClose);
        public void ShouldDisplayShoppingCartbadge() => _driver.WaitElementVisible(SMCartBadge);
        public void ClickHmbgrMenu()
        {
            var element = _driver.WaitElementVisible(BtnMenuHmbgr);
            element.Click();
        }
        public void ClickCart()
        {
            var element = _driver.WaitElementVisible(BtnMenuCart);
            element.Click();
        }
        public void ClickSMItemsLink()
        {
            var element = _driver.WaitElementVisible(SMAllItems);
            element.Click();
        }
        public void ClickSMAboutLink()
        {
            var element = _driver.WaitElementVisible(SMAbout);
            element.Click();
        }
        public void ClickSMLogoutLink()
        {
            var element = _driver.WaitElementVisible(SMLogout);
            element.Click();
        }
        public void ClickSMRASLink()
        {
            var element = _driver.WaitElementVisible(SMResetAppState);
            element.Click();
        }
        public void ClickSMCloseBtn()
        {
            var element = _driver.WaitElementVisible(SMBtnClose);
            element.Click();
        }
        public string GetItemBadgeNumber()
        {
            var element = _driver.WaitElementVisible(SMCartBadge);
            var itemCount = element.Text;

            return itemCount;
        }
        public bool IsCartBadgePresent() => _driver.FindElements(SMCartBadge).Count > 0;
    }
}
