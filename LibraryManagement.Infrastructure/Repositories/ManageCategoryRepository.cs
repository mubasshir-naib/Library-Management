using LibraryManagement.Core.Entities;
using LibraryManagement.Core.Interfaces;
using LibraryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Infrastructure.Repositories
{
    public class ManageCategoryRepository(AppDbContext dbContext):IManageCategoryRepository
    {
        public async Task<CategoryEntity>AddCategoryAsync(CategoryEntity categoryEntity)
        {
            categoryEntity.Id= Guid.NewGuid();
            dbContext.Categories.Add(categoryEntity);
            await dbContext.SaveChangesAsync();
            return categoryEntity;
        }
        public async Task<IEnumerable<CategoryEntity>> GetCategoriesAsync()
        {
           return  await dbContext.Categories.ToListAsync();
        }
        public async Task<CategoryEntity>UpdateCategoryAsync(Guid Id,CategoryEntity categoryEntity)
        {
            var category= await dbContext.Categories.FirstOrDefaultAsync(c=>c.Id==Id);
            if(category!= null)
            {   
                category.Name= categoryEntity.Name;
                category.Slug= categoryEntity.Slug;
                await dbContext.SaveChangesAsync();
                return category;
            }else return categoryEntity;
        }
        public async Task<bool>DeleteCategory(Guid Id)
        {
            var category = await dbContext.Categories.FirstOrDefaultAsync(c=>c.Id==Id);
            if (category != null) 
            {
                dbContext.Categories.Remove(category);
                await dbContext.SaveChangesAsync();
                return true;
            } else return false;

        }
    }
}
