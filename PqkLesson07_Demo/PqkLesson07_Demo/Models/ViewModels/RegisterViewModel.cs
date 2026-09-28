using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PqkLesson07_Demo.Models.ViewModels
{
    public class RegisterViewModel
    {
        [DisplayName("Tên đăng nhập")]
        [Required(ErrorMessage = "Tên đăng nhập không được bỏ trống!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Độ dài tên từ 3-20 ký tự!")]
        public string Username { get; set; }

        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được bỏ trống!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Hòm thư")]
        [Required(ErrorMessage = "Tên hòm thư không được bỏ trống!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được bỏ trống!")]
        [DataType(DataType.PhoneNumber)]
        public string SDT { get; set; }

        [DisplayName("Ngày sinh")]
        public DateTime NgaySinh { get; set; }
    }
}
