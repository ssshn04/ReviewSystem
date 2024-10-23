using Application.Reviews.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Reviews.Queries.Get
{
    public record GetReviewByIdQuery(int ReviewId) : IRequest<ReviewDto>;
}
