namespace AspnetPostgreDemo.Data.Models
{
    using System.Collections.Generic;

    public class Author : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PictureUrl { get; set; }

        public string Biography { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}