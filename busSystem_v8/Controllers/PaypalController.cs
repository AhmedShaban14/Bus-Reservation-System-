using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using busSystem_v8.Models;
using busSystem_v8.PayModel;

namespace busSystem_v8.Controllers
{
    public class PaypalController : Controller
    {
        BusSystemDB db = new BusSystemDB();
        // byb3t data bta3t el card 
        public ActionResult Index()
        {
            if (Session["cart"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var ls = Session["cart"] as List<Product>;
          
            return View(ls);
        }
        public ActionResult GetDataPaypal()
        {
            var getData = new GetDataPaypal();
            var order = getData.InformationOrder(getData.GetPayPalResponse(Request.QueryString["tx"]));
            ViewBag.tx = Request.QueryString["tx"];
            Credit cr = new Credit();
            cr.CreditMoney = 50;
            db.credit.Add(cr);
            db.SaveChanges();
            return View();
        }
        public ActionResult getButton(string at, string  ar)
        {
            return Content(at + "   " + ar);
        }
    }
}