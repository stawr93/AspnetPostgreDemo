namespace AspnetPostgreDemo.Data
{
    using System.Data.Entity;
    using Models;

    /// <summary>
    /// Контекст для работы с базой данных.
    /// Включает в себя коллекции сущностей, которые хранятся в БД.
    /// Позволяет проводить манипуляции над данными: создавать, читать, менять, удалять.
    /// </summary>
    public class BookStoreContext : DbContext
    {
        /// <summary>
        /// Коллекция книг, которая хранится в БД. Соответствует таблице "Books".
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Коллекция авторов, которая хранится в БД. Соответствует таблице "Authors".
        /// </summary>
        public DbSet<Author> Authors { get; set; }

        public DbSet<Order> Orders { get; set; } 


        public BookStoreContext()
        {
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany<Book>(order => order.Books)
                .WithMany(book => book.Orders)
                .Map(orderToBook =>
                {
                    orderToBook.MapLeftKey("OrderId");
                    orderToBook.MapRightKey("BookId");
                    orderToBook.ToTable("OrderBooks");
                });
        }
    }
}