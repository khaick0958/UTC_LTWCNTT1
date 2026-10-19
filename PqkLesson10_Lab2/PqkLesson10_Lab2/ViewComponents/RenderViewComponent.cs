using BaiThucHanh2.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiThucHanh2.ViewComponents;

// Tên component là "Render" vì tên lớp kết thúc bằng ViewComponent.
public class RenderViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var menuItems = new List<MenuItem>
        {
            new() { Id = 1, Name = "Branches", Link = "/Home/Privacy" },
            new() { Id = 2, Name = "Students", Link = "/Student/Index" },
            new() { Id = 3, Name = "Subjects", Link = "/Home/Privacy" },
            new() { Id = 4, Name = "Courses", Link = "/Home/Privacy" }
        };
        return View("RenderLeftMenu", menuItems);
    }
}
