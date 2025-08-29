using LibraryManagement.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.ManageBooks
{
    public record DeleteBookCommand(Guid bookId):IRequest<bool>;
    public class DeleteBookCommandHandler(IManageBooksRepository manageBooksRepository)
        : IRequestHandler<DeleteBookCommand, bool>
    {
        public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            return await manageBooksRepository.DeleteBooksbyId(request.bookId);
        }
    }
}
