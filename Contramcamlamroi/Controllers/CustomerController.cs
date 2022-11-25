using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contramcamlamroi.Models;

namespace Contramcamlamroi.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        private DBSportStoreEntities2 db = new DBSportStoreEntities2();
        public ActionResult Index(string _name)
        {
            if (_name == null)
                return View(db.Customers.ToList());
            else
                return View(db.Customers.Where(s => s.NameCus.Contains(_name)).ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customer cus)
        {
            try
            {
                db.Customers.Add(cus);
                db.SaveChanges();
                return RedirectToAction("Index_Admin");
            }
            catch
            {
                return Content("Error Craete New");
            }
        }
        public ActionResult Delete()
        {
            return View();
        }
        public ActionResult Details()
        {
            return View();
        }
    }
}