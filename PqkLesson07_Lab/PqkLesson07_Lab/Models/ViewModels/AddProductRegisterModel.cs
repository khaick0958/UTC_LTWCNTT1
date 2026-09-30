using System.ComponentModel.DataAnnotations;

namespace PqkLesson07_Lab.Models.ViewModels
{
    public class AddProductRegisterModel
    {
        [
            Display(Name = "Mã sản phẩm"),
            Required(ErrorMessage = "Mã sản phẩm không được để trống!"),
        ]
        public int Id { get; set; }

        [
            Display(Name = "Tên sản phẩm"),
            Required(ErrorMessage = "Tên sản phẩm không được để trống!"),
            StringLength(150, MinimumLength = 6, ErrorMessage = "Tên sản phẩm phải có độ dài từ 6-150 ký tự!")
        ]
        public string Name { get; set; }

        [
            Display(Name = "Link ảnh sản phẩm"),
            Required(ErrorMessage = "Vui lòng chọn hình ảnh")
        ]
        public string Image { get; set; }

        [
            Display(Name = "Giá sản phẩm"),
            Required(ErrorMessage = "Giá sản phẩm không được để trống!"),
            Range(100000.01f, float.MaxValue, ErrorMessage = "Giá sản phẩm tối thiểu phải lớn hơn 100000!")
        ]
        public double Price { get; set; }

        [
            Display(Name = "Giá sale của sản phẩm"),
            Required(ErrorMessage = "Giá sale không được để trống!"),
            Range(1.01f, float.MaxValue, ErrorMessage = "Giá sale không được âm!")
        ]
        public double SalePrice { get; set; }

        [
            Display(Name = "Mã danh mục của sản phẩm"),
            Required(ErrorMessage = "Mã danh mục không được để trống!")
        ]
        public int CategoryId { get; set; }

        [
            Display(Name = "Giới thiệu sản phẩm"),
            Required(ErrorMessage = "Giới thiệu sản phẩm không được để trống!"),
            StringLength(1500, ErrorMessage = "Giới thiệu sản phẩm không được quá 1500 ký tự!")
        ]
        public string Description { get; set; }
    }
}
