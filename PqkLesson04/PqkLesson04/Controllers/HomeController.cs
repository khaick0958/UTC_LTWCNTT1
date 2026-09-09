using Microsoft.AspNetCore.Mvc;
using PqkLesson04.Models;
using System.Diagnostics;

namespace PqkLesson04.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Category> categories = new List<Category>
            {
                new Category(1, "Áo dài"),
                new Category(2, "Áo đông"),
                new Category(3, "Túi xách"),
                new Category(4, "Đồng hồ"),
                new Category(5, "Ví da"),
                new Category(6, "Thắt lưng da"),
                new Category(7, "Tủ lạnh"),
                new Category(8, "Ti vi"),
                new Category(9, "Quạt điện"),
                new Category(10, "Lò sưởi")
            };

            List<Product> products = new List<Product>
            {
                new Product(1, "Nồi cơm điện tử cao tần 1.8 lít Coex CR-3460BG", "/img/cooker.jpg"),
                new Product(2, "Nồi cơm điện tử cao tần 1.8 lít Coex CR-3460BG", "/img/cooker.jpg"),
                new Product(3, "Nồi cơm điện tử cao tần 1.8 lít Coex CR-3460BG", "/img/cooker.jpg")
            };

            ViewBag.categories = categories;
            ViewBag.products = products;

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
