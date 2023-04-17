using System.ComponentModel.DataAnnotations;

namespace Practice_API.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Title.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please Enter Description.")]
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
