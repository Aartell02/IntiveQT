using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace IntiveQT.Models
{
    [Table("Author")]
    public class updateAuthor
    {
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Required]
        public string FirstName { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public bool Gender { get; set; }
    }
}
