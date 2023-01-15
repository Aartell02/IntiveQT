using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IntiveQT.Models
{
    public class UpdateBook
    {
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Rating { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(13)]
        [Required]
        public string ISBN { get; set; }
        [Required]
        public DateTime PublicationDate { get; set; }
    }
}
