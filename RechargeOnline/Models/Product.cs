using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RechargeOnline.Models
{
    public class Product
    {
        public int Id { set; get; }
        public int Id_categories { set; get; }
        public string Name { set; get; }
        public int Price { set; get; }
    }
}