using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Contramcamlamroi.Models;

namespace Contramcamlamroi.Controllers
{
    public class OrderDetailController : Controller
    {
        DBSportStoreEntities2 database = new DBSportStoreEntities2();
        // GET: OrderDetail
        public ActionResult GroupByTop5()
        {
            List<OrderDetail> ordersD = database.OrderDetails.ToList();
            List<Product> proList = database.Products.ToList();
            var query = from od in ordersD
                        join p in proList on od.IDProduct equals p.ProductID into tbl
                        group od by new
                        {
                            idPro = od.IDProduct,
                            namePro = od.Product.NamePro,
                            imagePro = od.Product.ImagePro,
                            price = od.Product.Price
                        } into gr
                        orderby gr.Sum(s => s.Quantity) descending
                        select new ViewModel
                        {
                            IDPro = gr.Key.idPro,
                            NamePro = gr.Key.namePro,
                            ImgPro = gr.Key.imagePro,
                            pricePro = (decimal)gr.Key.price,
                            Sum_Quantity = gr.Sum(s => s.Quantity)
                        };
            return View(query.Take(10).ToList());
        }
            public ActionResult GroupByTop()
            {
                List<OrderDetail> ordersD = database.OrderDetails.ToList();
                List<Product> proList = database.Products.ToList();
                var query = from od in ordersD
                            join p in proList on od.IDProduct equals p.ProductID into tbl
                            group od by new
                            {
                                idPro = od.IDProduct,
                                namePro = od.Product.NamePro,
                                imagePro = od.Product.ImagePro,
                                price = od.Product.Price
                            } into gr
                            orderby gr.Max(s => s.Quantity) descending
                            select new ViewModel
                            {
                                IDPro = gr.Key.idPro,
                                NamePro = gr.Key.namePro,
                                ImgPro = gr.Key.imagePro,
                                pricePro = (decimal)gr.Key.price,
                                Sum_Quantity = gr.Max(s => s.Quantity)
                            };
                return View(query.Take(10).ToList());
            }
        public ActionResult GroupByNew()
        {
            List<OrderDetail> ordersD = database.OrderDetails.ToList();
            List<Product> proList = database.Products.ToList();
            var query = from od in ordersD
                        join p in proList on od.IDProduct equals p.ProductID into tbl
                        group od by new
                        {
                            idPro = od.IDProduct,
                            namePro = od.Product.NamePro,
                            imagePro = od.Product.ImagePro,
                            price = od.Product.Price
                        } into gr
                        orderby gr.Min(s => s.Quantity) descending
                        select new ViewModel
                        {
                            IDPro = gr.Key.idPro,
                            NamePro = gr.Key.namePro,
                            ImgPro = gr.Key.imagePro,
                            pricePro = (decimal)gr.Key.price,
                            Sum_Quantity = gr.Min(s => s.Quantity)
                        };
            return View(query.Take(10).ToList());
        }
    }
}

             
     
 
