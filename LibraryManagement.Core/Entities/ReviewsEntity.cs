using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Entities
{
    public class ReviewsEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public string? Comment { get; set; }
        public DateTime Date {  get; set; }
        public string Rating { get; set; }
        public bool? IsHelpful { get; set; }
    }
}
