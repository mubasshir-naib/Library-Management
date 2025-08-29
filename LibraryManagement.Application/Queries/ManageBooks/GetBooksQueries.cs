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
    public record GetBooksQueries:IRequest<IEnumerable<BooksEntity>>
    {
    }
    public class GetBooksQueriesHandler(IManageBooksRepository manageBooksRepository) :
        IRequestHandler<GetBooksQueries, IEnumerable<BooksEntity>>
    {
        public async Task<IEnumerable<BooksEntity>> Handle(GetBooksQueries request, CancellationToken cancellationToken)
        {
            return await manageBooksRepository.GetBooks();
        }
    }
}
