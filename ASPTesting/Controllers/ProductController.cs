using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPTesting.Models;
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

        //Enable user to update a product by using its Product ID
        public IActionResult UpdateProduct(int id)
        {
            Product prod = repo.GetProduct(id);

            repo.UpdateProduct(prod);

            //If a product is there, View it. If no product, then ERROR msg
            if(prod == null)
            {
                return View("ProductNotFound");
            }
            return View(prod);
        }

        //Update product to bestbuy database
        public IActionResult UpdateProductToDatabase(Product product)
        {
            repo.UpdateProduct(product);

            return RedirectToAction("ViewProduct", new { id = product.ProductID });
        }

        //(1)Create product by using the webpage
        public IActionResult InsertProduct()
        {
            var prod = repo.AssignCategory();

            return View(prod);
        }

        //(2)Insert new product from webpage into bestbuy database
        public IActionResult InsertProductToDatabase(Product productToInsert)
        {
            repo.InsertProduct(productToInsert);

            return RedirectToAction("Index");
        }

        //Delete product from webpage and bestbuy database
        public IActionResult DeleteProduct(Product product)
        {
            repo.DeleteProduct(product);

            return RedirectToAction("Index");
        }
    }
}
