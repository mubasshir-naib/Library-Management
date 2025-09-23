using LibraryManagement.Core.Dto.ReviewBookDto;
using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Interfaces;
using MediatR;


namespace LibraryManagement.Application.Queries.Review
{
    public record GetAllReviewsQueries(Guid bookId) : IRequest<IEnumerable<ReviewDto>>;
    public class GetAllReviewsQueriesHandler(IReviewBookRepository reviewBookRepository) : IRequestHandler<GetAllReviewsQueries, IEnumerable<ReviewDto>>
    {
        public Task<IEnumerable<ReviewDto>> Handle(GetAllReviewsQueries request, CancellationToken cancellationToken)
        {
            return reviewBookRepository.GetAllReviews(request.bookId);
        }
    }
}
