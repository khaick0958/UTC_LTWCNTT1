namespace PqkLesson03.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public double Price { get; set; }
        public double SalePrice { get; set; }
        public int CategoryId {  get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public string CreatedAt { get; set; }
    }
}
