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
    public record UpdateCategoryCommand(Guid Id, CategoryEntity Category):IRequest<CategoryEntity>;
    public class UpdateCategoryCommandHandler(IManageCategoryRepository manageCategoryRepository)
        : IRequestHandler<UpdateCategoryCommand, CategoryEntity>
    {
        public async Task<CategoryEntity> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            return await manageCategoryRepository.UpdateCategoryAsync(request.Id, request.Category);
        }
    }
}
