using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SauceDemoTests.Utils;

namespace SauceDemoTests.Pages.Product
{
    public class ProductPage
    {
        // Fields
        private readonly IWebDriver _driver;

        // Locator
        private By ListProducts = By.CssSelector(".inventory_list");
        private By ProdCard = By.CssSelector(".inventory_item");
        private By ProdImg = By.CssSelector(".inventory_item_img");
        private By ProdName = By.CssSelector(".inventory_item_name");
        private By ProdDesc = By.CssSelector(".inventory_item_desc");
        private By ProdPrice = By.CssSelector(".inventory_item_price");
        private By ProdSort = By.CssSelector(".product_sort_container");
        private By BtnAddToCart = By.CssSelector(".btn_primary.btn_inventory");
        private By BtnRmvToCart = By.CssSelector(".btn_secondary.btn_inventory");

        // Constructor
        public ProductPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Actions
        public void ShouldDisplayProductList() => _driver.WaitForElementVisible(ListProducts);
        public void ShouldDisplayProductImage() => _driver.WaitForElementVisible(ProdImg);
        public void ShouldDisplayProductName() => _driver.WaitForElementVisible(ProdName);
        public void ShouldDisplayProductDescription() => _driver.WaitForElementVisible(ProdDesc);
        public void ShouldDisplayProductPrice() => _driver.WaitForElementVisible(ProdPrice);
        public void ShouldDisplayProductSorter() => _driver.WaitForElementVisible(ProdSort);
        public void ShouldDisplayProductAddToCart() => _driver.WaitForElementVisible(BtnAddToCart);
        public void ClickProduct()
        {
            var element = _driver.WaitForElementVisible(ProdName);
            element.Click();
        }
        // Select an item from the dropdown
        public void SelectFromDropdown(string itemName)
        {
            var element = _driver.WaitForElementVisible(ProdSort);
            var select = new SelectElement(element);
            select.SelectByText(itemName);
        }
        // Get the current item from the dropdown
        public string GetSelectedItem()
        {
            var element = _driver.WaitForElementVisible(ProdSort);
            var select = new SelectElement(element);
            return select.SelectedOption.Text;
        }
        public void ClickAddToCart()
        {
            var element = _driver.WaitForElementVisible(BtnAddToCart);
            element.Click();
        }
        public void ClickRemoveToCart()
        {
            var element = _driver.WaitForElementVisible(BtnRmvToCart);
            element.Click();
        }
    }
}
