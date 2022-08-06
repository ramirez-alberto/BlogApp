using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string Commenter { get; set; }
        public string Body { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        //Inverse navigation property
        public int ArticleID {get;set;}
        public Article Article { get; set; }
    }

}