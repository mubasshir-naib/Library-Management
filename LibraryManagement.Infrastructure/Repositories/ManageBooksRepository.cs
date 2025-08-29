using LibraryManagement.Core.Dto.ManageBookDto;
using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Enums;
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
    public class ManageBooksRepository(AppDbContext dbContext, IFileService fileService):IManageBooksRepository
    {
        private readonly IFileService _fileService= fileService;

        public async Task<IEnumerable<BookResponseDto>> GetBooks()
        {
            var Books = await dbContext.Books.ToListAsync();
            var BooksDto= new List<BookResponseDto>();
            foreach (var Book in Books) {
                var category = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == Book.Id);
                var bookDto = new BookResponseDto
                {
                    Title = Book.Title,
                    Author = Book.Author,
                    Category = category?.Name ?? "null",
                    NumberOfCopy = Book.NumberOfCopy,
                    CoverImage = Book.CoverImage,
                    PdfUrl = Book.PdfUrl,
                    AudioClip = Book.AudioClip,
                    Description = Book.Description,
                };
                BooksDto.Add(bookDto);
            }
            return BooksDto;
        }
        public async Task<BooksEntity> GetBooksbyId(Guid id)
        {
            return await dbContext.Books.FirstOrDefaultAsync(x=>x.Id == id);
        }
        public async Task<BookResponseDto>AddBooks(BookCreateDto dto)
        {
          
            string coverImagePath = await _fileService.SaveFileAsync(dto.CoverImage, "covers", new[] { ".png", ".jpg" });
            string pdfPath = await _fileService.SaveFileAsync(dto.PdfUrl, "books", new[] { ".pdf" });
            string audioPath = await _fileService.SaveFileAsync(dto.AudioClip, "audio", new[] { ".mp3", ".wav", ".mp4" });
           
            var book = new BooksEntity
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                Author = dto.Author,
                CategoryId = dto.CategoryId,
                NumberOfCopy = dto.NumberOfCopy,
                Description = dto.Description,
                CoverImage = coverImagePath,
                PdfUrl = pdfPath,
                AudioClip = audioPath,
                Status = BookStatus.Active, 
                Tag = string.Empty, 
                Publisher = null,
                PublishedDate = null,
                ISBN = null
            };

            dbContext.Books.Add(book);
            await dbContext.SaveChangesAsync();

            var category= await dbContext.Categories.FirstOrDefaultAsync(x=>x.Id ==book.CategoryId);

            //Map to response DTO
            var responseDto = new BookResponseDto
            {

                Title = book.Title,
                Author = book.Author,
                Category = category?.Name?? "null",
                NumberOfCopy = book.NumberOfCopy,
                CoverImage = book.CoverImage,
                PdfUrl = book.PdfUrl,
                AudioClip = book.AudioClip,
                Description = book.Description,

            };

            return responseDto;
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
