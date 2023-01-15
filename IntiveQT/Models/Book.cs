using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntiveQT.Models
{
    [Table("Book")]
    public class Book
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

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
