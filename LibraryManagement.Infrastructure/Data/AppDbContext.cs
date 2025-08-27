using LibraryManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext(options)
    {
        public DbSet<CategoryEntity>Categories { get; set; }
        public DbSet<NewsEntity> LatestNews { get; set; }
    }
}
