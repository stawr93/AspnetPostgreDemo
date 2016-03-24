using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AspnetPostgreDemo.Data;
using AspnetPostgreDemo.Data.Models;

namespace AspnetPostgreDemo.Controllers
{
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
            return View(_bookStoreContext.Books.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(long? id)
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

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,PictureUrl,Description,Price")] Book book)
        {
            if (ModelState.IsValid)
            {
                _bookStoreContext.Books.Add(book);
                _bookStoreContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
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
            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,PictureUrl,Description,Price")] Book book)
        {
            if (ModelState.IsValid)
            {
                _bookStoreContext.Entry(book).State = EntityState.Modified;
                _bookStoreContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
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
    }
}
