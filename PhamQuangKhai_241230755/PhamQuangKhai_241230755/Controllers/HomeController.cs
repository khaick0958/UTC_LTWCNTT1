using Microsoft.AspNetCore.Mvc;
using PhamQuangKhai_241230755.Models;
using System.Diagnostics;

namespace PhamQuangKhai_241230755.Controllers
{
    public class HomeController : Controller
    {
        private readonly QlnhaSachContext _db;
        public HomeController(QlnhaSachContext db) { _db = db; }

        public IActionResult Index()
        {
            ViewBag.TieuDe = "Phạm Quang Khải";
            var ds = _db.Saches.Where(s => s.Gia != null && s.Gia >= 100).ToList();
            return View(ds);
        }

        public IActionResult TheoTheLoai(int id)
        {
            var tl = _db.TheLoais.Find(id);
            ViewBag.TieuDe = tl?.TenTl;
            var ds = _db.Saches.Where(s => s.MaTl == id).ToList();
            return PartialView("PhamQuangKhai_MainContent", ds);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
