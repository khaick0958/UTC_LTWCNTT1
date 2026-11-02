using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab4_MVC_EFCore.Models;

public class Course
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Display(Name = "Mã môn học")]
    public int CourseID { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập tên môn học.")]
    [StringLength(100)]
    [Display(Name = "Tên môn học")]
    public string Title { get; set; } = string.Empty;

    [Range(1, 10, ErrorMessage = "Số tín chỉ phải từ 1 đến 10.")]
    [Display(Name = "Số tín chỉ")]
    public int Credits { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
