using LibraryManagement.Core.Enums;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Entities
{
    public class BorrowEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public DateTime BorrowingDate { get; set; }
        public DateTime? DueDate { get; set; }
        public bool? IsReturned { get; set; } = null;
        public DateTime? ReturnDate { get; set; }
        public BorrowRequestStatus BorrowRequestStatusEnum { get; set; }
    }
}
