using System;
namespace ASPTesting.Models
{
    public class Product
    {
        public Product()
        {
        }
        //Adding properties that correspond w/ column names in bestbuy database:
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public int OnSale { get; set; }
        public int StockLevel { get; set; }
    }
}
