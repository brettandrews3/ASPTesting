using System;
using System.Collections.Generic;
using ASPTesting.Models;
namespace ASPTesting
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts(); //stubbed-out method to pull all products from bestbuy
        public Product GetProduct(int id); //View one product from bestbuy
    }
}
