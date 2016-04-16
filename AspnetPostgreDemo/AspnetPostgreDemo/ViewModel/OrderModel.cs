using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspnetPostgreDemo.ViewModel
{
    using System.ComponentModel;
    using System.Security.Cryptography.X509Certificates;
    using Data.Models;

    public class OrderModel
    {
        [DisplayName("Order's Id") ]
        public long orderId { get; set; }

        [DisplayName ("Book's Id")]
        public List<string> books { get; set; }

        public OrderModel(Order order)
        {
            orderId =  order.Id;
            books = order.Books.Select(x => x.Title).ToList();
        }

    }
}