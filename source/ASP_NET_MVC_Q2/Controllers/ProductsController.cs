using System;
using System.Collections.Generic;
using System.Globalization;
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
        public ActionResult Index(int? page)
        {
            ProductListViewModel model = new ProductListViewModel();
            List<ProductViewModel> products = GetProductsFromJsonFile();
            model.ProductList = products;

            var pageNumber = page ?? 1;
            model.ProductList = model.ProductList.ToPagedList(pageNumber, pageSize);

            return View(model);
        }

        public ActionResult Detail(int id = 1)
        {
            ProductListViewModel model = new ProductListViewModel();
            List<ProductViewModel> productList = GetProductsFromJsonFile();
            model.ProductList = productList;

            var products = model.ProductList
                .Where(m => m.Id == id)
                .FirstOrDefault();

            products.PriceLocal = products.Price.ToString();


            return View(products);
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