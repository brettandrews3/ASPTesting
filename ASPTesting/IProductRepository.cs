using System;
using System.Collections.Generic;
using Testing.Models;
namespace ASPTesting
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts(); //stubbed-out method to pull all products from bestbuy
    }
}
