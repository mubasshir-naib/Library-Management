using LibraryManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<NewsEntity> LatestNews { get; set; }
        public DbSet<ReviewsEntity> Reviews { get; set; }
        public DbSet<BooksEntity> Books { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
            modelBuilder.Entity<BooksEntity>()
                .Property(r => r.Status)
                .HasConversion<string>();

        }
    }
}
