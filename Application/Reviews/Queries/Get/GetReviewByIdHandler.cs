using Application.Reviews.DTOs;
using Domain.Entities;
using Infrastructure;
using MediatR;

namespace Application.Reviews.Queries.Get
{
    public class GetReviewByIdHandler : IRequestHandler<GetReviewByIdQuery, ReviewDto>
    {
        private readonly ReviewDbContext _context;

        public GetReviewByIdHandler(ReviewDbContext context)
        {
            _context = context;
        }

        public async Task<ReviewDto> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
        {
            var review = await _context.Reviews.FindAsync(request.ReviewId);
            if (review == null)
            {
                throw new InvalidOperationException("Review not found.");
            }

            return new ReviewDto
            {
                ReviewId = review.ReviewId,
                UserId = review.UserId,
                ProductId = review.ProductId,
                Description = review.Description,
                Rating = review.Rating
            };
        }
    }
}
