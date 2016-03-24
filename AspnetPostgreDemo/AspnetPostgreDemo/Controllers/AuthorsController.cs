using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AspnetPostgreDemo.Data;
using AspnetPostgreDemo.Data.Models;

namespace AspnetPostgreDemo.Controllers
{
    /// <summary>
    /// Контроллер для работы с авторами.
    /// </summary>
    public class AuthorsController : Controller
    {
        /// <summary>
        /// Поле контроллера, в котором хранится контекст для работы с данными.
        /// </summary>
        private readonly BookStoreContext _bookStoreContext = new BookStoreContext();

        // GET: Authors
        /// <summary>
        /// Начальная страница.
        /// </summary>
        /// <returns>Возвращает представление, в котором содержится список авторов с краткой информацией.</returns>
        public ActionResult Index()
        {
            var authors = _bookStoreContext.Authors.ToList();
            return View(authors);
        }

        // GET: Authors/Details/5
        /// <summary>
        /// Страница с детальной информацией об авторе.
        /// </summary>
        /// <param name="id">Идентификатор автора. Опциональный параметер (может быть null).</param>
        /// <returns>Представление с детальной информацией об авторе.</returns>
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                // Если в запросе в качестве идентификатора был указан null
                // значит был получен некорретный запрос, о чем нужно сообщить клиенту
                // В ответе возвращаем Http код 400 (BadRequest).
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Ищем автора с указанным идентификатором
            var author = _bookStoreContext.Authors.Find(id);
            if (author == null)
            {
                // Если автор не был найден, нужно сообщить об этом клиенту
                // Возвращаем Http статус код 404 (NotFound)
                return HttpNotFound();
            }
            return View(author);
        }

        // GET: Authors/Create
        /// <summary>
        /// Страница создания нового автора.
        /// </summary>
        /// <returns>Соответствующее представление.</returns>
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        /// <summary>
        /// Метод для создания нового автора.
        /// </summary>
        /// <param name="author">Данные о новом авторе.</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,PictureUrl,Biography")] Author author)
        {
            // Только если присланные данные корректны
            if (ModelState.IsValid)
            {
                // Добавляем нового автора в контекст
                _bookStoreContext.Authors.Add(author);

                // И сохраняем изменения, чтобы новый автор был записан в БД
                _bookStoreContext.SaveChanges();

                // Перенаправляем клиента на страницу со списком авторов
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: Authors/Edit/5
        /// <summary>
        /// Страница для редактирования автора.
        /// </summary>
        /// <param name="id">Идентификатор редактируемого автора.</param>
        /// <returns>Представление для редактирования данных.</returns>
        public ActionResult Edit(long? id)
        {
            // Логика аналогична методу Details
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
        /// <summary>
        /// Метод для сохранения изменений в данных об авторе.
        /// </summary>
        /// <param name="author">Новые данные об авторе.</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,PictureUrl,Biography")] Author author)
        {
            // Логика аналогична методу Create
            if (ModelState.IsValid)
            {
                // В отличии от метода Create, нам необходимо не добавить, а изменить данные.
                // Поэтому нужно поменять состояние нашей сущности в контексте на "Изменено",
                // чтобы при вызове метода сохранения изменений ORM знала, что нужно изменить
                // данные об авторе.
                _bookStoreContext.Entry(author).State = EntityState.Modified;
                _bookStoreContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        /// <summary>
        /// Страница удаления автора.
        /// </summary>
        /// <param name="id">Идентификатор удаляемого автора.</param>
        public ActionResult Delete(long? id)
        {
            // Логика аналогична методу Edit
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
        /// <summary>
        /// Метод для удаления автора, после того, как пользователь подтвердил удаление.
        /// </summary>
        /// <param name="id">Идентификатор удаляемого автора.</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            // Ищем соответствующего автора
            var author = _bookStoreContext.Authors.Find(id);

            // Удаляем автора из контекста
            _bookStoreContext.Authors.Remove(author);

            // Сохраняем изменения, чтобы автор был удалени из БД
            _bookStoreContext.SaveChanges();

            // Перенаправлем клиента на страницу со списком авторов.
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Метод для освобождения ресурсов, которые использует контроллер.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Нужно освободить контекст.
                _bookStoreContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
