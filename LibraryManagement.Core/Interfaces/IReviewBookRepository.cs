using LibraryManagement.Core.Dto.ReviewBookDto;
using LibraryManagement.Core.Entities;

namespace LibraryManagement.Core.Interfaces
{
    public interface IReviewBookRepository
    {
        public Task<IEnumerable<ReviewDto>> GetAllReviews(Guid bookId);
        public Task<ReviewDto> AddReview(AddReviewRequestDto review);
        public Task<ReviewsEntity> UpdateReview(ReviewsEntity reviewEntity);
        public Task<bool> DeleteReview(Guid reviewId);
        public Task<ReviewDto> IsHelpful(Guid reviewId, Guid userId);
    }
}

