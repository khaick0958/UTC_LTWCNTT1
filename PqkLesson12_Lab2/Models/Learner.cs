namespace Lab6_PhanTrang_Loc_TimKiem.Models;

public class Learner
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Surname { get; set; } = "";
    public string Major { get; set; } = "";
    public DateTime EnrollDate { get; set; }
}
