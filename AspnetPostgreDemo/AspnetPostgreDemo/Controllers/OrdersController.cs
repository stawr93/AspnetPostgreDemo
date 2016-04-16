using AspnetPostgreDemo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspnetPostgreDemo.Controllers
{
    using Data.Models;
    using ViewModel;

    public class OrdersController : Controller
    {
        private readonly BookStoreContext _bookStoreContext = new BookStoreContext();
        // GET: Orders
        public ActionResult Index()
        {
            var orders = _bookStoreContext.Orders.ToList();
            var model = new List<OrderModel>();
            foreach (var item in orders)
            {
                model.Add(new OrderModel(item));
            }
            return View(model);
        }
        
        public ActionResult NewOrder()
        {
            var order = new Order();
            _bookStoreContext.Orders.Add(order);
            _bookStoreContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}