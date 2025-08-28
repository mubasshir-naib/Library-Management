using LibraryManagement.Application.Commands.Borrows;
using LibraryManagement.Application.Queries.Borrows;
using LibraryManagement.Core.DTOs;
using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Api.Controllers
{
    [Route("api/borrow")]
    [ApiController]
    public class BorrowController(ISender sender) : ControllerBase
    {
        [HttpGet("{bookId}")]
        public async Task<IActionResult> BorrowDetails(Guid bookId)
        {
            var result = await sender.Send(new GetBorrowBookDetailsQuery(bookId));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> BorrowRequest([FromBody] BorrowRequestDTO borrowRequest)
        {
            var result = await sender.Send(new AddBorrowRequestCommand(borrowRequest));
            return Ok(result);
        }

        [HttpPatch("{requestId}")]
        public async Task<IActionResult> ChangeBorrowRequestStatus([FromRoute] Guid requestId, [FromBody] BorrowRequestStatus status)
        {
            var result = await sender.Send(new ChangeBorrowBookStatusCommand(requestId,status));
            return Ok(result);
        }
        [HttpGet("all-request")]
        public async Task<IActionResult> GetAllBorrowRequest()
        {
            var result = await sender.Send(new GetAllBorrowRequestQuery());
            return Ok(result);
        }

        [HttpGet("current-borrow")]
        public async Task<IActionResult> GetCurrentBorrow()
        {
            var result = await sender.Send(new GetCurrentBorrowsQuery());
                return Ok(result);
        }

        [HttpGet("overdue-borrow")]
        public async Task<IActionResult> GetOverDueBorrow()
        {
            var result = await sender.Send(new GetOverDueBorrowsQuery());
            return Ok(result);
        }

        [HttpPatch("return-book/{requestId}")]
        public async Task<IActionResult> ReturnBookStatus([FromRoute] Guid requestId)
        {
            var result = await sender.Send(new ReturnBookCommand(requestId));
            return Ok(result);
        }
    }
}
