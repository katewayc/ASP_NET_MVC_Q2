using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using ASP_NET_MVC_Q2.Models;

namespace ASP_NET_MVC_Q2.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<ProductViewModel> ProductList { get; set; }
    }

    public class ProductViewModel
    {
        [Display(Name = "產品唯一代號")]
        public int Id { get; set; }

        [Display(Name = "地區")]
        public string Locale { get; set; }

        [Display(Name = "產品名稱")]
        public string Product_Name { get; set; }

        [Display(Name = "價格")]
        public decimal Price { get; set; }

        private string _promotePrice = "-";
        [Display(Name = "促銷價格")]
        public string Promote_Price
        {
            get
            {
                decimal result;
                if (decimal.TryParse(_promotePrice, out result))
                {
                    _promotePrice = Convert.ToString(string.Format(new CultureInfo(GetCurrencyByLocale(Locale)), "{0:c}", result));
                }

                return _promotePrice;
            }
            set
            {
                decimal result;
                if (!decimal.TryParse(value, out result)|| result == 0)
                {
                    value = "-";
                }

                _promotePrice = value;
            }
        }

        [Display(Name = "建立時間")]
        public DateTime Create_Date { get; set; }

        private string _priceLocal = "-";
        public string PriceLocal
        {
            get
            {
                decimal result;
                if (decimal.TryParse(_priceLocal, out result))
                {
                    _priceLocal = Convert.ToString(string.Format(new CultureInfo(GetCurrencyByLocale(Locale)), "{0:c}", result));
                }

                return    _priceLocal;
            }
            set
            {
                decimal result;
                if (decimal.TryParse(value, out result))
                {
                    if (result == 0) { value = "-"; }
                }

                _priceLocal = value;
            }
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