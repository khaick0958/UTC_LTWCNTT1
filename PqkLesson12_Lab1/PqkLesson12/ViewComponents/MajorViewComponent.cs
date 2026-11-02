using Lab4_MVC_EFCore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab4_MVC_EFCore.ViewComponents;

public class MajorViewComponent : ViewComponent
{
    private readonly SchoolContext db;
    public MajorViewComponent(SchoolContext context) => db = context;

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var majors = await db.Majors.OrderBy(m => m.MajorName).ToListAsync();
        return View("RenderMajor", majors);
    }
}
