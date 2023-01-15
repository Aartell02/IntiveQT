using IntiveQT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace IntiveQT.Data
{
    public class BooksAPIDbContext : DbContext
    {
        public BooksAPIDbContext(DbContextOptions<BooksAPIDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Book>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

            var decimalProps = modelBuilder.Model
            .GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => (System.Nullable.GetUnderlyingType(p.ClrType) ?? p.ClrType) == typeof(decimal));

            foreach (var property in decimalProps)
            {
                property.SetPrecision(5);
                property.SetScale(2);
            }
        }
        public DbSet<Book> Book { get; set; }

    }

}
