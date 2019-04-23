using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ASP_NET_MVC_Q2.Models
{
    public class Product
    {
        [Display(Name= "產品唯一代號")]
        public int Id { get; set; }

        [Display(Name = "地區")]
        public string Locale { get; set; }

        [Display(Name = "產品名稱")]
        public string Product_Name { get; set; }

        [Display(Name = "價格")]
        public decimal Price { get; set; }

        [Display(Name = "促銷價格")]
        public string Promote_Price { get; set; }

        [Display(Name = "建立時間")]
        public DateTime Create_Date { get; set; }
    }
}