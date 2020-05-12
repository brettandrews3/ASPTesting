using System;
using System.Collections.Generic;
using System.Data;
using ASPTesting.Models;
using Dapper;

namespace ASPTesting
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;

        public ProductRepository(IDbConnection conn)
        {
            //Send public data "conn" through to private connection "_conn"
            _conn = conn; 
        }

        //Create method GetAllProducts() to use Dapper to query bestbuy, return
        //collection of Product via IEnumerable
        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM Products;");
        }

        //Pull a single product by calling its Product ID
        public Product GetProduct(int id)
        {
            return (Product)_conn.QuerySingle<Product>("SELECT * FROM Products WHERE ProductID = @id;",
                new { id });
        }

        //Update a product from bestbuy by calling its Product ID
        public void UpdateProduct(Product product)
        {
            //Pass the update through secured connection _conn to update database
            _conn.Execute("UPDATE Products SET Name = @name, Price = @price, WHERE ProductID = @id;",
                new { name = product.Name, price = product.Price, id = product.ProductID });
        }

        //Insert(), Get(), Assign() all work to CREATE a new product in bestbuy
        //Create a product in bestbuy by adding it on the webpage
        public void InsertProduct(Product productToInsert)
        {
            _conn.Execute("INSERT INTO Products (NAME, PRICE, CATEGORYID) VALUES (@name, @price, @categoryID);",
                new { name = productToInsert.Name, price = productToInsert.Price, categoryID = productToInsert.CategoryID });
        }

        //Implement the GetCategories() from IProductRepository
        public IEnumerable<Category> GetCategories()
        {
            return _conn.Query<Category>("SELECT * FROM categories;");
        }

        //Implement the AssignCategory() from IProductRepository
        public Product AssignCategory()
        {
            var categoryList = GetCategories();
            var product = new Product();
            product.Categories = categoryList;

            return product;
        }
    }
}
