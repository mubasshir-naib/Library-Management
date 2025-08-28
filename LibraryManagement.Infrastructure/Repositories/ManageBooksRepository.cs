using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Interfaces;
using LibraryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Infrastructure.Repositories
{
    public class ManageBooksRepository(AppDbContext dbContext):IManageBooksRepository
    {
        public async Task<IEnumerable<BooksEntity>> GetBooks()
        {
            return await dbContext.Books.ToListAsync();
        }
        public async Task<BooksEntity> GetBooksbyId(Guid id)
        {
            return await dbContext.Books.FirstOrDefaultAsync(x=>x.Id == id);
        }
        public async Task<BooksEntity>AddBooks(BooksEntity entity)
        {
            entity.Id = Guid.NewGuid();
            dbContext.Books.Add(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task<bool> DeleteBooksbyId(Guid id)
        {
            var book= await  dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (book != null) 
            {
                dbContext.Books.Remove(book);
                await dbContext.SaveChangesAsync();
                return true;
            }else return false;
        }
        public async Task<BooksEntity>UpdateBook(BooksEntity entity,Guid id)
        {
            var book = await dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (book != null)
            {
                book.Author = entity.Author;
                book.Title = entity.Title;
                book.Author = entity.Author;
                book.CategoryId = entity.CategoryId;
                book.NumberOfCopy = entity.NumberOfCopy;
                book.CoverImage = entity.CoverImage;
                book.PdfUrl = entity.PdfUrl;
                book.AudioClip = entity.AudioClip;
                book.Description = entity.Description;

                await dbContext.SaveChangesAsync();
                return book;

            }
            else return entity;
        }
    }
}
