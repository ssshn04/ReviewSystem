namespace Application.Reviews.DTOs
{
    public class ReviewDto
    {
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string? Description { get; set; }
        public double Rating { get; set; }
    }
}
