using LibraryManagement.Core.DTOs;
using LibraryManagement.Core.Interfaces;
using MediatR;

namespace LibraryManagement.Application.Queries.Borrows
{
    public record GetBorrowBookDetailsQuery(Guid bookId):IRequest<BorrowBookDetailsDTO>;

    public class GetBorrowBookDetailsQueryHandler(IBorrowBookRepository borrowBookRepository) : IRequestHandler<GetBorrowBookDetailsQuery, BorrowBookDetailsDTO>
    {
        public Task<BorrowBookDetailsDTO> Handle(GetBorrowBookDetailsQuery request, CancellationToken cancellationToken)
        {
            return borrowBookRepository.GetBorrowBookDetails(request.bookId);
        }
    }
}
