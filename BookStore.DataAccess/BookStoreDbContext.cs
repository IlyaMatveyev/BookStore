using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {
            Database.EnsureCreated(); //создать бд при обращении, если её нет
        }

        public DbSet<BookEntity> Books { get; set; }
    }
}