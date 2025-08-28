using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.DTOs
{
    public class BorrowBookDetailsDTO
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string? CoverImage { get; set; }
        public string? Description { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime MustReturnBy { get; set; }

    }
}
