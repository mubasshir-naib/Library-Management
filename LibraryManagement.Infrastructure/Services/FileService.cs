using LibraryManagement.Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Infrastructure.Services
{
    public class FileService :IFileService
    {
        
        private readonly IAppEnvironment _appEnv;
        private readonly ILogger<FileService> _logger;

        public FileService(IAppEnvironment appEnv, ILogger<FileService> logger)
        {
            _appEnv = appEnv;
            _logger = logger;
        }

        public async Task<string> SaveFileAsync(IFormFile file, string folder, string[] allowedExtensions)
        {
            if (file == null || file.Length == 0)
            {
                _logger.LogError("No file provided for upload in folder: {Folder}", folder);
                throw new ArgumentException("No file provided.");
            }

            // Create folder path
            string uploadsDir = Path.Combine(_appEnv.WebRootPath, "Uploads", folder);
            if (!Directory.Exists(uploadsDir))
            {
                Directory.CreateDirectory(uploadsDir);
                _logger.LogInformation("Created directory: {UploadsDir}", uploadsDir);
            }

            // Ensure correct extension
            string extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!allowedExtensions.Contains(extension))
            {
                _logger.LogError("File extension {Extension} does not match allowed extensions for {FileName}",
                    extension, file.FileName);
                throw new ArgumentException($"File extension {extension} is not allowed.");
            }

            string fileName = $"{Guid.NewGuid()}{extension}";
            string filePath = Path.Combine(uploadsDir, fileName);

            _logger.LogInformation("Saving file {FileName} to {FilePath}", file.FileName, filePath);

            // Save file
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"/Uploads/{folder}/{fileName}";
        }

        public bool IsValidFile(IFormFile file, string[] allowedExtensions, long maxSizeBytes)
        {
            if (file == null || file.Length == 0)
            {
                _logger.LogWarning("File is null or empty.");
                return false;
            }

            if (file.Length > maxSizeBytes)
            {
                _logger.LogWarning("File {FileName} exceeds size limit of {MaxSizeBytes} bytes.",
                    file.FileName, maxSizeBytes);
                return false;
            }

            string extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!allowedExtensions.Contains(extension))
            {
                _logger.LogWarning("File {FileName} has invalid extension {Extension}. Allowed: {AllowedExtensions}",
                    file.FileName, extension, string.Join(", ", allowedExtensions));
                return false;
            }

            // Validate MIME type
            string contentType = file.ContentType.ToLowerInvariant();
            bool isValidContentType = (extension, contentType) switch
            {
                (".png", "image/png") => true,
                (".jpg", "image/jpeg") => true,
                (".pdf", "application/pdf") => true,
                (".mp3", "audio/mpeg") => true,
                (".wav", "audio/wav") => true,
                (".mp4", "audio/mp4") => true,
                _ => false
            };

            if (!isValidContentType)
            {
                _logger.LogWarning("File {FileName} has invalid MIME type {ContentType} for extension {Extension}",
                    file.FileName, contentType, extension);
            }

            return isValidContentType;
        }

        public async Task<Stream> GetFileAsync(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                _logger.LogError("File path is empty.");
                throw new ArgumentException("File path is empty.");
            }

            string physicalPath = Path.Combine(_appEnv.WebRootPath, filePath.TrimStart('/'));
            if (!File.Exists(physicalPath))
            {
                _logger.LogError("File not found at {PhysicalPath}", physicalPath);
                throw new FileNotFoundException("File not found.", physicalPath);
            }

            _logger.LogInformation("Retrieving file from {PhysicalPath}", physicalPath);
            return new FileStream(physicalPath, FileMode.Open, FileAccess.Read);
        }
    }
}