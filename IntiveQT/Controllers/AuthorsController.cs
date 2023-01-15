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
    public class AuthorsController : Controller
    {
        private readonly AuthorsAPIDbContext dbContext;

        public AuthorsController(AuthorsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor(updateAuthor addAuthor)
        {
            var author = new Author()
            {
                FirstName = addAuthor.FirstName,
                LastName = addAuthor.LastName,
                BirthDate = addAuthor.BirthDate,
                Gender = addAuthor.Gender,
            };

            await dbContext.Author.AddAsync(author);
            await dbContext.SaveChangesAsync();

            return Ok(author);
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthor()
        {
            return Ok(await dbContext.Author.ToListAsync());
        }

        [HttpGet]
        [Route("{FirstName}")]
        public async Task<IActionResult> SelectAuthor([FromRoute] string FirstName)
        {
            var author = await dbContext.Author.FirstOrDefaultAsync(name => name.FirstName == FirstName);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }
    }
}
