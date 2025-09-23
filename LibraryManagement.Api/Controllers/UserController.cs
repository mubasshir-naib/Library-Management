using LibraryManagement.Application.Commands.ManageBooks;
using LibraryManagement.Application.Commands.Users;
using LibraryManagement.Application.Queries.Users;
using LibraryManagement.Core.Dto.ManageBookDto;
using LibraryManagement.Core.Dto.UserDto;
using LibraryManagement.Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace LibraryManagement.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController(ISender sender, IFileService fileService) : ControllerBase
    {
        private readonly IFileService _fileService = fileService;

        [HttpPost("")]
        public async Task<IActionResult> AddUserAsync([FromForm] UserCreateDto dto)
        {
            try
            {
                if (dto.Avatar != null && !_fileService.IsValidFile(dto.Avatar, new[] { ".png", ".jpg" }))
                    return BadRequest("Invalid Image format. Must be .png or .jpg");

            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
            var result = await sender.Send(new AddUserCommand(dto));
            return Ok(result);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetUserAsync()
        {
            var result = await sender.Send(new GetUserQueries());
            return Ok(result);
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult>GetUserByIdAsync(Guid userId)
        {
            var result = await sender.Send(new GetUserByIdQuery(userId));
            return Ok(result);
        }
        [HttpPut("{userId}")]
        public async Task<IActionResult>UpdateUserAsync(Guid userId,UserCreateDto dto)
        {
            var result = await sender.Send(new UpdateUserCommand(userId, dto));
            return Ok(result);  

        }
        [HttpDelete("{userId}")]
        public async Task<IActionResult>DeleteUserAsync(Guid userId)
        {
            var result= await sender.Send(new  DeleteUserCommand(userId));
            return Ok(result);
        }
       

    }
}
