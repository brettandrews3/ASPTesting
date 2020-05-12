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
    }
}
