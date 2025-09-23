using LibraryManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Interfaces
{
    public interface IManageCategoryRepository
    {
        Task<CategoryEntity> AddCategoryAsync(CategoryEntity categoryEntity);
        Task<IEnumerable<CategoryEntity>> GetCategoriesAsync();
        Task<CategoryEntity> UpdateCategoryAsync(Guid Id, CategoryEntity categoryEntity);
        Task<bool> DeleteCategory(Guid Id);
    }
}
