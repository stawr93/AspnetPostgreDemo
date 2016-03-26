namespace AspnetPostgreDemo.ViewModel
{
    using System.ComponentModel;
    using Data.Models;

    /// <summary>
    /// Базовая модель для представления информации о книге.
    /// В ней содержатся все основные поля, которые будут необходимы для всех моделей-наследников. 
    /// </summary>
    public abstract class BookViewModelBase
    {
        /// <summary>
        /// Конструктор модели из сущности предметной области.
        /// Создает модель и заполняет ту информацию, которая содержится <see cref="book"/>.
        /// </summary>
        /// <param name="book">Сущность предметной области, на основании которой конструируется моедль представления.</param>
        protected BookViewModelBase(Book book)
        {
            Title = book.Title;
            PictureUrl = book.PictureUrl;
            Description = book.Description;
            Price = book.Price;
        }

        /// <summary>
        /// Конструктор по умолчанию без параметров.
        /// Нужен для того, чтобы можно было создать пустую модель, например, для создания новой книги.
        /// </summary>
        protected BookViewModelBase()
        {
        }

        /// <summary>
        /// Название книги.
        /// </summary>
        [DisplayName("Название")] // Этот атрибут используется для показа названия поля 
                                  // рядом с input'ом в конструкции @Html.LabelFor(model => model.Title)
        public string Title { get; set; }

        /// <summary>
        /// Ссылка на картинку.
        /// </summary>
        public string PictureUrl { get; set; }

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