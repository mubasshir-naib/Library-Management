using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Queries.ManageCategories
{
    public record GetCategoriesQueries:IRequest<IEnumerable<CategoryEntity>>;
    public class GetCategoriesQueriesHandler(IManageCategoryRepository manageCategoryRepository)
        : IRequestHandler<GetCategoriesQueries, IEnumerable<CategoryEntity>>
    {
        public async Task<IEnumerable<CategoryEntity>> Handle(GetCategoriesQueries request, CancellationToken cancellationToken)
        {
            return await manageCategoryRepository.GetCategoriesAsync();
        }
    }
}
