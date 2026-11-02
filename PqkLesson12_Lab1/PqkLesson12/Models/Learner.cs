using System.ComponentModel.DataAnnotations;

namespace Lab4_MVC_EFCore.Models;

public class Learner
{
    public int LearnerID { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập tên.")]
    [StringLength(100, ErrorMessage = "Tên không được vượt quá 100 ký tự.")]
    [Display(Name = "Tên")]
    public string FirstMidName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập họ.")]
    [StringLength(100, ErrorMessage = "Họ không được vượt quá 100 ký tự.")]
    [Display(Name = "Họ")]
    public string LastName { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    [Display(Name = "Ngày nhập học")]
    public DateTime EnrollmentDate { get; set; } = DateTime.Today;

    [Display(Name = "Ngành học")]
    public int MajorID { get; set; }

    public Major? Major { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
