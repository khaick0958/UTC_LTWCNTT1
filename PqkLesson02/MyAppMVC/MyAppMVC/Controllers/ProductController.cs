using Microsoft.AspNetCore.Mvc;
using MyAppMVC.Models;
using System.Diagnostics;

namespace MyAppMVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult IndexProduct()
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
