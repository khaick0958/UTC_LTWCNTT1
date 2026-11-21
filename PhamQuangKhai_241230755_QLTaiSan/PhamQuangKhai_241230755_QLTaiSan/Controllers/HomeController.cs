using Microsoft.AspNetCore.Mvc;
using PhamQuangKhai_241230755_QLTaiSan.Models;
using System.Diagnostics;

namespace PhamQuangKhai_241230755_QLTaiSan.Controllers
{
    public class HomeController : Controller
    {
        private readonly QltaiSanContext _db;
        public HomeController (QltaiSanContext db) { _db = db; }

        public IActionResult Index()
        {
            ViewBag.TieuDe = "Phạm Quang Khải";
            var ds = _db.TaiSans.Where(s => s.NguyenGia != null && s.NguyenGia >= 20).ToList();
            return View(ds);
        }

        public IActionResult TheoLoai(int id)
        {
            var lts = _db.LoaiTaiSans.Find(id);
            ViewBag.TieuDe = lts?.TenLoai;
            var ds = _db.TaiSans.Where(s => s.MaLoai == id).ToList();
            return PartialView("PhamQuangKhai_MainContent", ds);
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
