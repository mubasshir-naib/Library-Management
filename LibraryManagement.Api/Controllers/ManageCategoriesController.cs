using LibraryManagement.Application.Commands.ManageCategories;
using LibraryManagement.Application.Queries.ManageCategories;
using LibraryManagement.Core.Entities;
using LibraryManagement.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Api.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class ManageCategoriesController(ISender sender) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> AddCategoryAsync([FromBody] CategoryEntity categoryEntity)
        {
            var category= await sender.Send(new AddCategoryCommand(categoryEntity));
            return Ok(category);
        }
        [HttpGet("")]
        public async Task<IActionResult> GetCategoryAsync()
        {
            var categories = await sender.Send(new GetCategoriesQueries());
            return Ok(categories);
        }
        [HttpPut("{categoryId}")]
        public async Task<IActionResult> UpdateCategoryAsync(Guid categoryId, [FromBody] CategoryEntity entity)
        {
            var category = await sender.Send(new UpdateCategoryCommand(categoryId, entity));
            return Ok(category);
        }
        [HttpDelete("{categoryId}")]
        public async Task<IActionResult>DeleteCategoryAsync(Guid categoryId)
        {
            var category= await sender.Send(new  DeleteCategoryCommand(categoryId));
            return Ok(category);
        }
    }

}
