using System;
using System.Collections.Generic;
using ASPTesting.Models;
namespace ASPTesting
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts(); //stubbed-out method to pull all products from bestbuy
        public Product GetProduct(int id); //View one product from bestbuy
        public void UpdateProduct(Product product); //Update a product from bestbuy

        public void InsertProduct(Product productToInsert); //Insert new product in bestbuy database
        public IEnumerable<Category> GetCategories(); //Get the categories used in bestbuy
        public Product AssignCategory(); //Assign category to new product
    }
}
