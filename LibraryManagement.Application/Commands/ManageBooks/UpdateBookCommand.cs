using LibraryManagement.Core.Dto.ManageBookDto;
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
    public record UpdateBookCommand(BookCreateDto book,Guid bookId):IRequest<BookResponseDto>;
    public class UpdateBookCommandHandler(IManageBooksRepository manageBooksRepository)
        : IRequestHandler<UpdateBookCommand, BookResponseDto>
    {
        public async Task<BookResponseDto> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            return await manageBooksRepository.UpdateBook(request.book,request.bookId);
            
        }
    }
}
