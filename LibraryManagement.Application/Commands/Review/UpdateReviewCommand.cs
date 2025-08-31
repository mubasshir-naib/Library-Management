using LibraryManagement.Core.Dto.ReviewBookDto;
using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.Review
{
    
    public record UpdateReviewCommand(Guid reviewId, AddReviewRequestDto addReviewRequestDto) : IRequest<ReviewsEntity>;
    public class UpdateReviewHandler(IReviewBookRepository reviewBookRepository) : IRequestHandler<UpdateReviewCommand, ReviewsEntity>
    {
        public async Task<ReviewsEntity> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            return await reviewBookRepository.UpdateReview(
                new ReviewsEntity
                {
                    Id= request.reviewId,
                    UserId=request.addReviewRequestDto.UserId,
                    BookId=request.addReviewRequestDto.BookId,
                    Comment=request.addReviewRequestDto.Comment,
                    Rating=request.addReviewRequestDto.Rating,
                    Date=DateTime.Now,}
                );
        }
    }
}
