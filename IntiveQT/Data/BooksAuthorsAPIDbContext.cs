using IntiveQT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace IntiveQT.Data
{
    public class BooksAuthorsAPIDbContext : DbContext
    {
        public BooksAuthorsAPIDbContext(DbContextOptions<BooksAuthorsAPIDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        public DbSet<BookAuthor> BookAuthor { get; set; }

    }

}
