using System.ComponentModel.DataAnnotations.Schema;

namespace BlogRazorPage.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public int? AuthorId { get; set; }
        //[ForeignKey("AuthorId")]
        public Author Author { get; set; }
    }
}
