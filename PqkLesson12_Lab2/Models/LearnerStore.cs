namespace Lab6_PhanTrang_Loc_TimKiem.Models;

public class LearnerStore
{
    private readonly List<Learner> _items = new()
    {
        new() { Id=1, Name="Carson", Surname="Alexander", Major="IT", EnrollDate=new(2005,9,1) },
        new() { Id=2, Name="Meredith", Surname="Alonso", Major="Economics", EnrollDate=new(2002,9,1) },
        new() { Id=3, Name="Arturo", Surname="Anand", Major="IT", EnrollDate=new(2021,9,1) },
        new() { Id=4, Name="Gytis", Surname="Barzdukas", Major="Mathematics", EnrollDate=new(2020,9,1) },
        new() { Id=5, Name="Nam", Surname="Le", Major="Mathematics", EnrollDate=new(2023,10,4,15,59,0) },
        new() { Id=6, Name="Yan", Surname="Li", Major="IT", EnrollDate=new(2022,9,1) },
        new() { Id=7, Name="Minh", Surname="Tran", Major="Economics", EnrollDate=new(2023,10,4,14,47,0) },
        new() { Id=8, Name="Peggy", Surname="Justice", Major="Mathematics", EnrollDate=new(2021,9,1) },
        new() { Id=9, Name="Laura", Surname="Norman", Major="IT", EnrollDate=new(2022,9,1) },
        new() { Id=10, Name="Bich", Surname="Vu", Major="Economics", EnrollDate=new(2023,10,23,17,9,0) },
        new() { Id=11, Name="Rock", Surname="The", Major="Economics", EnrollDate=new(2023,12,22) },
        new() { Id=12, Name="Huy", Surname="Pham", Major="IT", EnrollDate=new(2024,1,8) },
        new() { Id=13, Name="Mai", Surname="Nguyen", Major="Mathematics", EnrollDate=new(2024,2,12) },
        new() { Id=14, Name="Linh", Surname="Do", Major="Economics", EnrollDate=new(2024,3,20) },
        new() { Id=15, Name="An", Surname="Tran", Major="IT", EnrollDate=new(2024,4,1) }
    };
    public List<Learner> All() => _items;
    public Learner? Find(int id) => _items.FirstOrDefault(x => x.Id == id);
    public void Add(Learner item) { item.Id = _items.Count == 0 ? 1 : _items.Max(x => x.Id) + 1; _items.Add(item); }
    public void Update(Learner item) { var old=Find(item.Id); if(old is null) return; old.Name=item.Name; old.Surname=item.Surname; old.Major=item.Major; old.EnrollDate=item.EnrollDate; }
    public void Delete(int id) { var item=Find(id); if(item is not null) _items.Remove(item); }
}
