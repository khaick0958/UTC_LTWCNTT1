using Microsoft.AspNetCore.Mvc;
using PqkLesson06.Models.DataModels;

namespace PqkLesson06.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            var member = new Member();

            member.MemberID = "001";
            member.Username = "admin";
            member.Fullname = "EXAMPLE";
            member.Password = "UTC2026";
            member.Email = "test@example.com";

            //ViewBag.member = member;

            return View(member);
        }

        public static readonly List<Member> members = new List<Member>()
        {
            new Member{MemberID = "001", Username = "A", Fullname = "AAA", Password = "Test1", Email = "Test1@example.com"},
            new Member{MemberID = "002", Username = "B", Fullname = "BBB", Password = "Test2", Email = "Test2@example.com"},
            new Member{MemberID = "003", Username = "C", Fullname = "CCC", Password = "Test3", Email = "Test3@example.com"},
            new Member{MemberID = "004", Username = "D", Fullname = "DDD", Password = "Test4", Email = "Test4@example.com"},
            new Member{MemberID = "005", Username = "E", Fullname = "EEE", Password = "Test5", Email = "Test5@example.com"}
        };

        public IActionResult getMembers()
        {
            ViewBag.members = members;

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Member member)
        {
            member.MemberID = Guid.NewGuid().ToString();
            members.Add(member);
            return RedirectToAction("GetMembers");
        }
     }
}
