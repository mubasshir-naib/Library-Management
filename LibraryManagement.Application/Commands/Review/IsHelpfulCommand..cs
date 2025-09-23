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
    public record IsHelpfulCommand(Guid reviewId,Guid userId) : IRequest<ReviewDto>;
    public class IsHelpfulCommandHandler(IReviewBookRepository reviewBookRepository) : IRequestHandler<IsHelpfulCommand, ReviewDto>
    {
        public async Task<ReviewDto> Handle(IsHelpfulCommand request, CancellationToken cancellationToken)
        {
            return await reviewBookRepository.IsHelpful(request.reviewId,request.userId);
        }
    }
}
