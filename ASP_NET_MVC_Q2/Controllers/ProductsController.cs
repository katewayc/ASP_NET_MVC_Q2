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

        public ActionResult Detail(int id =1)
        {
            ProductListViewModel productListViewModel = new ProductListViewModel();
            List<ProductViewModel> _products = GetProductsFromJsonFile();
            productListViewModel.ProductList = _products;

            var products = productListViewModel.ProductList
                .Where(m => m.Id == id)
                .FirstOrDefault();

            products.PriceLocal =Convert.ToString(string.Format(new CultureInfo(GetCurrencyByLocale(products.Locale)), "{0:c}", products.Price));

            decimal result;
            if (decimal.TryParse(products.Promote_Price, out result))
            { products.Promote_Price = Convert.ToString(string.Format(new CultureInfo(GetCurrencyByLocale(products.Locale)), "{0:c}", result)); }
            else
            { products.Promote_Price = "-"; }

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

        private string GetCurrencyByLocale(string locale)
        {
            string _currency = "";
            switch (locale)
            {
                case "US":
                    _currency = "en-US";
                    break;
                case "DE":
                    _currency = "de-DE";
                    break;
                case "CA":
                    _currency = "en-CA";
                    break;
                case "ES":
                    _currency = "es-ES";
                    break;
                case "FR":
                    _currency = "fr-FR";
                    break;
                case "JP":
                    _currency = "ja-JP";
                    break;
                default:
                    _currency = "en-US";
                    break;
            }
            return _currency;
        }
    }
}