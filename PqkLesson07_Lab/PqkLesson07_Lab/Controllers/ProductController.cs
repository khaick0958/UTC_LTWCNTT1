using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Win32;
using PqkLesson07_Lab.Models.DataModels;
using PqkLesson07_Lab.Models.ViewModels;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace PqkLesson07_Lab.Controllers
{
    public class ProductController : Controller
    {
        static readonly List<Product> products = new List<Product>();

        List<Category> categories = new List<Category>
        {
            new Category { Id = 1, Name = "Áo" },
            new Category { Id = 2, Name = "Quần" },
            new Category { Id = 3, Name = "Giày" },
            new Category { Id = 4, Name = "Máy tính"}
        };

        // GET: ProductController
        public ActionResult Index()
        {
            ViewBag.products = products;
            return View();
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            Product p = products.FirstOrDefault(x => x.Id == id);

            if (p == null)
            {
                return NotFound();
            }

            return View(p);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddProductRegisterModel register)
        {
            if (ModelState.IsValid)
            {
                Product p = new Product
                {
                    Id = register.Id,
                    Name = register.Name,
                    Image = register.Image,
                    Price = register.Price,
                    SalePrice = register.SalePrice,
                    CategoryId = register.CategoryId,
                    Description = register.Description
                };

                products.Add(p);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = new SelectList(
                    categories,
                    "Id",
                    "Name"
                );

                return View(register);
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            Product p = products.FirstOrDefault(x => x.Id == id);

            if (p == null)
            {
                return NotFound();
            }

            ViewBag.Categories = new SelectList(
                categories,
                "Id",
                "Name",
                p.CategoryId
            );

            return View(p);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AddProductRegisterModel edit)
        {
            if (ModelState.IsValid)
            {
                Product p = products.FirstOrDefault(x => x.Id == id);

                if (p == null)
                {
                    return NotFound();
                }

                p.Id = edit.Id;
                p.Name = edit.Name;
                p.Image = edit.Image;
                p.Price = edit.Price;
                p.SalePrice = edit.SalePrice;
                p.CategoryId = edit.CategoryId;
                p.Description = edit.Description;

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = new SelectList(
                    categories,
                    "Id",
                    "Name"
                );

                return View(edit);
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            Product p = products.FirstOrDefault(x => x.Id == id);

            if (p == null)
            {
                return NotFound();
            }

            return View(p);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            Product p = products.FirstOrDefault(x => x.Id == id);

            if (p != null)
            {
                products.Remove(p);
            }

            return RedirectToAction("Index");
        }
    }
}
