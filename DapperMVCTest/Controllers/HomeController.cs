using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DapperMVCTest.Models;
// These are the using statements you will need
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace DapperMVCTest.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // REMEMBER to add the two Nuget packages: Dapper and System.Data.SqlClient
        // Remember the using statements above

        public IActionResult Test()
        {
            IDbConnection db = new SqlConnection("Server=.;Database=Northwind;user id=sa;password=abc123;");
            db.Open();
            List<Categories> cats = db.Query<Categories>("select * from Categories").AsList<Categories>();
            db.Close();

            return View(cats);

        }

        public IActionResult Category(int catid)
        {
            IDbConnection db = new SqlConnection("Server=.;Database=Northwind;user id=sa;password=abc123;");
            db.Open();
            Categories cat = db.QuerySingle<Categories>($"select * from Categories where CategoryID = {catid}");
            db.Close();

            return View(cat);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
