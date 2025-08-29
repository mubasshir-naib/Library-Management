using LibraryManagement.Application.Commands.ManageBooks;
using LibraryManagement.Application.Queries.ManageBooks;
using LibraryManagement.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Api.Controllers
{
    [Route("api/manage-books")]
    [ApiController]
    public class ManageBooksController(ISender sender) : ControllerBase
    {
       [HttpPost("")]
       public async Task<IActionResult> AddBooksAsync([FromBody] BooksEntity book)
       {
            var result = await sender.Send(new AddBookCommand(book));
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
