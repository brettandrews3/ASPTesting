using System;
using System.Collections.Generic;

namespace ASPTesting.Models
{
    public class Product
    {
        public Product() //Define a new variable type: Product
        {
        }
        //Adding properties that correspond w/ column names in bestbuy database:
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public int OnSale { get; set; }
        public int StockLevel { get; set; }
        //Allow for Categories to be set now:
        public IEnumerable<Category> Categories { get; set; }
    }
}
