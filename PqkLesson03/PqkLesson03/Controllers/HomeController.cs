using Microsoft.AspNetCore.Mvc;
using PqkLesson03.Models;
using System.Diagnostics;

namespace PqkLesson03.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["messageVD"] = "Hello world 1!";
            ViewBag.messageVB = "Hello world 2!";
            TempData["messageTD"] = "Hello world 3!";
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
