using LibraryManagement.Core.Dto.ManageBookDto;
using LibraryManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Interfaces
{
    public interface IManageBooksRepository
    {
        Task<IEnumerable<BookResponseDto>> GetBooks();
        Task<BooksEntity> GetBooksbyId(Guid id);
        Task<BookResponseDto> AddBooks(BookCreateDto entity);
        Task<bool> DeleteBooksbyId(Guid id);
        Task<BooksEntity> UpdateBook(BooksEntity entity, Guid id);
    }
}
