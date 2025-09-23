using LibraryManagement.Core.Dto.ReviewBookDto;
using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Interfaces;
using LibraryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace LibraryManagement.Infrastructure.Repositories
{
    public class ReviewBookRepository(AppDbContext appDbContext) : IReviewBookRepository
    {
        public async Task<ReviewDto> AddReview(AddReviewRequestDto review)
        {
            bool alreadyReviewed = await appDbContext.Reviews.AnyAsync(b=>b.UserId==review.UserId && b.BookId==review.BookId);
            if (alreadyReviewed) return null;

            ReviewsEntity reviewsEntity = new ReviewsEntity
            {
                Id = Guid.NewGuid(),
                BookId = review.BookId,
                UserId = review.UserId,
                Comment = review.Comment,
                Rating = review.Rating,
                Date = DateTime.Now,
            };
            await appDbContext.Reviews.AddAsync(reviewsEntity);
            await appDbContext.SaveChangesAsync();

            return new ReviewDto
            {
                Id = reviewsEntity.Id,
                UserId = reviewsEntity.UserId,
                Rating = reviewsEntity.Rating,
                Comment = reviewsEntity.Comment,
                Date = reviewsEntity.Date,
                HelpfulCount=0
            };
        }

        public async Task<bool> DeleteReview(Guid reviewId)
        {
            ReviewsEntity selectedReview = await appDbContext.Reviews.FirstOrDefaultAsync(r=>r.Id==reviewId);
            if (selectedReview is not null)
            {
                var helpfulVotes = appDbContext.HelpfulCount.Where(h => h.ReviewId == reviewId);
                appDbContext.HelpfulCount.RemoveRange(helpfulVotes);

                appDbContext.Reviews.Remove(selectedReview);

                await appDbContext.SaveChangesAsync();
                return true;
            }
            return false;

        }

        
            public async Task<IEnumerable<ReviewDto>> GetAllReviews(Guid bookId)
        {
            var reviewDtos = await appDbContext.Reviews
                .Where(r => r.BookId == bookId)
                .GroupJoin(
                    appDbContext.HelpfulCount.Where(h => h.IsHelpful == true),
                    review => review.Id,
                    helpful => helpful.ReviewId,
                    (review, helpfulVotes) => new ReviewDto
                    {
                        Id = review.Id,
                        UserId = review.UserId,
                        Rating = review.Rating,
                        Comment = review.Comment,
                        Date = review.Date,
                        HelpfulCount = helpfulVotes.Count()
                    }
                )
                .ToListAsync();

            return reviewDtos;
        }

          
        

        public async Task<ReviewDto> IsHelpful(Guid reviewId, Guid foundHelpfuluserId)
        {
            var reviewEntity = await appDbContext.Reviews.FindAsync(reviewId);
            if (reviewEntity is null) return null;

            var helpfulCountEntity = await appDbContext.HelpfulCount
                .FirstOrDefaultAsync(h => h.ReviewId == reviewId && h.UserId == foundHelpfuluserId);

            if (helpfulCountEntity is null)
            {
            
                helpfulCountEntity = new HelpfulCountEntity
                {
                    Id = Guid.NewGuid(),
                    ReviewId = reviewId,
                    UserId = foundHelpfuluserId,
                    IsHelpful = true
                };

                await appDbContext.HelpfulCount.AddAsync(helpfulCountEntity);
            }
            else
            {
                
                helpfulCountEntity.IsHelpful = helpfulCountEntity.IsHelpful == true ? null : true;
                appDbContext.HelpfulCount.Update(helpfulCountEntity);
            }

            await appDbContext.SaveChangesAsync();

            var FoundHelpful=await appDbContext.HelpfulCount.Where(r=>r.ReviewId==reviewId && r.IsHelpful==true).ToListAsync();

            return new ReviewDto
            {
             Id=reviewEntity.Id,
             UserId=reviewEntity.UserId,
             Comment=reviewEntity.Comment,
             Date = reviewEntity.Date,
             Rating = reviewEntity.Rating,
             HelpfulCount= FoundHelpful.Count,
            }; 
        }
        

        public async Task<ReviewsEntity> UpdateReview(ReviewsEntity reviewEntity)
        {
            ReviewsEntity reviews = await appDbContext.Reviews.FirstOrDefaultAsync(r=>r.Id==reviewEntity.Id);
            if (reviews is null) return null;

            reviews.Comment = reviewEntity.Comment;
            reviews.Rating = reviewEntity.Rating;
            reviews.Date= reviewEntity.Date;

            appDbContext.Reviews.Update(reviews);
            await appDbContext.SaveChangesAsync();
            return reviews;
        }
    }
}
