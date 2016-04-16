using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspnetPostgreDemo.ViewModel 
{
    using Data.Models;

    public class DetailsBook : BookViewModelBase
    {

       public string Biography, FullName;

       public DetailsBook(Author author)
        {
            FullName = $"{author.FirstName} {author.LastName} ";
        }

        
        
    }
}