using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [StringLength(60,MinimumLength = 3)]
        [Required]
        public string? Title { get; set; }

        [Display(Name ="Release Date")]
        [DataType(DataType.Date)] //Formatting attributes
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }
        
        [Range(1,100)]
        [Column(TypeName = "decimal(18, 2)")]

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required] //Validation attributes
        [StringLength(30)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required]
        public string? Rating { get; set; }
    }
}