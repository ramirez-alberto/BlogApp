using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApp.Models
{
    public class Article
    {
        public int ArticleID { get; set; }

        [Required(ErrorMessage ="Title is required")]
        [MaxLength(50, ErrorMessage = "Length must be less then 50 characters")]
        public string? Title { get; set; }

        [MinLength(10)]
        [DataType(DataType.MultilineText)]
        public string? Body { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        //Collection  navigation property
        public ICollection<Comment>? Comments {get; set;}
    }
}