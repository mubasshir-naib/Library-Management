using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.ManageCategories
{
    public record AddCategoryCommand(CategoryEntity categoryEntity):IRequest<CategoryEntity>;
    public class AddCategoryCommandHandler(IManageCategoryRepository manageCategoryRepository)
        : IRequestHandler<AddCategoryCommand, CategoryEntity>
    {
        public async Task<CategoryEntity> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            return await manageCategoryRepository.AddCategoryAsync(request.categoryEntity);
        }
    }
}
