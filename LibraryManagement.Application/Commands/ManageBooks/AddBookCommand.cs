using LibraryManagement.Core.Dto.ManageBookDto;
using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Interfaces;
using MediatR;

namespace LibraryManagement.Application.Commands.ManageBooks
{
    public record AddBookCommand(BookCreateDto Book):IRequest<BooksEntity>;

    public class AddBookCommandHandler(IManageBooksRepository manageBooksRepository)
        : IRequestHandler<AddBookCommand, BooksEntity>
    {
        public async Task<BooksEntity> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            return await manageBooksRepository.AddBooks(request.Book);
        }
    }
}
