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
    }
}