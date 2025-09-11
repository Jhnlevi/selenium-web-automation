using OpenQA.Selenium;
using OrangeHRMTests.Constants;

namespace OrangeHRMTests.Pages.Menu
{
    internal class Menu_Page : BasePage
    {
        // Dictionary for all elements.
        private readonly Dictionary<string, By> _elements;
        public Menu_Page(IWebDriver driver) : base(driver)
        {
            _elements = new Dictionary<string, By>
            {
                { Fields_Menu.Admin, AdminMenuItem },
                { Fields_Menu.PIM, PIMMenuItem },
                { Fields_Menu.Leave, LeaveMenuItem },
                { Fields_Menu.MyInfo, MyInfoMenuItem },
                { Fields_Menu.Dashboard, DashboardMenuItem }
            };
        }

        private By AdminMenuItem = By.CssSelector("ul.oxd-main-menu a.oxd-main-menu-item[href=\'/web/index.php/admin/viewAdminModule\']");
        private By PIMMenuItem = By.CssSelector("ul.oxd-main-menu a.oxd-main-menu-item[href=\'/web/index.php/pim/viewPimModule\']");
        private By LeaveMenuItem = By.CssSelector("ul.oxd-main-menu a.oxd-main-menu-item[href=\'/web/index.php/leave/viewLeaveModule\']");
        private By MyInfoMenuItem = By.CssSelector("ul.oxd-main-menu a.oxd-main-menu-item[href=\'/web/index.php/pim/viewMyDetails\']");
        private By DashboardMenuItem = By.CssSelector("ul.oxd-main-menu a.oxd-main-menu-item[href=\'/web/index.php/dashboard/index\']");

        public void ClickElement(string fieldName) => Click(_elements[fieldName]);

    }
}

