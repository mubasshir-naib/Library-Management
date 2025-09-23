using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Queries.Borrows
{
    public record GetCurrentBorrowsQuery():IRequest<IEnumerable<BorrowEntity>>;
    public class GetCurrentBorrowsQueryHandler(IBorrowBookRepository borrowBookRepository) : IRequestHandler<GetCurrentBorrowsQuery, IEnumerable<BorrowEntity>>
    {
        public async Task<IEnumerable<BorrowEntity>> Handle(GetCurrentBorrowsQuery request, CancellationToken cancellationToken)
        {
            return await borrowBookRepository.GetCurrentBorrows();
        }
    }


}
