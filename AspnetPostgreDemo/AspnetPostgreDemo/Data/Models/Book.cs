namespace AspnetPostgreDemo.Data.Models
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }

        public string PictureUrl { get; set; }

        public Author Author { get; set; }

        public string Description { get; set; }
        
        public decimal Price { get; set; }
    }
}