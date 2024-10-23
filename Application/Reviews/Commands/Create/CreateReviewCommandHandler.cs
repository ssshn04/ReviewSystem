using Domain.Entities;
using Infrastructure;
using MediatR;
namespace Application.Reviews.Commands.Create
{
    public class CreateReviewHandler : IRequestHandler<CreateReviewCommand, int>
    {
        private readonly ReviewDbContext _context;

        public CreateReviewHandler(ReviewDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = new Review
            {
                UserId = request.UserId,
                ProductId = request.ProductId,
                Description = request.Description,
                Rating = request.Rating
            };
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync(cancellationToken);
            return review.ReviewId;
        }
    }
}
