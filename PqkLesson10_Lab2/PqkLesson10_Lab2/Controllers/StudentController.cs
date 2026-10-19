using BaiThucHanh2.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiThucHanh2.Controllers;

public class StudentController : Controller
{
    private static readonly List<Student> Students = new()
    {
        new() { Id = 101, Name = "Hải Nam", Email = "nam@g.com", Password = "123456", Branch = "IT", IsRegular = true, DateOfBirth = DateTime.MinValue, Gender = "Male", Address = "A1-2018" },
        new() { Id = 102, Name = "Minh Tú", Email = "tu@g.com", Password = "123456", Branch = "Business", IsRegular = true, DateOfBirth = DateTime.MinValue, Gender = "Female", Address = "A1-2019" },
        new() { Id = 103, Name = "Hoàng Phong", Email = "phong@g.com", Password = "123456", Branch = "CE", IsRegular = false, DateOfBirth = DateTime.MinValue, Gender = "Male", Address = "A1-2020" },
        new() { Id = 104, Name = "Xuân Mai", Email = "mai@g.com", Password = "123456", Branch = "English", IsRegular = false, DateOfBirth = DateTime.MinValue, Gender = "Female", Address = "A1-2021" }
    };

    public IActionResult Index(string? search)
    {
        IEnumerable<Student> result = Students;
        if (!string.IsNullOrWhiteSpace(search))
        {
            result = result.Where(s => s.Name.Contains(search, StringComparison.OrdinalIgnoreCase)
                || s.Email.Contains(search, StringComparison.OrdinalIgnoreCase)
                || s.Id.ToString().Contains(search, StringComparison.OrdinalIgnoreCase));
        }
        ViewData["Search"] = search ?? "";
        return View(result.ToList());
    }

    [HttpGet]
    public IActionResult Create() => View(new Student { DateOfBirth = DateTime.Now });

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Student student)
    {
        if (!ModelState.IsValid) return View(student);
        student.Id = Students.Count == 0 ? 101 : Students.Max(s => s.Id) + 1;
        Students.Add(student);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var student = Students.FirstOrDefault(s => s.Id == id);
        return student == null ? NotFound() : View(student);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Student updatedStudent)
    {
        if (id != updatedStudent.Id) return BadRequest();
        if (!ModelState.IsValid) return View(updatedStudent);
        var student = Students.FirstOrDefault(s => s.Id == id);
        if (student == null) return NotFound();

        student.Name = updatedStudent.Name;
        student.Email = updatedStudent.Email;
        student.Password = updatedStudent.Password;
        student.Branch = updatedStudent.Branch;
        student.IsRegular = updatedStudent.IsRegular;
        student.DateOfBirth = updatedStudent.DateOfBirth;
        student.Gender = updatedStudent.Gender;
        student.Address = updatedStudent.Address;
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var student = Students.FirstOrDefault(s => s.Id == id);
        if (student == null) return NotFound();
        Students.Remove(student);
        return RedirectToAction(nameof(Index));
    }
}
