using Application.Reviews.DTOs;
using Domain.Entities;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Reviews.Queries.List
{
    public class GetAllReviewsHandler : IRequestHandler<GetAllReviewsQuery, List<ReviewDto>>
    {
        private readonly ReviewDbContext _context;

        public GetAllReviewsHandler(ReviewDbContext context)
        {
            _context = context;
        }

        public async Task<List<ReviewDto>> Handle(GetAllReviewsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Reviews
                .Select(review => new ReviewDto
                {
                    ReviewId = review.ReviewId,
                    UserId = review.UserId,
                    ProductId = review.ProductId,
                    Description = review.Description,
                    Rating = review.Rating
                })
                .ToListAsync(cancellationToken);
        }
    }
}
