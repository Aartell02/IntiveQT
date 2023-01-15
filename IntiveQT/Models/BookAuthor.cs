using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntiveQT.Models
{
    [Table("BookAuthor")]
    public class BookAuthor
    {
        [Required]
        public int BookId { get; set; }
        [Required]
        public int AuthorId { get; set; }

    }
}
