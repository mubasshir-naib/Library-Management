using LibraryManagement.Application.Commands.ManageBooks;
using LibraryManagement.Application.Queries.ManageBooks;
using LibraryManagement.Core.Dto.ManageBookDto;
using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Api.Controllers
{
    [Route("api/manage-books")]
    [ApiController]
    public class ManageBooksController(ISender sender, IFileService fileService) : ControllerBase
    {
       private readonly IFileService _fileService=fileService;
       [HttpPost("")]
       public async Task<IActionResult> AddBooksAsync([FromForm] BookCreateDto dto)
       {
            try
            {
                if (!_fileService.IsValidFile(dto.CoverImage, new[] { ".png", ".jpg" }))
                    return BadRequest("Invalid cover image format. Must be .png or .jpg.");
                if (!_fileService.IsValidFile(dto.PdfUrl, new[] { ".pdf" }))
                    return BadRequest("Invalid book file format. Must be .pdf.");
                if (!_fileService.IsValidFile(dto.AudioClip, new[] { ".mp3", ".wav", ".mp4" }))
                    return BadRequest("Invalid audio clip format. Must be .mp3, .wav, or .mp4.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            var result = await sender.Send(new AddBookCommand(dto));
            return Ok(result);
       }
       [HttpGet("")]
       public async Task<IActionResult> GetBooksAsync()
       {
            var result = await sender.Send(new GetBooksQueries());
            return Ok(result);
       }
        [HttpPut("{bookId}")]
       public async Task<IActionResult> UpdateBookAsync([FromBody] BooksEntity book,Guid bookId)
       {
            var result =await sender.Send(new  UpdateBookCommand(book, bookId));
            return Ok(result);

       }
      
       [HttpDelete("{bookId}")]
       public async Task<IActionResult> DeleteBookAsync(Guid bookId)
       {
            var result = await sender.Send(new DeleteBookCommand(bookId));
            return Ok(result);

       }

    }
}
