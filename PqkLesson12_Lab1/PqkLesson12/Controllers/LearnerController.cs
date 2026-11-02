using Lab4_MVC_EFCore.Data;
using Lab4_MVC_EFCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lab4_MVC_EFCore.Controllers;

public class LearnerController : Controller
{
    private readonly SchoolContext db;

    public LearnerController(SchoolContext context) => db = context;

    public async Task<IActionResult> Index(string? searchString, int? mid)
    {
        var query = db.Learners.Include(l => l.Major).AsQueryable();
        if (mid.HasValue) query = query.Where(l => l.MajorID == mid.Value);
        if (!string.IsNullOrWhiteSpace(searchString))
        {
            query = query.Where(l => l.FirstMidName.Contains(searchString) ||
                                     l.LastName.Contains(searchString) ||
                                     l.Major!.MajorName.Contains(searchString));
        }
        ViewData["CurrentFilter"] = searchString;
        return View(await query.OrderBy(l => l.LearnerID).ToListAsync());
    }

    public async Task<IActionResult> LearnerByMajorID(int mid)
    {
        var learners = await db.Learners.Where(l => l.MajorID == mid)
            .Include(l => l.Major).OrderBy(l => l.LearnerID).ToListAsync();
        return PartialView("LearnerTable", learners);
    }

    public IActionResult Create()
    {
        PopulateMajors();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("FirstMidName,LastName,MajorID,EnrollmentDate")] Learner learner)
    {
        if (ModelState.IsValid)
        {
            db.Learners.Add(learner);
            await db.SaveChangesAsync();
            TempData["Success"] = "Đã thêm người học thành công.";
            return RedirectToAction(nameof(Index));
        }
        PopulateMajors(learner.MajorID);
        return View(learner);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var learner = await db.Learners.FindAsync(id);
        if (learner == null) return NotFound();
        PopulateMajors(learner.MajorID);
        return View(learner);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("LearnerID,FirstMidName,LastName,MajorID,EnrollmentDate")] Learner learner)
    {
        if (id != learner.LearnerID) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                db.Update(learner);
                await db.SaveChangesAsync();
                TempData["Success"] = "Đã cập nhật người học thành công.";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await db.Learners.AnyAsync(e => e.LearnerID == learner.LearnerID)) return NotFound();
                throw;
            }
        }
        PopulateMajors(learner.MajorID);
        return View(learner);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var learner = await db.Learners.Include(l => l.Major).FirstOrDefaultAsync(l => l.LearnerID == id);
        if (learner == null) return NotFound();
        return View(learner);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var learner = await db.Learners.FindAsync(id);
        if (learner != null)
        {
            db.Learners.Remove(learner);
            await db.SaveChangesAsync();
            TempData["Success"] = "Đã xóa người học.";
        }
        return RedirectToAction(nameof(Index));
    }

    private void PopulateMajors(object? selectedMajor = null)
    {
        ViewBag.MajorID = new SelectList(db.Majors.OrderBy(m => m.MajorName), "MajorID", "MajorName", selectedMajor);
    }
}
