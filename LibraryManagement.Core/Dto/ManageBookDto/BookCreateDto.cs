using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Dto.ManageBookDto
{
    public class BookCreateDto
    {
        public string Title { get; set; } 
        public string Author { get; set; } 
        public Guid CategoryId { get; set; } 
        public int NumberOfCopy { get; set; } 
        public IFormFile? CoverImage { get; set; } // Cover image file (.png/.jpg)
        public IFormFile? PdfUrl { get; set; } // Book file (.pdf)
        public IFormFile? AudioClip { get; set; } // Audio clip (.mp3/.wav/.mp4)
        public string? Description { get; set; }
    }
}
