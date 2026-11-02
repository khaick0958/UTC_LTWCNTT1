using System.ComponentModel.DataAnnotations;

namespace Lab4_MVC_EFCore.Models;

public class Enrollment
{
    public int EnrollmentID { get; set; }
    public int CourseID { get; set; }
    public int LearnerID { get; set; }

    [Range(0, 10, ErrorMessage = "Điểm phải từ 0 đến 10.")]
    public float Grade { get; set; }

    public Learner? Learner { get; set; }
    public Course? Course { get; set; }
}
