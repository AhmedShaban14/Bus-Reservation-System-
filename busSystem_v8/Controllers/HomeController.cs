using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using busSystem_v8.Models;

namespace busSystem_v8.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            SMSController sms = new SMSController();
            
            return View();
        }

        public ActionResult About_Member()
        {
            return View();
        }

        public ActionResult about()
        {
            return View();
        }

        public ActionResult air()
        {
            return View();
        }

        public ActionResult career()
        {
            return View();
        }

        public ActionResult contact()
        {
            return View();
        }

        public ActionResult faq()
        {
            return View();
        }

        public ActionResult jobpost()
        {
            return View();
        }

        public ActionResult moving()
        {
            return View();
        }

        public ActionResult service()
        {
            return View();
        }

        public ActionResult transportation()
        {
            return View();
        }

    }
}