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
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            return View(db.Customers.Where(s => s.IDCus == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, Customer name)
        {
            db.Entry(name).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View(db.Customers.Where(s => s.IDCus == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, Customer cate)
        {
            try
            {
                cate = db.Customers.Where(s => s.IDCus == id).FirstOrDefault();
                object p = db.Customers.Remove(cate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("This data is using in other table, Error Delete!");
            }
        }
        public ActionResult Details(int id)
        {
            return View(db.Customers.Where(s => s.IDCus == id).FirstOrDefault());
        }
    }
}
