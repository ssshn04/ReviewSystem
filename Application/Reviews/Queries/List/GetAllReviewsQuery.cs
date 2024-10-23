using Application.Reviews.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Reviews.Queries.List
{
    public record GetAllReviewsQuery : IRequest<List<ReviewDto>>
    {
    }
}
