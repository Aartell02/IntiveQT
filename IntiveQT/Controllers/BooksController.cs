using IntiveQT.Data;
using IntiveQT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntiveQT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly BooksAPIDbContext dbContext;

        public BooksController(BooksAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(UpdateBook addBook)
        {
            var book = new Book()
            {
                Title = addBook.Title,
                Description = addBook.Description,
                Rating = addBook.Rating,
                ISBN = addBook.ISBN,
                PublicationDate = addBook.PublicationDate
            };

            await dbContext.Book.AddAsync(book);
            await dbContext.SaveChangesAsync();

            return Ok(book);
        }

        [HttpGet]
        public async Task<IActionResult> GetBook()
        {
            return Ok(await dbContext.Book.ToListAsync());
        }

        [HttpPost]
        [Route("{Id:int}")]
        public async Task<IActionResult> UpdateBook([FromRoute] int Id, UpdateBook updateBook)
        {
            var book = await dbContext.Book.FindAsync(Id);
            if (book != null)
            {
                book.Title = updateBook.Title;
                book.Description = updateBook.Description;
                book.Rating = updateBook.Rating;
                book.ISBN = updateBook.ISBN;
                book.PublicationDate = updateBook.PublicationDate;
                
                await dbContext.SaveChangesAsync();

                return Ok(book);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int Id)
        {
            var book = await dbContext.Book.FindAsync(Id);
            if (book != null)
            {
                dbContext.Remove(book);
                await dbContext.SaveChangesAsync();
                return Ok(book);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("{Title}")]
        public async Task<IActionResult> SelectBook([FromRoute] string Title)
        {
            var book = await dbContext.Book.FirstOrDefaultAsync(name => name.Title == Title); ;
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }


    }
}
