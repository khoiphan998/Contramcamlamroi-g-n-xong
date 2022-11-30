using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contramcamlamroi.Models;

namespace Contramcamlamroi.Controllers
{
    public class OrderProController : Controller
    {
        // GET: OrderPro
        private DBSportStoreEntities2 db = new DBSportStoreEntities2();
        public ActionResult Index(string _name)
        {
            if (_name == null)
                return View(db.OrderPro.ToList());
            else
                return View(db.OrderPro.Where(s => s.NameCus.Contains(_name)).ToList());

        }
        public ActionResult Details(int id)
        {
            return View(db.OrderPro.Where(s => s.ID == id).FirstOrDefault());
        }
        public ActionResult Edit(int id)
        {
            return View(db.OrderPro.Where(s => s.ID == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, OrderPro cate)
        {
            db.Entry(cate).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View(db.OrderPro.Where(s => s.ID == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, OrderPro cate)
        {
            try
            {
                cate = db.OrderPro.Where(s => s.ID == id).FirstOrDefault();
                db.OrderPro.Remove(cate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("This data is using in other table, Error Delete!");
            }
        }
    }
    
}