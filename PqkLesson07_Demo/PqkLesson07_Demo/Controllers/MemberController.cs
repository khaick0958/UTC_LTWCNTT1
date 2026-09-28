using Microsoft.AspNetCore.Mvc;
using PqkLesson07_Demo.Models.DataModels;
using PqkLesson07_Demo.Models.ViewModels;

namespace PqkLesson07_Demo.Controllers
{
    public class MemberController : Controller
    {
        public static readonly List<Member> members = new List<Member>();

        public IActionResult Index()
        {
            ViewBag.members = members;
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                Member m = new Member
                {
                    Id = Guid.NewGuid().ToString(),
                    Username = register.Username,
                    Email = register.Email,
                    SDT = register.SDT,
                    NgaySinh = register.NgaySinh
                };

                members.Add(m);
                return RedirectToAction("Index");
            }
            else
            {
                return View(register);
            }
        }
    }
}
