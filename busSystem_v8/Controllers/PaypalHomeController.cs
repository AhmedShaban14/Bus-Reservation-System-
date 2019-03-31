using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using busSystem_v8.PayModel;

namespace busSystem_v8.Controllers
{
    public class PaypalHomeController : Controller
    {
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Product p)
        {
            if (ModelState.IsValid)
            {
                if (Session["cart"]!=null)
                {
                    var ls = Session["cart"] as List<Product>;
                    ls.Add(p);
                }
                else
                {
                    Session["cart"] = new List<Product>() {p};
                }
                ModelState.Clear();// clear data from Form
                RedirectToAction("Index", "Home"); // Anti F5 submit
            }
            return View(); // model validate is false
        }
    }
}