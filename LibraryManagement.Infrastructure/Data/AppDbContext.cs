using LibraryManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<NewsEntity> LatestNews { get; set; }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<BorrowEntity> Borrows { get; set; }


        public DbSet<ReviewsEntity> Reviews { get; set; }
        public DbSet<BooksEntity> Books { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BooksEntity>()
                .Property(r => r.Status)
                .HasConversion<string>();

            modelBuilder.Entity<UserEntity>(e =>
            {
                e.Property(r => r.UserRoleEnum).HasConversion<string>();
                e.Property(r => r.UserStatusEnum).HasConversion<string>();
            });

            modelBuilder.Entity<BorrowEntity>().Property(r=>r.BorrowRequestStatusEnum).HasConversion<string>();
             

        }

    }
}
