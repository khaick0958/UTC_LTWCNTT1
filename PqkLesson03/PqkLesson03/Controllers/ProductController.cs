using Microsoft.AspNetCore.Mvc;
using PqkLesson03.Models;

namespace PqkLesson03.Controllers
{
    public class ProductController : Controller
    {
        [Route("menu-san-pham", Name = "Menu")]
        public IActionResult ProductIndex(int? id)
        {
            List<Category> categories = new List<Category>
            {
                new Category()
                {
                    CategoryId = 1,
                    CategoryName = "Quần Áo"
                },
                new Category()
                {
                    CategoryId = 2,
                    CategoryName = "Túi xách"
                },
                new Category()
                {
                    CategoryId = 3,
                    CategoryName = "Đồng hồ"
                },
                new Category()
                {
                    CategoryId = 4,
                    CategoryName = "Ti vi"
                },
                new Category()
                {
                    CategoryId = 5,
                    CategoryName = "Tủ lạnh"
                },
                new Category()
                {
                    CategoryId = 6,
                    CategoryName = "Máy bơm"
                },
                new Category()
                {
                    CategoryId = 7,
                    CategoryName = "Quạt điện"
                },
                new Category()
                {
                    CategoryId = 8,
                    CategoryName = "Lò sưởi"
                }
            };

            List<Product> products = new List<Product>
            {
                new Product()
                {
                    ProductId = 1,
                    ProductName = "Bộ đồ bơi cho trẻ em nam",
                    ProductImage = Url.Content("~/img/DoBoi1.jpg"),
                    Price = 500000,
                    SalePrice = 350000,
                    CategoryId = 1,
                    Description = "[DESCRIPTION HERE]",
                    Status = true,
                    CreatedAt = "24/08/2021 12:00:00 SA"
                },
                new Product()
                {
                    ProductId = 2,
                    ProductName = "Bộ đồ bơi cho trẻ em nữ",
                    ProductImage = Url.Content("~/img/DoBoi2.jpg"),
                    Price = 450000,
                    SalePrice = 350000,
                    CategoryId = 1,
                    Description = "[DESCRIPTION HERE]",
                    Status = true,
                    CreatedAt = "24/08/2021 12:00:00 SA"
                },
                new Product()
                {
                    ProductId = 3,
                    ProductName = "Bộ đồ bơi cho trẻ em 3-5 tuổi",
                    ProductImage = Url.Content("~/img/DoBoi3.jpg"),
                    Price = 400000,
                    SalePrice = 350000,
                    CategoryId = 1,
                    Description = "[DESCRIPTION HERE]",
                    Status = true,
                    CreatedAt = "24/08/2021 12:00:00 SA"
                },
                new Product()
                {
                    ProductId = 4,
                    ProductName = "Đồng hồ quả lắc",
                    ProductImage = Url.Content("~/img/Clock.jpg"),
                    Price = 1500000,
                    SalePrice = 1000000,
                    CategoryId = 3,
                    Description = "[DESCRIPTION HERE]",
                    Status = true,
                    CreatedAt = "24/08/2021 12:00:00 SA"
                },
                new Product()
                {
                    ProductId = 5,
                    ProductName = "Túi xách da",
                    ProductImage = Url.Content("~/img/Bag1.jpg"),
                    Price = 600000,
                    SalePrice = 550000,
                    CategoryId = 2,
                    Description = "[DESCRIPTION HERE]",
                    Status = true,
                    CreatedAt = "24/08/2021 12:00:00 SA"
                },
                new Product()
                {
                    ProductId = 6,
                    ProductName = "Túi xách thời trang",
                    ProductImage = Url.Content("~/img/Bag2.jpg"),
                    Price = 750000,
                    SalePrice = 500000,
                    CategoryId = 2,
                    Description = "[DESCRIPTION HERE]",
                    Status = true,
                    CreatedAt = "24/08/2021 12:00:00 SA"
                },
            };

            if (id != null)
            {
                products = products
                    .Where(product => product.CategoryId == id)
                    .ToList();
            }

            ViewBag.products = products;
            ViewBag.categories = categories;
            return View();
        }

        [Route("chi-tiet-san-pham", Name = "Info")]
        public IActionResult Infomation(int id)
        {
            List<Product> products = new List<Product>
            {
                new Product()
                {
                    ProductId = 1,
                    ProductName = "Bộ đồ bơi cho trẻ em nam",
                    ProductImage = Url.Content("~/img/DoBoi1.jpg"),
                    Price = 500000,
                    SalePrice = 350000,
                    CategoryId = 1,
                    Description = "[DESCRIPTION HERE]",
                    Status = true,
                    CreatedAt = "24/08/2021 12:00:00 SA"
                },
                new Product()
                {
                    ProductId = 2,
                    ProductName = "Bộ đồ bơi cho trẻ em nữ",
                    ProductImage = Url.Content("~/img/DoBoi2.jpg"),
                    Price = 450000,
                    SalePrice = 350000,
                    CategoryId = 1,
                    Description = "[DESCRIPTION HERE]",
                    Status = true,
                    CreatedAt = "24/08/2021 12:00:00 SA"
                },
                new Product()
                {
                    ProductId = 3,
                    ProductName = "Bộ đồ bơi cho trẻ em 3-5 tuổi",
                    ProductImage = Url.Content("~/img/DoBoi3.jpg"),
                    Price = 400000,
                    SalePrice = 350000,
                    CategoryId = 1,
                    Description = "[DESCRIPTION HERE]",
                    Status = true,
                    CreatedAt = "24/08/2021 12:00:00 SA"
                },
                new Product()
                {
                    ProductId = 4,
                    ProductName = "Đồng hồ quả lắc",
                    ProductImage = Url.Content("~/img/Clock.jpg"),
                    Price = 1500000,
                    SalePrice = 1000000,
                    CategoryId = 3,
                    Description = "[DESCRIPTION HERE]",
                    Status = true,
                    CreatedAt = "24/08/2021 12:00:00 SA"
                },
                new Product()
                {
                    ProductId = 5,
                    ProductName = "Túi xách da",
                    ProductImage = Url.Content("~/img/Bag1.jpg"),
                    Price = 600000,
                    SalePrice = 550000,
                    CategoryId = 2,
                    Description = "[DESCRIPTION HERE]",
                    Status = true,
                    CreatedAt = "24/08/2021 12:00:00 SA"
                },
                new Product()
                {
                    ProductId = 6,
                    ProductName = "Túi xách thời trang",
                    ProductImage = Url.Content("~/img/Bag2.jpg"),
                    Price = 750000,
                    SalePrice = 500000,
                    CategoryId = 2,
                    Description = "[DESCRIPTION HERE]",
                    Status = true,
                    CreatedAt = "24/08/2021 12:00:00 SA"
                },
            };

            Product product = products.FirstOrDefault(p => p.ProductId == id);
            ViewBag.product = product;
            return View();
        }
    }
}
