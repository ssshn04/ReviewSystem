using MediatR;

namespace Application.Reviews.Commands.Create
{
    public class CreateReviewCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public int ProductId { get; set;}
        public string? Description { get; set; }
        public double Rating { get; set; }
    }
}
