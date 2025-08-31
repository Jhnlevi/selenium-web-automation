using SauceDemoTests.Pages.Product;
using SauceDemoTests.Utils;
using TestUtilities;

namespace SauceDemoTests.Tests.UI.Product
{
    public class ProductTests : BaseTest
    {
        private ProductPage _product;

        [SetUp]
        public override void SetUp()
        {
            // Setup basetest methods first
            base.SetUp();

            // Initialize ProductPage.
            _product = new ProductPage(_driver);

            // Navigate to SauceDemo Website
            ReportManager.LogInfo("Navigating to SauceDemo website.");
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/v1/");

            // Log in to the website
            ReportManager.LogInfo("Log in as standard user.");
            PreconditionFlow.LoginAsStandardUser(_driver, "standard_user", "secret_sauce");
        }

        //TC_Product_0001
        [Test]
        public void Product_VerifyProductList()
        {
            ReportManager.LogInfo("Verify that user can see product lists.");
            _product.ShouldDisplayProductList();
        }

        //TC_Product_0002
        [Test]
        public void Product_VerifyProductImage()
        {
            ReportManager.LogInfo("Verify that user can see the product's image.");
            _product.ShouldDisplayProductImage();
        }

        //TC_Product_0003
        [Test]
        public void Product_VerifyProductName()
        {
            ReportManager.LogInfo("Verify that user can see the product's name.");
            _product.ShouldDisplayProductName();
        }

        //TC_Product_0004
        [Test]
        public void Product_VerifyProductDescription()
        {
            ReportManager.LogInfo("Verify that user can see the product's description.");
            _product.ShouldDisplayProductDescription();
        }

        //TC_Product_0005
        [Test]
        public void Product_VerifyProductPrice()
        {
            ReportManager.LogInfo("Verify that user can see the product's price.");
            _product.ShouldDisplayProductDescription();
        }

        //TC_Product_0005, TC_Product_0008, TC_Product_0009, TC_Product_0010
        [TestCase("Name (A to Z)")]
        [TestCase("Name (Z to A)")]
        [TestCase("Price (low to high)")]
        [TestCase("Price (high to low)")]
        public void Product_SortProductLists(string options)
        {
            ReportManager.LogInfo("Verify that user can see the sort menu.");
            _product.ShouldDisplayProductSorter();

            ReportManager.LogInfo($"Verify that user can select '{options}' from the dropdown menu.");
            _product.SelectFromDropdown(options);

            Assert.That(_product.GetSelectedItem(), Is.EqualTo(options));
        }

        //TC_Product_0007
        [Test]
        public void Product_VerifyAddToCartButton()
        {
            ReportManager.LogInfo("Verify that user can see the add-to-cart button.");
            _product.ShouldDisplayProductAddToCart();
        }

        //TC_Product_0011
        [Test]
        public void Product_VerifyProductClickable()
        {
            ReportManager.LogInfo("Verify that user can click a product card to open product details.");
            _product.ClickProduct();

            ReportManager.LogInfo("Verify that user can see the product details page.");
            Assert.That(_driver.Url.Contains("inventory-item.html?id"));
        }
    }
}
