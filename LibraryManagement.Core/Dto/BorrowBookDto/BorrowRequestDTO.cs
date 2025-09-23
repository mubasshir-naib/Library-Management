using LibraryManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.DTOs
{
    public class BorrowRequestDTO
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime BorrowingDate { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
