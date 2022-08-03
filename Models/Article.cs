using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApp.Models
{
    public class Article
    {
        public int Id{get; set;}
        [StringLength(30)]
        [Required]
        public string? Title { get; set;}

        
        [DataType(DataType.MultilineText)]
        public string? Body { get; set; }
    }
}