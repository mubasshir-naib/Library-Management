using LibraryManagement.Application.Commands.Borrows;
using LibraryManagement.Core.Dto.ReviewBookDto;
using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Interfaces;
using MediatR;

namespace LibraryManagement.Application.Commands.Review
{
    public record AddReviewCommand(AddReviewRequestDto AddReview) :IRequest<ReviewDto>;
    public class AddReviewCommandHandler(IReviewBookRepository reviewBookRepository) : IRequestHandler<AddReviewCommand, ReviewDto>
    {
        public async Task<ReviewDto> Handle(AddReviewCommand request, CancellationToken cancellationToken)
        {
            return await reviewBookRepository.AddReview(request.AddReview);
        }
    }



}


