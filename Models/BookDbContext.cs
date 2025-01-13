using LibEaseAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibEaseAPI.Models
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
