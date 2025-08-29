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
        Task<IEnumerable<BooksEntity>> GetBooks();
        Task<BooksEntity> GetBooksbyId(Guid id);
        Task<BooksEntity> AddBooks(BooksEntity entity);
        Task<bool> DeleteBooksbyId(Guid id);
        Task<BooksEntity> UpdateBook(BooksEntity entity, Guid id);
    }
}
