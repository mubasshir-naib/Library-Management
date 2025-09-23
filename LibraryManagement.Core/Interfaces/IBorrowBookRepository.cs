using LibraryManagement.Core.DTOs;
using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Enums;

namespace LibraryManagement.Core.Interfaces
{
    public interface IBorrowBookRepository
    {
        public Task<BorrowBookDetailsDTO> GetBorrowBookDetails(Guid bookId);
        public Task<BorrowEntity?> BorrowBookRequest(BorrowRequestDTO borrowRequest);
        public Task<BorrowEntity?> ChangeBorrowBookStatus(Guid borrowId, BorrowRequestStatus status);
        public Task<BorrowEntity> ReturnBookStatus(Guid borrowId);
        public Task<IEnumerable<BorrowEntity>> GetAllBorrowRequest();
        public Task<IEnumerable<BorrowEntity>> GetCurrentBorrows();
        public Task<IEnumerable<BorrowEntity>> GetOverDueBorrows();
        public Task<IEnumerable<BorrowEntity>> GetBorrowsByUser(Guid userId);
        public Task<IEnumerable<BorrowEntity>> GetBorrowsByBooks(Guid bookId);

    }
}

