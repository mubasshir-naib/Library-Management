using LibraryManagement.Core.Dto.ManageBookDto;
using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Queries.ManageBooks
{
    public record GetBooksQueries:IRequest<IEnumerable<BookResponseDto>>
    {
    }
    public class GetBooksQueriesHandler(IManageBooksRepository manageBooksRepository) :
        IRequestHandler<GetBooksQueries, IEnumerable<BookResponseDto>>
    {
        public async Task<IEnumerable<BookResponseDto>> Handle(GetBooksQueries request, CancellationToken cancellationToken)
        {
            return await manageBooksRepository.GetBooks();
        }
    }
}
