using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Dto.ReviewBookDto
{
    public class AddReviewRequestDto
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public string? Comment { get; set; }
        public int Rating { get; set; }
    }
}
