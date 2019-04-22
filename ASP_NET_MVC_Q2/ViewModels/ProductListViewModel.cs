using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_NET_MVC_Q2.Models;

namespace ASP_NET_MVC_Q2.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<ProductViewModel> ProductList { get; set; }
    }

    public class ProductViewModel: Product
    {
       
    }
}