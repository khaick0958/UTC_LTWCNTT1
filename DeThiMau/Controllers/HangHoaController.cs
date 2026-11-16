using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLHangHoaMVC.Data;
using QLHangHoaMVC.Models;

namespace QLHangHoaMVC.Controllers;

public class HangHoaController(QLHangHoaContext db, IConfiguration configuration) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        await NapDuLieuForm();
        return View(new HangHoa());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(HangHoa model)
    {
        if (!ModelState.IsValid)
        {
            await NapDuLieuForm(model.MaLoai);
            return View(model);
        }

        db.HangHoas.Add(model);
        await db.SaveChangesAsync();
        TempData["ThongBao"] = "Đã thêm hàng hóa thành công.";
        return RedirectToAction("Index", "Home");
    }

    private async Task NapDuLieuForm(int? selected = null)
    {
        ViewBag.LoaiHangs = await db.LoaiHangs.OrderBy(x => x.MaLoai).ToListAsync();
        ViewBag.MaLoai = new SelectList(ViewBag.LoaiHangs, "MaLoai", "TenLoai", selected);
        ViewBag.StudentName = configuration["Student:FullName"] ?? "Họ tên sinh viên";
    }
}
