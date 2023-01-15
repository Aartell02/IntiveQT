using IntiveQT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace IntiveQT.Data
{
    public class AuthorsAPIDbContext : DbContext
    {
        public AuthorsAPIDbContext(DbContextOptions<AuthorsAPIDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Author>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();
        }
        public DbSet<Author> Author { get; set; }

    }

}
