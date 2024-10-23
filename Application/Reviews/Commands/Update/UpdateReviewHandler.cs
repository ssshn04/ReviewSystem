using Infrastructure;
using MediatR;

namespace Application.Reviews.Commands.Update
{
    public class UpdateReviewHandler : IRequestHandler<UpdateReviewCommand>
    {
        private readonly ReviewDbContext _context;

        public UpdateReviewHandler(ReviewDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _context.Reviews.FindAsync(request.ReviewId);
            if (review == null)
            {
                throw new InvalidOperationException("Review not found.");
            }

            review.Description = request.Description;
            review.Rating = request.Rating;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
