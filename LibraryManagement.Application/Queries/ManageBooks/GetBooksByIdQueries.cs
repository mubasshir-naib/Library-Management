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
    public record GetBooksByIdQueries(Guid Id):IRequest<BooksEntity>;
    public class GetBooksByIdQueriesHandler(IManageBooksRepository manageBooksRepository)
        : IRequestHandler<GetBooksByIdQueries, BooksEntity>
    {
        public async Task<BooksEntity> Handle(GetBooksByIdQueries request, CancellationToken cancellationToken)
        {
            return await manageBooksRepository.GetBooksbyId(request.Id);
        }
    }
}
