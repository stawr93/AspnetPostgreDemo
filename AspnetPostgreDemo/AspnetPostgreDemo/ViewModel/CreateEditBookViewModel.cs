namespace AspnetPostgreDemo.ViewModel
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;

    public class CreateEditBookViewModel : BookViewModelBase
    {
        public long Id { get; set; }
        
        [DisplayName("Автор")]
        public long AuthorId { get; set; }

        public IEnumerable<SelectListItem> Authors { get; set; }


        public CreateEditBookViewModel(Book book, IEnumerable<Author> authors) : base(book)
        {
            AuthorId = book.Author.Id;
            Authors = authors.Select(author => new SelectListItem
            {
                Text = $"{author.LastName} {author.FirstName}",
                Value = author.Id.ToString()
            });
        }

        public CreateEditBookViewModel(IEnumerable<Author> authors)
        {
            Authors = BuildAuthorsList(authors);
        }

        public CreateEditBookViewModel()
        {
        }

        public static IEnumerable<SelectListItem> BuildAuthorsList(IEnumerable<Author> authors)
        {
            return authors.Select(author => new SelectListItem
            {
                Text = $"{author.LastName} {author.FirstName}",
                Value = author.Id.ToString()
            });
        }
    }
}