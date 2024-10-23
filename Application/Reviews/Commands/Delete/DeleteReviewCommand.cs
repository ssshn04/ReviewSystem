using MediatR;

namespace Application.Reviews.Commands.Delete
{
    public record DeleteReviewCommand(int ReviewId) : IRequest
    {
    }
}
