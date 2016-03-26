namespace AspnetPostgreDemo.Data.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey(nameof(Author_Id))]
        public Author Author { get; set; }

        /// <summary>
        /// Идентификатор автора книги.
        /// </summary>
        public long Author_Id { get; set; }

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