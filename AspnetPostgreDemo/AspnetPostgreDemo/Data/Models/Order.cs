using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspnetPostgreDemo.Data.Models
{
    using System.Web.Services.Description;

    public class Order : BaseEntity
    {


        
        public virtual ICollection<Book> Books { get; set; }

        public Order()
        {
            Books = new List<Book>();
        }

    }
}