using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WalkingWithStyle.Mvc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Forms;
using WalkingWithStyle.Mvc;
using WalkingWithStyle.Mvc.Data;
using System.Collections.Generic;

namespace WalkingWithStyle.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private object _dbContext;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new ProductsViewModel();
            model.Products = GetProductsFromDatabase();  
            return View(model); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Shoes()
        {
            return View();
        }

        private List<Product> GetProductsFromDatabase()
        {
            return Products.ToString().Split(',').ToList();
        }

        public IActionResult ProductDetail(int id)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
