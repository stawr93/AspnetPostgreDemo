using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AspnetPostgreDemo.Data;
using AspnetPostgreDemo.Data.Models;

namespace AspnetPostgreDemo.Controllers
{
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
            Book book = _bookStoreContext.Books.Find(id);
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
