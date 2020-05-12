using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
//Controller handles a request and hands it to the correct View and Model
namespace ASPTesting.Controllers
{
    //Configuring the ProductController to View products:
    public class ProductController : Controller
    {
        private readonly IProductRepository repo;

        public ProductController(IProductRepository repo)
        {
            this.repo = repo;
        }

        // GET: /<controller>/
        //Index() here returns a View page of the same name (Index) with the
        //appropriate Model data (IEnumerable<Product>):
        public IActionResult Index()
        {
            var products = repo.GetAllProducts();

            return View(products);
        }

        //Enable user to View a product by entering its Product ID
        public IActionResult ViewProduct(int id)
        {
            var product = repo.GetProduct(id);

            return View(product);
        }
    }
}
