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

        public async Task<IEnumerable<BooksEntity>> GetBooks()
        {
            return await dbContext.Books.ToListAsync();
        }
        public async Task<BooksEntity> GetBooksbyId(Guid id)
        {
            return await dbContext.Books.FirstOrDefaultAsync(x=>x.Id == id);
        }
        public async Task<BooksEntity>AddBooks(BookCreateDto dto)
        {


            // Save files and get relative paths
            //string coverImagePath = await _fileService.SaveFileAsync(dto.CoverImage, "covers");
            //string pdfPath = await _fileService.SaveFileAsync(dto.PdfUrl, "books");
            //string audioPath = await _fileService.SaveFileAsync(dto.AudioClip, "audio");
            string coverImagePath;
            string pdfPath;
            string audioPath;
          
            coverImagePath = await _fileService.SaveFileAsync(dto.CoverImage, "covers", new[] { ".png", ".jpg" });
            pdfPath = await _fileService.SaveFileAsync(dto.PdfUrl, "books", new[] { ".pdf" });
            audioPath = await _fileService.SaveFileAsync(dto.AudioClip, "audio", new[] { ".mp3", ".wav", ".mp4" });
           
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
                Status = BookStatus.Active, // DefaultBookStatus.Available
                Tag = string.Empty, // Default
                Publisher = null,
                PublishedDate = null,
                ISBN = null
            };

            // Save to database
            //  await dbContext.Books.AddAsync(book);
            dbContext.Books.Add(book);
            await dbContext.SaveChangesAsync();

            // Map to response DTO
            //var responseDto = new BookResponseDto
            //{
                
            //    Title = book.Title,
            //    Author = book.Author,
            //    Category = "abc",
            //    NumberOfCopy = book.NumberOfCopy,
            //    CoverImage = book.CoverImage,
            //    PdfUrl = book.PdfUrl,
            //    AudioClip = book.AudioClip,
            //    Description = book.Description,
                
            //};

            return book;
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
