using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Interfaces;
using MediatR;

namespace LibraryManagement.Application.Queries.Borrows
{
    public record GetAllBorrowRequestQuery():IRequest<IEnumerable<BorrowEntity>>;
    public class GetAllBorrowRequestQueryHandler(IBorrowBookRepository borrowBookRepository) : IRequestHandler<GetAllBorrowRequestQuery, IEnumerable<BorrowEntity>>
    {
        public async Task<IEnumerable<BorrowEntity>> Handle(GetAllBorrowRequestQuery request, CancellationToken cancellationToken)
        {
            return await borrowBookRepository.GetAllBorrowRequest();
        }
    }


}
