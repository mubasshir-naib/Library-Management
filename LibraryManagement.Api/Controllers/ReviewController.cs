
using LibraryManagement.Application.Commands.Review;
using LibraryManagement.Application.Queries.Review;
using LibraryManagement.Core.Dto.ReviewBookDto;
using LibraryManagement.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Api.Controllers
{
    [Route("api/review")]
    [ApiController]
    public class ReviewController(ISender sender) : ControllerBase
    {
        [HttpGet("{bookId}")]
        public async Task<IActionResult> GetAllReviews([FromRoute] Guid bookId)
        {
            var result = await sender.Send(new GetAllReviewsQueries(bookId));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddReviews([FromBody] AddReviewRequestDto reviewRequestDto)
        {
            var result = await sender.Send(new AddReviewCommand(reviewRequestDto));
            return Ok(result);
        }

        
        [HttpPut("{reviewId}")]
        public async Task<IActionResult> UpdateReview([FromRoute] Guid reviewId, [FromBody] AddReviewRequestDto reviewRequestDto)
        {
            var result = await sender.Send(new UpdateReviewCommand(reviewId, reviewRequestDto));
            return Ok(result);
        }

        [HttpDelete("{reviewId}")]
        public async Task<IActionResult> DeleteReview([FromRoute] Guid reviewId)
        {
            var result = await sender.Send(new DeleteReviewCommand(reviewId));
            return Ok(result);
        }


        [HttpPost("isHelpful/{reviewId}")]
        public async Task<IActionResult> IsHelpful([FromRoute] Guid reviewId, [FromBody] Guid userId)
        {
            var result = await sender.Send(new IsHelpfulCommand(reviewId, userId));
            return Ok(result);
        }

    }
}
