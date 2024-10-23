namespace Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public float Price { get; set; }
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
