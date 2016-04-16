using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AspnetPostgreDemo.Data;
using AspnetPostgreDemo.Data.Models;

namespace AspnetPostgreDemo.Controllers
{
    using ViewModel;

    /// <summary>
    /// Контроллер для работы с книгами.
    /// Все методы аналогичны AuthorsController.
    /// </summary>
    public class BooksController : Controller
    {
        private readonly BookStoreContext _bookStoreContext = new BookStoreContext();

        // GET: Books
        public ActionResult Index()
        {
            var books = _bookStoreContext.Books
                .Include(book => book.Author)
                .ToList();
            return View(books.Select(book => new BriefBookInfoViewModel(book)));
        }

        // GET: Books/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var book = _bookStoreContext.Books
                .Include(b => b.Author)
                .SingleOrDefault(b => b.Id == id);

            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            var authors = _bookStoreContext.Authors.ToList();
            var viewModel = new CreateEditBookViewModel(authors);

            return View(viewModel);
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateEditBookViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                var book = CreateBook(bookViewModel);
                _bookStoreContext.Books.Add(book);
                _bookStoreContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookViewModel);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var book = _bookStoreContext.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            var authors = _bookStoreContext.Authors.ToList();
            var viewMobel = new CreateEditBookViewModel(book, authors);
            return View(viewMobel);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CreateEditBookViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                var book = _bookStoreContext.Books.Find(bookViewModel.Id);
                if (book == null)
                {
                    return HttpNotFound();
                }
                UpdateBook(book, bookViewModel);
                _bookStoreContext.Entry(book).State = EntityState.Modified;
                _bookStoreContext.SaveChanges();
                return RedirectToAction("Index");
            }

            var authors = _bookStoreContext.Authors.ToList();
            bookViewModel.Authors = CreateEditBookViewModel.BuildAuthorsList(authors);
            return View(bookViewModel);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var book = _bookStoreContext.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var book = _bookStoreContext.Books.Find(id);
            _bookStoreContext.Books.Remove(book);
            _bookStoreContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _bookStoreContext.Dispose();
            }
            base.Dispose(disposing);
        }

        private static Book CreateBook(CreateEditBookViewModel viewModel)
        {
            var book = new Book
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                PictureUrl = viewModel.PictureUrl,
                Price = viewModel.Price,
                Author_Id = viewModel.AuthorId
            };
            return book;
        }

        private static Book UpdateBook(Book bookForUpdating, CreateEditBookViewModel viewModel)
        {
            bookForUpdating.Author_Id = viewModel.AuthorId;
            bookForUpdating.Title = viewModel.Title;
            bookForUpdating.Description = viewModel.Description;
            bookForUpdating.PictureUrl = viewModel.PictureUrl;
            bookForUpdating.Price = viewModel.Price;
            bookForUpdating.Price = viewModel.Price;
            return bookForUpdating;;
        }

        public ActionResult KUPIKNIGU(long id)
        {
            var book = _bookStoreContext.Books.Find(id);
            var order = _bookStoreContext.Orders.ToList().LastOrDefault();
            order.Books.Add(book);
           
            _bookStoreContext.SaveChanges();


            return RedirectToAction("Details", new {id=id});
        }
    }
}
