namespace Domain.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string? Description { get; set; }
        public double Rating { get; set; }
    }
}
