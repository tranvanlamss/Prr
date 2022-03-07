using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RechargeOnline.Models;

namespace RechargeOnline.Controllers
{
    public class BrandsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Brands
        public ActionResult Index(int? idcate)
        {
            ViewBag.ListCategory = db.categories.Where(p => p.Id == idcate).ToList();
            ViewBag.ListBrand = db.brands.ToList();
            return View();
        }
    }
}
