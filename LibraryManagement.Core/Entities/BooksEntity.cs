using LibraryManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Entities
{
    public class BooksEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string? CoverImage { get; set; }
        public string? Description { get; set; }
        public Guid CategoryId { get; set; }
        public string Tag {  get; set; }
        public int NumberOfCopy { get; set; }
        public string? Publisher { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string? ISBN { get; set; }
        public string? AudioClip { get; set; }
        public string? PdfUrl { get; set; }
        public BookStatus Status {  get; set; }
    }
}
