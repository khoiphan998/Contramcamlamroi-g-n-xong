using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contramcamlamroi.Models;

namespace Contramcamlamroi.Controllers
{

    public class LoginUserController : Controller
    {
        
            // GET: LoginUser
            DBSportStoreEntities2 db = new DBSportStoreEntities2();
            public ActionResult Index()
            {
                return View();
            }
            [HttpPost]
            public ActionResult LoginAcount(AdminUser _user)
            {
                var check = db.AdminUsers.
                    Where(s => s.NameUser == _user.NameUser && s.PasswordUser == _user.PasswordUser).FirstOrDefault();
                if (check == null)
                {
                    ViewBag.ErrorInfo = "Sai Infor";
                    return View("Index");
                }
                else
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    Session["NameUser"] = _user.NameUser;
                    //Session["PasswordUser"] = _user.PasswordUser;
                    return RedirectToAction("Index_Product", "Product");
                }
            }
            public ActionResult RegisterUser()
            {
                return View();
            }
            [HttpPost]
            public ActionResult RegisterUser(AdminUser _user)
            {
                if (ModelState.IsValid)
                {
                    var check_ID = db.AdminUsers.Where(s => s.ID == _user.ID).FirstOrDefault();
                    if (check_ID == null)
                    {
                        db.Configuration.ValidateOnSaveEnabled = false;
                        db.AdminUsers.Add(_user);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.ErrorRegister = "This ID is exixst";
                        return View();
                    }

                }
                return View();
            }
            public ActionResult LogOutUser()
            {
                Session.Abandon();
                return RedirectToAction("Index", "LoginUser");
            }

        }
    }



