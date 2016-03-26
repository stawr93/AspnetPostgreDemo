namespace AspnetPostgreDemo.ViewModel
{
    using System;
    using Data.Models;

    // TODO: Наполнить класс модели необходимыми данными;
    // TODO: Реализовать конструктор public BriefAuthorViewModel(Author author);
    // TODO: Использовать эту модель в представлении списка авторов (View/Authors/Index);
    // TODO: Создать класс-наследник для представления полной информации об авторе
    // TODO: с соответствующими конструкторами и использовать созданную модель
    // TODO: в представлениях созданя/редактирования/удаления авторов.
    /// <summary>
    /// Модель для представления краткой информации об авторе.
    /// </summary>
    public class BriefAuthorViewModel
    {
        /// <summary>
        /// Конструктор модели из сущности предметной области.
        /// </summary>
        /// <param name="author">Автор, информацию о котором нужно представить пользователю.</param>
        public BriefAuthorViewModel(Author author)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Базовый конструктор без параметров. Для служебных целей.
        /// </summary>
        public BriefAuthorViewModel()
        {
        }
    }
}