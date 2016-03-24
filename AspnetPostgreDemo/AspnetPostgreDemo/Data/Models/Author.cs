namespace AspnetPostgreDemo.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;

    /// <summary>
    /// Автор книг.
    /// </summary>
    public class Author : BaseEntity
    {
        /// <summary>
        /// Имя.
        /// </summary>
        [DisplayName("Имя")]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        [DisplayName("Фамилия")]
        public string LastName { get; set; }

        /// <summary>
        /// Ссылка на аватарку автора.
        /// </summary>
        public string PictureUrl { get; set; }

        /// <summary>
        /// Биография автора: кто по образованию, кем работает/чем занимается,
        /// достижения, вклад в науку и т.п.
        /// </summary>
        [DisplayName("Биография")]
        public string Biography { get; set; }

        /// <summary>
        /// Книги, написанные автором.
        /// </summary>
        public ICollection<Book> Books { get; set; }
    }
}