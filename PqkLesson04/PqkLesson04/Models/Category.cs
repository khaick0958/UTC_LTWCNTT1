namespace PqkLesson04.Models
{
    public class Category
    {
        public Category()
        {
        }

        public Category(int id, string name)
        {
            this.CategoryId = id;
            this.CategoryName = name;
        }

        public int CategoryId {  get; set; }
        public string CategoryName { get; set; }
    }
}
