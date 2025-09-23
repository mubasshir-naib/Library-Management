using LibraryManagement.Core.DTOs;
using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Enums;
using LibraryManagement.Core.Interfaces;
using LibraryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace LibraryManagement.Infrastructure.Repositories
{
    public class BorrowBookRepository(AppDbContext appDbContext) : IBorrowBookRepository
    {
        public async Task<BorrowEntity?> ChangeBorrowBookStatus(Guid borrowId,BorrowRequestStatus status)
        {
            BorrowEntity? borrowEntity= await appDbContext.Borrows.FirstOrDefaultAsync(b => b.Id == borrowId);
            if (borrowEntity is null)
                return null;

            if (status == BorrowRequestStatus.Accepted)
            {
                borrowEntity.BorrowingDate = DateTime.Now;
                borrowEntity.DueDate = borrowEntity.BorrowingDate.AddDays(15);
            }

            borrowEntity.BorrowRequestStatusEnum = status;
               
                appDbContext.Borrows.Update(borrowEntity);
                await appDbContext.SaveChangesAsync();
            return borrowEntity;     
        }

        public async Task<BorrowEntity?> BorrowBookRequest(BorrowRequestDTO borrowRequest)
        {
            bool isBorrowedOrRequested = await appDbContext.Borrows
                .AnyAsync(b => b.BookId == borrowRequest.BookId &&
                    (b.BorrowRequestStatusEnum == BorrowRequestStatus.Pending
                    || (b.BorrowRequestStatusEnum == BorrowRequestStatus.Accepted && (b.IsReturned == false))));

            if (!isBorrowedOrRequested)
            {
                BorrowEntity Borrow = new BorrowEntity
                {
                    Id = Guid.NewGuid(),
                    UserId = borrowRequest.UserId,
                    BookId = borrowRequest.BookId,
                    BorrowingDate = borrowRequest.BorrowingDate,
                    DueDate = borrowRequest.DueDate,
                    IsReturned = false,
                    ReturnDate = null,
                    BorrowRequestStatusEnum = BorrowRequestStatus.Pending
                };
                await appDbContext.Borrows.AddAsync(Borrow);
                await appDbContext.SaveChangesAsync();

                return Borrow;
            }

            return null;
        }


        public async Task<IEnumerable<BorrowEntity>> GetAllBorrowRequest()
        {
            return await appDbContext.Borrows.Where(b=>b.BorrowRequestStatusEnum!=BorrowRequestStatus.Accepted).ToListAsync();
        }

        public async Task<BorrowBookDetailsDTO> GetBorrowBookDetails(Guid bookId)
        {
            int TotalBooks;
            int AvailableBooks;
            BooksEntity Books = await appDbContext.Books.FirstOrDefaultAsync(b => b.Id == bookId);
            if (Books == null) return null; 
            TotalBooks = Books.NumberOfCopy;
            IEnumerable<BorrowEntity> CurrentBorrows = await GetBorrowsByBooks(bookId);
            AvailableBooks = TotalBooks - CurrentBorrows.Count();


            if (AvailableBooks > 0) {
                return new BorrowBookDetailsDTO
                {
                    BookId = Books.Id,
                    Title = Books.Title,
                    Author = Books.Author,
                    CoverImage = Books.CoverImage,
                    Description = Books.Description,
                    AvailableFrom = DateTime.Today,
                    MustReturnBy = DateTime.Today.AddDays(15),
                };
            }
            DateTime earliestDueDate = (DateTime)CurrentBorrows.Min(b => b.DueDate);
            return new BorrowBookDetailsDTO
            {
                BookId = Books.Id,
                Title = Books.Title,
                Author = Books.Author,
                CoverImage = Books.CoverImage,
                Description = Books.Description,
                AvailableFrom = earliestDueDate,
                MustReturnBy = earliestDueDate.AddDays(15),
            };


        }

        public async Task<IEnumerable<BorrowEntity>> GetBorrowsByBooks(Guid bookId)
        {
            return await appDbContext.Borrows
                .Where(b=>b.Id==bookId && b.BorrowRequestStatusEnum==BorrowRequestStatus.Accepted && b.IsReturned==false)
                .ToListAsync();
        }

        public async Task<IEnumerable<BorrowEntity>> GetBorrowsByUser(Guid userId)
        {
            return await appDbContext.Borrows
                .Where(b=>b.UserId==userId && b.BorrowRequestStatusEnum==BorrowRequestStatus.Accepted)
                .ToListAsync();
        }

        public async Task<IEnumerable<BorrowEntity>> GetCurrentBorrows()
        {
            return await appDbContext.Borrows
                .Where(b=> b.BorrowRequestStatusEnum==BorrowRequestStatus.Accepted && b.IsReturned==false)
                .ToListAsync();
        }

        public async Task<IEnumerable<BorrowEntity>> GetOverDueBorrows()
        {
            return await appDbContext.Borrows
                .Where(b=>b.DueDate < DateTime.Today && b.IsReturned==false)
                .ToListAsync();
        }

        public async Task<BorrowEntity> ReturnBookStatus(Guid borrowId)
        {
           BorrowEntity borrowEntity=await appDbContext.Borrows.FirstOrDefaultAsync(b=>b.Id==borrowId && b.BorrowRequestStatusEnum==BorrowRequestStatus.Accepted);
            if (borrowEntity is null) return null;

            if (borrowEntity.IsReturned == true)
            {
                borrowEntity.IsReturned = false;
                borrowEntity.ReturnDate = null;
            }
            else
            {
                borrowEntity.IsReturned = true;
                borrowEntity.ReturnDate = DateTime.Now;
            }
            appDbContext.Borrows.Update(borrowEntity);
            await appDbContext.SaveChangesAsync();
            return borrowEntity;
        }
    }
}
