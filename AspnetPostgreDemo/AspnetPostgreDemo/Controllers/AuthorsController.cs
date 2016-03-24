using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AspnetPostgreDemo.Data;
using AspnetPostgreDemo.Data.Models;

namespace AspnetPostgreDemo.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly BookStoreContext _bookStoreContext = new BookStoreContext();

        // GET: Authors
        public ActionResult Index()
        {
            return View(_bookStoreContext.Authors.ToList());
        }

        // GET: Authors/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var author = _bookStoreContext.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,PictureUrl,Biography")] Author author)
        {
            if (ModelState.IsValid)
            {
                _bookStoreContext.Authors.Add(author);
                _bookStoreContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: Authors/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var author = _bookStoreContext.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,PictureUrl,Biography")] Author author)
        {
            if (ModelState.IsValid)
            {
                _bookStoreContext.Entry(author).State = EntityState.Modified;
                _bookStoreContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var author = _bookStoreContext.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var author = _bookStoreContext.Authors.Find(id);
            _bookStoreContext.Authors.Remove(author);
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
