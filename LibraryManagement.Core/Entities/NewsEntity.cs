using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Entities
{
    public class NewsEntity
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Details { get; set; }
        public string? CoverImage { get; set; }
        public DateTime? CreationDate { get; set; }=DateTime.Now;

    }
}
