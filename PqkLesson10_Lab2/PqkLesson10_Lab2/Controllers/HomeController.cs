using Microsoft.AspNetCore.Mvc;

namespace BaiThucHanh2.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => RedirectToAction("Index", "Student");
    public IActionResult Privacy() => View();
    public IActionResult Error() => View("Error");
}
