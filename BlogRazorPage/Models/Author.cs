namespace BlogRazorPage.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // Navigation Property
        //public ICollection<Blog> BlogWritten { get; set; }
    }
}
