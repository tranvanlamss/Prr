using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RechargeOnline.Models;
using System.Configuration;

namespace RechargeOnline.Areas.Admin.Controllers
{
    public class Order_adminController : Controller
    {
        DataContext db = new DataContext();
        // GET: Admin/Order_admin
        public ActionResult oder_admin()
        {
            ViewBag.ListBill = db.Oders.ToList();
            ViewBag.ListBill2 = "1";
            return View();
        }
        [HttpPost]
        public ActionResult oder_admin(Day day)
        {
            if (day.Date != null)
            {
                int result = Int32.Parse(day.Date);
                if (result < 10)
                {
                    day.Date = "0" + day.Date;
                }
            }
            if (day.Date == null && day.Month == null && day.Year == 0)
            {
                ViewBag.ListBill1 = day.Month;
                ViewBag.ListBill = db.Oders.ToList();
            }
            else if (day.Date != null && day.Month == null && day.Year == 0)
            {
                var query = "SELECT * FROM dbo.Oders WHERE Create_At LIKE '____" + day.Date + "_____%'";
                ViewBag.ListBill = db.Oders.SqlQuery(query).ToList();
            }
            else if (day.Date != null && day.Month == null && day.Year != 0)
            {
                var query = "SELECT * FROM dbo.Oders WHERE Create_At LIKE '%" + day.Date + "%" + day.Year + "%__%'";
                ViewBag.ListBill = db.Oders.SqlQuery(query).ToList();
            }
            else if (day.Date != null && day.Month != null && day.Year == 0)
            {
                var query = "SELECT * FROM dbo.Oders WHERE Create_At LIKE '%" + day.Month + "%" + day.Date + "%'";
                ViewBag.ListBill = db.Oders.SqlQuery(query).ToList();
            }
            else if (day.Date != null && day.Month != null && day.Year != 0)
            {
                var query = "SELECT * FROM dbo.Oders WHERE Create_At LIKE '%" + day.Month + "%" + day.Date + "%" + day.Year + "%'";
                ViewBag.ListBill = db.Oders.SqlQuery(query).ToList();
            }
            else if (day.Date == null && day.Month != null && day.Year == 0)
            {
                var query = "SELECT * FROM dbo.Oders WHERE Create_At LIKE '%" + day.Month + "%'";
                ViewBag.ListBill = db.Oders.SqlQuery(query).ToList();
            }
            else if (day.Date == null && day.Month == null && day.Year != 0)
            {
                var query = "SELECT * FROM dbo.Oders WHERE Create_At LIKE '%__%" + day.Year + "%__%'";
                ViewBag.ListBill = db.Oders.SqlQuery(query).ToList();
            }
            else if (day.Date == null && day.Month != null && day.Year != 0)
            {
                var query = "SELECT * FROM dbo.Oders WHERE Create_At LIKE '%" + day.Month + "%" + day.Year + "%'";
                ViewBag.ListBill = db.Oders.SqlQuery(query).ToList();
            }
            else if (day.Date == null && day.Month == null && day.Year != 0)
            {
                var query = "SELECT * FROM dbo.Oders WHERE Create_At LIKE '%" + day.Year + "%'";
                ViewBag.ListBill = db.Oders.SqlQuery(query).ToList();
            }
            ViewBag.ListBill1 = day.Month;

            return View();
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oder oder = db.Oders.Find(id);
            if (oder == null)
            {
                return HttpNotFound();
            }
            return View(oder);
        }
    }
}