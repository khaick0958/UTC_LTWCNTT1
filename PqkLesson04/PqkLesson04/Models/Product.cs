namespace PqkLesson04.Models
{
    public class Product
    {
        public Product()
        {
        }

        public Product(int id, string name, string image)
        {
            this.id = id;
            this.name = name;
            this.image = image;
        }

        public int id {  get; set; }
        public string name { get; set; }
        public string image { get; set; }
    }
}
