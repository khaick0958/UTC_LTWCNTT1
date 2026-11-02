namespace Lab4_MVC_EFCore.Models;

public class Major
{
    public int MajorID { get; set; }
    public string MajorName { get; set; } = string.Empty;
    public ICollection<Learner> Learners { get; set; } = new List<Learner>();
}
