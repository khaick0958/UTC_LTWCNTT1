using System.ComponentModel.DataAnnotations;

namespace PqkLesson07_Lab.Models.DataModels
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public double SalePrice { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
    }
}
