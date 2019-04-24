using System;
using System.Collections.Generic;
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

    public class ProductViewModel : Product
    {
        private string _PriceLocal = "-";
        public string PriceLocal
        {
            get
            {
                decimal result;
                if (decimal.TryParse(_PriceLocal, out result))
                {
                    _PriceLocal = Convert.ToString(string.Format(new CultureInfo(GetCurrencyByLocale(_PriceLocal)), "{0:c}", result));
                }

                return    _PriceLocal;
            }
            set
            {
                decimal result;
                if (decimal.TryParse(value, out result))
                {
                    if (result == 0) { value = "-"; }
                }

                _PriceLocal = value;
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