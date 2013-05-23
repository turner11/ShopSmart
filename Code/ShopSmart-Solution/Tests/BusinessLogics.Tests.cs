using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Rhino.Mocks;
//using NUnit.Mocks;
using ShopSmart.Dal;
using NSubstitute;
using ShopSmart.Bl;


namespace Tests
{
    /// <summary>
    /// Handles the tests for BusinessLogics class
    /// </summary>
    [TestFixture]
    public class SmartShopLogicsTests
    {
        #region Tests
        [Test]
        public void SortedGivenShopListTest()
        {

            //Assign
            Supermarket sm;
            List<Category> categories;
            List<Product> products;
            SmartShopLogicsTests.CreateDataBaseObjects(out sm, out categories, out products);

            ShopList list = new ShopList();
            #region Populating shopping list
            list.Supermarket = sm;
            list.SuperMarketId = sm.Id;
            for (int i = 0; i < products.Count; i++)
            {
                Product currProduct = products[i];
                ShoplistItem newItem = new ShoplistItem() { Product = currProduct, Quantity = i, ShopList = list };
                list.ShoplistItems.Add(newItem);
            }
            #endregion


            //act
            DataBase dataBase = Substitute.For<DataBase>();
            SmartShopLogics bs = new SmartShopLogics(dataBase);
            ShopList sorted = bs.GetSortedList(list);

            //assert
            int lastCategoryId = -1;
            for (int i = 0; i < sorted.ShoplistItems.Count; i++)
            {
                List<ShoplistItem> items = sorted.ShoplistItems.ToList();
                int currCategory = items[i].Product.Category.CategorySorts.Where(cat => cat.Supermarket == sm).SingleOrDefault().SortValue;
                //If list is sorted, the sort value should always increase
                Assert.IsTrue(currCategory >= lastCategoryId, "Shopping list was not sorted properly");
                lastCategoryId = currCategory;

            }

        }

        [Test]
        public void GetAllProductsFromDbTest()
        {
            DataBase dataBase = Substitute.For<DataBase>();

            //Assign
            Supermarket sm;
            List<Category> categories;
            List<Product> products;
            SmartShopLogicsTests.CreateDataBaseObjects(out sm, out categories, out products);

            dataBase.GetAllProducts().Returns(products);
            SmartShopLogics bs = new SmartShopLogics(dataBase);

            int expectedProducts = products.Count;

            //act
            int actualNumberOfProducts = bs.GetAllProducts().Count;

            //assert
            Assert.IsTrue(expectedProducts == actualNumberOfProducts, "Got unexpected number of products");
        }

        [Test]
        public void GetAllCategoriesFromDbTest()
        {
            DataBase dataBase = Substitute.For<DataBase>();

            //Assign
            Supermarket sm;
            List<Category> categories;
            List<Product> products;
            SmartShopLogicsTests.CreateDataBaseObjects(out sm, out categories, out products);

            dataBase.GetAllCategories().Returns(categories);
            SmartShopLogics bs = new SmartShopLogics(dataBase);

            int expected = categories.Count;

            //act
            int actual = bs.GetAllCategories().Count;

            //assert
            Assert.IsTrue(expected == actual, "Got unexpected number of categories");
        }

        [Test]
        public void GetAllSuperMarketsFromDbTest()
        {
            DataBase dataBase = Substitute.For<DataBase>();

            //Assign
            Random rnd = new Random(1);
            int expected = rnd.Next(1000);

            List<Supermarket> superMarkets = new List<Supermarket>();
            for (int i = 0; i < expected; i++)
            {
                Supermarket sm = new Supermarket() { Id = i, Name = "Supermarket " + i };
                superMarkets.Add(sm);
            }


            dataBase.GetAllSuperMarkets().Returns(superMarkets);
            SmartShopLogics bs = new SmartShopLogics(dataBase);

            expected = superMarkets.Count;

            //act
            int actual = bs.GetAllSuperMarkets().Count;

            //assert
            Assert.IsTrue(expected == actual, "Got unexpected number of superMarkets");
        } 
        #endregion
        
        #region Helper methods
        /// <summary>
        /// Creates the data base objects for varois tests...
        /// </summary>
        /// <param name="superMarket">The out argument for superMarket.</param>
        /// <param name="categories">The out argument for categories.</param>
        /// <param name="products">The out argument for products.</param>
        private static void CreateDataBaseObjects(out Supermarket superMarket, out List<Category> categories, out List<Product> products)
        {
            superMarket = new Supermarket() { Name = "SuperMarket", Id = 1 };
            #region Creating categories


            //vegtables
            Category vegetables = SmartShopLogicsTests.CreateCategory(superMarket, "vegetables", 1);
            //dairy
            Category dairy = SmartShopLogicsTests.CreateCategory(superMarket, "dairy", 5);
            //bakery
            Category bakery = SmartShopLogicsTests.CreateCategory(superMarket, "bakery", 9);

            categories = new List<Category> { vegetables, dairy, bakery };
            #endregion

            products = new List<Product>
                                            {
                                               #region Creating products
		                                        new Product
                                                {
                                                    ProductName="Bread",
                                                    Category = bakery
                                                },  new Product
                                                {
                                                    ProductName="Milk",
                                                    Category = dairy
                                                },  new Product
                                                {
                                                    ProductName="Pita",
                                                    Category = bakery
                                                },  new Product
                                                {
                                                    ProductName="Tomato",
                                                    Category = vegetables
                                                },  new Product
                                                {
                                                    ProductName="Onion",
                                                    Category = vegetables
                                                },  new Product
                                                {
                                                    ProductName="Cream",
                                                    Category = dairy
                                                } 
                
	                            #endregion
                                            };
        }
        /// <summary>
        /// Creates a category.
        /// </summary>
        /// <param name="supermarket">The Supermarket that the category sort will be for.</param>
        /// <param name="catName">Name of the category.</param>
        /// <param name="sortValue">The sort value for category.</param>
        /// <returns>the category with a sort value for specified supermarket</returns>
        private static Category CreateCategory(Supermarket supermarket, string catName, int sortValue)
        {
            //creating the category
            Category cat = new Category() { Name = catName };
            //creating the sort
            CategorySort catSort = new CategorySort() { Category = cat, Supermarket = supermarket, SortValue = sortValue, SupermarketId = supermarket.Id };
            //assigning the sort
            cat.CategorySorts.Add(catSort);
            return cat;
        } 
        #endregion
    }
}
