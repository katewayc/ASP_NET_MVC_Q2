using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_NET_MVC_Q2.ViewModels;
using Newtonsoft.Json;
using X.PagedList;

namespace ASP_NET_MVC_Q2.Controllers
{
    public class ProductsController : Controller
    {
        private int pageSize = 5;
        // GET: Products
        public ActionResult Index(int? page)
        {
            ProductListViewModel productListViewModel = new ProductListViewModel();
            List<ProductViewModel> products = GetProductsFromJsonFile();
            productListViewModel.ProductList = products;

            var pageNumber = page ?? 1;
            productListViewModel.ProductList = productListViewModel.ProductList.ToPagedList(pageNumber, pageSize);

            return View(productListViewModel);
        }

        private List<ProductViewModel> GetProductsFromJsonFile()
        {
            List<ProductViewModel> productListViewModels = null;

            string FileName = @"data.json";

            using (StreamReader sr = new StreamReader(Server.MapPath(@"~/App_Data/" + FileName)))
            {
                string json = sr.ReadToEnd();
                List<ProductViewModel> items = JsonConvert.DeserializeObject<List<ProductViewModel>>(json);
                productListViewModels = items;
            }

            return productListViewModels;
        }
    }
}