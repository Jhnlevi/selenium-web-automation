using OpenQA.Selenium;

namespace OrangeHRMTests.Pages.TopBar
{
    internal class Header_Page : BasePage
    {
        public Header_Page(IWebDriver driver) : base(driver) { }

        private By UserDropdownMenu = By.CssSelector(".oxd-userdropdown-tab");
        private By BtnLogout = By.CssSelector("ul.oxd-dropdown-menu a.oxd-userdropdown-link[href=\'/web/index.php/auth/logout\']");

        public void ClickUserDropdown() => Click(UserDropdownMenu);
        public void ClickLogoutButton() => Click(BtnLogout);
    }
}
