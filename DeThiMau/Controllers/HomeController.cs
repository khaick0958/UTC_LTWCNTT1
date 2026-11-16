using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLHangHoaMVC.Data;

namespace QLHangHoaMVC.Controllers;

public class HomeController(QLHangHoaContext db, IConfiguration configuration) : Controller
{
    private string StudentName => configuration["Student:FullName"] ?? "Họ tên sinh viên";

    public async Task<IActionResult> Index()
    {
        await NapDanhMuc();
        ViewBag.StudentName = StudentName;
        var ds = await db.HangHoas.Include(x => x.LoaiHang)
            .Where(x => x.Gia >= 100)
            .OrderBy(x => x.MaHang).ToListAsync();
        return View(ds);
    }

    [HttpGet]
    public async Task<IActionResult> TheoLoai(int id)
    {
        var ds = await db.HangHoas.Include(x => x.LoaiHang)
            .Where(x => x.MaLoai == id && x.Gia >= 100)
            .OrderBy(x => x.MaHang).ToListAsync();
        return PartialView("~/Views/Shared/_DanhSachHangHoa.cshtml", ds);
    }

    private async Task NapDanhMuc()
    {
        ViewBag.LoaiHangs = await db.LoaiHangs.OrderBy(x => x.MaLoai).ToListAsync();
    }

    public IActionResult Error() => View();
}
