using busSystem_v8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bus_System_V1.Controllers
{
    public class UserController : Controller
    {
        BusSystemDB db = new BusSystemDB();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                var info = db.users.Where(m => m.Email == user.Email).SingleOrDefault();
                if(info != null)
                {
                    return Json(new { result =0 });
                }
                else
                {
                    user.user_status_id = 2;
                    user.user_types_id = 2;
                    //user.ImgPath = "   ";
                    user.BirthDate = DateTime.Now;
                    db.users.Add(user);
                    db.SaveChanges();
                    Session["userData"]= user;
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult Login(User user)
        {
            var info= db.users.Where(m => m.Email == user.Email && m.Password == user.Password).SingleOrDefault();
            if(info != null)
            {
                Session["userData"] = info as User;
                if(info.user_types_id == 1)
                {
                    return RedirectToAction("index1", "Dashboard");
                }
                else if (info.user_status_id == 1)
                {
                    return RedirectToAction("page_error_500", "Dashboard");

                }
                else
                {
                    return RedirectToAction("Index","Home");
                }
            }
            
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult logout()
        {
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }
    }
}