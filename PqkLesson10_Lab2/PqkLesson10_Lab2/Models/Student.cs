using System.ComponentModel.DataAnnotations;

namespace BaiThucHanh2.Models;

public class Student
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập họ tên.")]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "Vui lòng nhập email.")]
    [EmailAddress(ErrorMessage = "Email không đúng định dạng.")]
    public string Email { get; set; } = "";

    // Chỉ phục vụ bài thực hành giao diện; ứng dụng thực tế không nên lưu mật khẩu dạng rõ.
    [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
    public string Password { get; set; } = "";

    [Required(ErrorMessage = "Vui lòng chọn ngành.")]
    public string Branch { get; set; } = "CE";

    public bool IsRegular { get; set; } = true;

    [Display(Name = "Ngày sinh")]
    public DateTime DateOfBirth { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Vui lòng chọn giới tính.")]
    public string Gender { get; set; } = "Male";

    public string Address { get; set; } = "";
}
