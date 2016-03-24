namespace AspnetPostgreDemo.Data.Models
{
    using System.ComponentModel;

    /// <summary>
    /// Сущность "Книга".
    /// </summary>
    public class Book : BaseEntity
    {
        /// <summary>
        /// Название книги.
        /// </summary>
        [DisplayName("Название")]
        public string Title { get; set; }

        /// <summary>
        /// Ссылка на картинку.
        /// </summary>
        public string PictureUrl { get; set; }

        /// <summary>
        /// Автор книги.
        /// </summary>
        public Author Author { get; set; }

        /// <summary>
        /// Описание книги.
        /// </summary>
        [DisplayName("Описание")]
        public string Description { get; set; }
        
        /// <summary>
        /// Стоимость книги.
        /// </summary>
        [DisplayName("Цена")]
        public decimal Price { get; set; }
    }
}