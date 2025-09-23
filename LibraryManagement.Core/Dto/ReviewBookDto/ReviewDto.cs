using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Dto.ReviewBookDto
{
    public class ReviewDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? Comment { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; }
        public int HelpfulCount { get; set; }
    }
}
