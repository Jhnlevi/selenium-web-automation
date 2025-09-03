using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestUtilities;

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
        public void ShouldDisplayProductList() => _driver.WaitForElementToBeVisible(ListProducts);
        public void ShouldDisplayProductImage() => _driver.WaitForElementToBeVisible(ProdImg);
        public void ShouldDisplayProductName() => _driver.WaitForElementToBeVisible(ProdName);
        public void ShouldDisplayProductDescription() => _driver.WaitForElementToBeVisible(ProdDesc);
        public void ShouldDisplayProductPrice() => _driver.WaitForElementToBeVisible(ProdPrice);
        public void ShouldDisplayProductSorter() => _driver.WaitForElementToBeVisible(ProdSort);
        public void ShouldDisplayProductAddToCart() => _driver.WaitForElementToBeVisible(BtnAddToCart);
        public void ClickProduct()
        {
            var element = _driver.WaitForElementToBeVisible(ProdName);
            element.Click();
        }
        // Select an item from the dropdown
        public void SelectFromDropdown(string itemName)
        {
            var element = _driver.WaitForElementToBeVisible(ProdSort);
            var select = new SelectElement(element);
            select.SelectByText(itemName);
        }
        // Get the current item from the dropdown
        public string GetSelectedItem()
        {
            var element = _driver.WaitForElementToBeVisible(ProdSort);
            var select = new SelectElement(element);
            return select.SelectedOption.Text;
        }
        public void ClickAddToCart()
        {
            var element = _driver.WaitForElementToBeVisible(BtnAddToCart);
            element.Click();
        }
        public void ClickRemoveToCart()
        {
            var element = _driver.WaitForElementToBeVisible(BtnRmvToCart);
            element.Click();
        }
        public string GetAddToCartBtnText()
        {
            var element = _driver.WaitForElementToBeVisible(BtnAddToCart);
            return element.Text;
        }
        public string GetRemoveFromCartBtnText()
        {
            var element = _driver.WaitForElementToBeVisible(BtnRmvToCart);
            return element.Text;
        }
        public void AddItemsToCart(int numberOfItems)
        {
            var elements = _driver.WaitForElementsToBeVisible(BtnAddToCart);

            for (int i = 0; i < numberOfItems; i++)
            {
                ReportManager.LogInfo("Clicking 'Add to Cart' button.");
                elements.ElementAt(i).Click();
            }
        }
        public void RemoveItemsToCart(int currentItemCount, int numberOfItems)
        {
            var elements = _driver.WaitForElementsToBeVisible(BtnRmvToCart);
            for (int i = currentItemCount - 1; i > numberOfItems; i--)
            {
                ReportManager.LogInfo("Clicking 'Remove' button.");
                elements.ElementAt(i).Click();
            }
        }
        public bool VerifyAllImagesAreLoaded()
        {
            var element = _driver.WaitForElementsToBeVisible(ProdImg);

            foreach (var image in element)
            {
                var result = ((IJavaScriptExecutor)_driver).ExecuteScript("return arguments[0].naturalWidth;", image);
                Console.WriteLine(result);
                var width = Convert.ToInt64(result);

                if (width == 0)
                    return false;
            }
            return true;
        }
    }
}
