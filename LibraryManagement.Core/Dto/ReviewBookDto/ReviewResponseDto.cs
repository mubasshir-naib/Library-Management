using LibraryManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Dto.ReviewBookDto
{
    public class ReviewResponseDto
    {
        public IEnumerable<ReviewDto> Reviews { get; set; }
        public RatingBreakDownDto RatingBreakDown { get; set; }
        public double AverageRating { get; set; }
        public int TotalReviews { get; set; }

      }
}
