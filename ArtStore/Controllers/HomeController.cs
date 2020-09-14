using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetStore.Models;

namespace PetStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            /*Product prod = Product.Create("Kitty Litter", 13.95m);
            return Content($"{prod.id} {prod.Name} {prod.Price}");*/


            /*Product prod = Product.Read(2);
            prod.Price = 19.00m;
            prod.Save();
            return Content($"{prod.id} {prod.Name} {prod.Price}");*/

            /*Product.Delete(5);
            return Content("OK");*/


            /*List<Product> prods = Product.Read();
            return Content(prods.Count.ToString());
            */
            return View();
        }

        public IActionResult Privacy()
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
