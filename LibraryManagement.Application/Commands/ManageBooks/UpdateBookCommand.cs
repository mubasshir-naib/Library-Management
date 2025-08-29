using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.ManageBooks
{
    public record UpdateBookCommand(BooksEntity book,Guid bookId):IRequest<BooksEntity>;
    public class UpdateBookCommandHandler(IManageBooksRepository manageBooksRepository)
        : IRequestHandler<UpdateBookCommand, BooksEntity>
    {
        public async Task<BooksEntity> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            return await manageBooksRepository.UpdateBook(request.book,request.bookId);
        }
    }
}
