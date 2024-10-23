using MediatR;

namespace Application.Reviews.Commands.Update
{
    public class UpdateReviewCommand : IRequest
    {
        public int ReviewId { get; set; }
        public string? Description { get; set;}
        public double Rating { get; set; }
    }
}
