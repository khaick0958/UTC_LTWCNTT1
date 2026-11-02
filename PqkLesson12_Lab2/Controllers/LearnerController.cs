using Lab6_PhanTrang_Loc_TimKiem.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab6_PhanTrang_Loc_TimKiem.Controllers;

public class LearnerController : Controller
{
    private readonly LearnerStore _store;
    private const int PageSize = 3;
    public LearnerController(LearnerStore store) => _store = store;

    public IActionResult Index(string? major, string? search, int page = 1)
    {
        page = Math.Max(1, page);
        var query = _store.All().AsQueryable();
        if (!string.IsNullOrWhiteSpace(major)) query = query.Where(x => x.Major == major);
        if (!string.IsNullOrWhiteSpace(search)) query = query.Where(x => x.Name.Contains(search, StringComparison.OrdinalIgnoreCase) || x.Surname.Contains(search, StringComparison.OrdinalIgnoreCase));
        var total = query.Count();
        var pages = Math.Max(1, (int)Math.Ceiling(total / (double)PageSize));
        page = Math.Min(page, pages);
        ViewBag.Major = major ?? ""; ViewBag.Search = search ?? ""; ViewBag.Page = page; ViewBag.TotalPages = pages; ViewBag.TotalItems = total;
        return View(query.OrderBy(x => x.Id).Skip((page - 1) * PageSize).Take(PageSize).ToList());
    }

    [HttpGet] public IActionResult Create() => View(new Learner { EnrollDate = DateTime.Today, Major = "IT" });
    [HttpPost, ValidateAntiForgeryToken] public IActionResult Create(Learner learner) { if (!ModelState.IsValid) return View(learner); _store.Add(learner); return RedirectToAction(nameof(Index)); }
    [HttpGet] public IActionResult Edit(int id) { var item=_store.Find(id); return item is null ? NotFound() : View(item); }
    [HttpPost, ValidateAntiForgeryToken] public IActionResult Edit(Learner learner) { if (!ModelState.IsValid) return View(learner); _store.Update(learner); return RedirectToAction(nameof(Index)); }
    [HttpGet] public IActionResult Delete(int id) { var item=_store.Find(id); return item is null ? NotFound() : View(item); }
    [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken] public IActionResult DeleteConfirmed(int id) { _store.Delete(id); return RedirectToAction(nameof(Index)); }
}
