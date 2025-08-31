using LibraryManagement.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.Review
{
    public record DeleteReviewCommand(Guid reviewId) :IRequest<bool>;
    public class DeleteReviewCommandHandler(IReviewBookRepository reviewBookRepository) : IRequestHandler<DeleteReviewCommand, bool>
    {
        public Task<bool> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            return reviewBookRepository.DeleteReview(request.reviewId);
        }
    }


}
