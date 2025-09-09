using OpenQA.Selenium;

namespace OrangeHRMTests.Pages.Menu
{
    internal class NavigationMenuPage : BasePage
    {
        public NavigationMenuPage(IWebDriver driver) : base(driver) { }

        private By AdminMenuItem = By.CssSelector("ul.oxd-main-menu a.oxd-main-menu-item[href=\'/web/index.php/admin/viewAdminModule\']");
        private By PIMMenuItem = By.CssSelector("ul.oxd-main-menu a.oxd-main-menu-item[href=\'/web/index.php/pim/viewPimModule\']");
        private By LeaveMenuItem = By.CssSelector("ul.oxd-main-menu a.oxd-main-menu-item[href=\'/web/index.php/leave/viewLeaveModule\']");
        private By MyInfoMenuItem = By.CssSelector("ul.oxd-main-menu a.oxd-main-menu-item[href=\'/web/index.php/pim/viewMyDetails\']");
        private By DashboardMenuItem = By.CssSelector("ul.oxd-main-menu a.oxd-main-menu-item[href=\'/web/index.php/dashboard/index\']");

        public void ClickAdmin() => Click(AdminMenuItem);
        public void ClickPIM() => Click(PIMMenuItem);
        public void ClickLeave() => Click(LeaveMenuItem);
        public void ClickInfo() => Click(MyInfoMenuItem);
        public void ClickDashboard() => Click(DashboardMenuItem);

    }
}

