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
        public void ShouldDisplayMenuHmbgr() => _driver.WaitForElementToBeVisible(BtnMenuHmbgr);
        public void ShouldDisplayMenuShpngCart() => _driver.WaitForElementToBeVisible(BtnMenuCart);
        public void ShouldDisplayMenuLogo() => _driver.WaitForElementToBeVisible(MenuAppLogo);
        public void ShouldDisplaySideMenu() => _driver.WaitForElementToBeVisible(SideMenu);
        public void ShouldDisplayAllItemsLink() => _driver.WaitForElementToBeVisible(SMAllItems);
        public void ShouldDisplayAboutLink() => _driver.WaitForElementToBeVisible(SMAbout);
        public void ShouldDisplayLogoutLink() => _driver.WaitForElementToBeVisible(SMLogout);
        public void ShouldDisplayAppStateLink() => _driver.WaitForElementToBeVisible(SMResetAppState);
        public void ShouldDisplaySMCloseButton() => _driver.WaitForElementToBeVisible(SMBtnClose);
        public void ShouldDisplayShoppingCartbadge() => _driver.WaitForElementToBeVisible(SMCartBadge);
        public void ClickHmbgrMenu()
        {
            var element = _driver.WaitForElementToBeVisible(BtnMenuHmbgr);
            element.Click();
        }
        public void ClickCart()
        {
            var element = _driver.WaitForElementToBeVisible(BtnMenuCart);
            element.Click();
        }
        public void ClickSMItemsLink()
        {
            var element = _driver.WaitForElementToBeVisible(SMAllItems);
            element.Click();
        }
        public void ClickSMAboutLink()
        {
            var element = _driver.WaitForElementToBeVisible(SMAbout);
            element.Click();
        }
        public void ClickSMLogoutLink()
        {
            var element = _driver.WaitForElementToBeVisible(SMLogout);
            element.Click();
        }
        public void ClickSMRASLink()
        {
            var element = _driver.WaitForElementToBeVisible(SMResetAppState);
            element.Click();
        }
        public void ClickSMCloseBtn()
        {
            var element = _driver.WaitForElementToBeVisible(SMBtnClose);
            element.Click();
        }
        public string GetItemBadgeNumber()
        {
            var element = _driver.WaitForElementToBeVisible(SMCartBadge);
            var itemCount = element.Text;

            return itemCount;
        }
        public bool IsCartBadgePresent() => _driver.FindElements(SMCartBadge).Count > 0;
    }
}
