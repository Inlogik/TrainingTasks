using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TrainingTasks5
{
    [TestFixture]
    public class LinqTests
    {
        [Test]
        public void find_all_products_that_are_out_of_stock()
        {
            var products = Data.GetProducts();

            Assert.AreEqual(5, products.Count());
        }

        [Test]
        public void find_all_products_that_are_in_stock_and_cost_more_than_3_per_unit()
        {
            var products = Data.GetProducts();

            Assert.AreEqual(71, products.Count());
        }

        [Test]
        public void find_the_sum_of_products()
        {
            var productsSum = Data.GetProducts();

            Assert.AreEqual(74050.85m, productsSum);
        }

        [Test]
        public void find_the_number_of_distinct_categories()
        {
            var distinctCats = Data.GetProducts();

            Assert.AreEqual(8, distinctCats.Count());
        }

        [Test]
        public void find_the_number_of_distinct_categories_another_way()
        {
            var distinctCats = Data.GetProducts();

            Assert.AreEqual(8, distinctCats.Count());
        }

        [Test]
        public void find_the_cheapest_product_with_the_category_Seafood_and_Beverages()
        {
            var products = Data.GetProducts();
            var categories = products.Select(x => new {x.Category, CheapestProduct = x}).ToList();

            Assert.AreEqual(2, categories.Count);
            Assert.AreEqual("Beverages", categories[0].Category);
            Assert.AreEqual("Seafood", categories[1].Category);
            Assert.AreEqual(24, categories[0].CheapestProduct.ProductID);
            Assert.AreEqual(13, categories[1].CheapestProduct.ProductID);
        }

        [Test]
        public void find_the_average_prices_of_seafood()
        {
            var productAv = Data.GetProducts().Average(x=>x.UnitPrice);

            Assert.AreEqual(20.6825m, productAv);
        }

        [Test]
        public void find_the_top_two_priced_products_in_separate_categories_by_unitprice()
        {
            var products = Data.GetProducts().Select(x => new
                                                              {
                                                                  Product = x,
                                                                  x.Category
                                                              }).ToList();

            Assert.AreEqual(38, products[0].Product.ProductID);
            Assert.AreEqual("Beverages", products[0].Category);
            Assert.AreEqual(29, products[1].Product.ProductID);
            Assert.AreEqual("Meat/Poultry", products[1].Category);
        }
    }
}
