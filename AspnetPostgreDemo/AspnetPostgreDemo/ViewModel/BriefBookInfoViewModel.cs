namespace AspnetPostgreDemo.ViewModel
{
    using System.ComponentModel;
    using Data.Models;
    
    // TODO: Заменить модель в представлении View/Books/Index на эту;
    // TODO: Также в методе Index контроллера BooksController передавать в метод View экземпляр этого класса.
    /// <summary>
    /// Модель для представления краткой информации о книге.
    /// Используется на странице со списком книг.
    /// </summary>
    public class BriefBookInfoViewModel : BookViewModelBase
    {
        /// <summary>
        /// Информация об авторе книги.
        /// </summary>
        [DisplayName("Автор")]
        public BriefAuthorViewModel BriefAuthor { get; set; }

        public BriefBookInfoViewModel(Book book) : base(book)
        {
            BriefAuthor = new BriefAuthorViewModel(book.Author);
            Id = book.Id;
        }
        public long Id { get; set; }
    }
}