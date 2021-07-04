using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Models
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Book> Books { get; set; }
    }
}
