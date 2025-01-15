using LibEaseAPI.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace LibEaseAPI.Models
{
    public class BookDbContext : IdentityDbContext<User>
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
        }

        // DbSet representing the Books table
        public DbSet<Book> Books { get; set; }

        // Override OnModelCreating to configure the model and seed data
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Hash password for user
            var hasher = new PasswordHasher<User>();


            // Seed a default user to the database
            builder.Entity<User>().HasData(new User
            {
                Id = Guid.NewGuid().ToString(), // Unique ID
                UserName = "admin@example.com",
                NormalizedUserName = "ADMIN@EXAMPLE.COM",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "AdminPassword123!"),
                SecurityStamp = Guid.NewGuid().ToString()
            });
        }
    }
}
