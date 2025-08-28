using LibraryManagement.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Commands.ManageCategories
{
    public record DeleteCategoryCommand(Guid categoryId):IRequest<bool>;
    public class DeleteCategoryCommandHandler(IManageCategoryRepository manageCategoryRepository)
        : IRequestHandler<DeleteCategoryCommand, bool>
    {
        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            return await manageCategoryRepository.DeleteCategory(request.categoryId);
        }
    }
}
