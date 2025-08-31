using OpenQA.Selenium;
using SauceDemoTests.Pages.MenuBar;
using SauceDemoTests.Utils;

namespace SauceDemoTests.Tests.MenuBar
{
    public class MenuBarTests : BaseTest
    {
        private MenuBarPage _menuBar;

        [SetUp]
        public override void SetUp()
        {
            // Setup basetest methods first.
            base.SetUp();

            // Initialize ProductPage.
            _menuBar = new MenuBarPage(_driver);

            // Navigate to SauceDemo Website.
            _test.Info("Navigating to SauceDemo website.");
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/v1/");

            // Log in to the website.
            _test.Info("Log in as standard user.");
            PreconditionFlow.LoginAsStandardUser(_driver, "standard_user", "secret_sauce");
        }

        //TC_Menu-Bar_0001
        [Test]
        public void Menu_VerifyHamburgerIcon()
        {
            _test.Info("Verify that user can see the hamburger menu icon.");
            _menuBar.ShouldDisplayMenuHmbgr();
        }

        //TC_Menu-Bar_0002
        [Test]
        public void Menu_VerifyShoppingCartIcon()
        {
            _test.Info("Verify that user can see the shopping cart menu icon.");
            _menuBar.ShouldDisplayMenuShpngCart();
        }

        //TC_Menu-Bar_0003
        [Test]
        public void Menu_VerifyHeaderLogo()
        {
            _test.Info("Verify that user can see the company logo in the header bar.");
            _menuBar.ShouldDisplayMenuLogo();
        }

        // No test case created to for this.
        [Test]
        public void Menu_VerifySideMenu()
        {
            _test.Info("Clicking the hamburger icon.");
            _menuBar.ClickHmbgrMenu();

            _test.Info("Verify that user can see the side menu.");
            _menuBar.ShouldDisplaySideMenu();
        }

        //TC_Menu_0001
        [Test]
        public void SideMenu_VerifyAllItemsButton()
        {
            _test.Info("Clicking the hamburger icon.");
            _menuBar.ClickHmbgrMenu();

            _test.Info("Verify that user can see 'All Items' link in the side menu.");
            _menuBar.ShouldDisplayAllItemsLink();
        }

        //TC_Menu_0002
        [Test]
        public void SideMenu_VerifyAboutButton()
        {
            _test.Info("Clicking the hamburger icon.");
            _menuBar.ClickHmbgrMenu();

            _test.Info("Verify that user can see 'About' link in the side menu.");
            _menuBar.ShouldDisplayAboutLink();
        }

        //TC_Menu_0003
        [Test]
        public void SideMenu_VerifyLogoutButton()
        {
            _test.Info("Clicking the hamburger icon.");
            _menuBar.ClickHmbgrMenu();

            _test.Info("Verify that user can see 'Logout' link in the side menu.");
            _menuBar.ShouldDisplayLogoutLink();
        }

        //TC_Menu_0004
        [Test]
        public void SideMenu_VerifyRASButton()
        {
            _test.Info("Clicking the hamburger icon.");
            _menuBar.ClickHmbgrMenu();

            _test.Info("Verify that user can see 'Reset App State' link in the side menu.");
            _menuBar.ShouldDisplayAppStateLink();
        }

        //TC_Menu_0005
        [Test]
        public void SideMenu_VerifyCloseButton()
        {
            _test.Info("Clicking the hamburger icon.");
            _menuBar.ClickHmbgrMenu();

            _test.Info("Verify that user can see 'X' close button in the side menu.");
            _menuBar.ShouldDisplaySMCloseButton();
        }

        // No test case created to for this.
        [Test]
        public void SideMenu_VerifyClosingOfSideMenu()
        {
            _test.Info("Clicking the hamburger icon.");
            _menuBar.ClickHmbgrMenu();

            _test.Info("Clicking the side menu close button.");
            _menuBar.ClickSMCloseBtn();

            // Getting the X-axis of side menu
            var sideMenu = _driver.FindElement(By.CssSelector(".bm-menu-wrap"));
            string style = sideMenu.GetAttribute("style");

            Assert.That(style.Contains("translate3d(-100%, 0px, 0px)"), "The side menu should be hidden off screen.");
        }

        // No test case created to for this.
        [Test]
        public void SideMenu_VerifyClickingAllItemsLink()
        {
            _test.Info("Clicking the hamburger icon.");
            _menuBar.ClickHmbgrMenu();

            _test.Info("Clicking the side menu 'All Items' link.");
            _menuBar.ClickSMItemsLink();

            Assert.That(_driver.Url.Contains("inventory"), Is.True);
        }

        // No test case created to for this.
        [Test]
        public void SideMenu_VerifyClickingAboutLink()
        {
            _test.Info("Clicking the hamburger icon.");
            _menuBar.ClickHmbgrMenu();

            _test.Info("Clicking the side menu 'About' link.");
            _menuBar.ClickSMAboutLink();

            Assert.That(_driver.Url.Contains("saucelabs"), Is.True);
        }

        // No test case created to for this.
        [Test]
        public void SideMenu_VerifyClickingLogoutLink()
        {
            _test.Info("Clicking the hamburger icon.");
            _menuBar.ClickHmbgrMenu();

            _test.Info("Clicking the side menu 'Logout' link.");
            _menuBar.ClickSMLogoutLink();

            Assert.That(_driver.Url.Contains("index"), Is.True);
        }

        // No test case created to for this.
        [Test]
        public void SideMenu_VerifyClickingRASLink()
        {
            _test.Info("Clicking the hamburger icon.");
            _menuBar.ClickHmbgrMenu();

            _test.Info("Clicking the side menu 'Reset App State' link.");
            _menuBar.ClickSMRASLink();
        }
    }
}
