using Infrastructure;
using MediatR;

namespace Application.Reviews.Commands.Delete
{
    public class DeleteReviewHandler : IRequestHandler<DeleteReviewCommand>
    {
        private readonly ReviewDbContext _context;

        public DeleteReviewHandler(ReviewDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _context.Reviews.FindAsync(request.ReviewId);
            if (review == null)
            {
                throw new InvalidOperationException("Review not found.");
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
