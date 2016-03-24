namespace AspnetPostgreDemo.Data
{
    using System.Data.Entity;
    using Models;

    public class BookStoreContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }
    }
}