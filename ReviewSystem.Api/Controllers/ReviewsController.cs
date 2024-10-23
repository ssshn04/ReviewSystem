using Application.Reviews.Commands.Create;
using Application.Reviews.Commands.Delete;
using Application.Reviews.Commands.Update;
using Application.Reviews.DTOs;
using Application.Reviews.Queries.Get;
using Application.Reviews.Queries.List;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ReviewSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/reviews
        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            var query = new GetAllReviewsQuery();
            var reviews = await _mediator.Send(query);
            return Ok(reviews);
        }

        // GET: api/reviews/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            var query = new GetReviewByIdQuery(id);
            var review = await _mediator.Send(query);
            return Ok(review);
        }

        // POST: api/reviews
        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] ReviewDto reviewDto)
        {
            var command = new CreateReviewCommand
            {
                UserId = reviewDto.UserId,
                ProductId = reviewDto.ProductId,
                Description = reviewDto.Description,
                Rating = reviewDto.Rating
            };

            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetReviewById), new { id = result }, null);
        }

        // PUT: api/reviews/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, [FromBody] ReviewDto reviewDto)
        {
            var command = new UpdateReviewCommand
            {
                ReviewId = id,
                Description = reviewDto.Description,
                Rating = reviewDto.Rating
            };

            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE: api/reviews/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var command = new DeleteReviewCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
