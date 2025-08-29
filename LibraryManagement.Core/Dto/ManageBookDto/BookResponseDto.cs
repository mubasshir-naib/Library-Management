using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Dto.ManageBookDto
{
    public class BookResponseDto
    {
        public string Title { get; set; } 
        public string Author { get; set; } 
        public string Category { get; set; } 
        public int NumberOfCopy { get; set; } 
        public string? CoverImage { get; set; } // URL or path to cover image
        public string? PdfUrl { get; set; } // URL or path to PDF file
        public string? AudioClip { get; set; } // URL or path to audio clip
        public string? Description { get; set; } // Description
    }
}
