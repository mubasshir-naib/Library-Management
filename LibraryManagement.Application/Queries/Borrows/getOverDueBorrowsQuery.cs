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
    public record GetOverDueBorrowsQuery():IRequest<IEnumerable<BorrowEntity>>;
    public class GetOverDueBorrowsQueryHandler(IBorrowBookRepository borrowBookRepository) : IRequestHandler<GetOverDueBorrowsQuery, IEnumerable<BorrowEntity>>
    {
        public async Task<IEnumerable<BorrowEntity>> Handle(GetOverDueBorrowsQuery request, CancellationToken cancellationToken)
        {
            return await borrowBookRepository.GetOverDueBorrows();
        }
    }



}
