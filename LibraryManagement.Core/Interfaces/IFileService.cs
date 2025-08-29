using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Interfaces
{
    //public interface IFileService
    //{
    //    //Task<string> SaveFileAsync(IFormFile file, string folder);
    //    //bool IsValidFile(IFormFile file, string[] allowedExtensions, long maxSizeBytes = 100 * 1024 * 1024);

    //}
    public interface IFileService
    {
        Task<string> SaveFileAsync(IFormFile file, string folder, string[] allowedExtensions);
        bool IsValidFile(IFormFile file, string[] allowedExtensions, long maxSizeBytes = 100 * 1024 * 1024);
        Task<Stream> GetFileAsync(string filePath);
    }
}
